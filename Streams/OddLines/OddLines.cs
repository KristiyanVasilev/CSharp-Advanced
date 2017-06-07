namespace OddLines
{
    using System;
    using System.IO;   

    public class OddLines
    {
        public static void Main()
        {
            var reader = new StreamReader("somefile.txt");
            using (reader)
            {
                var lineNumber = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine($"{lineNumber}: {line}");
                    }                    
                    line = reader.ReadLine();
                }
            }
        }
    }
}
