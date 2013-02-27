namespace real_wf
{
    partial class frmDataGrid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baloonTip = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSearchFiles = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnCloseDataGrid = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.refreshMyFiles = new System.Windows.Forms.Button();
            this.btnClose2 = new System.Windows.Forms.Button();
            this.dgvDownloads = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDownRefresh = new System.Windows.Forms.Button();
            this.btnDownClose = new System.Windows.Forms.Button();
            this.dgvDown = new System.Windows.Forms.DataGridView();
            this.dgvFileContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFileContextMenu
            // 
            this.dgvFileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem});
            this.dgvFileContextMenu.Name = "dgvFileContextMenu";
            this.dgvFileContextMenu.Size = new System.Drawing.Size(129, 26);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // baloonTip
            // 
            this.baloonTip.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.baloonTip.BalloonTipText = "Download complete!";
            this.baloonTip.BalloonTipTitle = "Done!";
            this.baloonTip.Text = "Download complete!";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage1.Controls.Add(this.btnSearchFiles);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.lblSearch);
            this.tabPage1.Controls.Add(this.dgvData);
            this.tabPage1.Controls.Add(this.btnCloseDataGrid);
            this.tabPage1.Controls.Add(this.btnGetData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search files";
            // 
            // btnSearchFiles
            // 
            this.btnSearchFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchFiles.Location = new System.Drawing.Point(770, 20);
            this.btnSearchFiles.Name = "btnSearchFiles";
            this.btnSearchFiles.Size = new System.Drawing.Size(79, 24);
            this.btnSearchFiles.TabIndex = 11;
            this.btnSearchFiles.Text = "Search";
            this.btnSearchFiles.UseVisualStyleBackColor = true;
            this.btnSearchFiles.Click += new System.EventHandler(this.btnSearchFiles_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(542, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(222, 20);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress_1);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(495, 26);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvData.Location = new System.Drawing.Point(1, 59);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(848, 319);
            this.dgvData.TabIndex = 6;
            this.dgvData.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDown_1);
            // 
            // btnCloseDataGrid
            // 
            this.btnCloseDataGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCloseDataGrid.Location = new System.Drawing.Point(729, 387);
            this.btnCloseDataGrid.Name = "btnCloseDataGrid";
            this.btnCloseDataGrid.Size = new System.Drawing.Size(114, 34);
            this.btnCloseDataGrid.TabIndex = 8;
            this.btnCloseDataGrid.Text = "Close";
            this.btnCloseDataGrid.UseVisualStyleBackColor = true;
            this.btnCloseDataGrid.Click += new System.EventHandler(this.btnCloseDataGrid_Click_1);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGetData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetData.Location = new System.Drawing.Point(586, 387);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(113, 34);
            this.btnGetData.TabIndex = 7;
            this.btnGetData.Text = "Refresh list";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage2.Controls.Add(this.refreshMyFiles);
            this.tabPage2.Controls.Add(this.btnClose2);
            this.tabPage2.Controls.Add(this.dgvDownloads);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My files";
            // 
            // refreshMyFiles
            // 
            this.refreshMyFiles.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.refreshMyFiles.Location = new System.Drawing.Point(615, 378);
            this.refreshMyFiles.Name = "refreshMyFiles";
            this.refreshMyFiles.Size = new System.Drawing.Size(114, 34);
            this.refreshMyFiles.TabIndex = 10;
            this.refreshMyFiles.Text = "Refresh";
            this.refreshMyFiles.UseVisualStyleBackColor = true;
            this.refreshMyFiles.Click += new System.EventHandler(this.refreshMyFiles_Click);
            // 
            // btnClose2
            // 
            this.btnClose2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose2.Location = new System.Drawing.Point(735, 378);
            this.btnClose2.Name = "btnClose2";
            this.btnClose2.Size = new System.Drawing.Size(114, 34);
            this.btnClose2.TabIndex = 9;
            this.btnClose2.Text = "Close";
            this.btnClose2.UseVisualStyleBackColor = true;
            this.btnClose2.Click += new System.EventHandler(this.btnClose2_Click);
            // 
            // dgvDownloads
            // 
            this.dgvDownloads.AllowUserToAddRows = false;
            this.dgvDownloads.AllowUserToResizeRows = false;
            this.dgvDownloads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDownloads.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDownloads.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDownloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDownloads.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDownloads.Location = new System.Drawing.Point(3, 53);
            this.dgvDownloads.MultiSelect = false;
            this.dgvDownloads.Name = "dgvDownloads";
            this.dgvDownloads.ReadOnly = true;
            this.dgvDownloads.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDownloads.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDownloads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDownloads.ShowEditingIcon = false;
            this.dgvDownloads.Size = new System.Drawing.Size(848, 319);
            this.dgvDownloads.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDownRefresh);
            this.tabPage3.Controls.Add(this.btnDownClose);
            this.tabPage3.Controls.Add(this.dgvDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(855, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Downloads";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDownRefresh
            // 
            this.btnDownRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDownRefresh.Location = new System.Drawing.Point(615, 358);
            this.btnDownRefresh.Name = "btnDownRefresh";
            this.btnDownRefresh.Size = new System.Drawing.Size(114, 34);
            this.btnDownRefresh.TabIndex = 13;
            this.btnDownRefresh.Text = "Refresh";
            this.btnDownRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDownClose
            // 
            this.btnDownClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDownClose.Location = new System.Drawing.Point(735, 358);
            this.btnDownClose.Name = "btnDownClose";
            this.btnDownClose.Size = new System.Drawing.Size(114, 34);
            this.btnDownClose.TabIndex = 12;
            this.btnDownClose.Text = "Close";
            this.btnDownClose.UseVisualStyleBackColor = true;
            this.btnDownClose.Click += new System.EventHandler(this.btnDownClose_Click);
            // 
            // dgvDown
            // 
            this.dgvDown.AllowUserToAddRows = false;
            this.dgvDown.AllowUserToResizeRows = false;
            this.dgvDown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDown.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDown.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDown.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDown.Location = new System.Drawing.Point(3, 33);
            this.dgvDown.MultiSelect = false;
            this.dgvDown.Name = "dgvDown";
            this.dgvDown.ReadOnly = true;
            this.dgvDown.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDown.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDown.ShowEditingIcon = false;
            this.dgvDown.Size = new System.Drawing.Size(848, 319);
            this.dgvDown.TabIndex = 11;
            // 
            // frmDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(887, 474);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmDataGrid";
            this.Text = "Available files";
            this.dgvFileContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip dgvFileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon baloonTip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnSearchFiles;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnCloseDataGrid;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClose2;
        public System.Windows.Forms.DataGridView dgvDownloads;
        private System.Windows.Forms.Button refreshMyFiles;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDownRefresh;
        private System.Windows.Forms.Button btnDownClose;
        public System.Windows.Forms.DataGridView dgvDown;
    }
}