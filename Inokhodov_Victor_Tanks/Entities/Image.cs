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
        public System.Drawing.Image Ball { get; private set; }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public System.Drawing.Image TankDown { get; private set; }
        public System.Drawing.Image TankUp { get; private set; }
        public System.Drawing.Image TankLeft { get; private set; }
        public System.Drawing.Image TankRight { get; private set; }

        public Image(string BPath, string WPath, string ball,
            string tankUp, string tankDown, string tankLeft, string tankRight)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);

            Ball = System.Drawing.Image.FromFile(ball);

            TankDown = System.Drawing.Image.FromFile(tankDown);
            TankUp = System.Drawing.Image.FromFile(tankUp);
            TankLeft = System.Drawing.Image.FromFile(tankLeft);
            TankRight = System.Drawing.Image.FromFile(tankRight);
=======
        public System.Drawing.Image Tank { get; private set; }

        public Image(string BPath, string WPath, string BallPath, string TankPath)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);
            Ball = System.Drawing.Image.FromFile(BallPath);
            Tank = System.Drawing.Image.FromFile(TankPath);
>>>>>>> parent of 3bca169... finished Tanks game
=======
        public System.Drawing.Image Tank { get; private set; }

        public Image(string BPath, string WPath, string BallPath, string TankPath)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);
            Ball = System.Drawing.Image.FromFile(BallPath);
            Tank = System.Drawing.Image.FromFile(TankPath);
>>>>>>> parent of 3bca169... finished Tanks game
=======
        public System.Drawing.Image Tank { get; private set; }

        public Image(string BPath, string WPath, string BallPath, string TankPath)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);
            Ball = System.Drawing.Image.FromFile(BallPath);
            Tank = System.Drawing.Image.FromFile(TankPath);
>>>>>>> parent of 3bca169... finished Tanks game
=======
        public System.Drawing.Image Tank { get; private set; }

        public Image(string BPath, string WPath, string BallPath, string TankPath)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);
            Ball = System.Drawing.Image.FromFile(BallPath);
            Tank = System.Drawing.Image.FromFile(TankPath);
>>>>>>> parent of 3bca169... finished Tanks game
        }
    }
}
