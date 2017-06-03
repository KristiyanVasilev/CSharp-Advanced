using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();

            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine()
                    .Split();

                switch (line[0])
                {
                    case "1":
                        if (!stack.Any())
                        {
                            stack.Push(line[1]);
                        }
                        else
                        {
                            stack.Push(stack.Peek() + line[1]);
                        }
                        break;

                    case "2":
                        var count = int.Parse(line[1]);
                        var update = stack.Peek();
                        update = update.Remove(update.Length - count);
                        stack.Push(update);                        
                        break;
                    case "3":
                        var index = int.Parse(line[1]);
                        var lastUpdate = stack.Peek();
                        Console.WriteLine(lastUpdate[index - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        break;
                }
            }
        }
    }
}
