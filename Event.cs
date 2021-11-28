using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject4
{
    enum EVENTTYPE { ENTER, LEAVE };
    class Event : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public DateTime Time { get; set; }
        public int Customer { get; set; }

        public Event()
        {
            Type = EVENTTYPE.ENTER;
            Time = DateTime.Now;
            Customer = -1;
        }

        public Event(EVENTTYPE type, DateTime time, int customer)
        {
            Type = type;
            Time = time;
            Customer = customer;
        }

        public override string ToString()
        {
            return string.Format("Customer {0} {1}s at {2}", Customer, Type, Time);
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
