namespace DiagonalDifference
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var matrix = new int[num][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();               
            }

            var firstSum = 0;
            var secondSum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                firstSum += matrix[i][i];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                secondSum += matrix[row][matrix[row].Length - 1 - row];
            }           
            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
