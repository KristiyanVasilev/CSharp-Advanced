using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortEvenNumber
{
    public class SortEvenNumber
    {
        public static void Main()
        {
            Func<double, double> giveMeSomeVAT = n => n * 1.20;
            Action<double> printNum = n => Console.WriteLine(n);

            var numbers = Console.ReadLine();

                numbers
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n *= 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine("{0:f2}",n));      
        }
    }
}
