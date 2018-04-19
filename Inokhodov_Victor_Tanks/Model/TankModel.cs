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
        static List<Tank> tanks;
        private static Random rnd = new Random();

        public void InitializeTank() => tanks = new List<Tank>();

        public static IEnumerable<Tank> GetTanks() => tanks;

        public void CreateTank(int x, int y, int size, int speed)
        {
            tanks.Add(new Tank(x, y, size, speed));
        }

        public bool CheckCollision(Tank tank, int x, int y, int width, int height)
        {
            if (Collision.CollisionWithBorders(tank, width, height))
            {
                NewDirection(tank);
                tank.PosX -= x;
                tank.PosY -= y;
            }

            foreach (Block block in BlockModel.GetBlocks())
            {
                if (Collision.CollisionBox(tank, block))
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

            if (Collision.CollisionBox(BallModel.GetBall(), tank))
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

        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
