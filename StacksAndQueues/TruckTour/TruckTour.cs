namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TruckTour
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var pumps = new Queue<GasPump>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var amountOfGas = line[0];
                var distanceToNext = line[1];
                GasPump pump = new GasPump(distanceToNext, amountOfGas, i);
                pumps.Enqueue(pump);
            }
                GasPump startPump = null;
                var completeJourney = false;
                while (true)
                {
                    GasPump currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    startPump = currentPump;
                    int gasInTank = currentPump.amountOfGas;

                    while (gasInTank >= currentPump.distanceToNext)
                    {
                        gasInTank -= currentPump.distanceToNext;
                        currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        if (currentPump == startPump)
                        {
                            completeJourney = true;
                            break;
                        }

                        gasInTank += currentPump.amountOfGas;
                    }
                    if (completeJourney)
                    {
                        Console.WriteLine(currentPump.index);
                        break;
                    }
                }
            
        }
    }

        public class GasPump
        {
            public int distanceToNext;
            public int amountOfGas;
            public int index;
            public GasPump(int distanceToNext, int amountOfGas, int index)
            {
                this.distanceToNext = distanceToNext;
                this.amountOfGas = amountOfGas;
                this.index = index;
            }
        }
 }

