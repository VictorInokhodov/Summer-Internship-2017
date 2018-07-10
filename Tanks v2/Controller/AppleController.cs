using System;
using Entities;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AppleController
    {
        private Model.Interfaces.IAppleModel appleModel;

        public void Initialize()
        {
            appleModel = new AppleModel();
            appleModel.Initialize();
        }

        public void Add(int num, int size, int width, int height, IEnumerable<Block> blocks)
        {
            appleModel.CreateApple(num, size, width, height, blocks);

        }

        public int CheckCollision(Ball ball)
        {
            int score = 0;
            var apples = appleModel.GetApples();

            for (int i = 0; i<apples.Count(); i++)
            {
                if (appleModel.CheckCollision(apples.ToArray()[i], ball))
                {
                    score++;
                    i--;
                }
            }

            return score;
        }

        public IEnumerable<Apple> GetApples() => appleModel.GetApples();
    }
}