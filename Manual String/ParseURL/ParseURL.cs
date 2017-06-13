namespace ParseUrl
{
    using System;
    using System.Linq;

    public class ParseUrl
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var tokens = input.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != 2 || tokens[1].IndexOf('/') == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            else
            {
                var protocol = tokens[0];
                var server = tokens[1].Substring(0, tokens[1].IndexOf('/'));
                var resourses = tokens[1].Substring(tokens[1].IndexOf('/') + 1);
                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resourses}");
            }

        }
    }
}
