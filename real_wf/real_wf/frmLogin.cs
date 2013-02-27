using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace real_wf
{
    public partial class frmLogin : Form // forma za logiranje
    {
        //konstruktor  forme za login koji provjerava je li korisnik već prijavljen
        public frmLogin()
        {
            if (helper.Name != "")
            {
                MessageBox.Show("Već ste prijavljeni");
                this.Close();
            }
            else
            {
                InitializeComponent();
                this.Show();
            }   
        }

        //klik na login -> provjera unesenog imena i provjera konekcije s bazom
        private void button1_Click(object sender, EventArgs e)
        {       
                bool usernameOK = false;
                //ako nije uneseno prazno polje
                if (txtUsername.Text != "")
                {
                    helper.Name = txtUsername.Text;
                    usernameOK = true;
                }
                else
                {
                    usernameOK = false;
                    MessageBox.Show("Please enter your username.");
                }
                string strHostName = "";
                try
                {
                    serviceWCF.Service1Client client = new serviceWCF.Service1Client();  //instanciranje WCf servisa
                    
                    //dobivanje vanjske IP adrese računala
                    strHostName = System.Net.Dns.GetHostName();
                    IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                    IPAddress[] addr = ipEntry.AddressList;
                    helper.IP = addr[addr.Length - 2].ToString();

                    Match result = Regex.Match(helper.IP, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                    if (!result.Success)
                        helper.IP = "127.0.0.1";

                    //ako je korisničko ime pravilno
                    if (usernameOK)
                    {
                        try
                        {
                            //provjera konekcije s servisom
                            if (client.checkConnection() == 1)
                            {
                                FileHandling checkUser = new FileHandling();

                                //ako ime nije slobodno
                                if (checkUser.checkUsername() == 1)
                                {
                                    MessageBox.Show("Ime se koristi.");
                                    helper.Name = "";
                                }
                                else
                                {
                                    //zatvaranje konekcije s servisom i login forme, 
                                    //te instanciranje i prikaz forme sa DataGrid-om
                                    client.Close();
                                    this.Close();
                                    frmDataGrid fdg = new frmDataGrid();
                                    fdg.Show();
                                }
                            }
                        }
                        // ukoliko servis nije dostupan
                        catch
                        {
                            MessageBox.Show("There has been a probem with connecting to server. Please try again.");
                            helper.Name = "";
                        }
                    }
                }
                //ukoliko servis nije dostupan
                catch
                {
                    MessageBox.Show("There has been a probem with connecting to server. Please try again.");
                    helper.Name = "";
                }
        }
        private void Form1_Load(object sender, EventArgs e){}
    }
}
