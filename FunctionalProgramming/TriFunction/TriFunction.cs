namespace TriFunction
{
    using System;

    public class TriFunction
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;
            foreach (var name in names)
            {
                foreach (var letter in name)
                {
                    sum += letter;
                }
                if (sum >= number)
                {
                    Console.WriteLine(name);
                    return;
                }
                sum = 0;
            }
        }
    }
}
