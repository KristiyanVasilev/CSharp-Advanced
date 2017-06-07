namespace FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var folderPath = "../../";
            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            var dictionary = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo lenght = new FileInfo(file);
                double fileSize = (double)lenght.Length / 1024;
                var clearFile = Path.GetFileName(file);
                var extension = Path.GetExtension(file);

                if (!dictionary.ContainsKey(extension))
                {
                    dictionary[extension] = new Dictionary<string, double>();
                    if (!dictionary[extension].ContainsKey(clearFile))
                    {
                        dictionary[extension].Add(clearFile, fileSize);
                    }
                }
                else
                {
                    if (!dictionary[extension].ContainsKey(clearFile))
                    {
                        dictionary[extension].Add(clearFile, lenght.Length);
                    }
                }
            }

            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using (var writer = new StreamWriter(strPath + @"\report2.txt"))
            {
                foreach (var extension in dictionary.OrderByDescending(x => x.Value.Count()))
                {
                    writer.WriteLine($"{extension.Key}");
                    foreach (var file in extension.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
                    {
                        var fileName = file.Key;
                        var fileSize = file.Value;
                        writer.WriteLine($"--{fileName} - {fileSize} kb");
                    }
                }
            }
        }
    }
}

