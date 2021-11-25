using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable
    {
        private Node<T> top;
        public int Count { get; set; }
       
        public void Enqueue(T item)
        {
            if(Count == 0)
            {
                top = new Node<T>(item, null);
            }
            else
            {
                Node<T> current = top;
                Node<T> previous = null;
                
                while(current != null && 
                            current.Item.CompareTo(item) >= 0)
                {
                    previous = current;
                    current = current.Next;
                }

                Node<T> newNode = new Node<T>(item, current);

                if(previous != null)
                {
                    previous.Next = newNode;
                }
                else
                {
                    top = newNode;
                }
            }
            Count++;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty priority queue.");
            }
            else
            {
                Node<T> oldNode = top;
                top = top.Next;
                Count--;
                oldNode = null;
            }

        }

        public void Clear()
        {
            top = null;
            Count = 0;
        }

        public T Peek()
        {
            if(!IsEmpty())
            {
                return top.Item;
            }
            else
            {
                throw new InvalidOperationException("Cannot obtain top of empty priority queue.");
            }
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }

}
