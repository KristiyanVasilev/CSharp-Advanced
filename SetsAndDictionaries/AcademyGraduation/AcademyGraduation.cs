namespace AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, double[]>();
            for (int i = 0; i < number; i++)
            {
                var studentName = Console.ReadLine();
                var studentGrades = Console.ReadLine()
                    .Split(new char[] {' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, studentGrades);
                }

            }
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }

        }
    }
}
