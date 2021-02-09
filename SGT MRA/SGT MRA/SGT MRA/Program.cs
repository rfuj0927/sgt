using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGT_MRA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new SgtMraMainForm());
            }catch(Exception ex)
            {
                MessageBox.Show("RuntimeError: " + ex.ToString(), "ERROR!");
            }
        }
    }
}
