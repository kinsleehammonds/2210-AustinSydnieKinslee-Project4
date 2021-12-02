///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         Event.cs
//	Description:       Contains to calsses and enum and regular Event class. 
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The namespace for the project
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// Sets the event types
    /// </summary>
    public enum EVENTTYPE { ENTER, LEAVE };

    /// <summary>
    /// Sets the events and then set the way the objects should be compared
    /// </summary>
    public class Event : IComparable
    {
        public EVENTTYPE Type { get; set; }
        public int Time { get; set; }
        public Customer Customer { get; set; }

        /// <summary>
        /// Parameterized Constructor 
        /// </summary>
        /// <param name="type">type of event to be set</param>
        /// <param name="time">time to be set</param>
        /// <param name="customer">the customer being brought in</param>
        public Event(EVENTTYPE type, int time, Customer customer)
        {
            //sets all the values to the ones being brought in
            Type = type;
            Time = time;
            Customer = customer;

        }//end Event

        /// <summary>
        /// Compares the objects by the time
        /// </summary>
        /// <param name="obj">object being brought in</param>
        /// <returns></returns>
        public int CompareTo(Object obj)
        {
            //if it is not an event throw an exception
            if (!(obj is Event))
                throw new ArgumentException("The argument is not an Event object");

            //if is is set the obj to an event
            Event e = (Event)obj;
            return e.Time.CompareTo(Time);      //compare by the times

        }//end CompareTo

    }//end Event

}//end Namespace
