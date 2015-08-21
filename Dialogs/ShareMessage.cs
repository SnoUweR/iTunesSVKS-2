using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunesSVKS_2.Dialogs
{
    public partial class ShareMessage : Form
    {
        public ShareMessage()
        {
            InitializeComponent();

        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.messageToShare = labelMessage.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            Close();
        }

        private void ShareMessage_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.messageToShare != null)
            {
                labelMessage.Text = Properties.Settings.Default.messageToShare;
            }
        }
    }
}
