using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BallDataGridView
    {
        public int Id { get; set; } = 1;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Score { get; set; }

        public BallDataGridView(Ball ball, int score)
        {
            Score = score;
            PosX = ball.PosX;
            PosY = ball.PosY;
        }
    }
}
