using GestionConges.Forms;
using System;
using System.Windows.Forms;

namespace GestionConges
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var mainForm = new frmGestionConges();
                Application.Run(mainForm);
            }
            else
            {
                // Fermeture si annulation
                Application.Exit();
            }
        }
    }
}