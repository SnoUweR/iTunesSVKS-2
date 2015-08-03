namespace iTunesSVKS_2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.songArtistLabel = new System.Windows.Forms.Label();
            this.songNameLabel = new System.Windows.Forms.Label();
            this.lastFMBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(514, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.songArtistLabel);
            this.groupBox1.Controls.Add(this.songNameLabel);
            this.groupBox1.Controls.Add(this.lastFMBtn);
            this.groupBox1.Location = new System.Drawing.Point(4, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 213);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Композиция";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.albumArtBox);
            this.panel1.Location = new System.Drawing.Point(335, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 165);
            this.panel1.TabIndex = 31;
            // 
            // albumArtBox
            // 
            this.albumArtBox.Location = new System.Drawing.Point(5, 5);
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.Size = new System.Drawing.Size(155, 155);
            this.albumArtBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.albumArtBox.TabIndex = 27;
            this.albumArtBox.TabStop = false;
            // 
            // songArtistLabel
            // 
            this.songArtistLabel.Location = new System.Drawing.Point(10, 145);
            this.songArtistLabel.Name = "songArtistLabel";
            this.songArtistLabel.Size = new System.Drawing.Size(313, 48);
            this.songArtistLabel.TabIndex = 30;
            this.songArtistLabel.Text = "Нет автора";
            this.songArtistLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // songNameLabel
            // 
            this.songNameLabel.AutoEllipsis = true;
            this.songNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.songNameLabel.Location = new System.Drawing.Point(10, 86);
            this.songNameLabel.Name = "songNameLabel";
            this.songNameLabel.Size = new System.Drawing.Size(307, 59);
            this.songNameLabel.TabIndex = 28;
            this.songNameLabel.Text = "Нет композиции";
            this.songNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lastFMBtn
            // 
            this.lastFMBtn.Enabled = false;
            this.lastFMBtn.Location = new System.Drawing.Point(335, 184);
            this.lastFMBtn.Name = "lastFMBtn";
            this.lastFMBtn.Size = new System.Drawing.Size(165, 23);
            this.lastFMBtn.TabIndex = 29;
            this.lastFMBtn.Text = "Загрузить с LastFM";
            this.lastFMBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 389);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox albumArtBox;
        private System.Windows.Forms.Label songArtistLabel;
        private System.Windows.Forms.Label songNameLabel;
        private System.Windows.Forms.Button lastFMBtn;
    }
}

