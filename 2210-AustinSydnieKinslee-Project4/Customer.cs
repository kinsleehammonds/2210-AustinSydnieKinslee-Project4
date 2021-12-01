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
        public double HoursOpen { get; set; }
        public double ExpectedTimeToBeServed { get; set; }

        public Customer()
        {
            ID = -1;
            RegisterNumber = -1;
            HoursOpen = 8;
            ExpectedTimeToBeServed = 4.5;
            DecideTimes();
        }
        public Customer(double hoursOpen, double expectedTimeToBeServed, int id)
        {
            ID = id;
            HoursOpen = hoursOpen;
            ExpectedTimeToBeServed = expectedTimeToBeServed;
            DecideTimes();
        }

        public void DecideTimes()
        {
            if(HoursOpen > 24)
            {
                int secondsOpen = HoursOpen * 3600;
                int secondsExpectedTimeToBeServed = ExpectedTimeToBeServed * 3600;
                ArrivalTime = rand.Next(secondsOpen) + 28800; //assume in all situations that the store opens at 8 am. 
                TimeToBeServed = Convert.ToInt32(NegExp(secondsExpectedTimeToBeServed) + 120) ;
            }
            else
            {
                MessageBox.Show("The store cannot be open for more than 24 hours. Please enter a new amount of hours open.");
            }

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
