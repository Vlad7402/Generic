using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Queue1<T>
    {
        private Dack<T> dack = new();

        public void Enqueue(T value)
        { dack.PushLast(value); }

        public T Dequeue()
        { return dack.GetFirst(); }

        public bool IsEmpty() 
        { return dack.IsEmpty; }

        public T ViewFirstItem()
        { return dack.First; }

        public void Print()
        { dack.PrintFromFirst(); }
    }
}
