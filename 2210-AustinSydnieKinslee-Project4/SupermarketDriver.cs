using System;

namespace _2210_AustinSydnieKinslee_Project4
{
    public class SupermarketDriver
    {
        public static double TimeOpen = 0;
        public static double ExpectedCheckoutTime = 0;
        public static int NumOfCustomers = 0;
        public static int NumOfRegisters = 0;
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
                        GetCustomers();
                        break;
                    case 2: 
                        GetHours();
                        break;
                    case 3: 
                        GetRegisters();
                        break;
                    case 4: 
                        GetCheckoutTime();
                        break;
                    case 5: 
                        RunSimulation();
                        break;
                    case 6: 
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        Enviornment.Exit(0);
                        break;
                }

                choice = menu.GetChoice();

            }
        }

        private static void GetCustomers()
        {
            Console.Clear();
            Console.WriteLine("How many customers will be served in a day?\n");
            
            try
            {
                NumOfCustomers = Convert.ToInt32(Console.ReadLine());
                if (NumOfCustomers <= 0)
                {
                   NumOfCustomers = 0;
                   Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                }
            }
            catch(Exception e)
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
                if (TimeOpen <= 0)
                {
                   TimeOpen = 0;
                   Console.WriteLine("Invalid Input. Please enter a number greater than 0. ");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Input. Please enter a number greater than 0.");
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
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Input. Please enter a number greater than 0.");
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
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Input. Please enter a number greater than 0.");
            }        }

        private static void RunSimulation()
        {
            Console.Clear();
            if(NumOfRegisters == 0 || NumOfCustomers == 0 || TimeOpen == 0 || ExpectedCheckoutTime == 0)
            {
                Console.WriteLine("You need to set the number of customers, number of registers, hours open, and expected time to check out before" + 
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
