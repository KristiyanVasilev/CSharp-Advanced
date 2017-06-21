namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager
    {
        public static void TraverseDirectorty(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentation = SessionData.currentPath.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                var currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIndentation;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var indexOfLastSlash = file.LastIndexOf("\\");
                        var fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);

                        //It page 8 of 03-Document(First Part)
                        //It should be depth - identation
                        if (depth - identation < 0)
                        {
                            break;
                        }
                    }
                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.UnauthorizedAccessException);
                }
            }

        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {

                OutputWriter.DisplayExceptions(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
            
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    var currentPath = SessionData.currentPath;
                    var indexOfLastSlash = currentPath.LastIndexOf("\\");
                    var newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayExceptions(ExceptionMessages.UnabelToGoHigherInPartitionHierarchy);   
                }
               
            }
            else
            {
                var currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryRelative(currentPath);
            }
        }
        public static void ChangeCurrentDirecotryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayExceptions(ExceptionMessages.InvalidPath);
                return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
