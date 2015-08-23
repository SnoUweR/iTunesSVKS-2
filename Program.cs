using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iTunesSVKS_2
{
    static class Program
    {
        static int mainThreadId;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool IsMainThread
        {
            get { return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThreadId; }
        }
    }
}
