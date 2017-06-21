namespace BashSoft
{
    using System;

    public static class InputReader
    {
        //I am not sure if this should be here!!!
        private static string endCommand = "quit";
        public static void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                var input = Console.ReadLine();
                input = input.Trim();
                if (input == endCommand)
                {
                    return;
                }
                CommandInterpreter.InterpredCommand(input);
            }
        }
    }
}
