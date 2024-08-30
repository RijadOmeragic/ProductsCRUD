using System;
using System.Windows.Forms;


namespace ProductsCRUD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form startnaForma = new frmProducts();
            Application.Run(startnaForma);


            
        }
    }
}
