namespace SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SoftUniParty
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var reservations = new SortedSet<string>();
            while (input != "PARTY")
            {
                reservations.Add(input);
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                if (true)
                {

                }
                reservations.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(reservations.Count());
            foreach (var guest in reservations)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
