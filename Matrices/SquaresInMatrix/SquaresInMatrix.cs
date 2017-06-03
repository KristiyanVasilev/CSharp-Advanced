namespace SquaresInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var matrix = new char[tokens[0], tokens[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine()
               .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(char.Parse)                        
               .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var matches = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSymbol = matrix[row, col];
                    var nextSymbol = matrix[row, col + 1];
                    if (currentSymbol == nextSymbol)
                    {
                        var nextLineOne = matrix[row + 1, col];
                        var nextLineTwo = matrix[row + 1, col + 1];
                        if (currentSymbol == nextLineOne && currentSymbol == nextLineTwo)
                        {
                            matches++;
                        }
                    }
                }
            }

            Console.WriteLine(matches);
        }
    }
}
