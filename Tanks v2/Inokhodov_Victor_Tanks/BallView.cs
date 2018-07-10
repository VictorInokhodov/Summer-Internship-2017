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
        public static void DrawBall(Ball ball, Graphics flagGraphics, Entities.Image image)
        {
            if (ball.Bullet.IsEnable)
            {
                var bul = ball.Bullet;

                flagGraphics.FillEllipse(Brushes.Black, bul.PosX, bul.PosY, bul.Size, bul.Size);
            }

            switch (ball.Direction)
            {
                case Direction.Left:
                    flagGraphics.DrawImage(image.BallLeft, ball.PosX, ball.PosY, ball.Size, ball.Size);
                    break;

                case Direction.Up:
                    flagGraphics.DrawImage(image.BallUp, ball.PosX, ball.PosY, ball.Size, ball.Size);
                    break;

                case Direction.Right:
                    flagGraphics.DrawImage(image.BallRight, ball.PosX, ball.PosY, ball.Size, ball.Size);
                    break;

                case Direction.Down:
                    flagGraphics.DrawImage(image.BallDown, ball.PosX, ball.PosY, ball.Size, ball.Size);
                    break;
            }

            //flagGraphics.FillRectangle(Brushes.Red, ball.PosX, ball.PosY, ball.Size, ball.Size);
        }
   }
}