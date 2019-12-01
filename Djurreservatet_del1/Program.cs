using System;
using System.Collections.Generic;

namespace Djurreservatet
{
    class Program
    {
        static void Main(string[] args)
        {
            Elephant elephant = new Elephant("Elephant", "Dumbo");
            Giraffe giraffe = new Giraffe("Giraffe", "Gustav");
            Coyote coyote = new Coyote("Coyote", "Clive");
            Seal seal = new Seal("Seal", "Simon");
            Bear bear = new Bear("Bear", "Yogi");

            List<Animal> animalList = new List<Animal>();

            animalList.Add(elephant);
            animalList.Add(giraffe);
            animalList.Add(coyote);
            animalList.Add(seal);
            animalList.Add(bear);

            Console.WriteLine();
            foreach (Animal animal in animalList)
            {
                Console.WriteLine($"{animal.type}: {animal.name}");
            }
        }
    }
}
