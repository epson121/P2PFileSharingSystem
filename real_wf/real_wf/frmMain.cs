using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace real_wf
{
    public partial class frmMain : Form //glavna forma, pokreće se s programom odmah
    {


        public frmMain()
        {
            InitializeComponent();
        }

     

        private void Main_Load(object sender, EventArgs e)
        {

        }

        //klik na login u tsMenu nas vodi na formu za login (upis imena)
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm1 = new frmLogin();
            
        }

        //klik na logout u tsMenu nas odjavljuje sa servisa i brise podatke iz baze
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (helper.Name == "")
            {
                MessageBox.Show("Niste prijavljeni!");
                return;
            }
            try
            {
                serviceWCF.Service1Client client = new serviceWCF.Service1Client();

                if (client.clearUserFiles(helper.Name) == 1)
                {
                    //MessageBox.Show("Logged out!");
                    helper.Name = "";
                    tslblSuccessfulLogout.Visible = true;
                    tslblNoLogout.Visible = false;
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Neuspješna odjava.");
            }
        }

        //about forma prikazuje podatke o programu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Luka Rajčević\n2012\n :)");
        }

        //logout kod zatvaranja i izlazak iz programa
       

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (helper.Name != "")
            {
                tslblNoLogout.Visible = true;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }



        private void downloadFilesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (helper.Name == "")
            {
                frmLogin frmLog = new frmLogin();
                frmLog.Show();
            }
            else
            {
                frmDataGrid formDataGrid = new frmDataGrid();
                formDataGrid.Show();
            }
        }

        
    }
}
