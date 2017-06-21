namespace BashSoft
{
    using System;
    using System.Diagnostics;
    public static class CommandInterpreter
    {
        public static void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string command = data[0];
            switch (command)
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cdRel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdAbs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readDb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                var courseName = data[1];
                var order = data[2].ToLower();
                var takeCommand = data[3].ToLower();
                var takeQunatity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQunatity, courseName, order);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQunatity, string courseName, string order)
        {
            if (takeCommand == "take")
            {
                if (takeQunatity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, order);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQunatity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, order, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayExceptions(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                var courseName = data[1];
                var filter = data[2].ToLower();
                var takeCommand = data[3].ToLower();
                var takeQunatity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQunatity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQunatity, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (takeQunatity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQunatity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayExceptions(ExceptionMessages.InvalidTakeQuantityParameter);       
                    }
                }
            }
            else
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                var courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                var courseName = data[1];
                var userName = data[2];
                StudentsRepository.GetStudentsScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryGetHelp(string input, string[] data)
        {
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
            OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
            OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
            OutputWriter.WriteEmptyLine();
        }

        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            string fileName = data[1];
            StudentsRepository.InitializedData(fileName);
        }

        private static void TryChangePathAbsolute(string input, string[] data)
        {
            string absPath = data[1];
            IOManager.ChangeCurrentDirecotryAbsolute(absPath);
        }

        private static void TryChangePathRelatively(string input, string[] data)
        {
            string relPath = data[1];
            IOManager.ChangeCurrentDirectoryRelative(relPath);
        }

        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectorty(0);
            }
            else if (data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(data[1], out depth);
                if (hasParsed)
                {
                    IOManager.TraverseDirectorty(depth);
                }
                else
                {
                    OutputWriter.DisplayExceptions(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                var firsPath = data[1];
                var secondPath = data[2];
                Tester.CompareContent(firsPath, secondPath);
            }
        }

        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.WriteMessage($"The command '{input}' is invalid");
        }
    }
}
