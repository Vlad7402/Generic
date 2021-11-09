using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Functions<T>
    {

        public void ReverseList(Dack<T> startList)
        {
            Stack1<T> temp = new();
            
            while(!startList.IsEmpty)
            { temp.Push(startList.GetFirst()); } 

            while(!temp.IsEmpty)
            { startList.PushLast(temp.Pop()); }            
        }

        public void FirstToEnd(Dack<T> startList)
        {
            Queue1<T> temp = new();
            T first = startList.GetFirst();
            while(!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            temp.Enqueue(first);
            while (!temp.IsEmpty())
            { startList.PushLast(temp.Dequeue()); }
        }

        public int CountDifferentElements(Dack<int> startList)
        {
            Queue1<int> temp = new();
            while(!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            int counter = 0;
            List<int> differentEllements = new();
            while(!temp.IsEmpty())
            {
                int _ = temp.Dequeue();
                if (!differentEllements.Contains(_))
                {
                    counter++;
                    differentEllements.Add(_);
                }
                startList.PushLast(_);
            }
            return counter;
        }

        public void RemoveRepeats(Dack<T> startList)
        {
            Queue1<T> temp = new();
            while (!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            List<T> differentEllements = new();
            while(!temp.IsEmpty())
            {
                var _ = temp.Dequeue();
                if (!differentEllements.Contains(_))
                {  
                    differentEllements.Add(_);
                    startList.PushLast(_);
                }
                
            }
        }

        public void AddDackInDackAfterX(Dack<int> startList, int x)
        {
            Queue1<int> temp1 = new();
            Queue1<int> temp2 = new();
            while(!startList.IsEmpty)
            {
                var _ = startList.GetFirst();
                temp1.Enqueue(_);
                temp2.Enqueue(_);
            }
            while(!temp1.IsEmpty())
            {
                var _ = temp1.Dequeue();
                startList.PushLast(_);
                if(_ == x)
                {
                    while(!temp2.IsEmpty())
                    {
                        startList.PushLast(temp2.Dequeue());
                    }
                }
            }
        }

        public void InsertItemIntoOrderedList(Dack<int> startList, int x)
        {
            Queue1<int> temp = new();
            while (!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            int previous = int.MinValue;
            while(!temp.IsEmpty())
            {                
                var next = temp.Dequeue();
                if (x > previous && x <= next)
                { startList.PushLast(x); }
                startList.PushLast(next);
            }
        }

        public void RemoveCustomElement(Dack<int> startList, int x)
        {
            Queue1<int> temp = new();
            while (!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            while(!temp.IsEmpty())
            {
                var _ = temp.Dequeue();
                if (_ != x)
                    startList.PushLast(_);
            }
        }

        public void InsertItemBeforeX(Dack<int> startList, int? x, int e)
        {
            Queue1<int> temp = new();
            while (!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            
            while (!temp.IsEmpty())
            {
                var next = temp.Dequeue();
                if (x == next)
                { 
                    startList.PushLast(e);
                    x = null;
                }
                startList.PushLast(next);
            }
        }

        public Dack<int> JoinLists()
        {
            string[] temp = File.ReadAllLines("Lists.txt");
            Queue1<int> queue1 = new();
            Queue1<int> queue2 = new();
            var _ = temp[0].Split(' ');
            for (int i = 0; i < _.Length; i++)
            { queue1.Enqueue(int.Parse(_[i])); }
            _ = temp[1].Split(' ');
            for (int i = 0; i < _.Length; i++)
            { queue2.Enqueue(int.Parse(_[i])); }
            Dack<int> dack = new();
            while (!queue1.IsEmpty())
            { dack.PushLast(queue1.Dequeue()); }
            while (!queue2.IsEmpty())
            { dack.PushLast(queue2.Dequeue()); }
            return dack;
        }

        public Dack<int> SplitList(Dack<int> startList, ref Dack<int> secondList, int x)
        {
            Queue1<int> temp = new();
            while (!startList.IsEmpty)
            { temp.Enqueue(startList.GetFirst()); }
            Dack<int> firstList = new();
            bool flag = false;
            while (!temp.IsEmpty())
            {
                int _ = temp.Dequeue();
                if (_ == x)
                { flag = true; }
                if(flag)
                { secondList.PushLast(_); }
                else 
                { firstList.PushLast(_); }
            }
            return firstList;
        }

        public void DoubleList(Dack<int> startList)
        {
            Queue1<int> queue1 = new();
            Queue1<int> queue2 = new();
            while (!startList.IsEmpty)
            {
                var _ = startList.GetFirst();
                queue1.Enqueue(_);
                queue2.Enqueue(_);
            }
            while (!queue1.IsEmpty())
                startList.PushLast(queue1.Dequeue());
            while (!queue2.IsEmpty())
                startList.PushLast(queue2.Dequeue());
        }

        public void ReplacementOfElements(Dack<int> startList, int x, int y)
        {
            Queue1<int> queue1 = new();
            int counter = 0;
            Dictionary<int, int> aaa = new();
            
            while(!startList.IsEmpty)
            {
                var _ = startList.GetFirst();
                if (counter == x)
                { 
                    aaa.Add(x, _);
                    _ = int.MinValue;
                }
                if (counter == y)
                { 
                    aaa.Add(y, _);
                    _ = int.MaxValue;
                }
                counter++;
                queue1.Enqueue(_);
            }
            while(!queue1.IsEmpty())
            {
                var _ = queue1.Dequeue();
                if(_ == int.MinValue)
                { startList.PushLast(aaa[y]); }
                else if (_ == int.MaxValue)
                { startList.PushLast(aaa[x]); }
                else { startList.PushLast(_); }
            }

        }
    }
}
