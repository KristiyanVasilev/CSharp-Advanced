namespace MaxSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MaxSum
    {
        public static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new int[tokens[0], tokens[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine()
               .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var maxSum = 0;
            var resultMatrix = new int[3, 3];

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        for (int i = 0; i < resultMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < resultMatrix.GetLength(1); j++)
                            {
                                resultMatrix[i, j] = matrix[row + i, col + j];
                            }
                        }
                    }

                }
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");                    
                }
                Console.WriteLine();
            }

        }
    }
}
