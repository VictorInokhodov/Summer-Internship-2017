using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IAppleModel
    {
        void Initialize();
        void CreateApple(int num, int size, int width, int height, IEnumerable<Block> blocks);
        bool CheckCollision(Apple apple, Ball ball);
        IEnumerable<Apple> GetApples();
    }
}