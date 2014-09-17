using System;
using GrumpiesHandsOnLabs.Scenarios;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            S01_Property.Run();
            S02_PropertyNotUpdatable.Run();
            S03_ValueType.Run();

            Console.Write("Press any key to exit...");
            string input = Console.ReadLine();
        }

    }
}
