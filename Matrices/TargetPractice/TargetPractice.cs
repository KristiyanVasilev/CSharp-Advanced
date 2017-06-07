namespace TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TargetPractice
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split();

            var rows = int.Parse(input[0]);
            var cols = int.Parse(input[1]);

            var matrix = new char[rows, cols];
            var snake = Console.ReadLine();
            FillMatrix(rows, cols, matrix, snake);

            var shotTokens = Console.ReadLine().Split(' ');
            var impactRow = int.Parse(shotTokens[0]);
            var impactCol = int.Parse(shotTokens[1]);
            var radius = int.Parse(shotTokens[2]);

            FireShot(matrix, impactRow, impactCol, radius);
             
            for (int col = 0; col < matrix.GetLength(1); col++)
            {

                RunGravity(matrix, col);
            }

            PrintMatrix(matrix);
        }

        private static void RunGravity(char[,] matrix, int col)
        {
            while (true)
            {
                var hasFallen = false;
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    var topChar = matrix[row - 1, col];
                    var currentChar = matrix[row, col];

                    if (currentChar == ' ' && topChar != ' ')
                    {
                        matrix[row, col] = topChar;
                        matrix[row - 1, col] = ' ';
                        hasFallen = true;
                    }
                }
                if (!hasFallen)
                {
                    break;
                }
            }
        }

        private static void FireShot(char[,] matrix, int impactRow, int impactCol, int radius)
        {            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((col - impactCol) * (col - impactCol) + (row - impactRow) * (row - impactRow) <= (radius * radius))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int rows, int cols, char[,] matrix, string snake)
        {
            var isMovingLeft = true;
            var currentIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (isMovingLeft)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentIndex >= snake.Length)
                        {
                            currentIndex = 0;
                        }

                        matrix[row, col] = snake[currentIndex];
                        currentIndex++;
                    }
                }
                isMovingLeft = !isMovingLeft;
            }
        }
    }
}
