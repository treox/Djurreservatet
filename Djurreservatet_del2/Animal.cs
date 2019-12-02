using System;

namespace Djurreservatet
{
    public abstract class Animal
    {
        public string type {get; protected set;}
        public string name {get; protected set;}
        public int hungerLevel {get; set;}
        public int animalStart {get; set;}

        ConsoleKeyInfo feed;

        public Animal(string type, string name, int hungerLevel, int animalStart)
        {
            this.name = name;
            this.type = type;
            this.hungerLevel = hungerLevel;
            this.animalStart = animalStart;
        }
        
        public virtual int IncreaseHungerLevel(int duration, int durationIntensity, int animalDuration)
        {
            int elapsedDays = duration/durationIntensity;
            int daysFeeded = animalDuration/durationIntensity;
            if (elapsedDays == daysFeeded)
            {
                hungerLevel = elapsedDays;   
            }
            else
            {
                int levelDif = elapsedDays - daysFeeded;
                hungerLevel = elapsedDays - levelDif;
            }
            return hungerLevel;
        }

        public virtual void FeedAnimal()
        {
            Console.WriteLine($"Ska {type} {name} matas?");
            Console.WriteLine("Om ja välj [y] eller valfri tangent för att gå vidare.");
            feed = Console.ReadKey();
            switch(feed.Key)
            {
                case ConsoleKey.Y:
                    animalStart = Environment.TickCount;
                    break;
                default:
                    break;
            }
        }

        public abstract void CheckStatus(int hungerLevel);
    }
}