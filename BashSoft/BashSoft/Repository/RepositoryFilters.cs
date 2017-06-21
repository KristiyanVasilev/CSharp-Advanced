using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wanteFilter, int studentsToTake)
        {
            if (wanteFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= 5, studentsToTake);
            }
            else if (wanteFilter == "average")
            {
                FilterAndTake(wantedData, x => x <= 5 && x >= 3.5, studentsToTake);
            }
            else if (wanteFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InvalidStudentFilter);
            }
        }
        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var username_Points in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                double averageScore = username_Points.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double mark = percentageOfFullfilment * 4 + 2;
                if (givenFilter(averageScore))
                {
                    OutputWriter.PrintStudent(username_Points);
                    counterForPrinted++;
                }
            }
        }
        //private static bool ExcellentFilter(double mark)
        //{
        //    return mark >= 5.0;
        //}
        //private static bool AverageFilter(double mark)
        //{
        //    return mark < 5.0 && mark >= 3.5;
        //}
        //private static bool PoorFilter(double mark)
        //{
        //    return mark < 3.5;
        //}
        //private static double Average(List<int> scoresOnTasks)
        //{
        //    int totalScore = 0;
        //    foreach (var score in scoresOnTasks)
        //    {
        //        totalScore += score;
        //    }
        //    var percentageOfAll = totalScore / (scoresOnTasks.Count * 100);
        //    var mark = percentageOfAll * 4 + 2;
        //    return mark;
        //}
    }
}
