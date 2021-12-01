using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SuperMarket 
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int LongestLine { get; set; }
        public bool Flag { get; set; }
        public int NumOfCustomers { get; set; }

        public double HoursOpen { get; set; }

        public double ExpectedTimeToBeServed { get; set; }

        public double Average { get; set; }

        public int Arrivals { get; set; }
        public int Departures { get; set; }

        List<Customer> customers = new List<Customer>();
        List<Queue<Customer>> lines = new List<Queue<Customer>>();
        PriorityQueue<Event> events = new PriorityQueue<Event>();

        public SuperMarket()
        {
            Min = 0;
            Max = 0;
            Average = 0;
            LongestLine = 0;
            Flag = false;
            NumOfCustomers = 200;
            ExpectedTimeToBeServed = 4.5;
            HoursOpen = 16;
            Arrivals = 0;
            Departures = 0;

            for (int i = 0; i < 2; i++)
                lines.Add(new Queue<Customer>());

        }

        public SuperMarket(int numOfCustomers, double hoursOpen, int numOfRegisters, double expectedWaitTime)
        {
            for (int i = 0; i < numOfRegisters; i++)
                lines.Add(new Queue<Customer>());
            Min = 0;
            Max = 0;
            Average = 0;
            LongestLine = 0;
            Flag = false;
            NumOfCustomers = numOfCustomers;
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedWaitTime;
        }

        public void GenerateCustomers()
        {
            for(int i = 0; i < NumOfCustomers; i++)
            {
                Customer newCustomer = new Customer(HoursOpen, ExpectedTimeToBeServed, i + 1);

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
                Arrivals++;
                for(int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Count < lines[line].Count)
                        line = i;
                }

                lines[line].Enqueue(e.Customer);
                e.Customer.RegisterNumber = line;

                if (lines[line].Count > 2)
                    Flag = true;

                if (LongestLine == 0)
                    LongestLine++;
                else if (lines[line].Count > LongestLine)
                    LongestLine = lines[line].Count;

            }
            else
            {
                Departures++;
                if(lines[e.Customer.RegisterNumber].Count == 1)
                {
                    Customer lineCustomer = lines[e.Customer.RegisterNumber].Dequeue();

                    if (Min == 0 || Min > lineCustomer.TimeToBeServed)
                        Min = lineCustomer.TimeToBeServed;

                    if (Max == 0 || lineCustomer.TimeToBeServed > Max)
                        Max = lineCustomer.TimeToBeServed;
                

                    Average += lineCustomer.TimeToBeServed;
                }
                else if(lines[e.Customer.RegisterNumber].Count > 1)
                {

                    Customer lineCustomer = lines[e.Customer.RegisterNumber].Dequeue();

                    if (Min == 0 || Min > lineCustomer.TimeToBeServed)
                        Min = lineCustomer.TimeToBeServed;

                    if (Max == 0 || lineCustomer.TimeToBeServed > Max)
                        Max = lineCustomer.TimeToBeServed;


                    Average += lineCustomer.TimeToBeServed;

                    lines[e.Customer.RegisterNumber].Peek().TimeToBeServed += lineCustomer.TimeToBeServed;
                    
                }
            }
        }

        public string ConvertMinutes(int seconds)
        {
            string msg = "";

            int mins = (int)seconds / 60;
            if (mins < 10)
                msg += "0" + mins;
            else
                msg += mins;

            msg += ":";

            int secs = seconds % 60;
            if (secs < 10)
                msg += "0" + secs;
            else
                msg += secs;


            return msg;
        }

        public void PrintSupermarket()
        {
            Console.Clear();
            Console.WriteLine("Registration Window" +
                 "\n--------------------------------");
            for (int i = 0; i < lines.Count; i++)
            {
                
                Console.Write("Line {0}: ", i + 1);
                foreach (Customer c in lines[i])
                    Console.Write(c.ID + " ");
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Longest Queue Entered So Far: {0}", LongestLine);
            Console.WriteLine("\n\n\n\tEvents Processed So Far: {0}", Arrivals + Departures);
            Console.WriteLine("\tArrivals: {0}", Arrivals);
            Console.WriteLine("\tDepartures: {0}", Departures);
            //Console.WriteLine("Min: {0}, Max: {1}", ConvertMinutes(Min), ConvertMinutes(Max));
        }

        public void RunSuperMarket()
        {
            GenerateCustomers();
            AddEvents();

            while(events.Count > 0)
            {
                HandleEvent(events.Peek());
                events.Dequeue();
                PrintSupermarket();

                Thread.Sleep(100);
            }

            Average /= customers.Count;
            int avg = Convert.ToInt32(Average);
            

            Console.WriteLine("Average: {0}, Did lines exceed 2: {1}", ConvertMinutes(avg), Flag);
            Console.ReadKey();
        }





    }
}
