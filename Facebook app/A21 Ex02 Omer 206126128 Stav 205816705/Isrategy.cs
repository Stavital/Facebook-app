using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
     public interface IStrategy
    {
        Dictionary<int, Album> SortAlbums(User i_LoggedInUserData);
    }
}
