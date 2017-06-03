namespace UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var logs = new SortedDictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                var line = input.Split(new char[] { '=', '$', ' ' });
                var ip = line[1];
                var message = line[3];
                var user = line[5];
                var count = 0;
                AddUser(logs, user);
                AddIpAddres(logs, user, ip, count);
                input = Console.ReadLine();
            }
            PrintLogs(logs);
        }

        public static void PrintLogs(SortedDictionary<string, Dictionary<string, int>> logs)
        {
            foreach (var person in logs)
            {
                Console.WriteLine($"{person.Key}: ");
                foreach (var item in person.Value)
                {
                    var ipto = item.Key;
                    var count = item.Value;
                    if (ipto != person.Value.Keys.Last())
                    {
                        Console.Write($"{ipto} => {count}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{ipto} => {count}.");
                    }
                }
            }
        }

        public static void AddIpAddres(SortedDictionary<string, Dictionary<string, int>> logs, string user, string ip, int count)
        {
            if (!logs[user].ContainsKey(ip))
            {
                logs[user][ip] = 0;
            }

            logs[user][ip] += 1;
        }

        public static void AddUser(SortedDictionary<string, Dictionary<string, int>> logs, string user)
        {
            if (!logs.ContainsKey(user))
            {
                logs[user] = new Dictionary<string, int>();
            }
        }
    }
}