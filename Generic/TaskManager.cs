using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    static class TaskManager
    {
        public static void StartWork()
        {
           
            Queue1<string> tasks = new();
            string mainTask = "Не отвлейкайтесь!";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в TaskManager \n" +
                    "Самое главное - не переходить от задачи к задачи, " +
                    "поэтому вы будете видеть только самую раннюю задачу \n" +
                    "Если вы хотите добавить задачу, нажмите \"1\" \n" +
                    "Если вы выполнили задачу нажмите \"2\" \n" +
                    $"{ mainTask }");
                int command = 0;
                while (command == 0)
                {
                    string userAnswer = Console.ReadLine();
                    if (!int.TryParse(userAnswer, out command))
                    { Console.WriteLine("Вы ввели неправильное число"); }
                }
                switch (command)
                {
                    case 1:
                        if(mainTask == "Не отвлейкайтесь!"|| mainTask == "Все задачи сделаны, самое время добавить новую")
                        mainTask = Console.ReadLine();
                        else
                        {
                            tasks.Enqueue(Console.ReadLine());
                        }
                        break;
                    case 2:
                        if(tasks.IsEmpty())
                        { mainTask = "Все задачи сделаны, самое время добавить новую"; }
                        else 
                        { mainTask = tasks.Dequeue(); }
                        break;
                    default:
                        break;

                }
            }

        }

        
    }
}
