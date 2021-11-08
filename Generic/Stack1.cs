using System;

namespace Generic
{
    class Stack1<T>
    {
        private Dack<T> dack = new();
        
        public void Push(T value)
        { dack.PushLast(value); }

        public T Pop()
        { return dack.GetLast(); }

        public void Print()
        { dack.PrintFromEnd(); }

        public T Top => dack.Last;

        public bool IsEmpty => dack.IsEmpty;
    }
}
