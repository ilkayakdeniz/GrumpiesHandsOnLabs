using System;
using GrumpiesHandsOnLabs.Scenarios;

namespace GrumpiesHandsOnLabs
{
    class Program
    {
        private static void Main(string[] args)
        {
            //S01_Property.Run();
            //S02_PropertyNotUpdatable.Run();
            //S03_ValueType.Run();
            //S04_unidirectional_many_to_one_insert.Run();
            //S05_unidirectional_many_to_one_update.Run();
            //S06_unidirectional_one_to_many_insert.Run();
            //S061_unidirectional_one_to_many_insert.Run();
            //S07_unidirectional_one_to_many_update.Run();
            //S08_bidirectional_references_side.Run();
            S09_bidirectional_has_many_side.Run();
            //S091_bidirectional_has_many_side.Run();
            //S092_bidirectional_has_many_side.Run();
            //S093_bidirectional_has_many_side.Run();

            Console.Write("Press any key to exit...");
            string input = Console.ReadLine();
        }

    }
}
