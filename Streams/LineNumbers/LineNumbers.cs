namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            Console.Write("Choose your file path: ");
            var filePath = Console.ReadLine();
            using (var reader = new StreamReader(filePath))
            {
                using (var writer = new StreamWriter("../../result.txt"))
                {
                    var line = reader.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{counter} {line}");
                        counter++;
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }                        
                    }
                }                            
            }
        }
    }
}
