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
        public System.Drawing.Image Tank { get; private set; }

        public Image(string BPath, string WPath, string BallPath, string TankPath)
        {
            BBlock = System.Drawing.Image.FromFile(BPath);
            WBlock = System.Drawing.Image.FromFile(WPath);
            Ball = System.Drawing.Image.FromFile(BallPath);
            Tank = System.Drawing.Image.FromFile(TankPath);
        }
    }
}
