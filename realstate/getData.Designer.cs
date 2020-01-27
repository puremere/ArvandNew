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
            this.PleftPanel = new System.Windows.Forms.Panel();
            this.loading = new System.Windows.Forms.PictureBox();
            this.percent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.getDataVerify = new System.Windows.Forms.Button();
            this.DDTO = new System.Windows.Forms.TextBox();
            this.tolable = new System.Windows.Forms.Label();
            this.DDFROM = new System.Windows.Forms.TextBox();
            this.Datefrom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PleftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PleftPanel
            // 
            this.PleftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PleftPanel.BackColor = System.Drawing.SystemColors.Control;
            this.PleftPanel.Controls.Add(this.loading);
            this.PleftPanel.Controls.Add(this.percent);
            this.PleftPanel.Controls.Add(this.label1);
            this.PleftPanel.Controls.Add(this.progressBar1);
            this.PleftPanel.Controls.Add(this.getDataVerify);
            this.PleftPanel.Controls.Add(this.DDTO);
            this.PleftPanel.Controls.Add(this.tolable);
            this.PleftPanel.Controls.Add(this.DDFROM);
            this.PleftPanel.Controls.Add(this.Datefrom);
            this.PleftPanel.Location = new System.Drawing.Point(27, 78);
            this.PleftPanel.Name = "PleftPanel";
            this.PleftPanel.Size = new System.Drawing.Size(652, 295);
            this.PleftPanel.TabIndex = 2;
            // 
            // loading
            // 
            this.loading.Image = ((System.Drawing.Image)(resources.GetObject("loading.Image")));
            this.loading.Location = new System.Drawing.Point(295, 3);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(70, 65);
            this.loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loading.TabIndex = 9;
            this.loading.TabStop = false;
            this.loading.Visible = false;
            // 
            // percent
            // 
            this.percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.percent.AutoSize = true;
            this.percent.ForeColor = System.Drawing.Color.DarkGreen;
            this.percent.Location = new System.Drawing.Point(269, 179);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(21, 13);
            this.percent.TabIndex = 8;
            this.percent.Text = "0%";
            this.percent.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "درحال دریافت اطلاعات";
            this.label1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(88, 136);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(512, 25);
            this.progressBar1.TabIndex = 6;
            // 
            // getDataVerify
            // 
            this.getDataVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.getDataVerify.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("getDataVerify.BackgroundImage")));
            this.getDataVerify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.getDataVerify.Location = new System.Drawing.Point(219, 205);
            this.getDataVerify.Name = "getDataVerify";
            this.getDataVerify.Size = new System.Drawing.Size(259, 39);
            this.getDataVerify.TabIndex = 5;
            this.getDataVerify.UseVisualStyleBackColor = true;
            this.getDataVerify.Click += new System.EventHandler(this.getDataVerify_Click);
            // 
            // DDTO
            // 
            this.DDTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.DDTO.Location = new System.Drawing.Point(88, 82);
            this.DDTO.Name = "DDTO";
            this.DDTO.Size = new System.Drawing.Size(207, 29);
            this.DDTO.TabIndex = 4;
            // 
            // tolable
            // 
            this.tolable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tolable.AutoSize = true;
            this.tolable.Location = new System.Drawing.Point(314, 92);
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
            this.DDFROM.Location = new System.Drawing.Point(359, 82);
            this.DDFROM.Name = "DDFROM";
            this.DDFROM.Size = new System.Drawing.Size(156, 29);
            this.DDFROM.TabIndex = 2;
            // 
            // Datefrom
            // 
            this.Datefrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Datefrom.AutoSize = true;
            this.Datefrom.Location = new System.Drawing.Point(547, 90);
            this.Datefrom.Name = "Datefrom";
            this.Datefrom.Size = new System.Drawing.Size(49, 13);
            this.Datefrom.TabIndex = 1;
            this.Datefrom.Text = "تاریخ از :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrchid;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PleftPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 403);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(461, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "دریافت اطلاعات از سرور ";
            // 
            // getData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 403);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "getData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "دریافت اطلاعات";
            this.Load += new System.EventHandler(this.getData_Load);
            this.PleftPanel.ResumeLayout(false);
            this.PleftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PleftPanel;
        private System.Windows.Forms.PictureBox loading;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button getDataVerify;
        private System.Windows.Forms.TextBox DDTO;
        private System.Windows.Forms.Label tolable;
        private System.Windows.Forms.TextBox DDFROM;
        private System.Windows.Forms.Label Datefrom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}