using System;

namespace Djurreservatet
{
    public class Giraffe : Animal
    {
        public int giraffeDuration;
        public Giraffe(string type, string name, int hungerLevel, int animalStart) : base(type, name, hungerLevel, animalStart)
        {

        }

        public override void CheckStatus(int hungerLevel)
        {
            int status = hungerLevel;

            if (status >= 8)
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