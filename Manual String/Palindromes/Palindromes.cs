namespace Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Palindromes
    {
        public static void Main()
        {
            var delimiters = new char[]
           {
                ',','.',' ','?','!'
           };
            var result = new List<string>();
            var input = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var word in input)
            {
                if (getStatus(word))
                {
                    if (!result.Contains(word))
                    {
                        result.Add(word);
                    }
                }
            }
            result.Sort();
            Console.WriteLine("[" + string.Join(", ", result) + "]");
        }
        public static bool getStatus(string myString)
        {
            string first = myString.Substring(0, myString.Length / 2);
            char[] arr = myString.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);
            return first.Equals(second);
        }
    }
}

