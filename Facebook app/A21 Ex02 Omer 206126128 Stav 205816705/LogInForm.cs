using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            initializeChildrenComponents();
        }

        private void initializeChildrenComponents()
        {
            setComponentsLocations();
        }

        private void setComponentsLocations()
        {
            WelcomeLable.Location = new Point((Width / 2) - (WelcomeLable.Width / 2), (int)(Height * 0.3));
            LogInBtn.Location = new Point((Width / 2) - (LogInBtn.Width / 2), (int)(Height * 0.6));
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            LoginResult result = FacebookService.Login(LoggedInUserData.AppId,
                "public_profile",
                "email",
                "user_photos", 
                "user_posts", 
                "user_events", 
                "user_birthday", 
                "user_events", 
                "user_hometown",
                "user_gender",
                "user_age_range",
                "user_link",
                "user_tagged_places",
                "user_videos",
                "user_friends",
                "user_likes",
                "pages_manage_posts",
                "publish_to_groups");

            LoggedInUserData.User = result.LoggedInUser;
            LoggedInUserData.AccesToken = result.AccessToken;
            this.Hide();
            Form mainFeed = FormsFactoryMethods.CreateFetureForm(FormsFactoryMethods.eForms.MainFeedForm);
            mainFeed.Show();
        }

        private void LogInForm_SizeChanged(object sender, EventArgs e)
        {
            setComponentsLocations();
        }
    }
}
