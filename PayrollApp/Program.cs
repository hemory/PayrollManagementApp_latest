using System;
using System.Threading;

namespace PayrollApp
{
    class Program
    {
        static void Main(string[] args)
        {

            FileReaderWriter fileReaderWriter = new FileReaderWriter();
            PrintStaffReport staffReport = new PrintStaffReport();


            Console.WriteLine("Welcome to the Pay Roll App");
            Thread.Sleep(1000);

            Console.WriteLine("Please tell us are you a manager? Enter (y)es or (n)o");
            string amAManager = Console.ReadLine().ToLower().Trim();

            Console.Clear();

            if (amAManager == "y")
            {
                string viewMenuAgain = string.Empty;
                bool toExit;

                do
                {
                    toExit = UIUtility.ViewManagerMenu(staffReport, fileReaderWriter);

                    if (toExit != true)
                    {
                        Console.WriteLine("Go back to Manager Menu?");
                        Console.WriteLine("Enter (y)es or (n)o");
                        viewMenuAgain = Console.ReadLine().ToLower().Trim(); 
                    }

                    Console.Clear();

                } while (viewMenuAgain == "y" && toExit != true);

                Console.WriteLine("Goodbye");
                Thread.Sleep(1000);

            }
            else if (amAManager == "n")
            {
                string viewMenuAgain;
                do
                {
                    Console.WriteLine("Would you like to add hours for (e)mployee or (c)ontractor?");
                    string staffChoice = Console.ReadLine().ToLower().Trim();

                    Console.WriteLine("What is the name of the staff you want to add?");
                    string staffName = Console.ReadLine().ToLower().Trim();

                    Console.WriteLine("How many hours did this staff member work?");
                    string staffHours = Console.ReadLine().ToLower().Trim();

                    fileReaderWriter.WriteStaffHoursToTextFile(staffChoice, staffName, staffHours);

                    Console.Clear();

                    Console.WriteLine("Would you like to add more staff hours?");
                    Console.WriteLine("Enter (y)es or (n)o");
                    viewMenuAgain = Console.ReadLine().ToLower().Trim();
                    Console.Clear();

                } while (viewMenuAgain == "y");

                Console.WriteLine("Goodbye");
                Thread.Sleep(1000);

            }
         


        }

       

    }
}
