using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SuperMarket 
    {
        List<Customer> customers = new List<Customer>();
        List<Queue<Customer>> lines = new List<Queue<Customer>>();
        PriorityQueue<Event> events = new PriorityQueue<Event>();

        public int openTime { get; set; }

        public int closeTime { get; set; }

        public SuperMarket()
        {

        }

        public SuperMarket(int numOfCustomers, int openTime, int closeTime)
        {

        }

        public void GenerateCustomers(int numOfCustomers)
        {
            for(int i = 0; i < numOfCustomers; i++)
            {
                Customer newCustomer = new Customer(openTime, closeTime);

                customers.Add(newCustomer);
            }
        }

        public void AddEvents()
        {
            foreach(Customer c in customers)
            {
                Event arrival = new Event(EVENTTYPE.ENTER, c.ArrivalTime, c);
                Event leave = new Event(EVENTTYPE.LEAVE, c.ArrivalTime + c.TimeToBeServed, c);
                events.Enqueue(arrival);
                events.Enqueue(leave);
            }
        }

        public void HandleEvent(Event e)
        {
            int line = 0;

            if(e.Type == EVENTTYPE.ENTER)
            {
                for(int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Count < lines[line].Count)
                        line = i;

                }

                lines[line].Enqueue(e.Customer);
                e.Customer.RegisterNumber = line;
            }
            else
            {
                if(lines[e.Customer.RegisterNumber].Peek() )

            }
        }





    }
}
