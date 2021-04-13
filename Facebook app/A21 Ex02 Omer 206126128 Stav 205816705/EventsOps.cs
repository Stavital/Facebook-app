using System;
using System.Windows.Forms;
using System.Drawing;
using FacebookWrapper.ObjectModel;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public static class EventsOps
    {
        private const int k_PostProfilePictureSize = 55;

        public static void AddEvents(GroupBox i_feedGroupBox)
        {
            try
            {
                Label header = new Label();
                header.Text = "Your Events";
                header.Size = new System.Drawing.Size(50, 27);
                header.AutoSize = true;
                header.ForeColor = Color.Blue;
                header.Location = new Point(20, 20);
                i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(header)));

                if (LoggedInUserData.User.Events.Count == 0)
                {
                    MessageBox.Show("No events on your Facebook account");
                }

                foreach (Event myEvent in LoggedInUserData.User.Events)
                {
                    addNewEvent(myEvent, i_feedGroupBox);
                    addPicture(myEvent, i_feedGroupBox);
                }
            }
            catch (Exception e)
            {
                Label errLabel = new Label();
                errLabel.Text = "we can not fecth information";
                errLabel.AutoSize = true;
                i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(errLabel)));
            }
        }

        private static void addNewEvent(Event i_newEvent, GroupBox i_feedGroupBox)
        {
            Point LabelLocation = new Point(10, 10);

            Label eventLabel = new Label();
            string eventName = i_newEvent.Name;
            string eventTime = i_newEvent.StartTime.ToString();
            long attendingCount = (long)i_newEvent.AttendingCount;
            string newEvent = string.Format("Event: {0}\n start at: {1}\n attending: {2}\n", eventName, eventTime, attendingCount);

            eventLabel.Text = newEvent;
            eventLabel.AutoSize = true;
            eventLabel.Location = MainOps.CalculateNextLabelPosition(LabelLocation);
            eventLabel.Visible = true;

            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(eventLabel)));
        }

        private static void addPicture(Event i_newEvent, GroupBox i_feedGroupBox)
        {
            PictureBox eventPicture = new PictureBox();
            Point LabelLocation = new Point(10, 10);

            eventPicture.Image = Properties.Resources.Facebook_1_Cake;
            eventPicture.Visible = true;
            eventPicture.SizeMode = PictureBoxSizeMode.Zoom;
            eventPicture.Location = MainOps.CalculateNextButtonPosition(LabelLocation, 100);
            eventPicture.MaximumSize = new Size(new Point(k_PostProfilePictureSize + 20, k_PostProfilePictureSize + 20));
            i_feedGroupBox.Invoke(new Action(() => i_feedGroupBox.Controls.Add(eventPicture)));
        }
    }
}
