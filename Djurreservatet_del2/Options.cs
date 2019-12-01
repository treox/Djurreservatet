using System;

namespace Djurreservatet
{
    public class Options
    {
        public void PresentOptions()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("[1] Mata elefant");
            Console.WriteLine("[2] Mata giraff");
            Console.WriteLine("[3] Mata prärievarg");
            Console.WriteLine("[4] Mata säl");
            Console.WriteLine("[5] Mata björn");
            Console.WriteLine("[6] Avsluta");
            Console.WriteLine();
        }
    }
}