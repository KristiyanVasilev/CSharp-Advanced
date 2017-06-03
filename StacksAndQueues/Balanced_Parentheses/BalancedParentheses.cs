namespace Balanced_Parentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BalancedParentheses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var openenedParethesis = new Stack<char>();
            var openingSymbols = new char[] { '(', '{', '[' };

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];

                if (openingSymbols.Contains(currentSymbol))
                {
                    openenedParethesis.Push(currentSymbol);
                }
                else
                {
                    if (openenedParethesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (currentSymbol)
                    {
                        case '}':
                            if (openenedParethesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ']':
                            if (openenedParethesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;

                        case ')':
                            if (openenedParethesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
