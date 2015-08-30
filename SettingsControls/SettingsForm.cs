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
using iTunesSVKS_2.Properties;

namespace iTunesSVKS_2.SettingsControls
{
    public partial class SettingsForm : Form
    {
        private LogicManager _logic = LogicManager.Instance;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

            foreach (Type player in LogicManager.Transports)
            {
                AddItem(player.Name, player.GetInterfaces().Contains(typeof (INetwork)),
                    player.GetInterfaces().Contains(typeof (IPlayer)));
            }

        }

        /// <summary>
        /// Добавляет в список транспортов новый элемент
        /// </summary>
        /// <param name="name">Название транспорта</param>
        /// <param name="isNetwork">Реализует ли он социальную сеть</param>
        /// <param name="isPlayer">Реализует ли он плеер</param>
        /// <returns></returns>
        private ListViewItem AddItem(string name, bool isNetwork, bool isPlayer)
        {
            ListViewItem tmpItem = new ListViewItem(name);
            tmpItem.SubItems.Add("").Tag = isNetwork;
            tmpItem.SubItems.Add("").Tag = isPlayer;
            return lvObjects.Items.Add(tmpItem);
        }

        private void lvObjects_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            this.columnName.Width = lvObjects.Width - 16*3 - 4;

            if (e.SubItem.Tag != null)
            {
                if (e.Header == this.columnNetwork)
                {
                    e.DrawBackground();
                    var imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
                    Image imgToDraw = e.SubItem.Tag.Equals(true) ? Resources.networkIconOn : Resources.networkIconOff;
                    e.Graphics.DrawImage(imgToDraw, imageRect);
                    e.Header.Width = 16;
                }
                else if (e.Header == this.columnPlayer)
                {
                    e.DrawBackground();
                    var imageRect = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
                    Image imgToDraw = e.SubItem.Tag.Equals(true) ? Resources.playerIconOn : Resources.playerIconOff;
                    e.Graphics.DrawImage(imgToDraw, imageRect);
                    e.Header.Width = 16;
                }
            }

            else
            {
                e.DrawDefault = true;
                return;
            }


        }

        private void lvObjects_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}
