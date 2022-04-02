namespace DBOTWCrypt
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbLog = new DarkUI.Controls.DarkTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBrowseOpenFiles = new DarkUI.Controls.DarkButton();
            this.btnSaveFilePath = new DarkUI.Controls.DarkButton();
            this.btnConvert = new DarkUI.Controls.DarkButton();
            this.tbLoadPath = new DarkUI.Controls.DarkTextBox();
            this.tbSavePath = new DarkUI.Controls.DarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(12, 244);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(684, 223);
            this.tbLog.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::DBOTWCrypt.Properties.Resources.dbologol;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(684, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnBrowseOpenFiles
            // 
            this.btnBrowseOpenFiles.Checked = false;
            this.btnBrowseOpenFiles.Location = new System.Drawing.Point(602, 160);
            this.btnBrowseOpenFiles.Name = "btnBrowseOpenFiles";
            this.btnBrowseOpenFiles.Size = new System.Drawing.Size(94, 22);
            this.btnBrowseOpenFiles.TabIndex = 2;
            this.btnBrowseOpenFiles.Text = "Load File Path";
            this.btnBrowseOpenFiles.Click += new System.EventHandler(this.btnBrowseOpenFiles_Click);
            // 
            // btnSaveFilePath
            // 
            this.btnSaveFilePath.Checked = false;
            this.btnSaveFilePath.Location = new System.Drawing.Point(602, 188);
            this.btnSaveFilePath.Name = "btnSaveFilePath";
            this.btnSaveFilePath.Size = new System.Drawing.Size(94, 22);
            this.btnSaveFilePath.TabIndex = 3;
            this.btnSaveFilePath.Text = "Save File Path";
            this.btnSaveFilePath.Click += new System.EventHandler(this.btnSaveFilePath_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Checked = false;
            this.btnConvert.Location = new System.Drawing.Point(602, 216);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(94, 22);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert Files!";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tbLoadPath
            // 
            this.tbLoadPath.Location = new System.Drawing.Point(14, 160);
            this.tbLoadPath.Name = "tbLoadPath";
            this.tbLoadPath.Size = new System.Drawing.Size(582, 20);
            this.tbLoadPath.TabIndex = 5;
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(14, 188);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.Size = new System.Drawing.Size(582, 20);
            this.tbSavePath.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 479);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.tbLoadPath);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnSaveFilePath);
            this.Controls.Add(this.btnBrowseOpenFiles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DBO TW Crypto Tool : By SanGawku";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTextBox tbLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DarkUI.Controls.DarkButton btnBrowseOpenFiles;
        private DarkUI.Controls.DarkButton btnSaveFilePath;
        private DarkUI.Controls.DarkButton btnConvert;
        private DarkUI.Controls.DarkTextBox tbLoadPath;
        private DarkUI.Controls.DarkTextBox tbSavePath;
    }
}

