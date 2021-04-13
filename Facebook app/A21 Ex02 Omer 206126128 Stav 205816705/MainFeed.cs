using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public partial class MainFeed : Form
    {
        // Style
        private const int k_PostsMargin = 20;
        private const int k_PostProfilePictureSize = 55;
        private const int k_NumOfPostsInHomePage = 3;
        private const int k_NumOfAlbumsInHomePage = 4;
        private const int k_LabelMargin = 50;
        private const float k_SearchTextBoxRatio = 0.5f;

        private static int s_PostWidth;
        private static string s_TextToFind;

        private string m_ActivityName;
        private bool m_ActivityIsChecked;
        private DateTime m_dateTime;
        private IEnumerator m_Iterator = null;

        private bool m_IsCollapsed = false;

        private Label m_GameHeader;
        public static ProxySportList m_MySportListProxy = new ProxySportList();

        // Prop
        public static Point s_PostProfilePicturePointSize
        {
            get
            {
                return new Point(k_PostProfilePictureSize, k_PostProfilePictureSize);
            }
        }

        public static int LabelMargin
        {
            get
            {
                return k_LabelMargin;
            }
        }

        public static int DefaultCenterWidth
        {
            get
            {
                return s_PostWidth;
            }
        }

        public bool NewPostVisabilty
        {
            set
            {
                NewPost.Visible = value;
            }
        }

        // Main
        public MainFeed()
        {
            InitializeComponent();
            initializeChildrenComponents();

            Thread albums = new Thread(() => AlbumsOps.FetchAlbums());
            albums.Start();
            albums.Join();
        }

        private void initializeChildrenComponents()
        {
            WelcomeUserNameLable.Text = LoggedInUserData.User.FirstName;
            UserNamePictureBox.Image = LoggedInUserData.User.ImageSmall;
        }

        private void mainFeed_Load(object sender, EventArgs e)
        {
            homeBtn_Click(new object(), new EventArgs());
        }

        // Home 
        private void homeBtn_Click(object sender, EventArgs e)
        {
            Transition();

            MainOps.ResetFeedGroupBox(FeedGroupBox, DefaultCenterWidth);

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);

            Point nextPosition = new Point();
            nextPosition = PostsOps.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox);
            nextPosition.Y += k_PostsMargin;

            AlbumsOps.AddAlbums(nextPosition, k_NumOfAlbumsInHomePage, FeedGroupBox, null);
        }

        // Albums
        private void fetchaAlbumsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Button Sort = new Button();
            Sort.Text = "Sort Albums";
            Sort.Click += SortAlbums_Click;
            Sort.Location = new Point(450, 50);
            Sort.BackColor = Color.RoyalBlue;
            FeedGroupBox.Controls.Add(Sort);

            Point picLocation = new Point(20, 50);
            AlbumsOps.AddAlbums(picLocation, int.MaxValue, FeedGroupBox, null);
        }

        // Posts
        private void fetchPostsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            Point groupBoxLocation = new Point();
            Point baseLocation = new Point(20, 10);
            PostsOps.addPosts(groupBoxLocation, baseLocation, k_NumOfPostsInHomePage, FeedGroupBox);
        }

        // Account 
        private void fetchAccountInfoBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Thread acountInfo = new Thread(() => AccountOps.AddAcountInfo(FeedGroupBox));
            acountInfo.Start();
        }

        // Events 
        private void fetchEventsBtn_Click(object sender, EventArgs e)
        {
            Transition();

            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Thread addEvents = new Thread(() => EventsOps.AddEvents(FeedGroupBox));
            addEvents.Start();
        }

        // LogOut
        private void logOut_Click(object sender, EventArgs e)
        {
            Transition();

            LoggedInUserData.User = null;

            this.Hide();
            LogInForm logInForm = new LogInForm();
            logInForm.Show();
        }

        private void dropDownBar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!m_IsCollapsed)
            {
                PanelDropDown.Height += 10;
                if (PanelDropDown.Size == PanelDropDown.MaximumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = true;
                }
            }
            else
            {
                PanelDropDown.Height -= 10;
                if (PanelDropDown.Size == PanelDropDown.MinimumSize)
                {
                    timer1.Stop();
                    m_IsCollapsed = false;
                }
            }
        }

        // Games
        public void GamesBtn_Click(object sender, EventArgs e)
        {
            Transition();

            NewPost.Hide();
            FeedGroupBox.Hide();

            Label Header = MainOps.CreateNewDefaultLabel(
                "Games",
                new Point(0, 0),
                DefaultCenterWidth);
            Controls.Add(Header);
            Header.Font = new Font("Britannic Bold", 32);
            Header.ForeColor = Color.RoyalBlue;
            Header.Location = new Point(NewPost.Location.X + (DefaultCenterWidth / 2) - (Header.Width / 2), NewPost.Location.Y + k_PostsMargin);
            m_GameHeader = Header;

            // Guessing game
            Button guessingGameBtn = new Button();
            guessingGameBtn.Click += birthdaysGameBtn_Click;
            guessingGameBtn.Size = new Size(150, 100);
            guessingGameBtn.BackgroundImage = A21_Ex02_Omer_206126128_Stav_205816705.Properties.Resources.GuessingGamePicture;
            guessingGameBtn.BackgroundImageLayout = ImageLayout.Stretch;
            guessingGameBtn.Location = new Point(
                //// ( ---- center of header ----------) - ( relative location)
                Header.Location.X + (Header.Width / 2) - (int)(1.5f * guessingGameBtn.Width),
                Header.Location.Y + Header.Height + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(guessingGameBtn);

            Button g = new Button();
            g.Click += birthdaysGameBtn_Click;
            g.Size = new Size(150, 100);
            g.BackgroundImage = A21_Ex02_Omer_206126128_Stav_205816705.Properties.Resources.GuessingGamePicture;
            g.BackgroundImageLayout = ImageLayout.Stretch;
            g.Location = new Point(Header.Location.X + (Header.Width / 2) + (g.Width / 2), Header.Location.Y + Header.Height + k_PostsMargin);
            GamesOps.AllGamesBtn.Add(g);

            GamesOps.AddAllButtunsToConstorls(GamesOps.AllGamesBtn, Controls);
        }

        private void birthdaysGameBtn_Click(object sender, EventArgs e)
        {
            GamesOps.RemoveAllButtunsFromConstorls(GamesOps.AllGamesBtn, Controls);

            // In this case we need to ranomize a friend and get his birthday - but permission denied
            /* newQuestion(
                            sender,
                            "How old is <RandomUserFriend().FullName>?",
                            new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin),
                            this);
            */
            GamesOps.NewAgeQuestion(
                sender,
                "How old is Guy Ronen?",
                new Point(NewPost.Location.X, m_GameHeader.Location.Y + m_GameHeader.Height + k_PostsMargin), Controls,
                this);
        }

        // serach
        private void searchBtn_Click(object sender, EventArgs e)
        {
            Transition();

            if (!string.IsNullOrEmpty(s_TextToFind))
            {
                Transition();
                Thread addEventSearch = new Thread(() => SearchOps.SetEventsSearch(s_TextToFind, FeedGroupBox));
                addEventSearch.Start();

                Thread addFriendSearch = new Thread(() => SearchOps.SetFriendPosts(s_TextToFind, FeedGroupBox));
                addFriendSearch.Start();

                Thread addGroupSearch = new Thread(() => SearchOps.SetGroupsSearch(s_TextToFind, FeedGroupBox));
                addGroupSearch.Start();

                Thread addPageSearch = new Thread(() => SearchOps.SetPageSearchs(s_TextToFind, FeedGroupBox));
                addPageSearch.Start();
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            s_TextToFind = SearchTextBox.Text;
        }

        // General
        public void Transition()
        {
            NewPost.Visible = true;
            MainOps.ResetFeedGroupBox(FeedGroupBox, DefaultCenterWidth);
            GamesOps.RemoveAllGuessingGameControls(Controls);
            ActivityDetailsPanel.Visible = false;
        }

        private void setControlsLocations()
        {
            DropDownPictureBox.Location = new Point(this.Size.Width - DropDownPictureBox.Width - k_LabelMargin, DropDownPictureBox.Location.Y);
            WelcomeUserNameLable.Location = new Point(DropDownPictureBox.Location.X - WelcomeUserNameLable.Width, WelcomeUserNameLable.Location.Y);
            UserNamePictureBox.Location = new Point(WelcomeUserNameLable.Location.X - UserNamePictureBox.Width, UserNamePictureBox.Location.Y);
            PanelDropDown.Location = new Point(UserNamePictureBox.Location.X, BlueTopBar.Height);

            SearchTextBox.Location = new Point((this.Size.Width / 2) - (SearchTextBox.Width / 2), SearchTextBox.Location.Y);
            SearchBtn.Location = new Point(SearchTextBox.Location.X + SearchTextBox.Width - SearchBtn.Width, SearchTextBox.Location.Y);

            NewPost.Location = new Point((this.Size.Width / 2) - (NewPost.Width / 2), NewPost.Location.Y);
            posted.Location = new Point(NewPost.Location.X - posted.Width, NewPost.Location.Y + NewPost.Height);

            FeedGroupBox.Location = new Point(NewPost.Location.X, posted.Location.Y + posted.Height + k_PostsMargin);

            HomeBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + HomeBtn.Width)) / 2, NewPost.Location.Y);
            FetchPostsBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + FetchPostsBtn.Width)) / 2, HomeBtn.Location.Y + HomeBtn.Height + 5);
            FetchaAlbumsBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + FetchaAlbumsBtn.Width)) / 2, FetchPostsBtn.Location.Y + FetchPostsBtn.Height + 5);
            FetchEventsBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + FetchEventsBtn.Width)) / 2, FetchaAlbumsBtn.Location.Y + FetchaAlbumsBtn.Height + 5);
            GamesBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + GamesBtn.Width)) / 2, FetchEventsBtn.Location.Y + FetchEventsBtn.Height + 5);
            SportBth.Location = new Point((NewPost.Location.X - (k_PostsMargin + SportBth.Width)) / 2, GamesBtn.Location.Y + GamesBtn.Height + 5);
            SportIteratorBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + SportIteratorBtn.Width)) / 2, SportBth.Location.Y + SportBth.Height + 5);
            ElectionsBtn.Location = new Point((NewPost.Location.X - (k_PostsMargin + ElectionsBtn.Width)) / 2, SportIteratorBtn.Location.Y + SportIteratorBtn.Height + 5);
        }

        private void setControlsSizes()
        {
            BlueTopBar.Height = (int)(FacebookIcon.Height * 1.5);
            SearchTextBox.Width = DefaultCenterWidth;
            NewPost.Width = DefaultCenterWidth;
            FeedGroupBox.Width = DefaultCenterWidth;
            PanelDropDown.MinimumSize = new Size(new Point(150, 0));
            PanelDropDown.MaximumSize = new Size(new Point(150, 150));

            foreach (Control control in Controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.Equals("Center"))
                    {
                        control.Width = DefaultCenterWidth;
                    }
                }
            }
        }

        private void mainFeed_SizeChanged(object sender, EventArgs e)
        {
            s_PostWidth = (int)(Width * k_SearchTextBoxRatio);
            setControlsSizes();
            setControlsLocations();
        }

        // Sport
        private void sportBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Visible = true;

            AddSportLabel.Visible = true;
            ActivityNameLabel.Visible = true;
            NewActivityNameTextBox.Visible = true;
            LimitTimeLabel.Visible = true;
            dateTimePickerForSport.Visible = true;
            AddBth.Visible = true;
            ActivityIsCheckedCheckBox.Visible = true;

            SportListActivitiesLabel.Visible = true;
            SportCheckedListBox.Visible = true;

            ActivityDetailsPanel.Visible = true;
            FeedGroupBox.Controls.Add(ActivityDetailsPanel);

            Point LabelLocation = new Point(0, 0);

            FeedGroupBox.BackColor = System.Drawing.Color.White;

            FeedGroupBox.Controls.Add(AddSportLabel);
            FeedGroupBox.Controls.Add(ActivityNameLabel);
            FeedGroupBox.Controls.Add(NewActivityNameTextBox);
            FeedGroupBox.Controls.Add(LimitTimeLabel);
            FeedGroupBox.Controls.Add(dateTimePickerForSport);
            FeedGroupBox.Controls.Add(ActivityIsCheckedCheckBox);
            FeedGroupBox.Controls.Add(AddBth);

            FeedGroupBox.Controls.Add(SportListActivitiesLabel);
            FeedGroupBox.Controls.Add(SportCheckedListBox);

            // init list
            SportCheckedListBox.Items.Clear();
            m_MySportListProxy.InitList(SportCheckedListBox);
        }

        private void addBth_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_ActivityName))
            {
                SportActivity newSportActivity = new SportActivity(ActivityIsCheckedCheckBox.Checked, m_ActivityName, m_dateTime);
                try
                {
                    // Storage
                    m_MySportListProxy.AddSportActivity(newSportActivity);

                    // UI
                    SportCheckedListBox.Items.Add(newSportActivity);

                    // clear UI
                    NewActivityNameTextBox.Text = string.Empty;
                    ActivityIsCheckedCheckBox.Checked = false;
                    MessageBox.Show("New activity just added :)");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please enter phrase to search", "Missing Input");
            }
        }

        private void addActivity_TextChanged(object sender, EventArgs e)
        {
            m_ActivityName = NewActivityNameTextBox.Text;
        }

        private void dateTimePickerForSport_ValueChanged(object sender, EventArgs e)
        {
            m_dateTime = dateTimePickerForSport.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            m_ActivityIsChecked = ActivityIsCheckedCheckBox.Checked;
        }

        private void sportCheckedListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            sportActivityBindingSource.DataSource = SportCheckedListBox.SelectedItem as SportActivity;
        }

        private void SportIteratorBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Label header = MainOps.CreateNewDefaultLabel("Iterate all of your sport acticity", new Point(0, 50), FeedGroupBox);
            header.Location = new Point(FeedGroupBox.Width / 2 - header.Width / 2, header.Location.Y);
            FeedGroupBox.Controls.Add(header);

            if (m_Iterator == null)
            {
                m_Iterator = (new SportListEnumarable() as IEnumerable).GetEnumerator();
            }

            string currectActivity = (m_Iterator.Current as SportActivity).Name;
            Label label = MainOps.CreateNewDefaultLabel(currectActivity, new Point(), FeedGroupBox);
            label.Location = new Point(FeedGroupBox.Width / 2 - label.Width / 2, header.Location.Y + k_LabelMargin);
            FeedGroupBox.Controls.Add(label);

            string currectDate = (m_Iterator.Current as SportActivity).LimitTime.ToString();
            Label labelDate = MainOps.CreateNewDefaultLabel(currectDate, new Point(), FeedGroupBox);
            labelDate.Location = new Point(label.Location.X, label.Location.Y + k_LabelMargin);
            FeedGroupBox.Controls.Add(labelDate);

            string currectCheckedf = (m_Iterator.Current as SportActivity).Checked.ToString();
            Label labelChecked = MainOps.CreateNewDefaultLabel(currectCheckedf, new Point(), FeedGroupBox);
            labelChecked.Location = new Point(labelDate.Location.X, labelDate.Location.Y + k_LabelMargin);
            FeedGroupBox.Controls.Add(labelChecked);

            Button nextBtn = new Button();
            nextBtn.Text = "Next";
            nextBtn.Location = new Point(labelChecked.Location.X, labelChecked.Location.Y + k_LabelMargin);
            nextBtn.Click += NextClickedHandler;
            FeedGroupBox.Controls.Add(nextBtn);
        }

        private void NextClickedHandler(object sender, EventArgs e)
        {
            if (!m_Iterator.MoveNext())
            {
                m_Iterator.Reset();
            }

            SportIteratorBtn_Click(sender, e);
        }

        private void ElectionsBtn_Click(object sender, EventArgs e)
        {
            Transition();
            FeedGroupBox.Visible = true;
            FeedGroupBox.BackColor = Color.White;

            Label header = MainOps.CreateNewDefaultLabel("Broadcast message to all of your friends by political point of view", new Point(0, 50), FeedGroupBox);
            header.Location = new Point(FeedGroupBox.Width / 2 - header.Width / 2 - 100, header.Location.Y);
            FeedGroupBox.Controls.Add(header);

            Button rightBroadcastBtn = new Button();
            rightBroadcastBtn.Text = "Right message to all";
            rightBroadcastBtn.Click += RightClickedHandler;
            rightBroadcastBtn.Location = new Point(300, 100);
            FeedGroupBox.Controls.Add(rightBroadcastBtn);

            Button leftBroadcastBtn = new Button();
            leftBroadcastBtn.Text = "Left message to all";
            leftBroadcastBtn.Location = new Point(200, 100);
            leftBroadcastBtn.Click += LeftClickedHandler;
            FeedGroupBox.Controls.Add(leftBroadcastBtn);
        }

        private void RightClickedHandler(object sender, EventArgs e)
        {
            BroadcastMessage rightMessage = new RightMessageBroadcast();
            rightMessage.Broadcast();
        }

        private void LeftClickedHandler(object sender, EventArgs e)
        {
            BroadcastMessage leftMessage = new LeftMessageBroadcast();
            leftMessage.Broadcast();
        }

        private void SortAlbums_Click(object sender, EventArgs e)
        {
            Transition();
            try
            {
                Point picLocation = new Point(20, 50);
                Dictionary<int, Album> sortedAlbums = AlbumsOps.SortAlbumsBy();

                AlbumsOps.AddAlbums(picLocation, int.MaxValue, FeedGroupBox, sortedAlbums);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }
    }
}
