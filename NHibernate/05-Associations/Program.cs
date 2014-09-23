using System;
using GrumpiesHandsOnLabs.Scenarios;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Scenario to run? Ex: 1, 2 , 91... ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        S01_Simple.Run();
                        break;

                    case "2":
                        S02_PropertyNotUpdatable.Run();
                        break;

                    default:
                        Console.WriteLine("Not Valid");
                        break;
                }
            }   
        }

    }
}
