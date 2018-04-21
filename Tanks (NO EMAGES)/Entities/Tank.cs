using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tank : Interfaces.ICollisionable
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Size { get; private set; }
        public int Speed { get; private set; }
        public bool IsEnable { get; set; } = true;
        public Bullet Bullet;
        public Direction Direction;

        public Tank(int x, int y, int size, int speed)
        {
            PosX = x;
            PosY = y;
            Size = size;
            Speed = speed;
            Bullet = new Bullet(0, 0, size / 3, speed + 2);
            Direction = Direction.Down;
        }
    }
}