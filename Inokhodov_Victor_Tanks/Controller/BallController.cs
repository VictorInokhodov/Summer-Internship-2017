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
        Model.Interfaces.IBallModel ballModel = new Model.BallModel();

        public void CreateBall(int x, int y, int size, int speed) => ballModel.CreateBall(x, y, size, speed);
        public void MoveBall(int x, int y, int width, int height, Direction direction)
        {
            ballModel.Move(x, y, direction);
            ballModel.CheckCollision(x, y, width, height);
        }
    }
}
