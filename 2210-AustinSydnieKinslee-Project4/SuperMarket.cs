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

/// <summary>
/// The namespace for the project
/// </summary>
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
        public int NumOfCustomers { get; set; }
        private double Average { get; set; }
        private int Arrivals { get; set; }
        private int Departures { get; set; }
        private readonly List<Customer> customers = new List<Customer>();
        private readonly List<Queue<Customer>> lines = new List<Queue<Customer>>();
        private readonly PriorityQueue<Event> events = new PriorityQueue<Event>();

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
            NumOfCustomers = 100;

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
            NumOfCustomers = numOfCustomers;
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedWaitTime;
            for (int i = 0; i < numOfRegisters; i++)
                lines.Add(new Queue<Customer>());

        }//end Supermarket

        #endregion

        #region Supporting Methods
        /// <summary>
        /// Generates all the customers 
        /// </summary>
        /// <param name="numOfCustomer">the number of customers to be brought in</param>
        public void GenerateCustomers()
        {
            //loops through each number to generate the right amount of customers
            for(int i = 0; i < NumOfCustomers; i++)
            {
                //creates a new customer
                Customer newCustomer = new Customer(HoursOpen, ExpectedTimeToBeServed, i + 1);

                //adds that customer to the a customer list
                customers.Add(newCustomer);

            }//end for loop

        }//end GenerateCustomers

        /// <summary>
        /// Adds the events and typer of events to the events priority queue
        /// </summary>
        public void AddEvents()
        {
            //foreach of the customers in the customers list
            foreach(Customer c in customers)
            {
                //creates new events and setting the customers arrival time to the enter event
                Event arrival = new Event(EVENTTYPE.ENTER, c.ArrivalTime, c);
                Event leave = new Event(EVENTTYPE.LEAVE, c.ArrivalTime + c.TimeToBeServed, c);      //arrival + how long the 
                                                                                                    //customer will take to be served
                events.Enqueue(arrival);               //add events to priority queue
                events.Enqueue(leave);

            }//end foreach

        }//end AddEvents


        /// <summary>
        /// Handles the enter and leave events
        /// </summary>
        /// <param name="e"></param>
        public void HandleEvent(Event e)
        {
            int line = 0;               //sets an property to a starter value

            //if the event is an enter typer
            if(e.Type == EVENTTYPE.ENTER)
            {
                //adds 1 to the arrivals 
                Arrivals++;

                //for all the registers
                for(int i = 0; i < lines.Count; i++)
                {
                    //if the current register is less than the line register
                    if (lines[i].Count < lines[line].Count)
                        line = i;                               //set line to the current register 
                                                                //allowing the user to get in the line with the stotest line
                }//end for loop

                lines[line].Enqueue(e.Customer);            //gets that queue and puts a customer into it
                e.Customer.RegisterNumber = line;           //sets the register number of that customer to the line number

                //if the line count is greater than 3
                if (lines[line].Count > 2)
                    Flag = true;                    //flag this so the user knows it should be changed

                if (LongestLine == 0)               //if the longest line is 0 add 1
                    LongestLine++;
                else if (lines[line].Count > LongestLine)   //else the longest line is less than the current line
                    LongestLine = lines[line].Count;         //resert the longest line

            }
            else
            {
                //add 1 to departures
                Departures++;

                //if the count of the current line is equal to 1
                if(lines[e.Customer.RegisterNumber].Count == 1)
                {
                    //dequeue that customer and store them in a holder value
                    Customer lineCustomer = lines[e.Customer.RegisterNumber].Dequeue();

                    //if the min is equal to 0 or it is greater than the current time that is being served
                    if (Min == 0 || Min > lineCustomer.TimeToBeServed)
                        Min = lineCustomer.TimeToBeServed;              //reset the min value to the smaller value

                    //if the max value is equal to 0 of it is less than the current time that is being served
                    if (Max == 0 || lineCustomer.TimeToBeServed > Max)
                        Max = lineCustomer.TimeToBeServed;              //reset the max value to the greater value
                
                    //keep adding all the times to be served (later to be divide to find the average)
                    Average += lineCustomer.TimeToBeServed;
                }
                else if(lines[e.Customer.RegisterNumber].Count > 1)         //if the count of the line is greater than 1
                {
                    //dequeue the customer and store in a holder customer
                    Customer lineCustomer = lines[e.Customer.RegisterNumber].Dequeue();

                    //same min, max, and average methods as above
                    if (Min == 0 || Min > lineCustomer.TimeToBeServed)
                        Min = lineCustomer.TimeToBeServed;

                    if (Max == 0 || lineCustomer.TimeToBeServed > Max)
                        Max = lineCustomer.TimeToBeServed;

                    Average += lineCustomer.TimeToBeServed;

                    //add the current customers time it took to be served to the next customer 
                    lines[e.Customer.RegisterNumber].Peek().TimeToBeServed += lineCustomer.TimeToBeServed;
                    
                }//end if else if

            }//end if else

        }//end HandleEvents

        /// <summary>
        /// This method will covert the seconds into 
        /// minutes and seconds 
        /// </summary>
        /// <param name="seconds">the seconds to be converted</param>
        /// <returns></returns>
        public string ConvertMinutes(int seconds)
        {
            string msg = "";                //string holder to the return value

            int mins = (int)seconds / 60;    //divides the second by 60 to return the amount of minutes
            
            //formats value so if the number is less than 0 it will add a 0 infront
            if (mins < 10)
                msg += "0" + mins;
            else
                msg += mins;

            msg += ":";     //adds a colon to make a cleaner look

            int secs = seconds % 60;           //mods the seconds by 60 to get the remainder left of the previous division
            if (secs < 10)
                msg += "0" + secs;
            else
                msg += secs;


            return msg;     //returns the string

        }//end ConvertMinutes

        /// <summary>
        /// Prints out the format of the Supermarket Simulation
        /// </summary>
        public void PrintSupermarket()
        {
            Console.Clear();                                        //Clears the window for clean look
            Console.ForegroundColor = ConsoleColor.White;           //Sets the font to white

            Console.WriteLine("\tRegistration Window" +           
                              "\n--------------------------------");        //A write line method to add a title and lines 

            //for all the lines
            for (int i = 0; i < lines.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;               //set the font to white
                Console.Write("Line {0}: ", i + 1);                         //writes the line and line number

                Console.ForegroundColor = ConsoleColor.Red;                 //sets font to red to showcase the customers

                //for each customer in the each queue in each register
                foreach (Customer c in lines[i])
                {
                    //adds a 0 if the customers id is less than 10
                    if(c.ID < 10)
                        Console.Write("0" + c.ID + " ");
                    else
                        Console.Write(c.ID + " ");

                }//end foreach

                Console.WriteLine();                        //moves to the next line

            }//end for loop

            Console.ForegroundColor = ConsoleColor.White;                               //sets the font back to white and adds lines
            Console.WriteLine("--------------------------------");                  

            //showcases the other values that have been calculated
            Console.WriteLine("Longest Queue Entered So Far: {0}", LongestLine);
            Console.WriteLine("\n\n\t\tEvents Processed So Far: {0}", Arrivals + Departures);
            Console.WriteLine("\t\tArrivals: {0}", Arrivals);
            Console.WriteLine("\t\tDepartures: {0}", Departures);
            
        }//end Print SuperMarket

        #endregion

        #region Running Supermarket Method

        /// <summary>
        /// Runs the whole supermarket to allow the driver just to call this method
        /// </summary>
        public void RunSuperMarket()
        {
            GenerateCustomers();
            AddEvents();                //adds all the events to the priority queue

            //while there is still events
            while(events.Count > 0)
            {
                HandleEvent(events.Peek());         //handle the first event
                events.Dequeue();                   //take that event away
                PrintSupermarket();                 //print it

                Thread.Sleep(100);                  //show the user for 100 millisecond

            }//end while

            //calculates the average and converts to in to allow it be converted to minutes
            int avg = Convert.ToInt32(Average /= customers.Count);

            //Writes the average, if the lines exceeded 2 and the min and max values
            Console.WriteLine("\nAverage: {0}. Did lines exceed 2: {1}.", ConvertMinutes(avg), Flag);
            Console.WriteLine("Min: {0}, Max: {1}", ConvertMinutes(Min), ConvertMinutes(Max));

            //allows the user to read what on the console
            Console.ReadKey();                              

        }//end RunSupermarket

        #endregion

    }//end SuperMarket

}//end namespace
