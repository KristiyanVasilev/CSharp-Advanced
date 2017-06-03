namespace PascalTriangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PascalTriangle
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var matrix = new long[number][];

            for (int i = 0; i < number; i++)
            {
                matrix[i] = new long[i + 1];
                matrix[i][0] = 1;
                matrix[i][matrix[i].Length - 1] = 1;

                for (int j = 1; j < matrix[i].Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                 }
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
