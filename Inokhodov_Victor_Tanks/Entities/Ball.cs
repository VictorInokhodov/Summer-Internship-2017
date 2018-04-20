using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Ball : Interfaces.ICollisionable
    {
        public int PosX { get; set; }
        public int PosY { get; set; } 
        public int Size { get; private set; }
        public int Speed { get; set; }
        public Direction Direction { get; set; }

        public Ball(int x, int y, int size, int speed)
        {
            PosX = x;
            PosY = y;
            Size = size;
            Speed = speed;
            Direction = Direction.Up;
        }
    }
}
