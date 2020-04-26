using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PayrollApp
{
   public class UIUtility
    {
        
        public static bool ViewManagerMenu(PrintStaffReport staffReport, FileReaderWriter fileReaderWriter)
        {
            bool toExit = false;

            Console.WriteLine("Please select from the following:");
            Console.WriteLine("[1]View Staff Salary Reports");
            Console.WriteLine("[2]Add Employees and their Hours");
            Console.WriteLine("[3]Exit");
            string menuChoice = Console.ReadLine();


            Console.Clear();

            switch (menuChoice)
            {
                case "1":
                    while (true)
                    {
                        Console.WriteLine("Which Employee list would you like to see: (E)mployee (M)anager or (C)ontractor?");
                        string managerChoice = Console.ReadLine().ToLower().Trim();

                        Console.Clear();

                        ChoiceForManagerReport(staffReport, managerChoice);

                        Console.WriteLine(Environment.NewLine);

                        Console.WriteLine($"Would you like to view another report? {Environment.NewLine}");
                        Console.WriteLine($"Enter (y)es to continue or press ENTER to go back to Main Menu. {Environment.NewLine}");

                        string viewAnotherReport = Console.ReadLine().ToLower().Trim();

                        if (viewAnotherReport != "y")
                        {
                            Console.Clear();
                            break;
                        }

                        Console.Clear();
                    }
                    break;
                case "2":
                    while (true)
                    {

                        Console.WriteLine("What is the name of the staff you want to add?");
                        string staffName = Console.ReadLine().ToLower().Trim();

                        Console.WriteLine("How many hours did this staff member work?");
                        string staffHours = Console.ReadLine().ToLower().Trim();


                        Console.WriteLine("Adding for (M)anager or (E)mployee (C)ontractor");
                        string staffChoice = Console.ReadLine().ToLower().Trim();

                        fileReaderWriter.WriteStaffHoursToTextFile(staffChoice, staffName, staffHours);



                        Console.WriteLine("Would you like to add another? Enter (y)es to continue or press ENTER to go back to the Main Menu.");
                        string addAnother = Console.ReadLine().ToLower().Trim();

                        if (addAnother != "y")
                        {
                            break;
                        }
                    }

                    break;
                case "3":
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(1000);
                    toExit = true;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option");
                    break;
            }

            return toExit;

        }

        public static void ChoiceForManagerReport(PrintStaffReport staffReport, string managerChoice)
        {

            switch (managerChoice)
            {
                case "e":
                    staffReport.PrintEmployeeReport();
                    break;
                case "m":
                    staffReport.PrintManagerReport();
                    break;

                case "c":
                    staffReport.PrintContractorReport();
                    break;

                default:
                    Console.WriteLine("Please choose a valid option");

                    break;
            }
        }
    }
}
