using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex02_Omer_206126128_Stav_205816705
{
    public abstract class BroadcastMessage
    {
        public void Broadcast()
        {
            ToMiddle();

            if (isUserBroadcastToRight())
            {
                ToRight();
            }

            if (isUserBroadcastToLeft())
            {
                ToLeft();
            }
        }

        private void ToLeft()
        {
            Console.WriteLine("Sent to left");
            MessageBox.Show("Sent to left");
        }

        private void ToMiddle()
        {
            Console.WriteLine("Sent to middle");
            MessageBox.Show("Sent to middle");
        }

        private void ToRight()
        {
            Console.WriteLine("Sent to right");
            MessageBox.Show("Sent to right");
        }

        public abstract bool isUserBroadcastToLeft();

        public abstract bool isUserBroadcastToRight();
    }

    public class RightMessageBroadcast : BroadcastMessage
    {
        public override bool isUserBroadcastToRight()
        {
            return true;
        }

        public override bool isUserBroadcastToLeft()
        {
            return false;
        }
    }

    public class LeftMessageBroadcast : BroadcastMessage
    {
        public override bool isUserBroadcastToRight()
        {
            return false;
        }

        public override bool isUserBroadcastToLeft()
        {
            return true;
        }
    }
}
