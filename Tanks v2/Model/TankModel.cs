using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Interfaces;

namespace Model
{
    public class TankModel : Interfaces.ITankModel
    {
        List<Tank> tanks;
        private Random rnd = new Random();

        public void InitializeTank() => tanks = new List<Tank>();

        public IEnumerable<Tank> GetTanks() => tanks;

        public void CreateTank(int x, int y, int size, int speed, int id)
        {
            tanks.Add(new Tank(x, y, size, speed, id));
        }

        public bool CheckCollision(Tank tank, int x, int y, int width, int height, Ball ball, IEnumerable<Block> blocks)
        {
            if (Collision.CollisionWithBorders(tank, width, height))
            {
                NewDirection(tank);
                tank.PosX -= x;
                tank.PosY -= y;
            }

            foreach (Block block in blocks)
            {
                if (Collision.CollisionBox(tank, block) && block.IsEnabled)
                {
                    NewDirection(tank);
                    tank.PosX -= x;
                    tank.PosY -= y;
                }
            }

            foreach (Tank el in tanks)
            {
                if (el != tank && Collision.CollisionBox(tank, el))
                {
                    tank.PosX -= x;
                    tank.PosY -= y;

                    switch (tank.Direction)
                    {
                        case Direction.Left:
                            tank.Direction = Direction.Right;
                            break;

                        case Direction.Up:
                            tank.Direction = Direction.Down;
                            break;

                        case Direction.Right:
                            tank.Direction = Direction.Left;
                            break;

                        case Direction.Down:
                            tank.Direction = Direction.Up;
                            break;
                    }
                }
            }

            if (Collision.CollisionBox(ball, tank))
            {
                return true;
            }

            return false;
        }

        private void NewDirection(Tank tank)
        {
            switch (rnd.Next(4))
            {
                case 0:
                    tank.Direction = Direction.Left;
                    break;

                case 1:
                    tank.Direction = Direction.Up;
                    break;

                case 2:
                    tank.Direction = Direction.Right;
                    break;

                case 3:
                    tank.Direction = Direction.Down;
                    break;
            }
        }

        public void Move(Tank tank, int x, int y)
        {
            tank.PosX += x;
            tank.PosY += y;
        }

        public bool MoveBullet(int width, int height, Ball ball, IEnumerable<Block> blocks)
        {
            foreach (Tank tank in tanks)
            {
                if (tank.Bullet.IsEnable)
                {
                    MoveBullet(tank, tank.Bullet);

                    if (Collision.CollisionWithBorders(tank.Bullet, width, height))
                    {
                        tank.Bullet.IsEnable = false;
                        tank.Bullet.PosX = -tank.Size;
                        tank.Bullet.wasDisabled = DateTime.Now;
                    }

                    if (Collision.CollisionBox(tank.Bullet, ball))
                    {
                        return true;
                    }

                    foreach (Block block in blocks)
                    {
                        if (Collision.CollisionBox(tank.Bullet, block) && block.IsEnabled)
                        {
                            tank.Bullet.IsEnable = false;
                            tank.Bullet.PosX = -tank.Size;
                            tank.Bullet.wasDisabled = DateTime.Now;

                            if (block.Name == "b")
                            {
                                block.IsEnabled = false;
                            }
                        }
                    }

                    foreach (Tank el in tanks)
                    {
                        if (el != tank)
                        {
                            if (Collision.CollisionBox(tank.Bullet, el))
                            {
                                tank.Bullet.IsEnable = false;
                                tank.Bullet.PosX = -tank.Size;
                                tank.Bullet.wasDisabled = DateTime.Now;
                            }

                            if (Collision.CollisionBox(tank.Bullet, el.Bullet))
                            {
                                tank.Bullet.IsEnable = false;
                                tank.Bullet.PosX = -tank.Size;
                                el.Bullet.IsEnable = false;
                                el.Bullet.PosX = -el.Size;
                                tank.Bullet.wasDisabled = DateTime.Now;
                                el.Bullet.wasDisabled = DateTime.Now;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void MoveBullet(Tank tank, Bullet bullet)
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


        public void Shoot()
        {
            foreach (Tank tank in tanks)
            {
                if (!tank.Bullet.IsEnable && tank.IsEnable && 
                    (DateTime.Now - tank.Bullet.wasDisabled).Milliseconds > 900)
                {
                    var bul = tank.Bullet;
                    bul.IsEnable = true;
                    bul.Direction = tank.Direction;

                    switch (bul.Direction)
                    {
                        case Direction.Left:
                            bul.PosX = tank.PosX + tank.Size / 2;
                            bul.PosY = tank.PosY + tank.Size / 2 - bul.Size / 2;
                            break;

                        case Direction.Up:
                            bul.PosX = tank.PosX + tank.Size / 2 - bul.Size / 2;
                            bul.PosY = tank.PosY + tank.Size / 2;
                            break;

                        case Direction.Right:
                            bul.PosX = tank.PosX + tank.Size / 2;
                            bul.PosY = tank.PosY + tank.Size / 2 - bul.Size / 2;
                            break;

                        case Direction.Down:
                            bul.PosX = tank.PosX + tank.Size / 2 - bul.Size / 2;
                            bul.PosY = tank.PosY + tank.Size / 2;
                            break;
                    }
                }
            }
        }
    }
}