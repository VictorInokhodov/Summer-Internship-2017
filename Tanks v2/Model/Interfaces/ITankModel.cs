﻿using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface ITankModel
    {
        void InitializeTank();
        void CreateTank(int x, int y, int size, int speed, int id);
        void Move(Tank tank, int x, int y);
        bool CheckCollision(Tank tank, int x, int y, int width, int height, Ball ball, IEnumerable<Block> blocks);
        bool MoveBullet(int width, int height, Ball ball, IEnumerable<Block> blocks);
        void Shoot();
        IEnumerable<Tank> GetTanks();
    }
}