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
    public static class GamesOps
    {
        // Style
        private const int k_PostsMargin = 20;
        private const int k_NumOfGuessingGameQuestions = 5;

        // Values
        private static int m_Score = 0;
        private static int m_GuessingGameQuestionNumber = 1;
        private static List<Button> m_AllGames = new List<Button>();
        private static List<Control> m_GuessingGameControls = new List<Control>();

        public static List<Button> AllGamesBtn
        {
            get
            {
                return m_AllGames;
            }
        }

        public static void AddAllButtunsToConstorls(List<Button> i_Buttons, Control.ControlCollection i_Controls)
        {
            foreach (Button button in i_Buttons)
            {
                i_Controls.Add(button);
            }
        }

        public static void RemoveAllButtunsFromConstorls(List<Button> i_Buttons, Control.ControlCollection i_Controls)
        {
            foreach (Button button in i_Buttons)
            {
                i_Controls.Remove(button);
            }
        }

        public static void NewAgeQuestion(object sender, string i_Question, Point i_BaseLOaction, Control.ControlCollection i_Controls, MainFeed i_MainFeed)
        {
            Label QuestionLabel = MainOps.CreateNewDefaultLabel(i_Question, i_BaseLOaction, MainFeed.DefaultCenterWidth);
            i_Controls.Add(QuestionLabel);
            m_GuessingGameControls.Add(QuestionLabel);

            TextBox answerTextBox = new TextBox();
            answerTextBox.Location = new Point(QuestionLabel.Location.X + QuestionLabel.Width + k_PostsMargin, QuestionLabel.Location.Y);
            i_Controls.Add(answerTextBox);
            m_GuessingGameControls.Add(answerTextBox);

            Button SubmitBtn = new Button();
            SubmitBtn.Text = "Submit";
            SubmitBtn.Location = new Point(answerTextBox.Location.X + answerTextBox.Width + k_PostsMargin, QuestionLabel.Location.Y);
            SubmitBtn.Click += (sender_, EventArgs) => 
            {
                buttonNext_Click(
                    sender,
                    EventArgs,
                    answerTextBox.Text.Equals("45"),
                    new Point(QuestionLabel.Location.X, QuestionLabel.Location.Y + QuestionLabel.Height),
                    i_Controls,
                    i_MainFeed);
            };
            i_Controls.Add(SubmitBtn);
            m_GuessingGameControls.Add(SubmitBtn);
        }

        private static void buttonNext_Click(object sender, EventArgs eventArgs, bool i_IsCorrect, Point i_Location, Control.ControlCollection i_Controls, MainFeed i_MainFeed)
        {
            Label isCorrectLabel = MainOps.CreateNewDefaultLabel(i_IsCorrect.ToString(), i_Location, MainFeed.DefaultCenterWidth);
            i_Controls.Add(isCorrectLabel);
            m_GuessingGameControls.Add(isCorrectLabel);
            isCorrectLabel.BringToFront();

                if (m_GuessingGameQuestionNumber < k_NumOfGuessingGameQuestions)
                {
                    m_GuessingGameQuestionNumber++;
                    m_Score++;

                    /* In this case we need to ranomize a friend and get his birthday - but permission denied
                    * newQuestion(
                                sender,
                                "How old is <RandomUserFriend().FullName>?",
                                new Point(NewPost.Location.X, NewPost.Location.X + k_PostsMargin),
                                this);
                    */

                    NewAgeQuestion(
                        sender,
                        "How old is Guy Ronen",
                        new Point(i_Location.X, i_Location.Y + k_PostsMargin),
                        i_Controls,
                        i_MainFeed);
                }
                else
                {
                    m_GuessingGameQuestionNumber = 1;
                    m_Score++;
                    RemoveAllGuessingGameControls(i_Controls);
                    i_MainFeed.GamesBtn_Click(new object(), new EventArgs());
                }
        }

        public static void RemoveAllGuessingGameControls(Control.ControlCollection i_Controls)
        {
            foreach (Control control in m_AllGames)
            {
                i_Controls.Remove(control);
            }

            foreach (Control control in m_GuessingGameControls)
            {
                i_Controls.Remove(control);
            }
        }
    }
}
