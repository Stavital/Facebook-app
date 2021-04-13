using System.Linq;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class AlbumsOps
    {
        private static FacebookObjectCollection<Album> s_Albums;
        private static bool s_IsFetched = false;

        public static void FetchAlbums()
        {
            s_Albums = LoggedInUserData.User.Albums;
            s_IsFetched = true;
        }

        public static void AddAlbums(Point i_PicLocation, int i_NumOfAlbums, GroupBox i_feedGroupBox, Dictionary<int, Album> i_albums)
        {
            try
            {
                while (!s_IsFetched) 
                { 
                }

                if (i_albums != null)
                {
                    foreach (KeyValuePair<int, Album> album in i_albums.OrderBy(entry => entry.Key))
                    {
                        Album tempAlbum = album.Value;
                        addAlbumToFeedBox(i_PicLocation, i_feedGroupBox, tempAlbum);
                        i_PicLocation = calculateNextAlbumCUverPhotoPosition(i_PicLocation);
                    }
                }
                else
                {
                    foreach (Album album in s_Albums)
                    {
                        if (i_NumOfAlbums <= 0)
                        {
                            break;
                        }

                        i_NumOfAlbums--;

                        addAlbumToFeedBox(i_PicLocation, i_feedGroupBox, album);
                        i_PicLocation = calculateNextAlbumCUverPhotoPosition(i_PicLocation);
                    }
                }
            }
            catch (Exception e)
            {
                MainOps.CreateNewErrMessage(i_feedGroupBox);
            }
        }

        public static Dictionary<int, Album> SortAlbumsBy() 
        {
            try
            {
                SortAlbums sortAlbums = new SortAlbums(LoggedInUserData.User) { Strategy = new SortAlbumsByNumberOfPhotos() };
                sortAlbums.SortAlbumsBy();

                return sortAlbums.Albums;
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private static Point calculateNextAlbumCUverPhotoPosition(Point i_prevPoint)
        {
            int x = i_prevPoint.X;
            int y = i_prevPoint.Y;

            x = (x + 200) % 400;
            if (x <= 50)
            {
                y += 220;
            }

            return new Point(x, y);
        }

        private static void addAlbumToFeedBox(Point i_PicLocation, GroupBox i_feedGroupBox,  Album i_album)
        {
            PictureBox albumPicture = new PictureBox();
            albumPicture.Size = new System.Drawing.Size(150, 150);
            albumPicture.Location = i_PicLocation;
            albumPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            albumPicture.LoadAsync(i_album.PictureAlbumURL);
            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumPicture)));

            Label albumName = new Label();
            albumName.Text = i_album.Name;
            albumName.ForeColor = Color.Black;
            albumName.Location = new Point(i_PicLocation.X, i_PicLocation.Y - albumName.Size.Height);
            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumName)));

            Point countLabelPoint = new Point(i_PicLocation.X, i_PicLocation.Y + albumPicture.Height);
            Label albumCount = MainOps.CreateNewDefaultLabel(i_album.Count + " Photos", countLabelPoint, i_feedGroupBox);
            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(albumCount)));
        }
    }
}
