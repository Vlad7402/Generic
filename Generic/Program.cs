using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void ExecuteProgramInFile()
        {
            Queue1<object> commandsQueue = FileReader.ReadFile();
            string dynamic = commandsQueue.Dequeue().ToString();
            while(!commandsQueue.IsEmpty())
            {
                object inputData = null;
                var command = RecognizeCommand(commandsQueue.Dequeue(), out inputData);
                
            }
        }

        static int? RecognizeCommand(object command, out object data)
        {
            data = null;
            if (command.ToString().Length == 1 && ((int)command) <= 5 && ((int)command) >= 1)
            {
                return (int)command;
            }
            else if (command.ToString().Length == 3)
            {
                data = command.ToString()[2];
                return int.Parse(command.ToString()[0].ToString());
            }
            else 
                return null;
        }
    }
}
