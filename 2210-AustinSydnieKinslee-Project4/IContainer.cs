using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    interface IContainer<T>
    {
        void Clear();
        bool IsEmpty();
        int Count { get; set; }
    }
}
