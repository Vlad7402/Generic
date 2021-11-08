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
            switch (dynamic)
            {
                case "stack":
                    StackProgram(commandsQueue);
                    break;
                case "queue":
                    QueueProgram(commandsQueue);
                    break;
                default:
                    throw new Exception("Ну как так-то");
            }
            
        }

        static void StackProgram(Queue1<object> commandsQueue)
        {
            Queue1<object> queue1 = new();
            //1 - вставка, 2 - удаление, 3 – просмотр начала очереди, 4 – проверка на пустоту, 5 - печать
            while (!commandsQueue.IsEmpty())
            {
                object inputData = null;
                var command = RecognizeCommand(commandsQueue.Dequeue(), out inputData);
                switch (command)
                {
                    case null:
                        throw new Exception("проблемы с вводом");
                    case 1:
                        queue1.Enqueue(inputData);
                        Console.WriteLine($"добавляем в очередь {inputData}");
                        break;
                    case 2:
                        Console.WriteLine($"убираем из очереди 1й элемент {queue1.Dequeue()}");
                        break;
                    case 3:
                        Console.WriteLine($"Первый элемент = {queue1.ViewFirstItem()}");
                        break;
                    case 4:
                        Console.WriteLine($"Очередь пустая = {queue1.IsEmpty()}");
                        break;
                    case 5:
                        //ДОДЕЛАТЬ
                        break;
                }

            }
        }
        static void QueueProgram(Queue1<object> commandsQueue)
        {
            Stack1<object> stack1 = new();
            object inputData = null;
            var command = RecognizeCommand(commandsQueue.Dequeue(), out inputData);
            switch (command)
            {
                case null:
                    throw new Exception("проблемы с вводом");
                case 1:
                    stack1.Push(inputData);
                    Console.WriteLine($"добавляем в очередь {inputData}");
                    break;
                case 2:
                    Console.WriteLine($"убираем из очереди 1й элемент {stack1.Pop()}");
                    break;
                case 3:
                    Console.WriteLine($"Первый элемент = {stack1.Top}");
                    break;
                case 4:
                    Console.WriteLine($"Очередь пустая = {stack1.IsEmpty}");
                    break;
                case 5:
                    //ДОДЕЛАТЬ
                    break;
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
