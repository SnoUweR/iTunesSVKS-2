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

        public string MessageToShare
        {
            get { return labelMessage.Text; } 
            set { labelMessage.Text = value; }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            MessageToShare = labelMessage.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
