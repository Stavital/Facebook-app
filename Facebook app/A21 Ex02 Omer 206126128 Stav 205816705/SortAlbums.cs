using System;
using System.Collections;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SortAlbums
    {
        public IStrategy Strategy { get; set; }
        public Dictionary<int, Album> Albums { get; set; }
        public User User { get; set; }

        public SortAlbums(User i_LoggedInUserData)
        {
            User = i_LoggedInUserData;
            Albums = new Dictionary<int, Album>();
        }

        public void SortAlbumsBy()
        {
            try
            {
                Albums = Strategy.SortAlbums(User);
            }
            catch (Exception err)
            {
                throw new Exception();
            }
        }
    }
}
