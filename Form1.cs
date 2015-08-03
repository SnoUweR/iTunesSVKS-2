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

namespace iTunesSVKS_2
{
    public partial class Form1 : Form
    {
        
        INetwork sNet = new VK();
        IPlayer pl = new iTunes();
        ITemplateProcessor tp = new DefaultProcessor();
        private Song currentSong;

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
            songNameLabel.Text = pl.GetCurrentSong().Name;
        }

       

        private void PlOnSongChanged(object sender, Song newsong)
        {
            currentSong = newsong;
            Console.WriteLine("Песня изменилась на {0}", currentSong);
            
        }

        private void customText_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = tp.ProcessTemplate(customText.Text, currentSong);
        }
    }
}
