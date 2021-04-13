using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormsFactoryMethods.CreateFetureForm(FormsFactoryMethods.eForms.LogInOform));
        }
    }
}
