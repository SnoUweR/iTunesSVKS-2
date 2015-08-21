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
    /// <summary>
    /// Простое диалоговое окно, которое содержит лишь текст
    /// </summary>
    public partial class SimpleDialog : Form
    {
        public SimpleDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает или задает стиль диалогового окна
        /// </summary>
        public FormBorderStyle BorderStyle
        {
            get { return this.FormBorderStyle; }
            set { this.FormBorderStyle = value; }
        }

        /// <summary>
        /// Возвращает или задает текст в диалоговом окне
        /// </summary>
        public string Message
        {
            get { return this.labMessage.Text; }
            set { this.labMessage.Text = value; }
        }

        /// <summary>
        /// Возвращает или задает название диалогового окна
        /// </summary>
        public string Title
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}
