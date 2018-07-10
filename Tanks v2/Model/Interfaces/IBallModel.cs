using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IBallModel
    {
        void CreateBall(int x, int y, int size, int speed);
        void Move();
        void CheckCollision(int width, int height, IEnumerable<Block> blocks);
        bool MoveBullet(int width, int height, IEnumerable<Block> blocks, IEnumerable<Tank> tanks);
        void Shoot();
        Ball GetBall();
    }
}