namespace ParseTags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ParseTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var startUpCase = "<upcase>";
            var endUpCase = "</upcase>";
            var startIndex = text.IndexOf(startUpCase);
            while (startIndex != -1)
            {
                var endIndex = text.IndexOf(endUpCase);
                if (endIndex == -1)
                {
                    break;
                }
                var toBeReplaced = text.Substring(startIndex, endIndex + endUpCase.Length - startIndex);
                var replaced = toBeReplaced.Replace(startUpCase, string.Empty)
                    .Replace(endUpCase, string.Empty)
                    .ToUpper();
                text = text.Replace(toBeReplaced, replaced);
                startIndex = text.IndexOf(startUpCase);
            }
            Console.WriteLine(text);
        }
    }
}
