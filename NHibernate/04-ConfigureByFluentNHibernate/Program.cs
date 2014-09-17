using System;
using GrumpiesHandsOnLabs.Scenarios;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            S01_AutoMapping.Run();
            S02_FluentMapping.Run();

            Console.Write("Press any key to exit...");
            string input = Console.ReadLine();
        }

    }
}
