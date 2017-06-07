namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            using (var wordsReader = new StreamReader("../../words.txt"))
            {
                var words = wordsReader
               .ReadToEnd()
               .ToLower()
               .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                using (var textReader = new StreamReader("../../text.txt"))
                {
                    var wordsFromText = textReader
                        .ReadToEnd()
                        .ToLower()
                        .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    using (var writer = new StreamWriter("../../result.txt"))
                    {
                        var results = new Dictionary<string, int>();
                        for (int i = 0; i < words.Length; i++)
                        {
                            int counter = 0;
                            for (int j = 0; j < wordsFromText.Length; j++)
                            {
                                if (wordsFromText[j].Contains(words[i]))
                                {
                                    counter++;
                                }
                            }
                            if (results.ContainsKey(words[i]))
                            {
                                results[words[i]] += counter;
                            }
                            else
                            {
                                results.Add(words[i], counter);
                            }
                        }
                        foreach (var word in results.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
