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

        public void Add(int num, int size, int width, int height)
        {
            appleModel.CreateApple(num, size, width, height);

        }

        public int CheckCollision()
        {
            int score = 0;
            var apples = AppleModel.GetApples();

            for (int i = 0; i < apples.Count(); i++)
            {
                if (appleModel.CheckCollision(apples.ToArray()[i]))
                {
                    score++;
                    i--;
                }
            }

            return score;
        }
    }
}
