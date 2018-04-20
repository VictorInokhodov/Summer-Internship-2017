using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Entities
{
    public class Bullet : Interfaces.ICollisionable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public bool IsEnable { get; set; } = false;
        public DateTime wasDisabled { get; set; } = DateTime.Now;
        public Direction Direction;

        public Bullet(int x, int y, int size, int speed)
        {
            PosX = x;
            PosY = y;
            Size = size;
            Speed = speed;
        }
    }
}
