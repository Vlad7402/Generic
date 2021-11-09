using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class TimeRecord
    {
        public static void Main()
        {
            int smoothnes = 20;
            int RunTimes = 2500;
            int step = 1;
            int slidingAvarage = 50;
            int procent = 1;
            List<long> timersResults = new(RunTimes);
            Console.CursorVisible = false;
            Console.WriteLine("Процесс выполнения завершён на   %.");
            for (int i = step; i <= (RunTimes + slidingAvarage) * step; i += step)
            {
                var array = GetIntArray(i);
                long[] results = new long[smoothnes];
                for (int j = 0; j < smoothnes; j++)
                    results[j] = GetAllapsedTime(array);
                //results[j] = GetAllapsedTime(GetMatrix(i, 123321), GetMatrix(i, 321123));


                RemoveWrongValues(results, array, smoothnes);
                //RemoveWrongValues(results, GetMatrix(i, 123321), GetMatrix(i, 321123), smoothnes);
                long smoothResult = results[0];
                for (int j = 1; j < smoothnes; j++)
                    smoothResult = (smoothResult + results[j]) / 2;

                if ((i / (float)((RunTimes + slidingAvarage) * step)) * 100 > procent)
                {
                    Console.SetCursorPosition(31, 0);
                    Console.Write(procent);
                    procent++;
                }
                timersResults.Add(smoothResult);
            }
            WriteToCSV(SlidingAvarageFilter(slidingAvarage, timersResults).ToArray());
        }
        private static long GetAllapsedTime(int[] array)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            //here you should put testing Alchoritm
            stopwatch.Stop();
            return stopwatch.ElapsedTicks / (TimeSpan.TicksPerMillisecond / 1000);
            // / (TimeSpan.TicksPerMillisecond / 1000)
        }
        private static List<decimal> SlidingAvarageFilter(int slidingAvarage, List<long> values)
        {
            List<decimal> result = new(values.Count);
            for (int i = slidingAvarage; i < values.Count; i++)
            {
                long avarage = 0L;
                for (int j = slidingAvarage; j > 0; j--)
                    avarage += values[i - j];

                result.Add((decimal)avarage / (decimal)slidingAvarage);
            }
            return result;
        }
        private static void RemoveWrongValues(long[] values, int[] array, int smoothnes)
        {
            for (int j = 1; j < smoothnes; j++)
            {
                if (values[j - 1] != 0L)
                {
                    while (values[j] / values[j - 1] > 2f)
                    {
                        values[j] = GetAllapsedTime(array);
                        if (values[j - 1] == 0L)
                            break;
                    }
                }
                if (values[j] != 0L)
                {
                    while (values[j - 1] / values[j] > 2f)
                    {
                        values[j - 1] = GetAllapsedTime(array);
                        if (values[j] == 0L)
                            break;
                    }
                }
            }
        }
        private static int[] GetIntArray(int numberOfElements)
        {
            int[] result = new int[numberOfElements];
            Random random = new(123321);
            for (int i = 0; i < numberOfElements; i++)
                result[i] = random.Next(100);

            return result;
        }
        private static void WriteToCSV(decimal[] timersResults)
        {
            string[] values = new string[timersResults.Length];
            for (int i = 0; i < timersResults.Length; i++)
                values[i] = Convert.ToString(timersResults[i]);

            File.WriteAllLines("Result.csv", values);
        }
    }
}
