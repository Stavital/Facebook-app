using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SportActivity
    {
        private bool m_Checked;
        private string m_ActivityName;
        private DateTime m_LimitTime;

        public SportActivity(bool i_Checked, string i_activityName, DateTime i_LimitTime)
        {
            m_Checked = i_Checked;
            m_ActivityName = i_activityName;
            m_LimitTime = i_LimitTime;
        }

        public string Name
        {
            get
            {
                return m_ActivityName;
            }

            set
            {
                m_ActivityName = value;
            }
        }

        public bool Checked 
        {
            get 
            {
                return m_Checked;
            }

            set 
            {
                m_Checked = value;
            }
        }

        public DateTime LimitTime
        {
            get
            {
                return m_LimitTime;
            }

            set
            {
                m_LimitTime = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
