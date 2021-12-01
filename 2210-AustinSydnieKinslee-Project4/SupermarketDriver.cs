using System;

namespace _2210_AustinSydnieKinslee_Project4
{
    class SupermarketDriver
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("Super Market Simulation");
            menu = menu + "Set number of Customers" + "Set number of hours of operation" + "Set number of registers";
            menu = menu + "Set the expected checkout duration" + "Run the simulation" + "End the program";
            int choice = menu.GetChoice(); //have user choose what they want to do

            while(choice != 6)
            {
                switch(choice)
                { 
                    case 1:
                        break;
                    case
                }

            }
        }
    }
}
