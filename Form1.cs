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

namespace iTunesSVKS_2
{
    public partial class Form1 : Form
    {
        
        INetwork sNet = new VK();
        IPlayer pl = new iTunes();

        public Form1()
        {
            InitializeComponent();

        }

        private void SNetOnConnected(object sender, string username)
        {
            songNameLabel.Text = sNet.GetStatus();
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
            Console.WriteLine("Песня изменилась на {0}", newsong);
        }
    }
}
