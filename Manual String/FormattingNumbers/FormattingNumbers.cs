namespace FormattingNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FormattingNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " ", "\t", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(numbers[0]);
            var b = double.Parse(numbers[1]);
            var c = double.Parse(numbers[2]);
            var binA = Convert.ToString(a, 2);
            if (binA.Length > 10)
            {
                binA = binA.Substring(0, 10);
            }
            Console.WriteLine($"|{a.ToString("X").PadRight(10, ' ')}|{binA.PadLeft(10, '0')}|{b.ToString("f2").PadLeft(10, ' ')}|{c.ToString("f3").PadRight(10, ' ')}|");
        }
    }
}
