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
            var dir = Directory.GetCurrentDirectory() + @"/Image";
            Image = new Entities.Image(dir + "/ball_up.png", dir + "/ball_down.png", dir + "/ball_left.png",
                                        dir + "/ball_right.png", dir + "/tank_up.png", dir + "/tank_down.png",
                                        dir + "/tank_left.png", dir + "/tank_right.png");

        }

        public static Entities.Image GetImages() => Image;
    }
}