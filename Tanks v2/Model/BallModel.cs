﻿using Entities;
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
        Ball ball;

        public void CreateBall(int x, int y, int size, int speed) => ball = new Ball(x, y, size, speed);

        public Ball GetBall() => ball;

        public void Move()
        {
            switch (ball.Direction)
            {
                case Direction.Left:
                    ball.PosX -= ball.Speed;
                    break;

                case Direction.Up:
                    ball.PosY -= ball.Speed;
                    break;

                case Direction.Right:
                    ball.PosX += ball.Speed;
                    break;

                case Direction.Down:
                    ball.PosY += ball.Speed;
                    break;
            }
        }

        public bool MoveBullet(int width, int height, IEnumerable<Block> blocks, IEnumerable<Tank> tanks)
        {
            if (ball.Bullet.IsEnable)
            {
                MoveBullet(ball.Bullet);

                if (Collision.CollisionWithBorders(ball.Bullet, width, height))
                {
                    ball.Bullet.IsEnable = false;
                    ball.Bullet.wasDisabled = DateTime.Now;
                }

                foreach (Block block in blocks)
                {
                    if (Collision.CollisionBox(ball.Bullet, block) && block.IsEnabled && block.Name == "b")
                    {
                        ball.Bullet.IsEnable = false;
                        ball.Bullet.wasDisabled = DateTime.Now;
                        block.IsEnabled = false;
                    }
                }

                foreach (Tank tank in tanks)
                {
                    if (Collision.CollisionBox(ball.Bullet, tank) && tank.IsEnable)
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


        public void CheckCollision(int width, int height, IEnumerable<Block> blocks)
        {
            int y = 0, x = 0;

            switch (ball.Direction)
            {
                case Direction.Left:
                    x = -ball.Speed;
                    break;

                case Direction.Up:
                    y = -ball.Speed;
                    break;

                case Direction.Right:
                    x = ball.Speed;
                    break;

                case Direction.Down:
                    y = ball.Speed;
                    break;
            }

            if (Collision.CollisionWithBorders(ball, width, height))
            {
                ball.PosX -= x;
                ball.PosY -= y;
            }

            foreach (Block block in blocks)
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