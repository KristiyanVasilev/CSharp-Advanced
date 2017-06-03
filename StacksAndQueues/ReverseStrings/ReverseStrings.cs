namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
