using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
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
                    System.Drawing.Image img = ImageModel.GetImages().TankDown;

                    switch (tank.Direction)
                    {
                        case Direction.Down:
                            img = ImageModel.GetImages().TankDown;
                            break;

                        case Direction.Left:
                            img = ImageModel.GetImages().TankLeft;
                            break;

                        case Direction.Right:
                            img = ImageModel.GetImages().TankRight;
                            break;

                        case Direction.Up:
                            img = ImageModel.GetImages().TankUp;
                            break;
                    }

                    flagGraphics.DrawImage(img, tank.PosX, tank.PosY, tank.Size, tank.Size);
                }
            }
        }
    }
}
