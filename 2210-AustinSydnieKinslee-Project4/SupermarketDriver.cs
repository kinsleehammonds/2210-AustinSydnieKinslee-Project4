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
        //all helping properties
        private static double TimeOpen = 0;
        private static double ExpectedCheckoutTime = 0;
        private static int NumOfCustomers = 0;
        private static int NumOfRegisters = 0;

        #region Main Driver
        /// <summary>
        ///  Main method to run the program that allows user input and output
        /// </summary>
        /// <param name="args">array of strings called args</param>
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

        #endregion

        #region Methods Called From Driver

        /// <summary>
        /// Validates the input to make sure no incorrect input could be put in
        /// </summary>
        private static void GetCustomers()
        {
            //clears the console
            Console.Clear();

            //ask user question
            Console.WriteLine("How many customers will be served in a day?\n");
            
            try
            {
                //converts the user input into an int  to allow it to be used 
                NumOfCustomers = Convert.ToInt32(Console.ReadLine());

                //if that nubmer is less than 0
                if (NumOfCustomers <= 0)
                {
                    //keep the num the same and tellt he user to retry
                    NumOfCustomers = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();

                }//end if
            }
            catch(Exception)        //catch anythign that is not a number
            {
                //tell the user that is not allowed
                Console.WriteLine("Invalid Input. Please enter a number greater than 0.");
                Console.ReadKey();

            }//end try catch

        }//end GetCustomers

        /// <summary>
        /// Validates the input to make sure no incorrect input could be put in
        /// </summary>
        private static void GetHours()
        {
            //clears console and ask user question
            Console.Clear();
            Console.WriteLine("How many hours will the store be open?\n(16 hours and 30 minutes would be 16.5)\n");

            //try catch
            try
            {
                //converts the input into a double to be used
                TimeOpen = Convert.ToDouble(Console.ReadLine());

                //if that input is less than 0
                if (TimeOpen <= 0 )
                {
                    //keep the timeopen the same and tell the user to try again
                    TimeOpen = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();
                }
                else if (TimeOpen > 24)     //if is is greater than 24 hours
                {
                    //keep the timeopen the same and tell the user to try again
                    TimeOpen = 0;
                    Console.WriteLine("Invalid Input. The is not more than 24 hours in a day");
                    Console.ReadKey();

                }//end if else if
            }
            catch(Exception)            //catch any input other than numbers
            {
                //tell the user that it is invalid
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();

            }//try catch

        }//end GetHours

        /// <summary>
        /// Validates the input to make sure no incorrect input could be put in
        /// </summary>
        private static void GetRegisters()
        {
            //clears console and ask user question
            Console.Clear();
            Console.WriteLine("How many registers will there be?\n");

            //try catch
            try
            {
                //converst the input into an int to be used
                NumOfRegisters = Convert.ToInt32(Console.ReadLine());

                //if the registers are less than or 0 
                if (NumOfRegisters <= 0)
                {
                    //keep the default value and tells the user it was invalid
                    NumOfRegisters = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();

                }//end if
            }
            catch(Exception)            //catches any input other than a number
            {
                //tells the user that, that was invalid data
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();

            }//end try catch

        }//end GetNumOfRegisters

        /// <summary>
        /// Validates the input to make sure no incorrect input could be put in
        /// </summary>
        private static void GetCheckoutTime()
        {
            //clears console and ask user question
            Console.Clear();
            Console.WriteLine("What is the expected checkout duration in minutes?\n(5 minutes and 30 seconds would be 5.5)\n");

            //end try catch
            try
            {
                //converst the input into a double to be used
                ExpectedCheckoutTime = Convert.ToDouble(Console.ReadLine());

                //if the input is less than or 0 
                if(ExpectedCheckoutTime <= 0)
                {
                    //keeps the default and tells the user it was invalid input
                    ExpectedCheckoutTime = 0;
                    Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                    Console.ReadKey();

                }//end if

            }
            catch(Exception)            //catches anything that is not a number
            {

                //tells the user that the input was invalid
                Console.WriteLine("Invalid Input. The input has to be a number.");
                Console.ReadKey();

            }//end catch

        }//end GetCheckoutTime

        /// <summary>
        /// Method to return a message that tells the user if they have not set any values needed
        /// to run the simulation
        /// </summary>
        /// <returns>string of what values need to be set</returns>
        public static string WhatValuesAreNotSet()
        {
            string str = null;
            if(NumOfCustomers == 0) //if the customer value is empty
            {
                str += "You need to set the number of customers.\n";
            }
            if(NumOfRegisters == 0)//if the register value is empty
            {
                str += "You need to set the number of registers.\n";
            }
            if(TimeOpen == 0)//if the hours the store is open is empty
            {
                str += "You need to set the number of hours the store will be open.\n";
            }
            if(ExpectedCheckoutTime == 0) //if the expected checkout time is empty
            {
                str += "You need to set the expected average checkout time for the customers.\n";
            }

            return str;
        }//end method

        /// <summary>
        /// Validates the input to make sure no incorrect input could be put in, 
        /// if everything is good it will run the whole simulation
        /// </summary>
        private static void RunSimulation()
        {
            //clears the console
            Console.Clear();

            //if any of the values are 0 
             if(WhatValuesAreNotSet() != null) 
            {
                Console.WriteLine(WhatValuesAreNotSet()); //tell the user what values they need to set
                Console.ReadKey();
            }
            else //if all the values have been entered
            {

                //creates a supermarket with all the values 
                SuperMarket supermarket = new SuperMarket(NumOfCustomers, TimeOpen, NumOfRegisters, ExpectedCheckoutTime);
                supermarket.RunSuperMarket();

                //sets a boolean to get out of while loop
                bool yes = false;

                //clears the console
                Console.Clear();

                //ask user if they want a new simulation, the same one, or just to exit the program
                Console.WriteLine("Would you like to try another simulation, keep the current simulation or, exit? " +
                    "\nType Yes (New Simulation), No (Same simulation), or Exit (Exits Program):");

                //sets input to a string
                string choice = Console.ReadLine();

                //while yes is not true
                while (!yes)
                {
                    if (choice.ToUpper() == "YES")      //if the choice is yes
                    {
                        //reset all the values to default
                        NumOfRegisters = 0;
                        NumOfCustomers = 0;
                        TimeOpen = 0;
                        ExpectedCheckoutTime = 0;

                        //clear the console and tell the user that everything has been reset
                        Console.Clear();
                        Console.WriteLine("All the values have been set back to 0.");
                        yes = true;                                                         //gets out of loop
                        Console.ReadKey();
                    }
                    else if (choice.ToUpper() == "NO")      //if choice is no
                    {
                        //keeps the same values and clear the console and tell the user everything remains the same
                        Console.Clear();
                        Console.WriteLine("All the values are the same.");
                        yes = true;
                        Console.ReadKey();
                    }
                    else if (choice.ToUpper() == "EXIT")        //if choice is exit
                    {
                        Console.Clear();                        //clears the console and tell the user goodbye
                        Console.WriteLine("Goodbye!");
                        yes = true;                             //stops loop
                        Console.ReadKey();
                        Environment.Exit(0);                    //exits the program
                        
                    }
                    else            //invalid data input
                    {
                        //tells the user to try again (keeps looping until the user puts in valid data
                        Console.Clear();
                        Console.WriteLine("Invalid response. Please type: Yes, No, or Exit.");
                        Console.ReadKey();
                        yes = false;            //keeps looping

                    }//end if else
                    
                }//end while

            }//end if else

        }//end RunSimulation

        #endregion

    }//end SupermarketDriver

}//end Namespace
