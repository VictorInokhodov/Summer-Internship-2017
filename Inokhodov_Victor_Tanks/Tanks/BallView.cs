using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Tanks
{
    class BallView
    {
        public static void DrawBall(Ball ball, Graphics flagGraphics)
        {
<<<<<<< HEAD
            if (ball.Bullet.IsEnable)
            {
                var bul = ball.Bullet;

                flagGraphics.FillEllipse(Brushes.Black, bul.PosX, bul.PosY, bul.Size, bul.Size);
            }

=======
            //flagGraphics.FillEllipse(Brushes.Blue, ball.PosX, ball.PosY, ball.Size, ball.Size);
>>>>>>> parent of 3bca169... finished Tanks game
            flagGraphics.DrawImage(ImageModel.GetImages().Ball, ball.PosX, ball.PosY, ball.Size, ball.Size);
        }
    }
}