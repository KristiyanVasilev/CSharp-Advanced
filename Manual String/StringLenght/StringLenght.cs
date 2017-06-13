namespace StringLenght
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StringLenght
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            if (input.Length > 20)
            {
                Console.WriteLine(input.Substring(0, 20));
            }
            else
            {
                var strToAdd = new string('*', 20 - input.Length);
                var result = input.Substring(0, input.Length) + strToAdd;
                Console.WriteLine(result);
            }           
        }
    }
}
