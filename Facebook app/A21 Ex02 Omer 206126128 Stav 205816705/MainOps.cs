using System;
using System.Windows.Forms;
using System.Drawing;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class MainOps
    {
        public static Label CreateNewDefaultLabel(string i_text, Point i_Location, GroupBox i_feedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.MaximumSize = new Size(i_feedGroupBox.Width, int.MaxValue);
            tempLabel.Text = i_text;
            tempLabel.Location = i_Location;

            return tempLabel;
        }

        public static Point CalculateNextLabelPosition(Point i_prevPoint)
        {
            return new Point(i_prevPoint.X, i_prevPoint.Y + 50);
        }

        public static Point CalculateNextButtonPosition(Point i_prevPoint, int i_labelWidth)
        {
            return new Point(i_labelWidth + 10, i_prevPoint.Y + MainFeed.LabelMargin);
        }

        public static Label CreateNewDefaultLabel(string i_text, Point i_Location, int i_WidthSize)
        {
            Label tempLabel = new Label();
            tempLabel.AutoSize = true;
            tempLabel.MaximumSize = new Size(i_WidthSize, int.MaxValue);
            tempLabel.Text = i_text;
            tempLabel.Location = i_Location;

            return tempLabel;
        }

        public static void ResetFeedGroupBox(GroupBox i_FeedGroupBox, int i_Width)
        {
            i_FeedGroupBox.Controls.Clear();
            i_FeedGroupBox.Visible = true;
            i_FeedGroupBox.BackColor = Color.Transparent;
            i_FeedGroupBox.Width = i_Width;
            i_FeedGroupBox.MaximumSize = new Size(i_Width, int.MaxValue);
        }

        private static void CreateAndAddToGroupBoxInformationLabel(string i_type, string i_user, Point i_prevPoint, GroupBox i_FeedGroupBox)
        {
            Label tempLabel = new Label();
            tempLabel.Text = i_type + i_user;
            tempLabel.Location = CalculateNextLabelPosition(i_prevPoint);
            tempLabel.AutoSize = true;
            i_FeedGroupBox.Controls.Add(tempLabel);
        }

        public static void CreateNewErrMessage(GroupBox i_feedGroupBox)
        {
            Label errLabel = new Label();
            errLabel.Text = "we can not fecth information";
            errLabel.AutoSize = true;
            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(errLabel)));
        }
    }
}
