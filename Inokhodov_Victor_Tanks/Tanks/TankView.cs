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
                flagGraphics.DrawImage(ImageModel.GetImages().Tank, tank.PosX, tank.PosY, tank.Size, tank.Size);
            }
        }
    }
}
