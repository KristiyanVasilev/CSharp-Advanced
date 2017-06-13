namespace StudentsResults
{
    using System;

    public class StudentsResults
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { '-', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var student = line[0];
                var result1 = double.Parse(line[1]);
                var result2 = double.Parse(line[2]);
                var result3 = double.Parse(line[3]);
                var average = (result1 + result2 + result3) / 3;
                Console.WriteLine(string.Format("{0, -10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", student,
                    result1, result2, result3, average));
            }
        }
    }
}
