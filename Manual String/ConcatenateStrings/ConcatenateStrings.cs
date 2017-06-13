namespace ConcatenateStrings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < lines; i++)
            {
                var str = Console.ReadLine();
                sb.Append(str);
                sb.Append(" ");
            }
            Console.WriteLine(sb);
        }
    }
}
