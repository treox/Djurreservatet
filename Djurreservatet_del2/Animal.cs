using System;
using System.Threading;

namespace Djurreservatet
{
    public abstract class Animal
    {
        public string type {get; protected set;}
        public string name {get; protected set;}
        public int hungerLevel {get; set;}
        public int animalStart {get; set;}

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
            Console.WriteLine($"Ska {type} {name} matas...");
            Thread.Sleep(1500);

            animalStart = Environment.TickCount;
        }

        public abstract void CheckStatus(int hungerLevel);
    }
}