using GrumpiesHandsOnLabs.Scenarios;
using System;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            S01_Configured_ConnectionStringInline.Run();
            S02_Configured_ConnectionStringName.Run();

            Console.Write("Press any key to exit...");
            string input = Console.ReadLine();
        }

    }
}
