using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace real_wf
{
    class Client
    {
        //odredišna IP adresa 
        string ip;
 
        //naziv datoteke koja se preuzima
        string fileToDownload;

        //metoda koja šalje poruku čvoru koji sadrži traženu datoteku
        public void connect(string destination, string fileName, string udpPort)
        {
            ip = destination;
            this.fileToDownload = fileName;
            //kreiranje polja bajtova u koje se spremaju podaci koji se šalju korisniku
            //(ime datoteke, veličina datoteke i veličina imena)
            byte[] data = new byte[4096];
            try
            {
                //dohvaćanje porta na koji se šalju podaci
                int portNumber = Convert.ToInt32(udpPort);
                //parsiranje IP adrese iz stringa
                ip = ip.Replace(" ", string.Empty);
                IPAddress ipaddr = IPAddress.Parse(this.ip);

                //kreiranje UDP klijenta i IPEndPointa koji šalju podatke
                UdpClient server = new UdpClient();
                IPEndPoint sender = new IPEndPoint(ipaddr, portNumber);

                //kreiranje poruke koja se šalje i njeno kodiranje u bajtove
                string welcome = "D" + helper.portTCP + ":" + this.fileToDownload;
                data = Encoding.ASCII.GetBytes(welcome);

                //slanje poruke (podaci, veličina podataka, podaci o računalu)
                server.Send(data, data.Length, sender);
            }
            //hvatanje izinmke
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
