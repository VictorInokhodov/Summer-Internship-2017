using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Inokhodov_Victor_Tanks
{
    class BallView
    {
        public static void DrawBall(Ball ball, Graphics flagGraphics)
        {
            if (ball.Bullet.IsEnable)
            {
                var bul = ball.Bullet;

                flagGraphics.FillEllipse(Brushes.Black, bul.PosX, bul.PosY, bul.Size, bul.Size);
            }

            flagGraphics.FillRectangle(Brushes.Red, ball.PosX, ball.PosY, ball.Size, ball.Size);
        }
   }
}