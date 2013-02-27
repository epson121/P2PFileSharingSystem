using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;

namespace real_wf
{
    class FileHandling:helper //klasa za upravljanje podacima (flderima, imenima pathovima i sl)
    {
        //popis datoteka (path)
        public string[] fileList;

        //popis imena datoteka (samo filename)
        List<string> fileName;

        //kreiranje direktorija za datoteke za dijeljenje
        public static void createFileDirectory()
        {
            if (helper.Name != null)
            {              
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                helper.path = appPath + @"\Files";
                if (!Directory.Exists(helper.path))
                    Directory.CreateDirectory(helper.path);
            }
        }

        //dohvaćanje fajlova iz kreiranog direktorija
        public void getDirectoryFiles()
        {
            fileList = Directory.GetFiles(helper.path);
        }

        //dohvaćanje imena iz njihovog patha
        public void getFileNames()
        {
            fileName = new List<string>();
            foreach (string x in fileList)
            {
                fileName.Add(Path.GetFileName(x));
            }
        }

        //provjera korisničkog imena prilikom prijave u aplikaciju
        //instanciranje servisa i pozivanje metode za provjeru
        public int checkUsername()
        {
            serviceWCF.Service1Client client = new serviceWCF.Service1Client();
            if (client.checkUsername(helper.Name) == 1)
            {
                client.Close();
                return 1;
            }
            else
            {
                client.Close();
                return 0;
            } 
        }

        //brisanje datoteka iz baze nakon što čvor napusti mrežu
        public void clearFilesFromService()
        {
            serviceWCF.Service1Client client = new serviceWCF.Service1Client();
            client.clearUserFiles(helper.Name);
            client.Close();
        }

        //upload naziva datoteka u bazu preko servisa
        public void uploadFilesToService()
        {
            //brišu se sve stare datoteka koje su na servisu te se dohvaćaju nazivi novih
            clearFilesFromService();
            getDirectoryFiles();
            getFileNames();

            //instancira se servis
            serviceWCF.Service1Client client = new serviceWCF.Service1Client();
            foreach (string filePath in fileList)
            {
                //spremanje imena datoteke (bez patha u tmp varijablu)
                string tmpFileName = Path.GetFileName(filePath);
                
                //dodavanje  tmp varijable u popis
                fileName.Add(tmpFileName);

                //stvaranje informacije o trenutnoj datoteci
                FileInfo fileInformation = new FileInfo(filePath);
                
                //dohavaćanje podatka o veličini trenutne datoteke (u bajtovima)
                long fileSize = fileInformation.Length / 1024;
                
                //upload podataka u bazu
                string hashFromFile = createHashFromFile(filePath);
                client.uploadFilesToService(helper.Name, helper.IP, tmpFileName, filePath, fileSize, hashFromFile, helper.portUDP.ToString()); 
            }
            client.Close();
        }

        //kreiranje popisa datoteka koje se nalaze na našem računalu
        public DataTable fillMyFiles()
        {
            //kreiranje tablice sa korespondirajućim nazivima stupaca
            DataTable table = new DataTable();
            table.Columns.Add("File name");
            table.Columns.Add("File size (KB)");
            table.Columns.Add("Path");

            //dohvaćanje datoteka i prolazak kroz sve njih te dodavanje u popis
            getDirectoryFiles();
            getFileNames();
            foreach (string filePath in fileList)
            {
                //kreiranje novog reda u tablici i dohvaćanje imena datoteke
                DataRow row = table.NewRow();
                string tmpFileName = Path.GetFileName(filePath);

                //stvaranje informacije o trenutnoj datoteci
                FileInfo fileInformation = new FileInfo(filePath);

                //dohavaćanje podatka o veličini trenutne datoteke (u bajtovima)
                long fileSize = fileInformation.Length / 1024;

                //spremanje podataka u novi red
                row[0] = tmpFileName;
                row[1] = fileSize;
                row[2] = filePath;
                table.Rows.Add(row);
            }
            return table;
        }

        //kreiranje hash funkcije za svaku datoteku koja se šalje na servis
        public string createHashFromFile(string filePath)
        {
            using (HashAlgorithm hashAlg = new SHA1Managed())   //sha1 hash
            {
                //otvaranje datoteke nad kojim se kreira hash
                using (Stream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    //računanje hasha
                    byte[] hash = hashAlg.ComputeHash(file);
                    // vraćanje vrijednosti hasha u obliku stringa
                    return BitConverter.ToString(hash);
                }
            }
        }
    }
}
