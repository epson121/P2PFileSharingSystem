using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Net;
using System.Threading;

namespace real_wf
{
    public partial class frmDataGrid : Form //forma sa dgv koji sadrži datoteke koje se dijele
    {

        FileHandling newFolder = new FileHandling();

        //konstruktor funkcije koji instancira klasu server i pokreće dvije dretve
        //koje obavljaju posao UDP i TCP servera (na klijentu)
        public frmDataGrid()
        {
            InitializeComponent();

            Server server = new Server(this);
            Thread listeningUDPThread = new Thread(new ThreadStart(server.startUDPServer));
            listeningUDPThread.IsBackground = true;
            listeningUDPThread.Start();
            Thread listeningTCPThread = new Thread(new ThreadStart(server.startTCPServer));
            listeningTCPThread.IsBackground = true;
            listeningTCPThread.Start();

            //ukoliko ne postoji direktorij za datoteke, kreira ga
            FileHandling.createFileDirectory();

            //uploada datoteke na servis a preko njega u bazu
            newFolder.uploadFilesToService();

            //instanciranje servisa i dohvaćanje podataka s njega u obliku tablice
            serviceWCF.Service1Client client = new serviceWCF.Service1Client();
            DataTable table = client.getData(helper.Name);
            dgvData.DataSource = table;
            client.Close();
            dgvDownloads.DataSource = newFolder.fillMyFiles();
            createDownDgv();
        }
   

        //desni klik, download
        //slanje ppodataka prema klasi klijent i njenoj metodi connect
        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            foreach (DataGridViewRow r in dgvDown.Rows)
            {
                //ukoliko je naziv datoteke onaj čiji sadržaj želimo ažurirati
                if (r.Cells[0].Value == this.dgvData.SelectedRows[0].Cells[0].Value)
                {
                    MessageBox.Show("You have already downloaded this file.");
                    return;
                }
                    
            }
            Client client = new Client();        
            client.connect(this.dgvData.SelectedRows[0].Cells[2].Value.ToString(), 
                            this.dgvData.SelectedRows[0].Cells[0].Value.ToString(),
                             this.dgvData.SelectedRows[0].Cells[3].Value.ToString());
           
            
        }

        // refresh liste datoteka, instanciranje servisa i ponovno dohvaćanje svih datoteka
        private void btnGetData_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            newFolder.uploadFilesToService();
            serviceWCF.Service1Client client = new serviceWCF.Service1Client();
            DataTable table = client.getData(helper.Name);
            dgvData.DataSource = table;
            client.Close();
        }

        //zatvaranje forme
        private void btnCloseDataGrid_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //prikaz kontekstnog menija nakon klika desne tipke miša
        private void dgvData_CellMouseDown_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //prikaz kontekstnog menija
                dgvData.CurrentCell = dgvData[e.ColumnIndex, e.RowIndex];
                dgvFileContextMenu.Show(Cursor.Position);
            }
        }

        //pretraga datoteka u bazi
        //instanciranje servisa i pozivanje njegove searchFiles metode
        private void btnSearchFiles_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                return;
            try
            {
                //spajanje na servis i provjera unešene vrijednosti preko searchFiles metode
                serviceWCF.Service1Client client = new serviceWCF.Service1Client();
                DataTable table = client.searchFiles(txtSearch.Text, helper.Name);
                if (table != null)
                {

                    dgvData.DataSource = null;
                    //postavljanje podataka u dataGridView
                    dgvData.DataSource = table;
                }
                else
                {
                    //ukoliko je tablica prazna
                    return;
                }
                client.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        //automatsko pretraživanje nakon unosa teksta u polje za pretragu
        // i pritiska na tipku ENTER
        private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchFiles_Click_1(null, null);
            }
        }

        //zatvaranje forme (tab my files)
        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //osvježavanje liste datoteka koje se nalaze na lokalnom računalu
        private void refreshMyFiles_Click(object sender, EventArgs e)
        {
            FileHandling fh = new FileHandling();
            dgvDownloads.DataSource = fh.fillMyFiles();
        }

        //zatvaranje forme (tab downloads)
        private void btnDownClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //kreiranje data grid viewa u tabu downloads
        void createDownDgv()
        {
            DataTable tab = new System.Data.DataTable();
            tab.Columns.Add("File name");
            tab.Columns.Add("Done (kB)");
            tab.Columns.Add("Done");
            dgvDown.DataSource = tab;
            return;
        }

        //kreiranje delegata za ažuriranje grafičkog sučelja iz druge dretve
        public delegate void updateUIDelegate(string name, string done, string message);

        //metoda koja vrši ažuriranje grafičkog sučelja
        public void updateDownDgv(string filename, string done, string message)
        {

            //ukoliko je potrebna invokacija (ukoliko ovu metodu ne poziva glavna dretva)
            if (InvokeRequired)
            {

                //u red glavne dretve se dodaje i obavljanje ove funkcije (pozivanje preko delegata uz parametre)
                this.BeginInvoke(new updateUIDelegate(updateDownDgv), filename, done, message);
                return;
            }

            //ažuriranje sučelja
            //prolazak kroz svaki red u grid view-u
            foreach (DataGridViewRow r in dgvDown.Rows)
            {
                //ukoliko je naziv datoteke onaj čiji sadržaj želimo ažurirati
                if ((string)r.Cells[0].Value == filename)
                {
                    //sadržaj se ažurira (količina primljenih podataka)
                    r.Cells[1].Value = done;
                    r.Cells[2].Value = message;
                    dgvDown.Invalidate();
                    return;
                }
                    
            }
            //ukoliko ne postoji takva datoteka, dodaje se novi red za nju
            DataTable tab = (DataTable)dgvDown.DataSource;
            DataRow row =  tab.NewRow();
            row[0] = filename;
            row[1] = done;
            row[2] = message;
            tab.Rows.Add(row);
            dgvDown.DataSource = null;
            dgvDown.DataSource = tab;
        }
    }
}
