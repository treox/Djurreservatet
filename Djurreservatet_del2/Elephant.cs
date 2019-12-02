using System;

namespace Djurreservatet
{
    public class Elephant : Animal
    {
        public int elephantDuration;

        public Elephant(string type, string name, int hungerLevel, int animalStart) : base(type, name, hungerLevel, animalStart)
        {

        }

        public override void CheckStatus(int hungerLevel)
        {
            int status = hungerLevel;

            if (status >= 11)
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