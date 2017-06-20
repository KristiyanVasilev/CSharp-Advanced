namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var command = Console.ReadLine();
           
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        AddOne(numbers);
                        break;
                    case "multiply":
                        Multiply(numbers);
                        break;
                    case "subtract":
                        Subtract(numbers);
                        break;
                    case "print":
                        PrintNum(numbers);
                        break;
                }
                command = Console.ReadLine();
            }
        }

        private static void PrintNum(int[] numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }

        private static int[] Subtract(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
            return numbers;
        }

        private static int[] Multiply(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] *= 2;
            }
            return numbers;
        }

        public static int[] AddOne(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]++;
            }
            return numbers;
        }
    }
}
