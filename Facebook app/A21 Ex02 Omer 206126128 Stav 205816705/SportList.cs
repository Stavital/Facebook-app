using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public sealed class SprotList : IActivityList
    {
        private static SprotList s_ActivityIMustDo = null;
        private static object s_LockObj = new object();
        private static Dictionary<string, SportActivity> m_SportActivity;

        private SprotList()
        {
            m_SportActivity = new Dictionary<string, SportActivity>()
            {
                // add instances
            };
        }

        public static SprotList Instance
        {
            get
            {
                if (s_ActivityIMustDo == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_ActivityIMustDo == null)
                        {
                            s_ActivityIMustDo = new SprotList();
                        }
                    }
                }

                return s_ActivityIMustDo;
            }
        }

        public Dictionary<string, SportActivity> SportActivities
        {
            get
            {
                return m_SportActivity;
            }

            set
            {
                m_SportActivity = value;
            }
        }

        public void AddSportActivity(SportActivity i_addingActivity)
        {
            if (i_addingActivity.Checked)
            {
                m_SportActivity[i_addingActivity.Name] = i_addingActivity;
            }
            else
            {
                m_SportActivity[i_addingActivity.Name] = i_addingActivity;
            }
        }

        public void ToogleChangeItemChecked(string i_ActivityToToogleKey)
        {
            m_SportActivity[i_ActivityToToogleKey].Checked = !m_SportActivity[i_ActivityToToogleKey].Checked;
        }

        public bool IsChecked(string i_ActivityToCheckKey)
        {
            return m_SportActivity[i_ActivityToCheckKey].Checked;
        }
    }
}
