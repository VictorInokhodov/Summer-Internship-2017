using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Collision
    {
        public static bool CheckCollision(int x1, int y1, int size1, int x2, int y2, int size2)
        {
            if(x1 > x2 - size1 && x1<x2 + size2 &&
                y1> y2 - size1 && y1<y2 + size2)
            {
                return true;
            }

            return false;
        }

        public static bool CollisionBox(Interfaces.ICollisionable obj1, Interfaces.ICollisionable obj2)
        {
            return CheckCollision(obj1.PosX, obj1.PosY, obj1.Size, obj2.PosX, obj2.PosY, obj2.Size);
        }
        public static bool CollisionWithBorders(Interfaces.ICollisionable obj, int width, int height)
        {
            if (obj.PosX< 0 || obj.PosX> width - obj.Size ||
                obj.PosY< 0 || obj.PosY> height - obj.Size)
            {
                return true;
            }

            return false;
        }
            
    }
}
