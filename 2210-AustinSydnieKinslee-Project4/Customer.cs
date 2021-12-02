///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         Customer.cs
//	Description:       Define a Customer class that creates a customer object with an ID, register number, what time
//                             time the customer enters the register line, and how long it takes the customer to be 
//                              served once they are the first in line. 
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

namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// Defines the Customer class to create a Customer with a random arrival time and a random(negative exponential) 
    /// time it takes the customer to be served.
    /// </summary>
    public class Customer
    {
        private static Random rand = new Random(); //random object to generate a random time the customer gets in line

        public int ID { get; set; } //hold the customer's id
        public int ArrivalTime { get; set; } //hold the arrival time of the customer
        public int TimeToBeServed { get; set; } //hold how long it takes the customer to be served
        public int RegisterNumber { get; set; } //hold what register the customer is at
        public double HoursOpen { get; set; } //hold how long the store is open
        public double ExpectedTimeToBeServed { get; set; } //hold the average amount of time all customers take to be served

        /// <summary>
        /// Empty Constructor for the Customer class
        /// </summary>
        public Customer()
        {
            ID = -1; 
            RegisterNumber = -1;
            HoursOpen = 8;
            ExpectedTimeToBeServed = 4.5;
            DecideTimes();
        }//end method

        /// <summary>
        /// Constructor that uses the hoursOpen parameter to help determine the ArrivalTime of the customer, and 
        /// expectedTimeToBeServed param to help determine the TimeToBeServed for the customer. And sets the id param as
        /// the customer's ID
        /// </summary>
        /// <param name="hoursOpen">double of how many hours the store is open</param>
        /// <param name="expectedTimeToBeServed">double of how many minutes it takes the customer to be served</param>
        /// <param name="id">the ID number for the customer</param>
        public Customer(double hoursOpen, double expectedTimeToBeServed, int id)
        {
            ID = id;
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedTimeToBeServed;
            DecideTimes();
        }//end method

        /// <summary>
        /// Method to find the random number that is the customer's arrival time and the negative exponential random of the 
        /// time it takes the customer to be served. 
        /// </summary>
        public void DecideTimes()
        {
            if (HoursOpen < 24)
            {
                int secondsOpen = Convert.ToInt32(HoursOpen * 3600); //convert the hours open to seconds open
                int secondsExpectedTimeToBeServed = Convert.ToInt32(ExpectedTimeToBeServed * 60); //convert the expected time to be served in minutes to seconds
                ArrivalTime = rand.Next(secondsOpen) + 28800; //assume in all situations that the store opens at 8 am. Find a random time after that for the customer to get in line
                TimeToBeServed = Convert.ToInt32(NegExp(secondsExpectedTimeToBeServed - 120) + 120); //Convert the double from the negative exponential to get a random amount of time it takes the customer to be served
            }
            else
                throw new Exception("The store cannot be open for more than 24 hours. Please enter a new amount of hours open."); //throw an exception if the user enters in information saying the store is open for more than 24 hours
        }//end method

        /// <summary>
        /// CODE BY DON BAILES
        /// </summary>
        /// <param name="ExpectedValue">The average of the negative exponential</param>
        /// <returns></returns>
        private Double NegExp(int ExpectedValue)
        {

            return -ExpectedValue * Math.Log(rand.NextDouble(), Math.E);

        }//end method


    }//end class
}
