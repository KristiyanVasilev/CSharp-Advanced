namespace LittleJohn
{
    using System;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main()
        {
            var oneArrow = 0;
            var doubleArrow = 0;
            var treeArrow = 0;
            for (int i = 0; i < 4; i++)
            {
                var line = Console.ReadLine();
                var pattern = @">{1,3}-{5}>{1,2}";
                var matches = Regex.Matches(line, pattern);
                foreach (Match match in matches)
                {
                    if (match.ToString().StartsWith(">>>") && match.ToString().EndsWith(">>"))
                    {
                        treeArrow++;
                    }
                    else if (match.ToString().StartsWith(">>"))
                    {
                        doubleArrow++;
                    }
                    else if (match.ToString().StartsWith(">"))
                    {
                        oneArrow++;
                    }
                }
            }
            var sum = string.Concat(oneArrow.ToString(), doubleArrow.ToString(), treeArrow.ToString());

            var sumInBinary = Convert.ToString(int.Parse(sum), 2);
            var reversedSumInBinary = string.Empty;
            for (int i = sumInBinary.Length - 1; i >= 0; i--)
            {
                reversedSumInBinary += sumInBinary[i];
            }
            var result = sumInBinary + reversedSumInBinary;
            var printResult = Convert.ToInt64(result, 2);
            Console.WriteLine(printResult);
        }
    }
}
