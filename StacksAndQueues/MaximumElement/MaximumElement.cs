namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MaximumElement
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNumbers = new Stack<int>();
            var maxNum = int.MinValue;

            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var queryType = line[0];

                if (queryType == 1)
                {
                    stack.Push(line[1]);
                    if (maxNum < line[1])
                    {
                        maxNum = line[1];
                        maxNumbers.Push(maxNum);
                    }
                    
                }
                else if (queryType == 2)
                {
                    if (stack.Pop() == maxNum)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count != 0)
                        {
                            maxNum = maxNumbers.Peek();
                        }
                        else
                        {
                            maxNum = int.MinValue;
                        }
                    }                                     
                }
                else
                {
                    Console.WriteLine(maxNum);
                }
            }
        }
    }
}
