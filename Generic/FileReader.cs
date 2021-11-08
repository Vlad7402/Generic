using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public static class FileReader
    {
        public static Queue1<object> ReadFile()
        {
            var line = File.ReadAllLines("input.txt");
            if (!CheckFile(line)) throw new Exception("the file is not filled correctly");
            return ParseLine(line);
        }
        
        private static bool CheckFile(string[] line)
        { return line.Length == 2 && (line[0].ToLower() == "stack" || line[0].ToLower() == "queue"); }

        private static Queue1<object> ParseLine(string[] line)
        {
            var queue = new Queue1<object>();
            queue.Enqueue(line[0]);
            string[] commandLine = line[1].Split(' ');
            for (int i = 0; i < commandLine.Length; i++)
            {
                queue.Enqueue(commandLine[i]);
            }
            return queue;
        }

    }
}
