using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class LoggedInUserData
    {
        private const string k_appID = "1556806451170375";

        private static User m_User;
        private static string m_AccesToken;

        public static User User
        {
            get
            {
                return m_User;
            }

            set
            {
                m_User = value;
            }
        }

        public static string AccesToken
        {
            get
            {
                return m_AccesToken;
            }

            set
            {
                m_AccesToken = value;
            }
        }

        public static string AppId
        {
            get
            {
                return k_appID;
            }
        }
    }
}
