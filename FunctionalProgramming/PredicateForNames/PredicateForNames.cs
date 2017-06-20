namespace PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PredicateForNames
    {
        public static void Main()
        {
            var nameLenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
                if (name.Length <= nameLenght)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
