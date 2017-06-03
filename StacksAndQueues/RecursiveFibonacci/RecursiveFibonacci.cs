namespace RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecursiveFibonacci
    {
        private static long[] fibNums;
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            fibNums = new long[number];
            var result = GetFibonacci(number);
            Console.WriteLine(result);
        }

        private static long GetFibonacci(int number)
        {
            if (number <= 2)
            {
                return 1;
            }
            if (fibNums[number - 1] != 0)
            {
                return fibNums[number - 1];
            }
            return fibNums[number - 1] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
