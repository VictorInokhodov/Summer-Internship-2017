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
        void Move(int x, int y, Direction direction);
        void CheckCollision(int x, int y, int width, int height);
        void Shoot();
    }
}
