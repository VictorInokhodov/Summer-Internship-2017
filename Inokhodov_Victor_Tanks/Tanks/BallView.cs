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
            if (ball.Bullet.IsEnable)
            {
                var bul = ball.Bullet;

                flagGraphics.FillEllipse(Brushes.Black, bul.PosX, bul.PosY, bul.Size, bul.Size);
            }

            System.Drawing.Image img = ImageModel.GetImages().BallUp;

            switch (ball.Direction)
            {
                case Direction.Down:
                    img = ImageModel.GetImages().BallDown;
                    break;

                case Direction.Left:
                    img = ImageModel.GetImages().BallLeft;
                    break;

                case Direction.Right:
                    img = ImageModel.GetImages().BallRight;
                    break;

                case Direction.Up:
                    img = ImageModel.GetImages().BallUp;
                    break;
            }

            //flagGraphics.FillEllipse(Brushes.Blue, ball.PosX, ball.PosY, ball.Size, ball.Size);
            flagGraphics.DrawImage(img, ball.PosX, ball.PosY, ball.Size, ball.Size);
        }
    }
}