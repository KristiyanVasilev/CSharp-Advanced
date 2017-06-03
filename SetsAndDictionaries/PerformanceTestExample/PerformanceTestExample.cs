namespace PerformanceTestExample
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PerformanceTestExample
    {
        public static void Main()
        {
            var watch = Stopwatch.StartNew();
            var list = new List<string>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i.ToString());
            }
            watch.Stop();
            Console.WriteLine($"List - {watch.ElapsedMilliseconds}");

            watch = Stopwatch.StartNew();
            var hashSet = new HashSet<string>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i.ToString());
            }
            watch.Stop();
            Console.WriteLine($"HashSet - {watch.ElapsedMilliseconds}");
        }
    }
}
