namespace CharacterMultiplier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            var strings = Console.ReadLine()
                .Split(new char[] { '\r', '\t', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var first = strings[0];
            var second = strings[1];
            Multiply(first, second);
        }

        private static void Multiply(string first, string second)
        {
            var sum = 0;
            var min = Math.Min(first.Length, second.Length);
            for (int i = 0; i < min; i++)
            {
                sum += first[i] * second[i];
            }

            if (first.Length != second.Length)
            {
                var max = Math.Max(first.Length, second.Length);
                if (first.Length > second.Length)
                {
                    for (int i = min; i < max; i++)
                    {
                        sum += first[i];
                    }
                }
                else
                {
                    for (int i = min; i < max; i++)
                    {
                        sum += second[i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
