namespace RubiksCube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RubiksCube
    {
        public static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = tokens[0];
            var cols = tokens[1];
            var matrix = new int[rows][];
            var num = 0;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    num++;
                    matrix[row][col] = num;
                }
            }

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine().Split();
                var index = int.Parse(line[0]);
                var direction = line[1];
                var moves = int.Parse(line[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, index, moves);
                        break;
                    case "down":
                        MoveCol(matrix, index, matrix.Length - moves);
                        break;
                    case "left":
                        MoveRow(matrix, index, moves);
                        break;
                    case "right":
                        MoveRow(matrix, index, matrix[0].Length - moves);
                        break;
                }
            }

            var element = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            for (int j = 0; j < matrix[0].Length; j++)
                            {
                                if (matrix[i][j] == element)
                                {
                                    var currentElement = matrix[row][col];
                                    matrix[row][col] = element;
                                    matrix[i][j] = currentElement;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int index, int moves)
        {
            var temp = new int[matrix[0].Length];
            for (int i = 0; i < matrix[0].Length; i++)
            {
                temp[i] = matrix[index][(i + moves) % matrix[0].Length];
            }
            matrix[index] = temp; 

        }

        private static void MoveCol(int[][] matrix, int index, int moves)
        {
            var temp = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                temp[i] = matrix[(i + moves) % matrix.Length][index];
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][index] = temp[i];
            }
        }
    }
}






