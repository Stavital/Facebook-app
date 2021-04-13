using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class FormsFactoryMethods
    {
        public enum eForms
        {
            LogInOform,
            MainFeedForm
        }

        public static Form CreateFetureForm(eForms i_createForm)
        {
            switch (i_createForm)
            {
                // In each case we can config the form by its purpose.
                case eForms.LogInOform:
                    return new LogInForm(); 
                case eForms.MainFeedForm:
                    return new MainFeed();
                default:
                    throw new Exception("Invalid");
            }
        }
    }
}
