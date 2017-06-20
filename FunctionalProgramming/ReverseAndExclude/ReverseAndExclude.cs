namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            Func<int, int, bool> divisible = (x, y) => x % y != 0;

            var numbers = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
                

            var divisibleNum = int.Parse(Console.ReadLine());

            foreach (var number in numbers)
            {
                if (divisible(number, divisibleNum))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
