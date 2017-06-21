using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        public static void InitializedData(string FileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(FileName);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                var pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+(([A-Z][a-z]{0,3})\d{2}_\d{2,4})\s+(\d+)";
                var regex = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);
                for (int i = 0; i < allInputLines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[i]) && regex.IsMatch(allInputLines[i]))
                    {
                        Match currentMatch = regex.Match(allInputLines[i]);
                        var courseName = currentMatch.Groups[1].Value;
                        var userName = currentMatch.Groups[2].Value;
                        int studentScoreOnTask;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[4].Value, out studentScoreOnTask);
                        var data = allInputLines[i].Split(' ');
                        if (hasParsedScore && (studentScoreOnTask >= 0 && studentScoreOnTask <= 100))
                        {
                            if (!studentsByCourse.ContainsKey(courseName))
                            {
                                studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                            }
                            if (!studentsByCourse[courseName].ContainsKey(userName))
                            {
                                studentsByCourse[courseName].Add(userName, new List<int>());
                            }
                            studentsByCourse[courseName][userName].Add(studentScoreOnTask);
                        }
                    }
                }
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InvalidPath);
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");

            //var input = Console.ReadLine();
            //while (!string.IsNullOrEmpty(input))
            //{
            //    var tokens = input.Split(' ');
            //    var course = tokens[0];
            //    var student = tokens[1];
            //    var mark = int.Parse(tokens[2]);

            //    if (!studentsByCourse.ContainsKey(course))
            //    {
            //        studentsByCourse.Add(course, new Dictionary<string, List<int>>());
            //    }
            //    if (!studentsByCourse[course].ContainsKey(student))
            //    {
            //        studentsByCourse[course].Add(student, new List<int>());
            //    }
            //    studentsByCourse[course][student].Add(mark);
            //    input = Console.ReadLine();
            //}

        }
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }
        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public static void GetStudentsScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
            }
        }
        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}: ");
                foreach (var studentMarksEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarksEntry);
                }
            }
        }
        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }
                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }
        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (studentsToTake == null)
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }
            RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
        }

    }
}
