using GrumpiesHandsOnLabs.Scenarios;
using System;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            S01_Configured.Run();

            Console.Write("Press any key to exit...");
            string input = Console.ReadLine();
        }

    }
}
