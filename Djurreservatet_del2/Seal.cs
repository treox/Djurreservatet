using System;

namespace Djurreservatet
{
    public class Seal : Animal
    {
        public int sealDuration;
        public int sealFoodCountMeat;      
        public Seal(string type, string name, int hungerLevel, int animalStart) : base(type, name, hungerLevel, animalStart)
        {

        }

        public override void CheckStatus(int hungerLevel)
        {
            int status = hungerLevel;

            if (status >= 14)
            {
                Console.WriteLine($"{type} {name} behöver få mat.");
            }
            else
            {
                Console.WriteLine($"{type} {name} behöver inte matas.");
            }
            Console.WriteLine($"Matades {status} dagar sedan");
            Console.WriteLine("_______________");
        }
    }
}