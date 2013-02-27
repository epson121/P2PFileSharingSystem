using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace servis
{
    // Implementacija metoda iz interfacea
    public class Service1 : IService1
    {
        public string Welcome(string Name)
        {
            return "First WCF " + Name;
        }

        //provjera spajanja na servis
        public int checkConnection()
        {
            return 1;
        }

        //početna funkcija spajanja i ubacivanja imena i IP adrese u bazu, trenutno je nepotrebna
        public int connect(string Name, string IP)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            try
            {
                myConnection.Open();
            }
            catch
            {
                return 0;
            }

            SqlCommand myCommand = new SqlCommand("INSERT INTO test(name, IP) VALUES (@nameDB, @ipDB) ", myConnection);

            myCommand.Parameters.Add("nameDB", SqlDbType.VarChar).Value = Name;
            myCommand.Parameters.Add("ipDB", SqlDbType.VarChar).Value = IP;

            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return 1;
        }

        //upload popisa datoteka za dijeljenje na server
        public int uploadFilesToService(string Name, string IP,  string fileName, string filePath, long fileSize, string fileHash, string udp)
        {
            //spajanje na bazu
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            try
            {
                myConnection.Open();
            }
            catch
            {
                return 0;
            }

            //izvršavanje upita nad bazom
            SqlCommand myCommand = new SqlCommand("INSERT INTO test(name, IP, filename, filepath, filesize, hash, portudp) VALUES (@nameDB, @ipDB, @filenameDB, @filepathDB, @filesizeDB, @filehashDB, @portudpDB)", myConnection);
           
            myCommand.Parameters.Add("nameDB", SqlDbType.VarChar).Value = Name;
            myCommand.Parameters.Add("ipDB", SqlDbType.VarChar).Value = IP;
            myCommand.Parameters.Add("filenameDB", SqlDbType.VarChar).Value = fileName;
            myCommand.Parameters.Add("filepathDB", SqlDbType.VarChar).Value = filePath;
            myCommand.Parameters.Add("filesizeDB", SqlDbType.VarChar).Value = fileSize;
            myCommand.Parameters.Add("filehashDB", SqlDbType.VarChar).Value = fileHash;
            myCommand.Parameters.Add("portudpDB", SqlDbType.VarChar).Value = udp;

            myCommand.ExecuteNonQuery();
            myConnection.Close();
            //uspješno obavljen posao
            return 1;
        }

        //logout sa servisa, brisanje zapisa o korisniku iz baze
        public int clearUserFiles(string Name)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("DELETE FROM test WHERE name = @nameDB", myConnection);
            myCommand.Parameters.Add("NAMEdb", SqlDbType.VarChar).Value = Name;
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            return 1;

        }

        public int checkUsername(string Name)
        {
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM test WHERE name = @nameDB", myConnection);
            myCommand.Parameters.Add("NAMEdb", SqlDbType.VarChar).Value = Name;
            SqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
           // myCommand.ExecuteNonQuery();
            if (myReader.HasRows)
            {
                myConnection.Close();
                return 1;
            }
            else
            {
                myConnection.Close();
                return 0;
            }
        }

        public DataTable searchFiles(string text, string name)
        {
            //kreiranje tablice sa potencijalnim podacima, spajanje na bazu i otvaranje konekcije
            DataTable table = new DataTable("Tablica");
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            try
            {
               
                myConnection.Open();
            }
            catch
            {
                return table;
            }
            //dodavanje kolona u dataTable
            table.Columns.Add("File name");
            table.Columns.Add("File size (KB)");
            table.Columns.Add("IP");
            table.Columns.Add("PORT");


            SqlDataReader myReader;

            //izvršavanje upita nad bazom, selektiranje potrebniih podataka
            //string command = "SELECT IP, filename, filesize FROM test WHERE filename LIKE %" + text + "%'";
            SqlCommand myCommand = new SqlCommand("SELECT IP, filename, filesize, portudp FROM test WHERE filename LIKE @textDB AND name <> @nameDB", myConnection);
           
            myCommand.Parameters.Add("textDB", SqlDbType.VarChar).Value = "%" + text + "%";
            myCommand.Parameters.Add("nameDB", SqlDbType.VarChar).Value = name;
            myReader = myCommand.ExecuteReader();

            //čitanje podataka i spremanje u datatable (tablicu)
            while (myReader.Read())
            {
                DataRow row = table.NewRow();

                row[0] = myReader["filename"];
                row[1] = myReader["filesize"];
                row[2] = myReader["IP"];
                row[3] = myReader["portudp"];
             
                table.Rows.Add(row);

            }
            myConnection.Close();

            return table;
        }
        //dohvaćanje popisa datoteka za dijeljenje sa servera (gumbom getData na formi)
        public DataTable getData(string Name)
        {
            //kreiranje tablice u koju će biti spremljeni podaci
            DataTable table = new DataTable("Tablica");

            //kreiranje konekcije na bazu i otvaranje iste
            SqlConnection myConnection = new SqlConnection(@"Data Source=LUKA-PC\SQLEXPRESS;Initial Catalog=users;Integrated Security=True");
            try
            {
                myConnection.Open();
            }
            catch
            {
                return table;
            }
            //dodavanje kolona u dataTable
            table.Columns.Add("File name");
            table.Columns.Add("File size (KB)");
            table.Columns.Add("IP");
            table.Columns.Add("PORT");
            
            
            
            SqlDataReader myReader;

            //izvršavanje upita nad bazom, selektiranje potrebniih podataka
            SqlCommand myCommand = new SqlCommand("SELECT IP, filename, filesize, portudp FROM test WHERE name <> @nameDB", myConnection);
            myCommand.Parameters.Add("nameDB", SqlDbType.VarChar).Value = Name;
            myReader = myCommand.ExecuteReader();

            //čitanje podataka i spremanje u datatable (tablicu)
            while (myReader.Read())
            {
                DataRow row = table.NewRow();
               
                    row[0] = myReader["filename"];
                    row[1] = myReader["filesize"];
                    row[2] = myReader["IP"];
                    row[3] = myReader["portudp"];
                    table.Rows.Add(row);
               
            }

            myConnection.Close();
            //vraćanje tablice koja se dodaje u dgv
            return table;

        }
    }
}
