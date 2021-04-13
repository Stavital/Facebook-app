using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class SortAlbumsByNumberOfPhotos : IStrategy
    {
        public Dictionary<int, Album> SortAlbums(User i_LoggedInUserData) 
        {
            try
            {
                Dictionary<int, Album> albumesOfUser = new Dictionary<int, Album>();

                foreach (Album album in i_LoggedInUserData.Albums)
                {
                    albumesOfUser.Add((int)album.Count, album);
                }

                return albumesOfUser;
            }

            catch (Exception err)
            {
                throw new Exception();
            }
        }
    }
}
