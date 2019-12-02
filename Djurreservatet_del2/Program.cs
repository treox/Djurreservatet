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
            ConsoleKeyInfo foodChoice;

            int leafCount = 100;
            int meatCount = 50;

            int number;

            int duration;
            int durationIntensity = 5000; // One day is sumulated as duration/durationIntensity.

            Options options = new Options();

            Elephant elephant = new Elephant("Elefant", "Dumbo", 0, 0);
            Giraffe giraffe = new Giraffe("Giraff", "Gustav", 0, 0);
            Coyote coyote = new Coyote("Prärievarg", "Clive", 0, 0);
            Seal seal = new Seal("Säl", "Simon", 0, 0);
            Bear bear = new Bear("Björn", "Yogi", 0, 0);

            Leaf leaf = new Leaf("Leaf");
            Meat meat = new Meat("Meat");

            for (int l = 1; l <= leafCount; l++)
            {
                leaf.leafList.Add(new Leaf($"Leaf{l}"));
            }

            for (int m = 1; m <= meatCount; m++)
            {
                meat.meatList.Add(new Meat($"Meat{m}"));
            }

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
                    number = 10;
                    leaf.DecreaseFoodCount(number);
                    elephant.elephantFoodCountLeaf += number;
                    goto askToFeedQuit;

                case ConsoleKey.D2:
                    giraffe.FeedAnimal();
                    number = 7;
                    leaf.DecreaseFoodCount(number);
                    giraffe.giraffeFoodCountLeaf += number;
                    goto askToFeedQuit;

                case ConsoleKey.D3:
                    coyote.FeedAnimal();
                    number = 5;
                    meat.DecreaseFoodCount(number);
                    coyote.coyoteFoodCountMeat += number;
                    goto askToFeedQuit;

                case ConsoleKey.D4:
                    seal.FeedAnimal();
                    number = 3;
                    meat.DecreaseFoodCount(number);
                    seal.sealFoodCountMeat += number;
                    goto askToFeedQuit;

                case ConsoleKey.D5:
                    bear.FeedAnimal();
                    Console.WriteLine($"Vill du ge {bear.type}en löv eller kött?");
                    Console.WriteLine($"För kött gör val [k].");
                    Console.WriteLine($"För löv gör val [l].");
                    
                    foodChoice = Console.ReadKey();
                    if (foodChoice.Key == ConsoleKey.K)
                    {
                        number = 7;
                        meat.DecreaseFoodCount(number);
                        bear.bearFoodCountMeat += number;
                        goto askToFeedQuit;
                    }
                    else if (foodChoice.Key == ConsoleKey.L)
                    {
                        number = 15;
                        leaf.DecreaseFoodCount(number);
                        bear.bearFoodCountLeaf += number;
                        goto askToFeedQuit;
                    }
                    else if (foodChoice.Key != ConsoleKey.K || foodChoice.Key != ConsoleKey.L)
                    {
                        goto askToFeedQuit;
                    }
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
                    Console.WriteLine("_______________");
                    Console.WriteLine($"{elephant.type} {elephant.name} har fått {elephant.elephantFoodCountLeaf} löv.");
                    Console.WriteLine($"{giraffe.type} {giraffe.name} har fått {giraffe.giraffeFoodCountLeaf} löv.");
                    Console.WriteLine($"{coyote.type} {coyote.name} har fått {coyote.coyoteFoodCountMeat} kött.");
                    Console.WriteLine($"{seal.type} {seal.name} har fått {seal.sealFoodCountMeat} kött.");
                    Console.WriteLine($"{bear.type} {bear.name} har fått {bear.bearFoodCountLeaf} löv.");
                    Console.WriteLine($"{bear.type} {bear.name} har fått {bear.bearFoodCountMeat} kött.");
                    Console.WriteLine("_______________");
                    Console.WriteLine();
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
                    beforeFoodStatus:
                    Console.Clear();
                    Console.WriteLine($"Antal löv i förråd: {leaf.leafList.Count}");
                    Console.WriteLine($"Antal kött i förråd: {meat.meatList.Count}");

                    Console.WriteLine();
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
                        goto beforeFoodStatus;
                    }
                    goto askToFeedQuit;

                case ConsoleKey.D8:
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

            Console.WriteLine("_______________");
            Console.WriteLine($"{elephant.type} {elephant.name} har fått {elephant.elephantFoodCountLeaf} löv.");
            Console.WriteLine($"{giraffe.type} {giraffe.name} har fått {giraffe.giraffeFoodCountLeaf} löv.");
            Console.WriteLine($"{coyote.type} {coyote.name} har fått {coyote.coyoteFoodCountMeat} kött.");
            Console.WriteLine($"{seal.type} {seal.name} har fått {seal.sealFoodCountMeat} kött.");
            Console.WriteLine($"{bear.type} {bear.name} har fått {bear.bearFoodCountLeaf} löv.");
            Console.WriteLine($"{bear.type} {bear.name} har fått {bear.bearFoodCountMeat} kött.");
            Console.WriteLine("_______________");

            Console.WriteLine($"Antal löv i förråd: {leaf.leafList.Count}");
            Console.WriteLine($"Antal kött i förråd: {meat.meatList.Count}");
            Console.WriteLine("_______________");
            Console.WriteLine("SLUT");
        }
    }
}

