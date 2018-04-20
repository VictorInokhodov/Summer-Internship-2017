using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Apple : Interfaces.ICollisionable
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Size { get; private set; }

        public Apple(int x, int y, int size)
        {
            PosX = x;
            PosY = y;
            Size = size;
        }
    }
}
