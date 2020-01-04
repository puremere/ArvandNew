namespace realstate
{
    partial class getData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(getData));
            this.PRightPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TmainHolder = new System.Windows.Forms.TableLayoutPanel();
            this.TholderOfTwoTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PleftPanel = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.getDataVerify = new System.Windows.Forms.Button();
            this.DDTO = new System.Windows.Forms.TextBox();
            this.tolable = new System.Windows.Forms.Label();
            this.DDFROM = new System.Windows.Forms.TextBox();
            this.Datefrom = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.percent = new System.Windows.Forms.Label();
            this.loading = new System.Windows.Forms.PictureBox();
            this.PRightPanel.SuspendLayout();
            this.TmainHolder.SuspendLayout();
            this.TholderOfTwoTopPanel.SuspendLayout();
            this.PleftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.SuspendLayout();
            // 
            // PRightPanel
            // 
            this.PRightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PRightPanel.Controls.Add(this.tableLayoutPanel1);
            this.PRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PRightPanel.Location = new System.Drawing.Point(3, 3);
            this.PRightPanel.Name = "PRightPanel";
            this.PRightPanel.Size = new System.Drawing.Size(391, 213);
            this.PRightPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(84, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TmainHolder
            // 
            this.TmainHolder.ColumnCount = 1;
            this.TmainHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TmainHolder.Controls.Add(this.TholderOfTwoTopPanel, 0, 0);
            this.TmainHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TmainHolder.Location = new System.Drawing.Point(0, 0);
            this.TmainHolder.Name = "TmainHolder";
            this.TmainHolder.RowCount = 2;
            this.TmainHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TmainHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TmainHolder.Size = new System.Drawing.Size(800, 450);
            this.TmainHolder.TabIndex = 1;
            // 
            // TholderOfTwoTopPanel
            // 
            this.TholderOfTwoTopPanel.ColumnCount = 2;
            this.TholderOfTwoTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TholderOfTwoTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TholderOfTwoTopPanel.Controls.Add(this.PleftPanel, 0, 0);
            this.TholderOfTwoTopPanel.Controls.Add(this.PRightPanel, 1, 0);
            this.TholderOfTwoTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TholderOfTwoTopPanel.Location = new System.Drawing.Point(3, 3);
            this.TholderOfTwoTopPanel.Name = "TholderOfTwoTopPanel";
            this.TholderOfTwoTopPanel.RowCount = 1;
            this.TholderOfTwoTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TholderOfTwoTopPanel.Size = new System.Drawing.Size(794, 219);
            this.TholderOfTwoTopPanel.TabIndex = 1;
            // 
            // PleftPanel
            // 
            this.PleftPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PleftPanel.Controls.Add(this.loading);
            this.PleftPanel.Controls.Add(this.percent);
            this.PleftPanel.Controls.Add(this.label1);
            this.PleftPanel.Controls.Add(this.progressBar1);
            this.PleftPanel.Controls.Add(this.getDataVerify);
            this.PleftPanel.Controls.Add(this.DDTO);
            this.PleftPanel.Controls.Add(this.tolable);
            this.PleftPanel.Controls.Add(this.DDFROM);
            this.PleftPanel.Controls.Add(this.Datefrom);
            this.PleftPanel.Controls.Add(this.tableLayoutPanel3);
            this.PleftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PleftPanel.Location = new System.Drawing.Point(400, 3);
            this.PleftPanel.Name = "PleftPanel";
            this.PleftPanel.Size = new System.Drawing.Size(391, 213);
            this.PleftPanel.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 65);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(343, 25);
            this.progressBar1.TabIndex = 6;
            // 
            // getDataVerify
            // 
            this.getDataVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getDataVerify.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("getDataVerify.BackgroundImage")));
            this.getDataVerify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.getDataVerify.Location = new System.Drawing.Point(135, 136);
            this.getDataVerify.Name = "getDataVerify";
            this.getDataVerify.Size = new System.Drawing.Size(142, 37);
            this.getDataVerify.TabIndex = 5;
            this.getDataVerify.UseVisualStyleBackColor = true;
            this.getDataVerify.Click += new System.EventHandler(this.getDataVerify_Click);
            // 
            // DDTO
            // 
            this.DDTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DDTO.Location = new System.Drawing.Point(26, 17);
            this.DDTO.Name = "DDTO";
            this.DDTO.Size = new System.Drawing.Size(100, 29);
            this.DDTO.TabIndex = 4;
            // 
            // tolable
            // 
            this.tolable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tolable.AutoSize = true;
            this.tolable.Location = new System.Drawing.Point(151, 23);
            this.tolable.Name = "tolable";
            this.tolable.Size = new System.Drawing.Size(24, 13);
            this.tolable.TabIndex = 3;
            this.tolable.Text = "تا : ";
            // 
            // DDFROM
            // 
            this.DDFROM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DDFROM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DDFROM.Location = new System.Drawing.Point(208, 17);
            this.DDFROM.Name = "DDFROM";
            this.DDFROM.Size = new System.Drawing.Size(100, 29);
            this.DDFROM.TabIndex = 2;
            // 
            // Datefrom
            // 
            this.Datefrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Datefrom.AutoSize = true;
            this.Datefrom.Location = new System.Drawing.Point(323, 23);
            this.Datefrom.Name = "Datefrom";
            this.Datefrom.Size = new System.Drawing.Size(49, 13);
            this.Datefrom.TabIndex = 1;
            this.Datefrom.Text = "تاریخ از :";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(84, 39);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(8, 8);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "درحال دریافت اطلاعات";
            this.label1.Visible = false;
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.ForeColor = System.Drawing.Color.DarkGreen;
            this.percent.Location = new System.Drawing.Point(135, 107);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(21, 13);
            this.percent.TabIndex = 8;
            this.percent.Text = "0%";
            this.percent.Visible = false;
            // 
            // loading
            // 
            this.loading.Image = ((System.Drawing.Image)(resources.GetObject("loading.Image")));
            this.loading.Location = new System.Drawing.Point(26, 96);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(85, 77);
            this.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loading.TabIndex = 9;
            this.loading.TabStop = false;
            this.loading.Visible = false;
            // 
            // getData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TmainHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "getData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "دریافت اطلاعات";
            this.Load += new System.EventHandler(this.getData_Load);
            this.PRightPanel.ResumeLayout(false);
            this.TmainHolder.ResumeLayout(false);
            this.TholderOfTwoTopPanel.ResumeLayout(false);
            this.PleftPanel.ResumeLayout(false);
            this.PleftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PRightPanel;
        private System.Windows.Forms.TableLayoutPanel TmainHolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel TholderOfTwoTopPanel;
        private System.Windows.Forms.Panel PleftPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox DDTO;
        private System.Windows.Forms.Label tolable;
        private System.Windows.Forms.TextBox DDFROM;
        private System.Windows.Forms.Label Datefrom;
        private System.Windows.Forms.Button getDataVerify;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox loading;
    }
}