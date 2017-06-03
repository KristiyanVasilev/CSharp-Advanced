namespace BasicStackOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();           

            var secondLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numsToPush = input[0];
            var numsToPop = input[1];
            var numPresents = input[2];
            var stack = new Stack<int>();            

            for (int i = 0; i < numsToPush; i++)
            {
                stack.Push(secondLine[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(numPresents))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }           
        }
    }
}
