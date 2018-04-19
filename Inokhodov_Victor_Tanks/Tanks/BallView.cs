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
            //flagGraphics.FillEllipse(Brushes.Blue, ball.PosX, ball.PosY, ball.Size, ball.Size);
            flagGraphics.DrawImage(ImageModel.GetImages().Ball, ball.PosX, ball.PosY, ball.Size, ball.Size);
        }
    }
}