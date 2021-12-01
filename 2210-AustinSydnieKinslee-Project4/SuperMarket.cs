using System;
using System.Collections.Generic;
using System.Text;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SuperMarket
    {
        List<Queue<Customer>> lines = new List<Queue<Customer>>();
        PriorityQueue<Event> events = new PriorityQueue<Event>();


        public SuperMarket()
        {

        }

        public SuperMarket(int numOfCustomers)
        {

        }
    }
}
