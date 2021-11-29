using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class Customer
    {
        Random rand = new Random();
        public int ArrivalTime { get; set; }
        public int TimeToBeServed { get; set; }

        public Customer(int openTime, int closeTime)
        {
            DecideTimes();
        }

        public void DecideTimes(int timeOpen)
        {
            ArrivalTime = rand.Next(secondsOpen) + 28800;
            TimeToBeServed = Convert.ToInt32(NegExp(345 - 120));

        }

        private Double NegExp(int ExpectedValue)
        {

            return -ExpectedValue * Math.Log(rand.NextDouble(), Math.E);

        }

        //it's not a lot but I can't figure out what else it might need

    }
}
