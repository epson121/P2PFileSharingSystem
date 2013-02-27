using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace real_wf
{
    //klasa server koja obavlja osluškivanje na konekcije
    class Server
    {
        //udp klijent - ne inicijaliziran
        UdpClient _server = null;

        //IPEndpoint - neinicijaliziran
        IPEndPoint _client = null;

        // varijabla u koju se sprema primljena poruka
        string stringData;

        //varijabla u koju se sprema IP računala koje traži datoteku
        string senderIp;

        //konstruktor ove klase sprema originalnu instancu klase frmDataGrid kako bi mogao na njoj vršiti promjene
        frmDataGrid dg;
        public Server(Form f)
        {
            dg = (frmDataGrid)f;
        }

        //metoda koja pokreće UDP server i osluškuje na UDP poruke
        public void startUDPServer()
        {
            //inicijalizacija klijenta i dohvaćanje broja porta
            _server = new UdpClient(0);
            int port = ((IPEndPoint)_server.Client.LocalEndPoint).Port;
            helper.portUDP = port;
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            _client = new IPEndPoint(IPAddress.Any, 0);

            //prihvaćanje poruke na UDP serveru
            while (true)
            {
                byte[] data = new byte[4096];
                data = _server.Receive(ref sender);
                senderIp = sender.Address.ToString();
                stringData = Encoding.ASCII.GetString(data, 0, data.Length);

                //ukoliko poruka započinje sa "D" pokreće se dretva za slanje datoteke korisniku koji ju je tražio
                if (stringData[0] == 'D')
                {
                    Thread fileSearchThread = new Thread(new ThreadStart(fileSearch));
                    fileSearchThread.IsBackground = true;
                    fileSearchThread.Start();
                }
            }
        }
        //kreiranje socketa 
        Socket handlerSocket;

        //metoda koja osluškuje na konekciju na TCP server
        public void startTCPServer()
        {
            //dohvaćanje slobodnog porta
            helper.portTCP = getFreePortNumber();
            TcpListener tcpListener = new TcpListener(helper.portTCP);
            tcpListener.Start();
            while (true)
            {
                //ukoliko se dogodi konekcija
                handlerSocket = tcpListener.AcceptSocket();
                if (handlerSocket.Connected)
                {
                    //kreira se nova dretva koja prima datoteku
                    Thread download = new Thread(new ThreadStart(downloadFile));
                    download.IsBackground = true;
                    download.Start();
                }

            }
        }

        int received = 0;

        //metoda koja prima datoteku
        public void downloadFile()
        {
            //naziv datoteke - prazan
            string fileName = string.Empty;

            // network stream za određeni socket
            NetworkStream networkStream = new NetworkStream(handlerSocket);
            int thisRead = 0;

            //veličina bloka bajtova koja se dohvaća
            int blockSize = 1024;

            //niz bajtova veličine bloka
            Byte[] dataByte = new Byte[blockSize];
            lock (this)
            {
                int count = 0;
                
                //mapa u koju se sprema datoteka
                string folderPath = helper.path + "\\";

                //prihvaćanje podataka preko socketa
                handlerSocket.Receive(dataByte);

                //parsiranje podataka iz poruke (ime datoteke)
                int fileNameLen = BitConverter.ToInt32(dataByte, 0);
                fileName = Encoding.ASCII.GetString(dataByte, 4, fileNameLen);

                //zapisivanje podataka u mapu
                Stream fileStream = File.OpenWrite(folderPath + fileName);
                fileStream.Write(dataByte, 4 + fileNameLen, (1024 - (4 + fileNameLen)));

                //dok ima podataka z ačitati
                while (true)
                {
                    //čitanje sa socketa
                    thisRead = networkStream.Read(dataByte, 0, blockSize);

                    //varijabla koja prati veličinu prihvaćene datoteke
                    received = received + thisRead;
                    count++;
                    //ažuriranje grafičkog sučelja nakon svakih 50kb
                    if (count == 50)
                    {
                        //Thread.Sleep(1);
                        dg.updateDownDgv(fileName, received / 1024 + " kB", "In progress...");
                        count = 0;
                    }
                    
                    //zapisivanje primljenih bajtova na disk
                    fileStream.Write(dataByte, 0, thisRead);
                    if (thisRead == 0)
                        break;
                }
                //zatvaranje toka i ažuriranje grafičkog sučelja da je datoteka spremljena
                dg.updateDownDgv(fileName, received / 1024 + " kB", "Finished");
                fileStream.Close();
                received = 0;
            }
        }

        //pretraga datoteka i slanje TCP serveru
        public void fileSearch()
        {
            //varijabla koja indicira pronađenu datoteku
            bool foundFile = false;
            
            //dekodiranje primljene poruke i prinalaženje naziva datoteke
            string[] files = Directory.GetFiles(helper.path);
            string[] receivedMessage = stringData.Split(':');

            //pronalaženje porta na koji se šalje datoteka
            int tcpPort = Convert.ToInt32(receivedMessage[0].Substring(1));
            stringData = receivedMessage[1].ToString();

            //prolazak kroz sve datoteke na lokalnom računalu
            foreach (string file in files)
            {
                string tmpFileName = Path.GetFileName(file);

                //ukoliko je pronađena tražena datoteka
                if (tmpFileName == stringData)
                {
                    foundFile = true;

                    //kodiranje datoteke i slanje na TCP port
                    try
                    {
                        byte[] fileNameByte = Encoding.ASCII.GetBytes(tmpFileName);
                        byte[] fileData = File.ReadAllBytes(file);
                        byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                        byte[] fileNameLen = BitConverter.GetBytes( fileNameByte.Length);
                        //kodiranje niza koji se šalje
                        fileNameLen.CopyTo(clientData, 0);
                        fileNameByte.CopyTo(clientData, 4);
                        fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                        //kreiranje tcp klijenta i network streama
                        TcpClient clientSocket = new TcpClient(senderIp, tcpPort);
                        NetworkStream networkStream = clientSocket.GetStream();
                        networkStream.Write(clientData, 0, clientData.GetLength(0));
                        networkStream.Close();
                    }
                    catch{}
                }
            }

            if (!foundFile)
                MessageBox.Show("there is no such file");
        }

        //dohvaćanje slobodnog porta rekurzivno
        public int getFreePortNumber()
        {
            //generiranje nasumičnog broja
            Random r = new Random();
            int port = r.Next(10000, 50000);
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            //ukoliko je nasumično generirani broj zauzet (kao port broj) ponovno se poziva funkcija
            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    getFreePortNumber();
                }
            }
            return port;
        }
    }
         
}
