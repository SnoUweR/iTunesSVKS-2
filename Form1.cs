using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTunesSVKS_2.Networks;
using iTunesSVKS_2.Players;
using iTunesSVKS_2.TemplateProcessor;
using iTunesSVKS_2.Networks.LastFM;
using iTunesSVKS_2.Common;

namespace iTunesSVKS_2
{
    public partial class Form1 : Form
    {
        
        INetwork sNet = new VK();
        IPlayer pl = new iTunes();
        ITemplateProcessor tp = new DefaultProcessor();
        private Song currentSong;


        Action<Label, string> changeLabelText = (label, s) => label.Text = s;
        Action<TextBox, string> changeTextBoxText = (textBox, s) => textBox.Text = s;
        Action<PictureBox, Image> changeBoxImage = (box, image) => box.Image = image;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void SNetOnConnected(object sender, string username)
        {
            List<Friend> tmpFr = sNet.GetFriends();

            foreach (Friend fr in tmpFr)
            {
                comboBFriends.Items.Add(fr);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            sNet.Connected += SNetOnConnected;
            //sNet.Auth();
            pl.SongChanged += PlOnSongChanged;
            pl.Initialize();
        }

       

        private void PlOnSongChanged(object sender, Song newsong)
        {
            currentSong = newsong;
            Console.WriteLine("Песня изменилась на {0}", currentSong);

            songNameLabel.Invoke(changeLabelText, new object[] {songNameLabel, currentSong.Name});
            songArtistLabel.Invoke(changeLabelText, new object[] { songArtistLabel, currentSong.Artist });
            albumArtBox.Invoke(changeBoxImage, new object[] { albumArtBox, currentSong.Cover });

            ProcessTemplate();

        }

        private void customText_TextChanged(object sender, EventArgs e)
        {
            ProcessTemplate();
        }

        private void ProcessTemplate()
        {
            textBox2.Invoke(changeTextBoxText, new object[] {textBox2, tp.ProcessTemplate(customText.Text, currentSong)});
        }

        private void FindCoverButton_Click(object sender, EventArgs e)
        {
            ICoverFinder c = new LastFM();
            if (c.FindCover(new Song()
            {
                Artist = "Pendulum",
                Name = "The Other Side"
            }))
            {
                albumArtBox.Invoke(changeBoxImage, new object[] {albumArtBox, c.GetCoverImage()});
            }
        }
    }
}
