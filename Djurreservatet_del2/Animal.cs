using System;

namespace Djurreservatet
{
    public abstract class Animal
    {
        public string type {get; protected set;}
        public string name {get; protected set;}
        public int hungerLevel {get; protected set;}
        ConsoleKeyInfo feed;

        public Animal(string type, string name, int hungerLevel)
        {
            this.name = name;
            this.type = type;
            this.hungerLevel = hungerLevel;
        }
        
        public virtual int IncreaseHungerLevel(int duration, int durationIntensity)
        {
            hungerLevel += duration/durationIntensity;
            return hungerLevel;
        }

        public virtual void FeedAnimal(int start, int durationIntensity)
        {
            int duration = Environment.TickCount - start;

            Console.WriteLine($"Ska {type} {name} matas?");
            Console.WriteLine("Om ja välj [y] eller valfri tangent för att gå vidare.");
            feed = Console.ReadKey();
            switch(feed.Key)
            {
                case ConsoleKey.Y:
                    hungerLevel -= duration/durationIntensity;
                    break;
                default:
                    break;
            }
        }
    }
}