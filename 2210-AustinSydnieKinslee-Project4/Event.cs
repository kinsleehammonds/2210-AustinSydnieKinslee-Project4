using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// khgkhhk
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    enum EVENTTYPE { ENTER, LEAVE };

    class Event : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public int Time { get; set; }
        public Customer Customer { get; set; }

        public Event(EVENTTYPE type, int time, Customer customer)
        {
            Type = type;
            Time = time;
            Customer = customer;
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is Event))
                throw new ArgumentException("The argument is not an Event object");

            Event e = (Event)obj;
            return e.Time.CompareTo(Time);
        }
    }
}
