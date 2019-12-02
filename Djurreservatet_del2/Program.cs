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
            ConsoleKeyInfo retur;

            int duration;
            int durationIntensity = 5000; // One day is sumulated as duration/durationIntensity.

            Options options = new Options();

            Elephant elephant = new Elephant("Elefant", "Dumbo", 0, 0);
            Giraffe giraffe = new Giraffe("Giraff", "Gustav", 0, 0);
            Coyote coyote = new Coyote("Prärievarg", "Clive", 0, 0);
            Seal seal = new Seal("Säl", "Simon", 0, 0);
            Bear bear = new Bear("Björn", "Yogi", 0, 0);

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
            foreach (Animal animal in animalList)
            {
                animal.animalStart = Environment.TickCount;
            }

            askToFeedQuit:
            Console.Clear();

            options.PresentOptions();
            select = Console.ReadKey();

            duration = Environment.TickCount - start;
            elephant.elephantDuration = Environment.TickCount - elephant.animalStart;
            giraffe.giraffeDuration = Environment.TickCount - giraffe.animalStart;
            coyote.coyoteDuration = Environment.TickCount - coyote.animalStart;
            seal.sealDuration = Environment.TickCount - seal.animalStart;
            bear.bearDuration = Environment.TickCount - bear.animalStart;

            elephant.hungerLevel = elephant.IncreaseHungerLevel(duration, durationIntensity, elephant.elephantDuration);
            giraffe.hungerLevel = giraffe.IncreaseHungerLevel(duration, durationIntensity, giraffe.giraffeDuration);
            coyote.hungerLevel = coyote.IncreaseHungerLevel(duration, durationIntensity, coyote.coyoteDuration);
            seal.hungerLevel = seal.IncreaseHungerLevel(duration, durationIntensity, seal.sealDuration);
            bear.hungerLevel = bear.IncreaseHungerLevel(duration, durationIntensity, bear.bearDuration);

            switch(select.Key)
            {
                case ConsoleKey.D1:
                    elephant.FeedAnimal();
                    goto askToFeedQuit;

                case ConsoleKey.D2:
                    giraffe.FeedAnimal();
                    goto askToFeedQuit;

                case ConsoleKey.D3:
                    coyote.FeedAnimal();
                    goto askToFeedQuit;

                case ConsoleKey.D4:
                    seal.FeedAnimal();
                    goto askToFeedQuit;

                case ConsoleKey.D5:
                    bear.FeedAnimal();
                    goto askToFeedQuit;

                case ConsoleKey.D6:
                    beforeCheckStatus:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"Det är dag {duration/durationIntensity}:");
                    Console.WriteLine("_______________");

                    foreach (Animal animal in animalList)
                    {
                        animal.CheckStatus(animal.hungerLevel);
                    }
                    Console.WriteLine("Vill du gå tillbaka till menyn?");
                    Console.WriteLine("Om ja tryck på [Retur].");
                    retur = Console.ReadKey();
                    if (retur.Key == ConsoleKey.Enter)
                    {
                        goto askToFeedQuit;
                    }
                    else if (retur.Key != ConsoleKey.Enter)
                    {
                        Console.Clear();
                        goto beforeCheckStatus;
                    }
                goto askToFeedQuit; 

                case ConsoleKey.D7:
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
            duration = Environment.TickCount - start;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Det är dag {duration/durationIntensity}:");
            Console.WriteLine("_______________");

            foreach (Animal animal in animalList)
            {
                animal.CheckStatus(animal.hungerLevel);
            }
        }
    }
}

