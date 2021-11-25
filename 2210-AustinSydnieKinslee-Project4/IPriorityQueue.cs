using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    interface IPriorityQueue<T> : IContainer<T> where T: IComparable
    {
        void Enqueue(T item);
        void Dequeue();
        T Peek();
    }
}
