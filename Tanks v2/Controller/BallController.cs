using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BallController
    {
        public Model.Interfaces.IBallModel ballModel = new Model.BallModel();

        public void CreateBall(int x, int y, int size, int speed) => ballModel.CreateBall(x, y, size, speed);

        public void MoveBall(int width, int height, IEnumerable<Block> blocks)
        {
            ballModel.Move();
            ballModel.CheckCollision(width, height, blocks);
        }

        public void Shoot() => ballModel.Shoot();

        public Ball GetBall() => ballModel.GetBall();

        public bool MoveBullet(int width, int height, IEnumerable<Block> blocks, IEnumerable<Tank> tanks) => ballModel.MoveBullet(width, height, blocks, tanks);
    }
}