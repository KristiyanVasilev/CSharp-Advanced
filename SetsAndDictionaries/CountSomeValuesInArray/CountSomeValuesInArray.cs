namespace CountSomeValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CountSomeValuesInArray
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();                

            var dictionary = new SortedDictionary<double, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                var digit = numbers[i];
                if (!dictionary.ContainsKey(digit))
                {
                    dictionary.Add(digit, 1);
                }
                else
                {
                    dictionary[digit]++;
                }                
            }

            foreach (var digit in dictionary)
            {
                Console.WriteLine($"{digit.Key} - {digit.Value} times");
            }
        }
    }
}
