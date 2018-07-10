using Model;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class TankController
    {
        Model.Interfaces.ITankModel tankModel;

        public void InitializeTanks(int num, int size, IEnumerable<Point> points, int speed)
        {
            tankModel = new Model.TankModel();
            var pointsArray = points.ToArray();

            tankModel.InitializeTank();

            for (int i = 0; i<num; i++)
            {
                tankModel.CreateTank(pointsArray[i].X, pointsArray[i].Y, size, speed, i + 1);
            }
        }

        public bool MoveTank(int width, int height, Ball ball, IEnumerable<Block> blocks)
        {
            bool gameOver = false;

            foreach (Entities.Tank tank in tankModel.GetTanks())
            {
                if (tank.IsEnable)
                {
                    switch (tank.Direction)
                    {
                        case Direction.Left:
                            tankModel.Move(tank, -tank.Speed, 0);
                            gameOver = tankModel.CheckCollision(tank, -tank.Speed, 0, width, height, ball, blocks);
                            break;

                        case Direction.Up:
                            tankModel.Move(tank, 0, -tank.Speed);
                            gameOver = tankModel.CheckCollision(tank, 0, -tank.Speed, width, height, ball, blocks);
                            break;

                        case Direction.Right:
                            tankModel.Move(tank, tank.Speed, 0);
                            gameOver = tankModel.CheckCollision(tank, tank.Speed, 0, width, height, ball, blocks);
                            break;

                        case Direction.Down:
                            tankModel.Move(tank, 0, tank.Speed);
                            gameOver = tankModel.CheckCollision(tank, 0, tank.Speed, width, height, ball, blocks);
                            break;
                    }

                    if (gameOver)
                    {
                        return gameOver;
                    }
                }
            }

            return gameOver;
        }

        public IEnumerable<Tank> GetTanks() => tankModel.GetTanks();

        public void Shoot() => tankModel.Shoot();

        public bool MoveBullets(int width, int height, Ball ball, IEnumerable<Block> blocks) => tankModel.MoveBullet(width, height, ball, blocks);
    }
}