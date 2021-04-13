using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class SearchOps
    {
        private static Point LabelLocation = new Point(10, 10);
        private static int k_LabelMargin = 50;

        public static void SetEventsSearch(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            Point LabelLocation = new Point(10, 10);

            try
            {
                foreach (Event myEvent in LoggedInUserData.User.Events)
                {
                    if (!string.IsNullOrEmpty(myEvent.Name))
                    {
                        if (myEvent.Name.Contains(i_TextToFind))
                        {
                            addEvent(myEvent, i_FeedGroupBox);
                            addPicture(myEvent, i_FeedGroupBox);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMessage(i_FeedGroupBox);
            }
        }

        public static void SetFriendPosts(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            try 
            {
                foreach (User user in LoggedInUserData.User.Friends)
                {
                    foreach (Post post in user.Posts)
                    {
                        if (!string.IsNullOrEmpty(post.Message))
                        {
                            if (post.Message.Contains(i_TextToFind))
                            {
                                addFriendPost(post, i_FeedGroupBox);
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                errMessage(i_FeedGroupBox);
            } 
        }

        public static void SetGroupsSearch(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            try
            {
                foreach (Group group in LoggedInUserData.User.Groups)
                {
                    if (group.Name.Contains(i_TextToFind))
                    {
                        addGroup(group, i_FeedGroupBox);
                    } 
                }
            }
            catch(Exception e)
            {
                errMessage(i_FeedGroupBox);
            }
        }

        public static void SetPageSearchs(string i_TextToFind, GroupBox i_FeedGroupBox)
        {
            try 
            { 
                foreach (Page page in LoggedInUserData.User.LikedPages)
                {
                    if (page.Name.Contains(i_TextToFind))
                    {
                         addPage(page, i_FeedGroupBox);
                    }
                }
            }
            catch(Exception e)
            {
                errMessage(i_FeedGroupBox);
            }
        }

        private static void addPicture(Event i_newEvent, GroupBox i_FeedGroupBox)
        {
            PictureBox eventPicture = new PictureBox();
            Point LabelLocation = new Point(10, 10);
            eventPicture.Image = Properties.Resources.Facebook_1_Cake;
            eventPicture.Visible = true;
            eventPicture.SizeMode = PictureBoxSizeMode.Zoom;
            eventPicture.Location = MainOps.CalculateNextButtonPosition(LabelLocation, 100);
            eventPicture.MaximumSize = new Size(MainFeed.s_PostProfilePicturePointSize);
            i_FeedGroupBox.Controls.Add(eventPicture);
        }

        private static void errMessage(GroupBox i_FeedGroupBox)
        {
            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Clear()));
            Label errMessage = new Label();
            errMessage.Text = "sorry, we can't access the information";
            errMessage.AutoSize = true;
            errMessage.Location = new Point(20, 20);
            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(errMessage)));
        }

        private static void addEvent(Event i_newEvent, GroupBox i_FeedGroupBox)
        {
            addHeader("Events", i_FeedGroupBox);
            LabelLocation.Y += k_LabelMargin;

            Label eventLabel = new Label();
            string eventName = i_newEvent.Name;
            string eventTime = i_newEvent.StartTime.ToString();
            long attendingCount = (long)i_newEvent.AttendingCount;
            string newEvent = string.Format("Event: {0}\n start at: {1}\n attending: {2}\n", eventName, eventTime, attendingCount);

            eventLabel.Text = newEvent;
            eventLabel.AutoSize = true;
            eventLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            eventLabel.Visible = true;

            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(eventLabel)));
        }

        private static void addFriendPost(Post i_newPost, GroupBox i_FeedGroupBox)
        {
            addHeader("Friends Posts", i_FeedGroupBox);
            LabelLocation.Y += k_LabelMargin;

            Label friendPostLabel = new Label();
            string userName = i_newPost.From.Name + "posted";
            friendPostLabel.Text = userName;
            friendPostLabel.AutoSize = true;
            friendPostLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            friendPostLabel.Visible = true;

            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(friendPostLabel)));
        }

        private static void addGroup(Group i_newGroup, GroupBox i_FeedGroupBox)
        {
            addHeader("Groups", i_FeedGroupBox);
            LabelLocation.Y += k_LabelMargin;

            Label groupLabel = new Label();
            string groupName = i_newGroup.Name;
            string groupOwner = i_newGroup.Owner.ToString();
            string groupNumberOfPosts = i_newGroup.WallPosts.Count().ToString();
            string newGroup = string.Format("The Group {0} created by {1} has {2} posts", groupName, groupOwner, groupNumberOfPosts);
            groupLabel.Text = newGroup;
            groupLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            groupLabel.AutoSize = true;
            groupLabel.Visible = true;

            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(groupLabel)));
        }

        private static void addPage(Page i_newPage, GroupBox i_FeedGroupBox)
        {
            addHeader("Pages", i_FeedGroupBox);
            LabelLocation.Y += k_LabelMargin;

            Label pageLabel = new Label();
            string pageName = i_newPage.Name;
            string pageNumberOfPosts = i_newPage.Posts.Count().ToString();
            string pageAdmins = i_newPage.Admins.ToString();
            string newPagePost = string.Format("The page {0} created by {1} has {2} posts", pageName, pageAdmins, pageNumberOfPosts);
            pageLabel.Text = newPagePost;
            pageLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            pageLabel.AutoSize = true;
            pageLabel.Visible = true;

            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(pageLabel)));
        }

        private static void addHeader(string i_name, GroupBox i_FeedGroupBox)
        {
            Label header = new Label();
            header.Text = "Your " + i_name + ":";
            header.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            header.AutoSize = true;
            header.Visible = true;
            i_FeedGroupBox.Invoke(new Action(() => i_FeedGroupBox.Controls.Add(header)));
        }
    }
}
