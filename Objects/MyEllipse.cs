using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Lab5.Objects
{
    class MyEllipse : BaseObject
    {
        public int Countdown;
        public Action<MyEllipse>? ZeroCountdown;

        public MyEllipse(float x, float y, float angle) : base(x, y, angle) 
        {
            SetRandomCountdown();
        }
        
        public override void Render(Graphics g)
        {
            newCountdown();
            g.FillEllipse(new SolidBrush(Color.YellowGreen), -15, -15, 25, 25);
            g.DrawString($"{Countdown}", new Font("Verdana", 8), new SolidBrush(Color.Green), 10, 10);            
        }
        
        public override GraphicsPath GetGraphicsPath()
        {
            GraphicsPath path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 25, 25);
            return path;
        }

        public void SetRandomCountdown()
        {
            Countdown = Rndm.Next(50, 100);
        }

        private void newCountdown()
        {
            Countdown--;
            if (Countdown == 0)
            {
                ZeroCountdown?.Invoke(this);
            }
        }
    }
}
