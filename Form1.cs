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
using iTunesSVKS_2.Dialogs;

namespace iTunesSVKS_2
{
    public partial class Form1 : Form
    {
        
        //INetwork sNet = new VK();
        //private INetwork sk = new Skype();
        //IPlayer pl = new iTunes();
        ICoverFinder c = new LastFM();
        LogicManager _logic = new LogicManager();
        ITemplateProcessor tp = new DefaultProcessor();

        SimpleDialog sd = new SimpleDialog();

        readonly Action<Label, string> changeLabelText = (label, s) => label.Text = s;
        readonly Action<TextBox, string> changeTextBoxText = (textBox, s) => textBox.Text = s;
        readonly Action<PictureBox, Image> changeBoxImage = (box, image) => box.Image = image;

        public Form1()
        {
            InitializeComponent();
            
        }

        public string MessageToShare
        {
            get { return Properties.Settings.Default.messageToShare; }
            set
            {
                Properties.Settings.Default.messageToShare = value;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //sNet.Connected += SNetOnConnected;
            //sNet.Auth();
            _logic.SongChanged += PlOnSongChanged;
            _logic.Connected += SkOnConnected;
            _logic.Connecting += NetworkOnConnecting;
            _logic.Start();
        }

        private void NetworkOnConnecting(object sender, string networkName)
        {
            Console.WriteLine("Идет подключение к социальной сети.");

            /* Вообще, я думаю, что подобные штуки должны проводиться где-нибудь в LogicManager,
             * ибо архитектура, по моему замыслу, предполагает, что другие деволоперы смогут
             * вполне легко писать свои UI, не заботясь о том, как всё внутри тут устроено.
             */
            if (this.InvokeRequired)
            {
                BeginInvoke(new Action<object, string>(NetworkOnConnecting), new object[]{sender, networkName});
            }
            else
            {

                sd.BorderStyle = FormBorderStyle.None;
                sd.Title = "Подключение к " + networkName;
                sd.Message = String.Format("Ожидание ответа от социальной сети ({0})", networkName);
                sd.ShowDialog(this);
            }

        }

        private void SkOnConnected(object sender, string username)
        {
            Console.WriteLine(_logic.GetStatus());

            // За такое, думаю, меня побьют
            if (this.InvokeRequired)
            {
                BeginInvoke(new Action(sd.Close));
            }
            else
            {
                sd.Close();
            }


            //Ну и способ, лол. Можно было бы заюзать .net 4 с HasFlag, но вдруг кто-то 
            //на ХР будет запускать?
            if ((_logic.NetworkOptions & LogicManager.NetworkOptionsEnum.Sharing) != 0)
            {
                ISharer friendsNetwork = _logic.GetNetworkHandler() as ISharer;
                if (friendsNetwork != null)
                {
                    List<Friend> tmpFr = friendsNetwork.GetFriends();

                    foreach (Friend fr in tmpFr)
                    {
                        BeginInvoke(new Action<Friend>((friend) => comboBFriends.Items.Add(friend)), fr);
                    }

                    BeginInvoke(new Action<bool>((enabled) => shareButton.Enabled = enabled), true);
                }
            }
            else
            {
                Console.WriteLine("Сеть не поддерживает шэринг :(");
            }
 
        }


        private void PlOnSongChanged(object sender, Song newsong)
        {

            songNameLabel.Invoke(changeLabelText, new object[] {songNameLabel, _logic.CurrentSong.Name});
            songArtistLabel.Invoke(changeLabelText, new object[] { songArtistLabel, _logic.CurrentSong.Artist });
            albumArtBox.Invoke(changeBoxImage, new object[] { albumArtBox, _logic.CurrentSong.Cover });
            ProcessTemplate();
            _logic.StatusToChange = textBox2.Text;

        }

        private void customText_TextChanged(object sender, EventArgs e)
        {
            ProcessTemplate();
        }

        private void ProcessTemplate()
        {
            textBox2.Invoke(changeTextBoxText, new object[] { textBox2, tp.ProcessTemplate(customText.Text, _logic.CurrentSong) });
            _logic.StatusToChange = textBox2.Text;
        }

        private void FindCoverButton_Click(object sender, EventArgs e)
        {
            if (c.FindCover(_logic.CurrentSong))
            {
                albumArtBox.Invoke(changeBoxImage, new object[] {albumArtBox, c.GetCoverImage()});
            }
        }

        private void SaveCoverButton_Click(object sender, EventArgs e)
        {
            if (c.IsFound())
            {
                ICoverSetter coverSet = _logic.GetPlayerHandler() as ICoverSetter;
                if (coverSet != null)
                {
                    coverSet.SetCover(c.GetImagePath());
                }
            }
        }

        private void shareButton_Click(object sender, EventArgs e)
        {
            if ((_logic.NetworkOptions & LogicManager.NetworkOptionsEnum.Sharing) != 0)
            {
                ISharer friendsNetwork = _logic.GetNetworkHandler() as ISharer;
                if (friendsNetwork != null)
                {
                    Friend selectedFriend = (Friend) comboBFriends.SelectedItem;
                    friendsNetwork.Share(selectedFriend.Id, tp.ProcessTemplate(MessageToShare, _logic.CurrentSong));
                }
            }
        }

        private void autoUpdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _logic.AutoScrobble = autoUpdCheckBox.Checked;
        }

        private void setStatusButton_Click(object sender, EventArgs e)
        {
            ProcessTemplate();
            _logic.StatusToChange = textBox2.Text;
            _logic.ForceUpdateStatus();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           _logic.Close();
        }

        private void changeShareTextBtn_Click(object sender, EventArgs e)
        {
            ShareMessage sm = new ShareMessage {MessageToShare = MessageToShare};
            if (sm.ShowDialog(this) == DialogResult.OK)
            {
                MessageToShare = sm.MessageToShare;
            }

        }
    }
}
