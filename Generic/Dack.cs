using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Dack<T>
    {
        private DackEl<T> last, first;

        public void PushLast(T value)
        {
            DackEl<T> item = new();
            item.Value = value;
            if (last != null)
            {
                item.Previous = last;
                last.Next = item;
            }
            last = item;
            if (first == null)
                first = item;
        }

        public void EnqueueFirst(T value)
        {
            DackEl<T> item = new();
            item.Value = value;
            if (first != null)
            {
                item.Next = first;
                first.Previous = item;
            }
            first = item;
            if (last == null)
                last = item;
        }

        public T GetLast()
        {
            T lastValue = this.Last;
            if (first == last)
            {
                first = last = null;
                return lastValue;
            }
            last.Previous.Next = null;
            last = last.Previous;
            return lastValue;
        }

        public T GetFirst()
        {
            T firstValue = this.First;
            if (first == last)
            {
                first = last = null;
                return firstValue;
            }
            first.Next.Previous = null;
            first = first.Next;
            return firstValue;
        }

        public T First 
        { 
            get
            {
                if (!IsEmpty)
                    return first.Value;

                throw new Exception("Generic type is empty");
            } 
        }

        public T Last
        {
            get
            {
                if (!IsEmpty)
                    return last.Value;

                throw new Exception("Generic type is empty");
            }
        }

        public bool IsEmpty { get { return last == null; } }

        private class DackEl<T>
        {
            public DackEl<T> Next, Previous;
            public T Value;
        }
    }
}
