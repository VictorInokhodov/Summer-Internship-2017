using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inokhodov_Victor_Tanks
{
    public static class AppleView
    {
        public static void DrawApples(IEnumerable<Apple> apples, Graphics flagGraphics)
        {
            foreach (Apple apple in apples)
            {
                flagGraphics.FillEllipse(Brushes.GreenYellow, apple.PosX, apple.PosY, apple.Size, apple.Size);
            }

        }
    }
}