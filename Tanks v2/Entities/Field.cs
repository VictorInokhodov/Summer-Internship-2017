using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Field
    {
        public int Size { get; set; }
        public int NumOfEnemies { get; set; }
        public int NumOfApples { get; set; }
        public int GameSpeed { get; set; }
        public double NumOfBlocks { get; } = 13.0;

        public double BlockSize { get { return Size / NumOfBlocks;  } }

        public Field(int size, int enemies, int apples, int speed)
        {
            Size = size;
            NumOfEnemies = enemies;
            NumOfApples = apples;
            GameSpeed = speed;
        }
    }
}
