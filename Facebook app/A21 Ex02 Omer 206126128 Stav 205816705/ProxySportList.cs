using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class ProxySportList : IActivityList
    {
        public SprotList m_SportList;

        public ProxySportList()
        {
            m_SportList = SprotList.Instance;

            // Dummy data for illustration
            SportActivity run22 = new SportActivity(false, "Run 22 miles", DateTime.Now);
            SportActivity Swim10 = new SportActivity(false, "Swim 10 miles", DateTime.Now);
            SportActivity BB = new SportActivity(false, "Basketball with friend", DateTime.Now);

            SprotList.Instance.AddSportActivity(run22);
            SprotList.Instance.AddSportActivity(Swim10);
            SprotList.Instance.AddSportActivity(BB);
        }

        public Dictionary<string, SportActivity> SportActivities
        {
            get
            {
                return m_SportList.SportActivities;
            }

            set
            {
                m_SportList.SportActivities = value;
            }
        }

        // Validator
        public void AddSportActivity(SportActivity i_addingActivity)
        {
            if (SportActivities.ContainsKey(i_addingActivity.Name))
            {
                throw new Exception("This Activity is already on the list");
            }

            if(i_addingActivity.LimitTime < DateTime.Now)
            {
                throw new Exception("Choose different time");
            }
            else
            {
                SportActivities.Add(i_addingActivity.Name, i_addingActivity);
            }
        }

        public void InitList(ListBox i_sportCheckedListBox)
        {
            foreach (KeyValuePair<string, SportActivity> entry in SportActivities)
            {
                i_sportCheckedListBox.Items.Add(entry.Value);
            }
        }

        public void ToogleChangeItemChecked(string i_ActivityToToogleKey)
        {
            if (!SportActivities.ContainsKey(i_ActivityToToogleKey))
            {
                throw new Exception("This Activity isnt on the list");
            }
            else
            {
                m_SportList.ToogleChangeItemChecked(i_ActivityToToogleKey);
            }
        }

        public bool IsChecked(string i_ActivityToCheckKey)
        {
            bool ans = false;

            if (!SportActivities.ContainsKey(i_ActivityToCheckKey))
            {
                throw new Exception("This Activity isnt on the list");
            }
            else
            {
                ans = m_SportList.IsChecked(i_ActivityToCheckKey);
            }

            return ans;
        }
    }
}