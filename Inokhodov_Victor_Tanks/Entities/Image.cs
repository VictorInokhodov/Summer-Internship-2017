using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Image
    {
        public System.Drawing.Image BBlock { get; private set; }
        public System.Drawing.Image WBlock { get; private set; }
        public System.Drawing.Image BallUp { get; private set; }
        public System.Drawing.Image BallDown { get; private set; }
        public System.Drawing.Image BallRight { get; private set; }
        public System.Drawing.Image BallLeft { get; private  set; }
        public System.Drawing.Image TankDown { get; private set; }
        public System.Drawing.Image TankUp { get; private set; }
        public System.Drawing.Image TankLeft { get; private set; }
        public System.Drawing.Image TankRight { get; private set; }

        public Image(string BPath, string WPath, string ballUp, string ballDown, string ballLeft, string ballRight, 
            string tankUp, string tankDown, string tankLeft, string tankRight)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);

            BallUp = System.Drawing.Image.FromFile(ballUp);
            BallDown = System.Drawing.Image.FromFile(ballDown);
            BallLeft = System.Drawing.Image.FromFile(ballLeft);
            BallRight = System.Drawing.Image.FromFile(ballRight);

            TankDown = System.Drawing.Image.FromFile(tankDown);
            TankUp = System.Drawing.Image.FromFile(tankUp);
            TankLeft = System.Drawing.Image.FromFile(tankLeft);
            TankRight = System.Drawing.Image.FromFile(tankRight);
        }
    }
}
