namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, int, bool> filter = (x, y) => x % y == 0;
            SelectAndPrint(num, numbers, filter);
        }

        private static void SelectAndPrint(int num, int[] numbers, Func<int, int, bool> filter)
        {
            for (int i = 1; i <= num; i++)
            {
                var hasPassed = true;
                foreach (var devider in numbers)
                {
                    if (!filter(i, devider))
                    {
                        hasPassed = false;
                        break;
                    }                    
                }
                if (hasPassed)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
