namespace SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SpecialWords
    {
        public static void Main()
        {
            var separators = new char[]
            {
                '(', ')', '[', ']', '<', '>', ',', '-',
                '!', '?', ' '
            };

            var specialWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var words = new Dictionary<string, int>();
            foreach (var word in specialWords)
            {
                words[word] = 0;
            }
            foreach (var specialWord in text)
            {
                if (words.ContainsKey(specialWord))
                {
                    words[specialWord]++;
                }
            }
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }           
        }
    }
}
