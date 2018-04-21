using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inokhodov_Victor_Tanks
{
    public class TankView
    {
        public static void DrawTanks(IEnumerable<Tank> tanks, Graphics flagGraphics)
        {
            foreach (Tank tank in tanks)
            {
                if (tank.Bullet.IsEnable)
                {
                    var bul = tank.Bullet;

                    flagGraphics.FillEllipse(Brushes.Black, bul.PosX, bul.PosY, bul.Size, bul.Size);
                }
                if (tank.IsEnable)
                {
                    flagGraphics.FillRectangle(Brushes.Blue, tank.PosX, tank.PosY, tank.Size, tank.Size);
                }
            }
        }
    }
}