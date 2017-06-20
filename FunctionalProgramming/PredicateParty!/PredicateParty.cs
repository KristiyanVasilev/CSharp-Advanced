namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PredicateParty
    {
        public static void Main()
        {
            var guests = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var commands = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Party!")
            {
                switch (commands[0])
                {
                    case "Remove":
                        switch (commands[1])
                        {
                            case "StartsWith":
                                var startString = commands[2];
                                Predicate<string> filterStartName = x => x.StartsWith(startString);
                                guests.RemoveAll(filterStartName);
                                break;

                            case "EndsWith":
                                var endString = commands[2];
                                Predicate<string> filterEndName = x => x.EndsWith(endString);
                                guests.RemoveAll(filterEndName);
                                break;
                            case "Length":
                                var lenghtName = int.Parse(commands[2]);
                                Predicate<string> filterLenghtName = x => x.Length == lenghtName;
                                guests.RemoveAll(filterLenghtName);
                                break;
                        }
                        break;
                    case "Double":
                        switch (commands[1])
                        {
                            case "StartsWith":
                                var startString = commands[2];
                                Func<string, bool> filterStartName = x => x.StartsWith(startString);
                                var matches = new List<string>();
                                matches = guests.Where(filterStartName).ToList();
                                guests.AddRange(matches);
                                break;

                            case "EndsWith":
                                var endString = commands[2];
                                Predicate<string> filterEndName = x => x.EndsWith(endString);
                                matches = guests.FindAll(filterEndName);
                                guests.AddRange(matches);
                                break;
                            case "Length":
                                var lenghtName = int.Parse(commands[2]);
                                Func<string, bool> filterLenghtName = x => x.Length == lenghtName;
                                matches = guests.Where(filterLenghtName).ToList();
                                foreach (var match in matches)
                                {
                                    var index = guests.LastIndexOf(match);
                                    guests.Insert(index, match);
                                }                        
                                break;
                        }
                        break;
                }
                commands = Console.ReadLine()
                    .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (!guests.Any())
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
        }
    }
}
