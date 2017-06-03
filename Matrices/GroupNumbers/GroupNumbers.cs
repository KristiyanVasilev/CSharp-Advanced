namespace GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GroupNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var zero = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var first = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var second = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
