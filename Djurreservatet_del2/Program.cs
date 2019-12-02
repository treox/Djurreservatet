using System;
using System.Collections.Generic;
using System.Threading;

namespace Djurreservatet
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo quit;
            ConsoleKeyInfo select;

            int durationIntensity = 5000; // One day is sumulated as duration/durationIntensity.

            Options options = new Options();

            Elephant elephant = new Elephant("Elefant", "Dumbo", 0);
            Giraffe giraffe = new Giraffe("Giraff", "Gustav", 0);
            Coyote coyote = new Coyote("Prärievarg", "Clive", 0);
            Seal seal = new Seal("Säl", "Simon", 0);
            Bear bear = new Bear("Björn", "Yogi", 0);

            List<Animal> animalList = new List<Animal>();

            animalList.Add(elephant);
            animalList.Add(giraffe);
            animalList.Add(coyote);
            animalList.Add(seal);
            animalList.Add(bear);

            Console.WriteLine();
            Console.WriteLine("Välkommen till djurreservatet!");
            Console.WriteLine("Programmet kollar om djur behöver matas.");
            Thread.Sleep(2000);
            Console.WriteLine();

            int start = Environment.TickCount;

            askToFeedQuit:
            options.PresentOptions();
            select = Console.ReadKey();

            switch(select.Key)
            {
                case ConsoleKey.D1:
                    elephant.FeedAnimal(start, durationIntensity);
                    goto askToFeedQuit;

                case ConsoleKey.D2:
                    giraffe.FeedAnimal(start, durationIntensity);
                    goto askToFeedQuit;

                case ConsoleKey.D3:
                    coyote.FeedAnimal(start, durationIntensity);
                    goto askToFeedQuit;

                case ConsoleKey.D4:
                    seal.FeedAnimal(start, durationIntensity);
                    goto askToFeedQuit;

                case ConsoleKey.D5:
                    bear.FeedAnimal(start, durationIntensity);
                    goto askToFeedQuit;

                case ConsoleKey.D6:
                    Console.WriteLine();
                    Console.WriteLine("Vill du avsluta?");
                    Console.WriteLine("Om ja gör val [y] eller valfri tangent för att mata djuren igen.");
                    quit = Console.ReadKey();
                    switch(quit.Key)
                    {
                        case ConsoleKey.Y:
                            break;
                        default:
                            goto askToFeedQuit;
                    }
                    break;
                default:
                    goto askToFeedQuit;
            }        
            int duration = Environment.TickCount - start;

            int elephantHungerLevel = elephant.IncreaseHungerLevel(duration, durationIntensity);
            int giraffeHungerLevel = giraffe.IncreaseHungerLevel(duration, durationIntensity);
            int coyoteHungerLevel = coyote.IncreaseHungerLevel(duration, durationIntensity);
            int sealHungerLevel = seal.IncreaseHungerLevel(duration, durationIntensity);
            int bearHungerLevel = bear.IncreaseHungerLevel(duration, durationIntensity);

            Console.WriteLine();
            Console.WriteLine($"Det är dag {duration/durationIntensity}:");

            foreach (Animal animal in animalList)
            {
                Console.WriteLine($"Så hungrig är {animal.type}en {animal.name}: {animal.hungerLevel}");
                Console.WriteLine($"{animal.type}en {animal.name} behöver ? äta.");
            }
        }
    }
}

