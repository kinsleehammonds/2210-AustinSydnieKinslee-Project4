///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  Project 4 - SuperMarket Simulation
//	File Name:         SuperMarketDriver.cs
//	Description:       Runs the menu and user input and output.
//	Course:            CSCI 2210 - Data Structures	
//	Author:            Austin Hamilton, hamiltonaj@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Sydnie Dery, derysf@etsu.edu, Dept. of Computing, East Tennessee State University
//                     Kinslee Hammonds, hammondsk1@etsu.edu, Dept. of Computing, East Tennessee State University
//	Created:           Monday, November 22, 2021
//	Copyright:         Austin Hamilton, Sydnie Dery, Kinslee Hammonds, 2021
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

/// <summary>
/// The namespace for the project
/// </summary>
namespace _2210_AustinSydnieKinslee_Project4
{
    /// <summary>
    /// The driver which runs all user input
    /// </summary>
    public class SupermarketDriver
    {
        public static double TimeOpen = 0;
        public static double ExpectedCheckoutTime = 0;
        public static int NumOfCustomers = 0;
        public static int NumOfRegisters = 0;
        static void Main(string[] args)
        {
            //creates a new menue and adds all the choices
            Menu menu = new Menu("Super Market Simulation");
            menu = menu + "Set number of Customers" + "Set number of hours of operation" + "Set number of registers"
                        + "Set the expected checkout duration" + "Run the simulation" + "End the program";

            int choice = menu.GetChoice(); //have user choose what they want to do

            //while the choice is not the exit choice
            while(choice != 6)
            {
                //switch to control where the users input goes
                switch(choice)
                { 
                    case 1:
                        GetCustomers();         //calls getcustomers method
                        break;
                    case 2: 
                        GetHours();             //calls gethours method
                        break;
                    case 3: 
                        GetRegisters();         //calls getregisters method
                        break;
                    case 4: 
                        GetCheckoutTime();      //calls getcheckouttime method
                        break;
                    case 5: 
                        RunSimulation();        //cals the runsimulation method
                        break;

                }//end switch

                choice = menu.GetChoice();          //gets the choice of the user (makes sure it goes back to the menu)

            }//end while

            Console.Clear();                        //clears the console and tell the user goodbye
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
            Environment.Exit(0);                    //exits the program

        }//end driver 
            
        /// <summary>
        /// Validate the input to make sure no incorrect input could be put in
        /// </summary>
        private static void GetCustomers()
        {
            //clears the console
            Console.Clear();

            //ask user question
            Console.WriteLine("How many customers will be served in a day?\n");
            
            try
            {
                //converts the user input into an int 
                NumOfCustomers = Convert.ToInt32(Console.ReadLine());
                if (NumOfCustomers <= 0)
                {
                   NumOfCustomers = 0;
                   Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid Input. Please enter a number greater than 0.");
            }

        }

        private static void GetHours()
        {
            Console.Clear();
            Console.WriteLine("How many hours will the store be open?\n(16 hours and 30 minutes would be 16.5)\n");

            try
            {
                TimeOpen = Convert.ToDouble(Console.ReadLine());

                if (TimeOpen <= 0 )
                {
                    TimeOpen = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();
                }
                else if (TimeOpen > 24)
                {
                    TimeOpen = 0;
                    Console.WriteLine("Invalid Input. The is not more than 24 hours in a day");
                    Console.ReadKey();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();
            }
        }

        private static void GetRegisters()
        {
            Console.Clear();
            Console.WriteLine("How many registers will there be?\n");
            try
            {
                NumOfRegisters = Convert.ToInt32(Console.ReadLine());
                if (NumOfRegisters <= 0)
                {
                    NumOfRegisters = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();
            }
        }

        private static void GetCheckoutTime()
        {
            Console.Clear();
            Console.WriteLine("What is the expected checkout duration in minutes?\n(5 minutes and 30 seconds would be 5.5)\n");
            try
            {
                ExpectedCheckoutTime = Convert.ToDouble(Console.ReadLine());
                if(ExpectedCheckoutTime <= 0)
                {
                    ExpectedCheckoutTime = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();
                }

            }
            catch(Exception)
            {
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();
            }        

        }

        private static void RunSimulation()
        {
            Console.Clear();
            if(NumOfRegisters == 0 || NumOfCustomers == 0 || TimeOpen == 0 || ExpectedCheckoutTime == 0)
            {
                Console.WriteLine("You need to set the number of customers, number of registers, hours open, \nand expected time to check out before" + 
                    "the simulation can be ran.");
                Console.ReadKey();
            }
            else
            {
                SuperMarket supermarket = new SuperMarket(NumOfCustomers, TimeOpen, NumOfRegisters, ExpectedCheckoutTime);
                supermarket.RunSuperMarket();
            }
        }
    }
}
