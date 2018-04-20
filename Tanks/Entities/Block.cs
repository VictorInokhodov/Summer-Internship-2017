using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Block : Interfaces.ICollisionable
    {
        public string Name { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public int Size { get; private set; }
        public bool IsEnabled { get; set; } = true;
        public bool CanBeBroken { get; private set; }

        public Block(string name, int x, int y, int size, bool canBeBroken = false)
        {
            Name = name;
            PosX = x;
            PosY = y;
            Size = size;
            CanBeBroken = canBeBroken;
        }
    }
}