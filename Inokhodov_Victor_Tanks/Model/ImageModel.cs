using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class ImageModel
    {
        public static Entities.Image Image;

        public static void LoadImages()
        {
            var dir = Directory.GetCurrentDirectory() + @"/Images";
            Image = new Entities.Image(dir + "/block.png", dir + "/Gold_Block.png",
                dir + "/ball.png", dir + "/tank_up.png", dir + "/tank_down.png",
                dir + "/tank_left.png", dir + "/tank_right.png"); 
        }

        public static Entities.Image GetImages() => Image;
    }
}
