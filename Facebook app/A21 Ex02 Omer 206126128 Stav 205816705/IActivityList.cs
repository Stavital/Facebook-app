using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public interface IActivityList
    {
        void AddSportActivity(SportActivity i_CustomThing);

        Dictionary<string ,SportActivity> SportActivities 
        { 
            get; 
        }

        void ToogleChangeItemChecked(string i_ActivityToToogleKey);

        bool IsChecked(string i_ActivityToCheckKey);
    }
}
