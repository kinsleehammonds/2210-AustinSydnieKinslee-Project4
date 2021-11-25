using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class Node<T> where T: IComparable
    {
        public T Item { get; set; }

        public Node<T> Next { get; set; }

        public Node(T value, Node<T> link)
        {
            Item = value;
            Next = link;
        }
    }
}
