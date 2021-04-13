using System.Windows.Forms;
using System.Drawing;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class PostsOps
    {
        private const int k_PostProfilePictureSize = 55;
        private const int k_PostsMargin = 20;

        public static Point addPosts(Point i_GroupBoxLocation, Point i_BaseLocation, int i_NumOfPost, GroupBox i_feedGroupBox)
        {
            Point nextPosition = new Point();
                if (i_NumOfPost >= 0)
                {
                    foreach (Post post in LoggedInUserData.User.WallPosts)
                    {
                        i_NumOfPost--;

                        int Y_Offset = 1;
                        GroupBox singlePostGroupBox = createPostGroupPost(i_GroupBoxLocation, i_feedGroupBox);
                        singlePostGroupBox.Tag = "Center";
                        PictureBox defaultPic = createDefaultFacebookProfilePicture(singlePostGroupBox);
                        PictureBox myPic = new PictureBox();
                        myPic.Image = LoggedInUserData.User.ImageSmall;
                        myPic.MaximumSize = new Size(new Point(k_PostProfilePictureSize, k_PostProfilePictureSize));

                        if (post.From != null && post.From.Name != null)
                        {
                            Point labelLocation = i_BaseLocation;
                            labelLocation.X += defaultPic.Width;
                            Label postFromName = MainOps.CreateNewDefaultLabel(post.From.Name, labelLocation, i_feedGroupBox);
                            singlePostGroupBox.Controls.Add(postFromName);

                            if (!postFromName.Text.Equals(LoggedInUserData.User.Name))
                            {
                                Point location = new Point(postFromName.Location.X + postFromName.Width, postFromName.Location.Y);
                                Label ToMyUser = MainOps.CreateNewDefaultLabel("->" + LoggedInUserData.User.Name, location, i_feedGroupBox);
                            
                                singlePostGroupBox.Controls.Add(ToMyUser);
                                singlePostGroupBox.Controls.Add(defaultPic);
                            }
                            else
                            {
                                singlePostGroupBox.Controls.Add(myPic);
                            }

                            if (post.Name != null)
                            {
                                Point location = new Point(postFromName.Location.X, i_BaseLocation.Y + Y_Offset * postFromName.Height);
                                Label postName = MainOps.CreateNewDefaultLabel(post.Name, location, i_feedGroupBox);
                                Y_Offset++;
                                singlePostGroupBox.Controls.Add(postName);
                            }

                            if (post.CreatedTime != null)
                            {
                                Point location = new Point(postFromName.Location.X, i_BaseLocation.Y + Y_Offset * postFromName.Height);
                                Label postDate = MainOps.CreateNewDefaultLabel(post.CreatedTime.ToString(), location, i_feedGroupBox);
                                singlePostGroupBox.Controls.Add(postDate);
                            }

                            if (post.Message != null)
                            {
                                Point location = new Point(defaultPic.Location.X, defaultPic.Location.Y + defaultPic.Height);
                                Label postMessage = MainOps.CreateNewDefaultLabel(post.Message, location, i_feedGroupBox);
                                Y_Offset++;
                                singlePostGroupBox.Controls.Add(postMessage);
                            }

                            i_feedGroupBox.Controls.Add(singlePostGroupBox);
                            i_GroupBoxLocation = calculateNextPostPosition(i_GroupBoxLocation, singlePostGroupBox.Height);
                            nextPosition = i_GroupBoxLocation;
                        }

                        // validation
                        if (i_NumOfPost <= 0)
                        {
                            break;
                        }
                    }
                }

                return nextPosition;
        }

        private static GroupBox createPostGroupPost(Point i_GroupBoxLoaction, GroupBox i_feedGroupBox)
        {
            GroupBox singlePostGroupBox = new GroupBox();
            singlePostGroupBox.AutoSize = true;
            singlePostGroupBox.BackColor = Color.White;
            singlePostGroupBox.MaximumSize = new Size(i_feedGroupBox.Width, int.MaxValue);
            singlePostGroupBox.Width = i_feedGroupBox.Width;
            singlePostGroupBox.Location = i_GroupBoxLoaction;
            singlePostGroupBox.Visible = true;

            return singlePostGroupBox;
        }

        private static PictureBox createDefaultFacebookProfilePicture(GroupBox i_SinglePostGroupBox)
        {
            PictureBox defaultPic = new PictureBox();
            defaultPic.Image = Properties.Resources.FacebookDefaultProfilePicture;
            defaultPic.MaximumSize = new Size(new Point(k_PostProfilePictureSize, k_PostProfilePictureSize));
            defaultPic.SizeMode = PictureBoxSizeMode.Zoom;

            return defaultPic;
        }

        private static Point calculateNextPostPosition(Point i_prevPoint, int i_PrevGroupBoxHeight)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + i_PrevGroupBoxHeight + k_PostsMargin);
        }
    }
}
