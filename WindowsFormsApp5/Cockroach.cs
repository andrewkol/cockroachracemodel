using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp5
{
    class Cockroach
    {
        private int currentX, currentY, radius, startX, range, speed, Time_of_Finish;
        Color BugColor;
        Rectangle currentPosition;
        public Cockroach(int startX, int startY, int range)
        {
            this.currentX = startX;
            this.currentY = startY;
            this.startX = startX;
            radius = 30;
            this.range = range;
            BugColor = Color.FromArgb(Util.GetRandom(0, 255), Util.GetRandom(0, 255), Util.GetRandom(0, 255));
            speed = Util.GetRandom(1, 30);
            currentPosition = new Rectangle(startX - radius, startY - radius, radius, radius);
            Time_of_Finish = 0;
        }
        public int Speed { get { return speed; } set { speed = value; } }
        public int _Time_of_Finish { get { return Time_of_Finish; } }
        public Graphics Draw(Graphics graf)
        {
            graf.FillEllipse(new SolidBrush(BugColor), currentPosition);
            return graf;
        }
        public void Move(int currentTime)
        {
            if (currentX < (range + startX))
            {
                if(Util.GetRandom(1,20) > 15)
                    ReSpeed();
                currentX += speed;
                Rerectangle();
            }
            else
            {
                speed = 0;
                currentX = 1020;
                Rerectangle();
                Time_of_Finish = currentTime;
            }
        }
        private void Rerectangle()
        {
            currentPosition.X = currentX;
        }
        private void ReSpeed()
        {
            if(Util.GetRandom(0, 20) > 10)
            {
                speed += Util.GetRandom(1, 5);
            }
            else
                if(speed - 5 > 0 )
                    speed -= Util.GetRandom(1, 5);
        }
    }
}
