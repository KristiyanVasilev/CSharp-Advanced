namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            queue.Enqueue(number);

            for (int i = 0; i < 50; i++)
            {
                var firstNum = queue.Peek();
                queue.Enqueue(firstNum + 1);
                queue.Enqueue(2 * firstNum + 1);
                queue.Enqueue(firstNum + 2);
                Console.Write(queue.Dequeue() + " ");
            }
           
        }
    }
}
