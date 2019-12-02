using System;

namespace Djurreservatet
{
    public class Coyote : Animal
    {
        public int coyoteDuration;
        public int coyoteFoodCountMeat;

        public Coyote(string type, string name, int hungerLevel, int animalStart) : base(type, name, hungerLevel, animalStart)
        {

        }

        public override void CheckStatus(int hungerLevel)
        {
            int status = hungerLevel;

            if (status >= 16)
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