using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppleModel : Interfaces.IAppleModel
    {
        public List<Apple> apples;
        public Random rnd = new Random();

        public void Initialize() => apples = new List<Apple>();

        public void CreateApple(int num, int size, int width, int height, IEnumerable<Block> blocks)
        {
            while (apples.Count<num)
            {
                bool canBePlaced = true;
                
                do
                {
                    canBePlaced = true;

                    apples.Add(new Apple(rnd.Next(width - size), rnd.Next(height - size), size));

                    foreach (Block block in blocks)
                    {
                        if (apples.Count > 0 && Collision.CollisionBox(apples.Last(), block))
                        {
                            canBePlaced = false;
                            apples.Remove(apples.Last());
                        }
                    }

                } while (!canBePlaced);
            }
        }

        public IEnumerable<Apple> GetApples() => apples;

        public bool CheckCollision(Apple apple, Ball ball)
        {
            if (Collision.CollisionBox(ball, apple))
            {
                apples.Remove(apple);
                return true;
            }

            return false;
        }
    }
}