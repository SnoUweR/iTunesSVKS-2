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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveCoverButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.songArtistLabel = new System.Windows.Forms.Label();
            this.songNameLabel = new System.Windows.Forms.Label();
            this.FindCoverButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBFriends = new System.Windows.Forms.ComboBox();
            this.changeShareTextBtn = new System.Windows.Forms.Button();
            this.albumArtCheckBox = new System.Windows.Forms.CheckBox();
            this.shareButton = new System.Windows.Forms.Button();
            this.wallSongButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.realSongChckBox = new System.Windows.Forms.CheckBox();
            this.customText = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.setStatusButton = new System.Windows.Forms.Button();
            this.autoUpdCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.shareBtn = new System.Windows.Forms.Button();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.SaveCoverButton);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.shareBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.songArtistLabel);
            this.groupBox1.Controls.Add(this.songNameLabel);
            this.groupBox1.Controls.Add(this.FindCoverButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 213);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Композиция";
            // 
            // SaveCoverButton
            // 
            this.SaveCoverButton.Location = new System.Drawing.Point(164, 184);
            this.SaveCoverButton.Name = "SaveCoverButton";
            this.SaveCoverButton.Size = new System.Drawing.Size(165, 23);
            this.SaveCoverButton.TabIndex = 35;
            this.SaveCoverButton.Text = "Сохранить в iTunes";
            this.SaveCoverButton.UseVisualStyleBackColor = true;
            this.SaveCoverButton.Click += new System.EventHandler(this.SaveCoverButton_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 2);
            this.label2.TabIndex = 33;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(8, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 2);
            this.label1.TabIndex = 32;
            this.label1.Text = "label1";
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
            // songArtistLabel
            // 
            this.songArtistLabel.Location = new System.Drawing.Point(11, 78);
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
            this.songNameLabel.Location = new System.Drawing.Point(14, 19);
            this.songNameLabel.Name = "songNameLabel";
            this.songNameLabel.Size = new System.Drawing.Size(307, 59);
            this.songNameLabel.TabIndex = 28;
            this.songNameLabel.Text = "Нет композиции";
            this.songNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FindCoverButton
            // 
            this.FindCoverButton.Location = new System.Drawing.Point(335, 184);
            this.FindCoverButton.Name = "FindCoverButton";
            this.FindCoverButton.Size = new System.Drawing.Size(165, 23);
            this.FindCoverButton.TabIndex = 29;
            this.FindCoverButton.Text = "Загрузить с LastFM";
            this.FindCoverButton.UseVisualStyleBackColor = true;
            this.FindCoverButton.Click += new System.EventHandler(this.FindCoverButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBFriends);
            this.groupBox4.Controls.Add(this.changeShareTextBtn);
            this.groupBox4.Controls.Add(this.albumArtCheckBox);
            this.groupBox4.Controls.Add(this.shareButton);
            this.groupBox4.Controls.Add(this.wallSongButton);
            this.groupBox4.Location = new System.Drawing.Point(334, 314);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 155);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поделиться";
            // 
            // comboBFriends
            // 
            this.comboBFriends.FormattingEnabled = true;
            this.comboBFriends.Location = new System.Drawing.Point(6, 19);
            this.comboBFriends.Name = "comboBFriends";
            this.comboBFriends.Size = new System.Drawing.Size(161, 21);
            this.comboBFriends.TabIndex = 27;
            this.comboBFriends.Text = "Выберите друга";
            // 
            // changeShareTextBtn
            // 
            this.changeShareTextBtn.Location = new System.Drawing.Point(5, 69);
            this.changeShareTextBtn.Name = "changeShareTextBtn";
            this.changeShareTextBtn.Size = new System.Drawing.Size(163, 23);
            this.changeShareTextBtn.TabIndex = 25;
            this.changeShareTextBtn.Text = "Изменить текст";
            this.changeShareTextBtn.UseVisualStyleBackColor = true;
            this.changeShareTextBtn.Click += new System.EventHandler(this.changeShareTextBtn_Click);
            // 
            // albumArtCheckBox
            // 
            this.albumArtCheckBox.AutoSize = true;
            this.albumArtCheckBox.Location = new System.Drawing.Point(6, 127);
            this.albumArtCheckBox.Name = "albumArtCheckBox";
            this.albumArtCheckBox.Size = new System.Drawing.Size(133, 17);
            this.albumArtCheckBox.TabIndex = 24;
            this.albumArtCheckBox.Text = "Прикрепить обложку";
            this.albumArtCheckBox.UseVisualStyleBackColor = true;
            // 
            // shareButton
            // 
            this.shareButton.Enabled = false;
            this.shareButton.Location = new System.Drawing.Point(5, 42);
            this.shareButton.Name = "shareButton";
            this.shareButton.Size = new System.Drawing.Size(163, 23);
            this.shareButton.TabIndex = 20;
            this.shareButton.Text = "Порекомендовать";
            this.shareButton.UseVisualStyleBackColor = true;
            this.shareButton.Click += new System.EventHandler(this.shareButton_Click);
            // 
            // wallSongButton
            // 
            this.wallSongButton.Enabled = false;
            this.wallSongButton.Location = new System.Drawing.Point(5, 98);
            this.wallSongButton.Name = "wallSongButton";
            this.wallSongButton.Size = new System.Drawing.Size(163, 23);
            this.wallSongButton.TabIndex = 21;
            this.wallSongButton.Text = "Поместить себе на страницу";
            this.wallSongButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.realSongChckBox);
            this.groupBox2.Controls.Add(this.customText);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.setStatusButton);
            this.groupBox2.Controls.Add(this.autoUpdCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(5, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 155);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Шаблон";
            // 
            // realSongChckBox
            // 
            this.realSongChckBox.AutoSize = true;
            this.realSongChckBox.Location = new System.Drawing.Point(6, 123);
            this.realSongChckBox.Name = "realSongChckBox";
            this.realSongChckBox.Size = new System.Drawing.Size(267, 17);
            this.realSongChckBox.TabIndex = 27;
            this.realSongChckBox.Text = "Транслировать в статус реальную песню (Beta)";
            this.realSongChckBox.UseVisualStyleBackColor = true;
            // 
            // customText
            // 
            this.customText.Location = new System.Drawing.Point(6, 19);
            this.customText.Multiline = true;
            this.customText.Name = "customText";
            this.customText.Size = new System.Drawing.Size(311, 36);
            this.customText.TabIndex = 26;
            this.customText.Text = "Сейчас прослушиваю {artist} - {name} via iTunes";
            this.customText.TextChanged += new System.EventHandler(this.customText_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 61);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(311, 33);
            this.textBox2.TabIndex = 14;
            // 
            // setStatusButton
            // 
            this.setStatusButton.Location = new System.Drawing.Point(213, 96);
            this.setStatusButton.Name = "setStatusButton";
            this.setStatusButton.Size = new System.Drawing.Size(104, 23);
            this.setStatusButton.TabIndex = 4;
            this.setStatusButton.Text = "Обновить";
            this.setStatusButton.UseVisualStyleBackColor = true;
            this.setStatusButton.Click += new System.EventHandler(this.setStatusButton_Click);
            // 
            // autoUpdCheckBox
            // 
            this.autoUpdCheckBox.AutoSize = true;
            this.autoUpdCheckBox.Location = new System.Drawing.Point(6, 100);
            this.autoUpdCheckBox.Name = "autoUpdCheckBox";
            this.autoUpdCheckBox.Size = new System.Drawing.Size(104, 17);
            this.autoUpdCheckBox.TabIndex = 7;
            this.autoUpdCheckBox.Text = "Автоматически";
            this.autoUpdCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdCheckBox.CheckedChanged += new System.EventHandler(this.autoUpdCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::iTunesSVKS_2.Properties.Resources.search32;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button1.Location = new System.Drawing.Point(51, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 34;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.button1, "Искать данную песню");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // shareBtn
            // 
            this.shareBtn.BackgroundImage = global::iTunesSVKS_2.Properties.Resources.share32;
            this.shareBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.shareBtn.FlatAppearance.BorderSize = 0;
            this.shareBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shareBtn.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.shareBtn.Location = new System.Drawing.Point(13, 117);
            this.shareBtn.Name = "shareBtn";
            this.shareBtn.Size = new System.Drawing.Size(32, 32);
            this.shareBtn.TabIndex = 32;
            this.shareBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.shareBtn, "Поделиться песней с друзьями...");
            this.shareBtn.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 536);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button FindCoverButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBFriends;
        private System.Windows.Forms.Button changeShareTextBtn;
        private System.Windows.Forms.CheckBox albumArtCheckBox;
        private System.Windows.Forms.Button shareButton;
        private System.Windows.Forms.Button wallSongButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox realSongChckBox;
        private System.Windows.Forms.TextBox customText;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button setStatusButton;
        private System.Windows.Forms.CheckBox autoUpdCheckBox;
        private System.Windows.Forms.Button shareBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SaveCoverButton;
    }
}

