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

        public bool MoveBullet(int width, int height)
        {
            if (ball.Bullet.IsEnable)
            {
                MoveBullet(ball.Bullet);

                if (Collision.CollisionWithBorders(ball.Bullet, width, height))
                {
                    ball.Bullet.IsEnable = false;
                    ball.Bullet.wasDisabled = DateTime.Now;
                }

                foreach (Block block in BlockModel.GetBlocks())
                {
                    if (Collision.CollisionBox(ball.Bullet, block) && block.IsEnabled)
                    {
                        ball.Bullet.IsEnable = false;
                        ball.Bullet.wasDisabled = DateTime.Now;

                        if (block.Name == "b")
                        {
                            block.IsEnabled = false;
                        }
                    }
                }

                foreach (Tank tank in TankModel.GetTanks())
                {
                    if (Collision.CollisionBox(ball.Bullet, tank))
                    {
                        ball.Bullet.IsEnable = false;
                        ball.Bullet.wasDisabled = DateTime.Now;
                        tank.IsEnable = false;
                        tank.PosX = -tank.Size;

                        return true;
                    }

                    if (Collision.CollisionBox(ball.Bullet, tank.Bullet))
                    {
                        ball.Bullet.IsEnable = false;
                        tank.Bullet.IsEnable = false;
                        ball.Bullet.wasDisabled = DateTime.Now;
                        tank.Bullet.wasDisabled = DateTime.Now;

                        tank.Bullet.PosX = -tank.Size;
                        ball.Bullet.PosX = -ball.Size;
                    }
                }
            }

            return false;
        }

        private void MoveBullet(Bullet bullet)
        {
            switch (bullet.Direction)
            {
                case Direction.Left:
                    bullet.PosX -= bullet.Speed;
                    break;

                case Direction.Up:
                    bullet.PosY -= bullet.Speed;
                    break;

                case Direction.Right:
                    bullet.PosX += bullet.Speed;
                    break;

                case Direction.Down:
                    bullet.PosY += bullet.Speed;
                    break;
            }
        }


        public void CheckCollision(int x, int y, int width, int height)
        {
            if (Collision.CollisionWithBorders(ball, width, height))
            {
                ball.PosX -= x;
                ball.PosY -= y;
            }

            foreach (Block block in BlockModel.GetBlocks())
            {
                if (Collision.CollisionBox(ball, block) && block.IsEnabled)
                {
                    ball.PosX -= x;
                    ball.PosY -= y;
                }
            }
        }

        public void Shoot()
        {
            if (!ball.Bullet.IsEnable &&
                (DateTime.Now - ball.Bullet.wasDisabled).Milliseconds > 300)
            {
                var bul = ball.Bullet;
                bul.IsEnable = true;
                bul.Direction = ball.Direction;

                switch (bul.Direction)
                {
                    case Direction.Left:
                        bul.PosX = ball.PosX + ball.Size / 2;
                        bul.PosY = ball.PosY + ball.Size / 2 - bul.Size / 2;
                        break;

                    case Direction.Up:
                        bul.PosX = ball.PosX + ball.Size / 2 - bul.Size / 2;
                        bul.PosY = ball.PosY + ball.Size / 2;
                        break;

                    case Direction.Right:
                        bul.PosX = ball.PosX + ball.Size / 2;
                        bul.PosY = ball.PosY + ball.Size / 2 - bul.Size / 2;
                        break;

                    case Direction.Down:
                        bul.PosX = ball.PosX + ball.Size / 2 - bul.Size / 2;
                        bul.PosY = ball.PosY + ball.Size / 2;
                        break;
                }
            }
        }

    }
}