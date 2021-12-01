///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         SuperMarket.cs
//	Description:       Creates all the supporting methods and one method that will run all of those supporting 
//                          methods.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Austin Hamilton, hamiltonaj@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Sydnie Dery, derysf@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Kinslee Hammonds, hammondsk1@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, November 22, 2021
//	Copyright:         Austin Hamilton, Sydnie Dery, Kinslee Hammonds, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SuperMarket 
    {
        #region Properties 

        private int Min { get; set; }
        private int Max { get; set; }
        private int LongestLine { get; set; }
        private bool Flag { get; set; }
        private double HoursOpen { get; set; }
        private double ExpectedTimeToBeServed { get; set; }
        private double Average { get; set; }
        private int Arrivals { get; set; }
        private int Departures { get; set; }
        private List<Customer> customers = new List<Customer>();
        private List<Queue<Customer>> lines = new List<Queue<Customer>>();
        private PriorityQueue<Event> events = new PriorityQueue<Event>();

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SuperMarket()
        {
            //Setting default values to be changed later
            Min = 0;
            Max = 0;
            Average = 0;
            LongestLine = 0;
            Flag = false;

            //Setting values to be tested easier
            ExpectedTimeToBeServed = 4.5;
            HoursOpen = 16;
            Arrivals = 0; 
            Departures = 0;

            //Generating all the customer
            GenerateCustomers(100);

            //adding the queues to the list
            for (int i = 0; i < 2; i++)
                lines.Add(new Queue<Customer>());

        }//end SuperMarket

        
        /// <summary>
        /// The parameterized constructor
        /// </summary>
        /// <param name="numOfCustomers">the number of customers to be added</param>
        /// <param name="hoursOpen">the hours the store will be open</param>
        /// <param name="numOfRegisters">the number of registers open at the store</param>
        /// <param name="expectedWaitTime">the time a customer is expected to be served</param>
        public SuperMarket(int numOfCustomers, double hoursOpen, int numOfRegisters, double expectedWaitTime)
        {
            //Setting default values to be changed later
            Min = 0;
            Max = 0;
            Average = 0;
            LongestLine = 0;
            Flag = false;

            //Setting all the values to input by the user
            GenerateCustomers(numOfCustomers);
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedWaitTime;
            for (int i = 0; i < numOfRegisters; i++)
                lines.Add(new Queue<Customer>());

        }//end Supermarket

        #endregion

        /// <summary>
        /// Generates all the customers 
        /// </summary>
        /// <param name="numOfCustomer">the number of customers to be brought in</param>
        public void GenerateCustomers(int numOfCustomer)
        {
            //loops through each number to generate the right amount of customers
            for(int i = 0; i < numOfCustomer; i++)
            {
                //creates a new customer
                Customer newCustomer = new Customer(HoursOpen, ExpectedTimeToBeServed, i + 1);

                //adds that customer to the a customer list
                customers.Add(newCustomer);

            }//end for loop

        }//end GenerateCustomers

        /// <summary>
        /// 
        /// </summary>
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Registration Window" +
                 "\n--------------------------------");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Line {0}: ", i + 1);

                Console.ForegroundColor = ConsoleColor.Red;
                foreach (Customer c in lines[i])
                {
                    if(c.ID < 10)
                        Console.Write("0" + c.ID + " ");
                    else
                        Console.Write(c.ID + " ");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Longest Queue Entered So Far: {0}", LongestLine);
            Console.WriteLine("\n\n\t\tEvents Processed So Far: {0}", Arrivals + Departures);
            Console.WriteLine("\t\tArrivals: {0}", Arrivals);
            Console.WriteLine("\t\tDepartures: {0}", Departures);
            
        }

        public void RunSuperMarket()
        {
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
            

            Console.WriteLine("\nAverage: {0}, Did lines exceed 2: {1}", ConvertMinutes(avg), Flag);
            Console.WriteLine("Min: {0}, Max: {1}", ConvertMinutes(Min), ConvertMinutes(Max));
            Console.ReadKey();
        }





    }
}
