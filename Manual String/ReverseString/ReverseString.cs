namespace ReverseString
{
    using System;
    using System.Linq;

    public class ReverseString
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToCharArray().Reverse();                
            Console.WriteLine(string.Join("", text));
        }
    }
}
