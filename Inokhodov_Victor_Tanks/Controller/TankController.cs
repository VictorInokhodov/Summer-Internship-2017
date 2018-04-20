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

            for (int i = 0; i < num; i++)
            {
                tankModel.CreateTank(pointsArray[i].X, pointsArray[i].Y, size, speed);
            }
        }

        public bool MoveTank(int width, int height)
        {
            bool gameOver = false;

            foreach (Entities.Tank tank in TankModel.GetTanks())
            {
                switch (tank.Direction)
                {
                    case Direction.Left:
                        tankModel.Move(tank, -tank.Speed, 0);
                        gameOver = tankModel.CheckCollision(tank, -tank.Speed, 0, width, height);
                        break;

                    case Direction.Up:
                        tankModel.Move(tank, 0, -tank.Speed);
                        gameOver = tankModel.CheckCollision(tank, 0, -tank.Speed, width, height);
                        break;

                    case Direction.Right:
                        tankModel.Move(tank, tank.Speed, 0);
                        gameOver = tankModel.CheckCollision(tank, tank.Speed, 0, width, height);
                        break;

                    case Direction.Down:
                        tankModel.Move(tank, 0, tank.Speed);
                        gameOver = tankModel.CheckCollision(tank, 0, tank.Speed, width, height);
                        break;
                }

                if (gameOver)
                {
                    return gameOver;
                }
            }

            return gameOver;
        }
    }
}
