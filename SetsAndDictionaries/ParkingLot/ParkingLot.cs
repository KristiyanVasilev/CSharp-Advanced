namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var tokens = Regex.Split(input, ", ");
                var direction = tokens[0];
                var carNumber = tokens[1];

                if (direction == "IN")
                {
                    parking.Add(carNumber);
                }
                else
                {
                    if (parking.Contains(carNumber))
                    {
                        parking.Remove(carNumber);
                    }                    
                }           

                input = Console.ReadLine();
            }
            if (parking.Count() != 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }            
        }
    }
}
