using System;

namespace Djurreservatet
{
    public abstract class Animal
    {
        public string type {get; protected set;}
        public string name {get; protected set;}
        public int hungerLevel {get; protected set;}

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

        public abstract void FeedAnimal();
    }
}