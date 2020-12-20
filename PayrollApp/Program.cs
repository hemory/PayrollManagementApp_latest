using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PayrollApp
{
    class Program
    {
        static void Main(string[] args)
        {
           


            Console.WriteLine("Welcome to the Pay Roll App");
            //Thread.Sleep(1000);

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine().ToLower().Trim();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine().ToLower().Trim();

            Console.WriteLine("Are you a [M]anager [E]mployee [C]ontractor ?");
            string roleChoice = Console.ReadLine().Trim();

            string workingPath = FileReaderWriter.AssignWorkingPath(roleChoice);

            bool userExists = FileReaderWriter.CheckIfUserExistsInRepo(firstName, lastName, workingPath, out string fullUserPath);


            //manager flow
            if (roleChoice == "m")
            {

                if (userExists)
                {
                    while (true)
                    {
                        Manager manager = new Manager(firstName, lastName)
                        {
                            UserTimeSheets = FileReaderWriter.GetTimeSheetData(firstName, lastName, fullUserPath)
                        };


                        Console.WriteLine("[1]View Time sheet [2]Add Entry [3] View Staff Time Sheets");
                        string userChoice = Console.ReadLine();

                        switch (userChoice)
                        {
                            case "1":

                               manager.ViewManagerTimeSheet();

                                break;

                            case "2":


                                Console.Write("Enter Hours: ");
                                string staffHours = Console.ReadLine().ToLower().Trim();

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                break;

                            case "3":

                                Console.WriteLine("View [E]mployee [C]ontractor");
                                string managerViewChoice = Console.ReadLine().ToLower().Trim();

                                Console.WriteLine("First Name");
                                firstName = Console.ReadLine().ToLower().Trim();

                                Console.WriteLine("Last Name");
                                lastName = Console.ReadLine().ToLower().Trim();


                                workingPath = FileReaderWriter.AssignWorkingPath(managerViewChoice);

                                userExists = FileReaderWriter.CheckIfUserExistsInRepo(firstName, lastName, workingPath, out string fullPath);


                                if (userExists)
                                {
                                    if (managerViewChoice == "e")
                                    {
                                        Employee employee = new Employee(firstName, lastName)
                                        {
                                            UserTimeSheets = FileReaderWriter.GetTimeSheetData(firstName, lastName, fullPath)
                                        };

                                        employee.ViewEmployeeTimeSheet();
                                    }

                                    if (managerViewChoice == "c")
                                    {
                                        Contractor contractor = new Contractor(firstName, lastName)
                                        {
                                            UserTimeSheets = FileReaderWriter.GetTimeSheetData(firstName, lastName, fullPath)
                                        };


                                        contractor.ViewContractorTimeSheet();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No data found...");
                                }

                                break;

                            default:
                                Console.WriteLine("Please make a valid entry.");
                                break;

                        }

                        Console.WriteLine("Return to menu? [y] or [n]");
                        string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                        if (returnToMainMenu != "y")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No record is found... Would you like to create a profile? [y] or [n]");
                    string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();

                    if (choiceToCreateAProfile == "y")
                    {
                        Console.WriteLine(
                            $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}");
                        Console.Write("Confirm (y)es or (n): ");
                        string confirmName = Console.ReadLine().ToLower().Trim();

                        if (confirmName == "n")
                        {
                            Console.Clear();
                            Console.Write("Enter your first name: ");
                            firstName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(firstName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                firstName = Console.ReadLine().ToLower().Trim();
                            }

                            Console.Write("Enter your last name: ");
                            lastName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(lastName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                lastName = Console.ReadLine().ToLower().Trim();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Great, lets add your first time sheet entry.");

                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            FileReaderWriter.CreateNewUser(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");
                        }
                    }

                }
            }


            //employee flow
            if (roleChoice == "e")
            {

                if (userExists)
                {
                    while (true)
                    {
                        Employee employee = new Employee(firstName, lastName)
                        {
                            UserTimeSheets = FileReaderWriter.GetTimeSheetData(firstName, lastName, fullUserPath)
                        };


                        Console.WriteLine("[1]View Time sheet [2]Add Entry");
                        string userChoice = Console.ReadLine();

                        switch (userChoice)
                        {
                            case "1":

                                employee.ViewEmployeeTimeSheet();

                                break;

                            case "2":

                                Console.Write("Enter Hours: ");
                                string staffHours = Console.ReadLine().ToLower().Trim();

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                break;

                            default:
                                Console.WriteLine("Please make a valid entry.");
                                break;
                        }

                        Console.WriteLine("Return to menu? [y] or [n]");
                        string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                        if (returnToMainMenu != "y")
                        {
                            break;
                        }

                    }



                }
                else
                {
                    Console.WriteLine("No record is found... Would you like to create a profile? [y] or [n]");
                    string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();

                    if (choiceToCreateAProfile == "y")
                    {
                        Console.WriteLine(
                            $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}");
                        Console.Write("Confirm (y)es or (n): ");
                        string confirmName = Console.ReadLine().ToLower().Trim();

                        if (confirmName == "n")
                        {
                            Console.Clear();
                            Console.Write("Enter your first name: ");
                            firstName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(firstName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                firstName = Console.ReadLine().ToLower().Trim();
                            }

                            Console.Write("Enter your last name: ");
                            lastName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(lastName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                lastName = Console.ReadLine().ToLower().Trim();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Great, lets add your first time sheet entry.");

                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");
                        }
                    }

                }
            }

            //contractor flow
            if (roleChoice == "c")
            {
                if (userExists)
                {
                    while (true)
                    {
                        Contractor contractor = new Contractor(firstName, lastName)
                        {
                            UserTimeSheets = FileReaderWriter.GetTimeSheetData(firstName, lastName, fullUserPath)
                        };



                        Console.WriteLine("[1]View Time sheet [2]Add Entry");
                        string userChoice = Console.ReadLine();

                        switch (userChoice)
                        {
                            case "1":

                                contractor.ViewContractorTimeSheet();

                                break;

                            case "2":


                                Console.Write("Enter Hours: ");
                                string staffHours = Console.ReadLine().ToLower().Trim();

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                break;

                            default:
                                Console.WriteLine("Please make a valid entry.");
                                continue;
                        }

                        Console.WriteLine("Return to menu? [y] or [n]");
                        string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                        if (returnToMainMenu != "y")
                        {
                            break;
                        }

                    }

                }
                else
                {
                    Console.WriteLine("No record is found... Would you like to create a profile? [y] or [n]");
                    string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();

                    if (choiceToCreateAProfile == "y")
                    {
                        Console.WriteLine(
                            $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}");
                        Console.Write("Confirm (y)es or (n): ");
                        string confirmName = Console.ReadLine().ToLower().Trim();

                        if (confirmName == "n")
                        {
                            Console.Clear();
                            Console.Write("Enter your first name: ");
                            firstName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(firstName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                firstName = Console.ReadLine().ToLower().Trim();
                            }

                            Console.Write("Enter your last name: ");
                            lastName = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(lastName))
                            {
                                Console.WriteLine("Input can't be empty! Enter your input once more");
                                lastName = Console.ReadLine().ToLower().Trim();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Great, lets add your first time sheet entry.");

                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");
                        }
                    }

                }
            }


            Console.WriteLine("Press an key to exit");
            Console.ReadLine();
        }
    }
}
