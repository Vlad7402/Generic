using System;

namespace Generic
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //ExecuteProgramInFile();
            CompleteFunctions();
        }

        static void CompleteFunctions()
        {
            Functions<int> functions = new();
            Dack<int> workDack = CreateWorkDack(10);
            {
                Console.Write(" 1. ");
                workDack.PrintFromFirst();
                functions.ReverseList(workDack);
                Console.Write(" <-было - стало -> ");
                workDack.PrintFromFirst();
            }
            {
                Console.Write("\n 2. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.FirstToEnd(workDack);
                workDack.PrintFromFirst();
            }
            var _ = workDack.GetFirst();
            workDack.PushLast(workDack.First);
            {
                Console.Write("\n 3. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                int countDifEl = functions.CountDifferentElements(workDack);
                workDack.PrintFromFirst();
                Console.Write($" разных элементов {countDifEl}");
            }
            {
                Console.Write("\n 4. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.RemoveRepeats(workDack);
                workDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(10);
            {
                Console.Write("\n 5. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.AddDackInDackAfterX(workDack, 5);
                workDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(8);
            workDack.PushLast(9);
            {
                Console.Write("\n 6. ");
                workDack.PrintFromFirst();
                Console.Write("  <-было - стало -> ");
                functions.InsertItemIntoOrderedList(workDack, 9);
                workDack.PrintFromFirst();
            }
            {
                Console.Write("\n 7. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.RemoveCustomElement(workDack, 9);
                workDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(10);
            {
                Console.Write("\n 8. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.InsertItemBeforeX(workDack, 5, 6);
                workDack.PrintFromFirst();
            }
            {
                Console.Write("\n 9. ");
                Console.Write("\t       <-было - стало -> ");
                workDack = functions.JoinLists();
                workDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(10);
            {
                Console.Write("\n10. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                Dack<int> secondDack = new();
                workDack = functions.SplitList(workDack, ref secondDack, 5);
                workDack.PrintFromFirst();
                Console.Write(" | " );
                secondDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(10);
            {
                Console.Write("\n11. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.DoubleList(workDack);
                workDack.PrintFromFirst();
            }
            workDack = CreateWorkDack(10);
            {
                Console.Write("\n12. ");
                workDack.PrintFromFirst();
                Console.Write(" <-было - стало -> ");
                functions.ReplacementOfElements(workDack, 4, 7);
                workDack.PrintFromFirst();
            }
        }

        private static Dack<int> CreateWorkDack(int count)
        {
            Dack<int> workDack = new();
            for (int i = 0; i < count; i++)
            {
                workDack.PushLast(i);
            }
            return workDack;
        }

        #region FileWorker
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

        static void QueueProgram(Queue1<object> commandsQueue)
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
                        queue1.Print();
                        break;
                }

            }
        }
        static void StackProgram(Queue1<object> commandsQueue)
        {
            Stack1<object> stack1 = new();

            while (!commandsQueue.IsEmpty())
            {
                object inputData = null;
                var command = RecognizeCommand(commandsQueue.Dequeue(), out inputData);
                switch (command)
                {
                    case null:
                        throw new Exception("проблемы с вводом");
                    case 1:
                        stack1.Push(inputData);
                        Console.WriteLine($"добавляем в стек {inputData}");
                        break;
                    case 2:
                        Console.WriteLine($"достаем из стека верхний элемент {stack1.Pop()}");
                        break;
                    case 3:
                        Console.WriteLine($"Верхний элемент = {stack1.Top}");
                        break;
                    case 4:
                        Console.WriteLine($"Очередь пустая = {stack1.IsEmpty}");
                        break;
                    case 5:
                        stack1.Print();
                        break;
                }
            }
        }
        static int? RecognizeCommand(object command, out object data)
        {
            data = null;
            if (command.ToString().Length == 1 && int.Parse(command.ToString()) <= 5 && int.Parse(command.ToString()) >= 1)
            {
                return int.Parse(command.ToString());
            }
            else if (command.ToString().Length == 3)
            {
                data = command.ToString()[2];
                return int.Parse(command.ToString()[0].ToString());
            }
            else 
                return null;
        }
        #endregion
    }
}
