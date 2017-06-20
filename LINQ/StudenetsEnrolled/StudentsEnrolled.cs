namespace StudentsEnrolled
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentsEnrolled
    {
        public static void Main()
        {
            var result = new List<Person>();
            var input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split();
                result.Add(new Person(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
                input = Console.ReadLine();
            }

            var students = result.GroupBy(pr => pr.Group)
                .OrderBy(pr => pr.Key);

            foreach (var student in students)
            {
                Console.Write(student.Key + " - ");
                var sb = new StringBuilder();
                foreach (var person in student)
                {
                    sb.Append(person.Name).Append(", ");
                }
                sb.Length -= 2;
                Console.WriteLine(sb);
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }

        public Person(string name, int group)
        {
           this.Name = name;
           this.Group = group;
        }
    }
}
