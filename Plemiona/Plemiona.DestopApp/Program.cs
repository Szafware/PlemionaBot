using Plemiona.DestopApp.Forms;
using System;
using System.Windows.Forms;

namespace Plemiona.DestopApp
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}