using System;
using System.Windows.Forms;
using System.Drawing;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public class AccountOps
    {
        private static int k_LabelMargin = 50;

        public static void AddAcountInfo(object i_feedGroupBox)
        {
            GroupBox feedGroupBox = (GroupBox)i_feedGroupBox;
            try
            {
                Label header = new Label();
                header.Text = "Information About Your Account";
                header.Location = new Point(0, 20);
                header.AutoSize = true;
                feedGroupBox.Invoke(new Action(() => feedGroupBox.Controls.Add(header)));

                Label line = new Label();
                line.Text = "----------------------------------------------------------";
                line.AutoSize = true;
                line.Location = new Point(0, 30);
                feedGroupBox.Invoke(new Action(() => feedGroupBox.Controls.Add(line)));

                Point LabelLocation = new Point(10, 10);
                Point baseLocation = new Point(10, 10);

                if (LoggedInUserData.User.Name == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Name :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Name :", LoggedInUserData.User.Name, baseLocation, feedGroupBox)));   
                }

                if (LoggedInUserData.User.Email == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Email :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Email :", LoggedInUserData.User.Email, LabelLocation, feedGroupBox)));
                }

                LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

                if (LoggedInUserData.User.Birthday == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Birthday :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Birthday :", LoggedInUserData.User.Birthday, LabelLocation, feedGroupBox)));
                }

                LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

                if (LoggedInUserData.User.Gender == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Gender :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Gender :", LoggedInUserData.User.Gender.ToString(), LabelLocation, feedGroupBox)));
                }

                LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

                if (LoggedInUserData.User.Hometown == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Home Town :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Home Town :", LoggedInUserData.User.Hometown.ToString(), LabelLocation, feedGroupBox)));
                }

                LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

                if (LoggedInUserData.User.Educations == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("Education :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("Education :", LoggedInUserData.User.Educations.ToString(), LabelLocation, feedGroupBox)));
                }

                LabelLocation = new Point(LabelLocation.X, LabelLocation.Y + k_LabelMargin);

                if (LoggedInUserData.User.RelationshipStatus == null)
                {
                    feedGroupBox.Invoke(new Action(() => createAddingButton("RelationshipStatus :", LabelLocation, feedGroupBox)));
                }
                else
                {
                    feedGroupBox.Invoke(new Action(() => createInformationLabel("RelationshipStatus :", LoggedInUserData.User.RelationshipStatus.ToString(), LabelLocation, feedGroupBox)));
                }
            }
            catch (Exception e)
            {
                MainOps.CreateNewErrMessage(feedGroupBox); 
            }
        }

        private static void createInformationLabel(string i_type, string i_user, Point i_prevPoint, GroupBox i_feedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = MainOps.CalculateNextLabelPosition(i_prevPoint);
            tempLabel.AutoSize = true;
            i_feedGroupBox.Controls.Add(tempLabel);
        }

        private static void createAddingButton(string i_type, Point i_prevPoint, GroupBox i_feedGroupBox)
        {
            Button addingButton = new Button();
            addingButton.Text = "Add Information";
            addingButton.BackColor = Color.White;
            addingButton.Visible = true;
            addingButton.AutoSize = true;

            Label tempLabel = new Label();
            tempLabel.Text = i_type;
            tempLabel.Width = 200;
            tempLabel.Location = MainOps.CalculateNextLabelPosition(i_prevPoint);
            addingButton.Location = MainOps.CalculateNextButtonPosition(i_prevPoint, tempLabel.Width);
            i_feedGroupBox.Controls.Add(tempLabel);
            i_feedGroupBox.Controls.Add(addingButton);
        }
    }
}
