using Entities;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BallModel : Interfaces.IBallModel
    {
        static Ball ball;

        public void CreateBall(int x, int y, int size, int speed) => ball = new Ball(x, y, size, speed);

        public static Ball GetBall() => ball;

        public void Move(int x, int y, Direction direction)
        {
            ball.PosX += x;
            ball.PosY += y;
            ball.Direction = direction;
        }

        public void CheckCollision(int x, int y, int width, int height)
        {
            if (Collision.CollisionWithBorders(ball, width, height))
            {
                ball.PosX -= x;
                ball.PosY -= y;
            }

            foreach (ICollisionable block in BlockModel.GetBlocks())
            {
                if (Collision.CollisionBox(ball, block))
                {
                    ball.PosX -= x;
                    ball.PosY -= y;
                }
            }
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

    }
}
