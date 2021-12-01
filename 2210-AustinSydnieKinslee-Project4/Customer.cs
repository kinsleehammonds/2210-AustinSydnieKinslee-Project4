using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class Customer : IEquatable
    {
        Random rand = new Random();

        public int ID { get; set; }
        public int ArrivalTime { get; set; }
        public int TimeToBeServed { get; set; }
        public int RegisterNumber { get; set; }
        public int HoursOpen { get; set; }
        public int ExpectedTimeToBeServed { get; set; }

        public Customer()
        {
            RegisterNumber = -1;
            HoursOpen = 8;
            DecideTimes();
        }
        public Customer(double hoursOpen, double expectedTimeToBeServed)
        {
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedTimeToBeServed;
            DecideTimes();
        }

        public void DecideTimes()
        {
            int secondsOpen = HoursOpen * 3600;
            ArrivalTime = rand.Next(secondsOpen) + 28800;
            TimeToBeServed = Convert.ToInt32(NegExp(345 - 120));

        }

        private Double NegExp(int ExpectedValue)
        {

            return -ExpectedValue * Math.Log(rand.NextDouble(), Math.E);

        }

        public bool Equals(Customer other)
        {
            return this.ID.Equals(other.ID);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);
            if (!(obj is Customer))
                throw new ArgumentException("");

            return Equals(obj as Customer);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        //it's not a lot but I can't figure out what else it might need

    }
}
