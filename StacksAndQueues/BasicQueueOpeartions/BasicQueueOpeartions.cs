namespace BasicQueueOpeartions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BasicQueueOpeartions
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
            var queue = new Queue<int>();

            for (int i = 0; i < numsToPush; i++)
            {
                queue.Enqueue(secondLine[i]);
            }

            for (int i = 0; i < numsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(numPresents))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
