using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SuperMarket 
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public bool Flag { get; set; }
        public int NumOfCustomers { get; set; }

        public double Average { get; set; }

        List<Customer> customers = new List<Customer>();
        List<Queue<Customer>> lines = new List<Queue<Customer>>();
        PriorityQueue<Event> events = new PriorityQueue<Event>();

        public int OpenTime { get; set; }

        public int CloseTime { get; set; }

        public SuperMarket()
        {
            Min = 0;
            Max = 0;
            Average = 0;
            Flag = false;

        }

        public SuperMarket(int numOfCustomers, int openTime, int closeTime)
        {
            Min = 0;
            Max = 0;
            Average = 0;
            Flag = false;
            NumOfCustomers = numOfCustomers;
            OpenTime = openTime;
            CloseTime = closeTime;
        }

        public void GenerateCustomers()
        {
            for(int i = 0; i < NumOfCustomers; i++)
            {
                Customer newCustomer = new Customer(openTime, closeTime, i + 1);

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

                if (lines[line].Count > 2)
                    Flag = true;
            }
            else
            {
                if(lines[e.Customer.RegisterNumber].Count == 1)
                {
                    lines[e.Customer.RegisterNumber].Dequeue();
                }
                else if(lines[e.Customer.RegisterNumber].Count > 1)
                {
                    Customer lineCustomer = lines[e.Customer.RegisterNumber].Dequeue();

                    if (lineCustomer.TimeToBeServed < Min)
                        Min = lineCustomer.TimeToBeServed;
                    if (lineCustomer.TimeToBeServed > Max)
                        Max = lineCustomer.TimeToBeServed;
                    Average += lineCustomer.TimeToBeServed;

                    lines[e.Customer.RegisterNumber].Peek().TimeToBeServed += lineCustomer.TimeToBeServed;
                    
                }
            }
        }

        public void RunSuperMarket()
        {

        }





    }
}
