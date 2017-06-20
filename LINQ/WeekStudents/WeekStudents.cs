namespace WeekStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeekStudents
    {
        public static void Main()
        {
            var group = new List<string[]>();
            var input = Console.ReadLine();
            while (input != "END")
            {
                group.Add(input.Split());
                input = Console.ReadLine();
            }
            group
                .Where(arr => arr.Skip(2).Count(mark => int.Parse(mark) <= 3) >= 2)
                .ToList()
                .ForEach(arr => Console.WriteLine($"{arr[0]} {arr[1]}"));
        }
    }
}
