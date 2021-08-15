using System;
using System.Threading;

namespace PayrollApp
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Welcome to the Pay Roll App");
            ClearTimer(1000);

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine().ToLower().Trim();

            while (string.IsNullOrEmpty(firstName))
            {
                Console.Write("Input can't be empty! Enter your input once more: ");
                firstName = Console.ReadLine().ToLower().Trim();
            }

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine().ToLower().Trim();

            while (string.IsNullOrEmpty(lastName))
            {
                Console.Write("Input can't be empty! Enter your input once more: ");
                lastName = Console.ReadLine().ToLower().Trim();
            }

            //Main Menu

            Console.Write("Are you a [M]anager [E]mployee [C]ontractor: ");
            string roleChoice = Console.ReadLine().Trim();

            bool notValidChoice = roleChoice != "m" && roleChoice != "e" && roleChoice != "c";

            while (string.IsNullOrEmpty(roleChoice) || notValidChoice )
            {
                Console.Write("Input must be a choice of m, e, or c. Input must not be empty: ");
                roleChoice = Console.ReadLine().ToLower().Trim();
                notValidChoice = roleChoice != "m" && roleChoice != "e" && roleChoice != "c";
            }

            string workingPath = FileReaderWriter.AssignWorkingPath(roleChoice);

            bool userExists = FileReaderWriter.CheckIfUserExistsInRepo(firstName, lastName, workingPath, out string fullUserPath);


            ClearTimer(1000);

          
                //manager flow
                if (roleChoice == "m")
                {

                    if (userExists)
                    {
                        while (true)
                        {
                            Manager manager = new Manager(firstName, lastName)
                            {
                                UserTimeSheets = FileReaderWriter.GetTimeSheetData(fullUserPath)
                            };


                            Console.Write("[1]View Time sheet [2]Add Entry [3] View Staff Time Sheets: ");
                            string userChoice = Console.ReadLine();

                            ClearTimer(1000);

                            switch (userChoice)
                            {
                                case "1":

                                    manager.ViewTimeSheet();

                                    break;

                                case "2":


                                    Console.Write("Enter Hours: ");
                                    string staffHours = Console.ReadLine().ToLower().Trim();

                                    while (string.IsNullOrEmpty(staffHours))
                                    {
                                        Console.Write("Input can't be empty! Enter your input once more: ");
                                        staffHours = Console.ReadLine().ToLower().Trim();
                                    }

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                    break;

                                case "3":

                                    Console.Write("View [E]mployee [C]ontractor: ");
                                    string managerViewChoice = Console.ReadLine().ToLower().Trim();
                                    ClearTimer(1000);
                                    Console.Write("First Name: ");
                                    firstName = Console.ReadLine().ToLower().Trim();

                                    Console.Write("Last Name: ");
                                    lastName = Console.ReadLine().ToLower().Trim();

                                    ClearTimer(1000);
                                    workingPath = FileReaderWriter.AssignWorkingPath(managerViewChoice);

                                    userExists = FileReaderWriter.CheckIfUserExistsInRepo(firstName, lastName, workingPath, out string fullPath);


                                    if (userExists)
                                    {
                                        if (managerViewChoice == "e")
                                        {
                                            Employee employee = new Employee(firstName, lastName)
                                            {
                                                UserTimeSheets = FileReaderWriter.GetTimeSheetData(fullPath)
                                            };

                                            employee.ViewTimeSheet();
                                        }

                                        if (managerViewChoice == "c")
                                        {
                                            Contractor contractor = new Contractor(firstName, lastName)
                                            {
                                                UserTimeSheets = FileReaderWriter.GetTimeSheetData(fullPath)
                                            };


                                            contractor.ViewTimeSheet();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No data found...");
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Please make a valid entry.");
                                    continue;

                            }

                            ClearTimer(2000);

                            Console.Write("Return to menu? [y] or any other key to exit: ");
                            string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                            if (returnToMainMenu != "y")
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.Write("No record is found... Would you like to create a profile? [y] or any other key to exit: ");
                        string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();

                        ClearTimer(1000);

                        if (choiceToCreateAProfile == "y")
                        {
                            Console.Write(
                                $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}: ");
                            Console.Write("Hit any key to confirm or (n) to update info: ");
                            string confirmName = Console.ReadLine().ToLower().Trim();

                            ClearTimer(1000);

                            if (confirmName == "n")
                            {
                                Console.Clear();
                                Console.Write("Enter your first name: ");
                                firstName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(firstName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    firstName = Console.ReadLine().ToLower().Trim();
                                }

                                Console.Write("Enter your last name: ");
                                lastName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(lastName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    lastName = Console.ReadLine().ToLower().Trim();
                                }

                                fullUserPath = FileReaderWriter.UpdateUserRepoPath(firstName, lastName, workingPath);


                                ClearTimer(1000);
                            }

                            Console.WriteLine("Great, lets add your first time sheet entry.");
                            ClearTimer(1000);

                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(staffHours))
                            {
                                Console.Write("Input can't be empty! Enter your input once more: ");
                                staffHours = Console.ReadLine().ToLower().Trim();
                            }

                        ClearTimer(1000);
                            FileReaderWriter.CreateNewUser(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");

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
                                UserTimeSheets = FileReaderWriter.GetTimeSheetData(fullUserPath)
                            };


                            Console.Write("[1]View Time sheet [2]Add Entry: ");
                            string userChoice = Console.ReadLine();

                            ClearTimer(1000);
                            switch (userChoice)
                            {
                                case "1":

                                    employee.ViewTimeSheet();

                                    break;

                                case "2":

                                    Console.Write("Enter Hours: ");
                                    string staffHours = Console.ReadLine().ToLower().Trim();

                                    while (string.IsNullOrEmpty(staffHours))
                                    {
                                        Console.Write("Input can't be empty! Enter your input once more: ");
                                        staffHours = Console.ReadLine().ToLower().Trim();
                                    }

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                    break;

                                default:
                                    Console.WriteLine("Please make a valid entry.");
                                    continue;
                            }
                            ClearTimer(2000);


                        Console.Write("Return to menu? [y] or any other key to exit: ");
                        string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                            if (returnToMainMenu != "y")
                            {
                                break;
                            }

                        }



                    }
                    else
                    {
                    Console.Write("No record is found... Would you like to create a profile? [y] or any other key to exit: ");
                    string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();
                        ClearTimer(1000);
                        if (choiceToCreateAProfile == "y")
                        {
                            Console.Write(
                                $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}: ");

                        Console.Write("Hit any key to confirm or (n) to update info: ");

                        string confirmName = Console.ReadLine().ToLower().Trim();
                            ClearTimer(1000);
                            if (confirmName == "n")
                            {
                                Console.Clear();
                                Console.Write("Enter your first name: ");
                                firstName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(firstName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    firstName = Console.ReadLine().ToLower().Trim();
                                }

                                Console.Write("Enter your last name: ");
                                lastName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(lastName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    lastName = Console.ReadLine().ToLower().Trim();
                                }

                                fullUserPath = FileReaderWriter.UpdateUserRepoPath(firstName, lastName, workingPath);

                                ClearTimer(1000);
                            }

                            Console.WriteLine("Great, lets add your first time sheet entry.");
                            ClearTimer(1000);
                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(staffHours))
                            {
                                Console.Write("Input can't be empty! Enter your input once more: ");
                                staffHours = Console.ReadLine().ToLower().Trim();
                            }

                        ClearTimer(1000);
                            FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");

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
                                UserTimeSheets = FileReaderWriter.GetTimeSheetData(fullUserPath)
                            };



                            Console.Write("[1]View Time sheet [2]Add Entry: ");
                            string userChoice = Console.ReadLine();

                            ClearTimer(1000);
                            switch (userChoice)
                            {
                                case "1":

                                    contractor.ViewTimeSheet();

                                    break;

                                case "2":


                                    Console.Write("Enter Hours: ");
                                    string staffHours = Console.ReadLine().ToLower().Trim();

                                    while (string.IsNullOrEmpty(staffHours))
                                    {
                                        Console.Write("Input can't be empty! Enter your input once more: ");
                                        staffHours = Console.ReadLine().ToLower().Trim();
                                    }

                                FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                                    break;

                                default:
                                    Console.WriteLine("Please make a valid entry.");
                                    continue;
                            }

                            ClearTimer(2000);
                        Console.Write("Return to menu? [y] or any other key to exit: ");
                        string returnToMainMenu = Console.ReadLine().ToLower().Trim();

                            if (returnToMainMenu != "y")
                            {
                                break;
                            }

                        }

                    }
                    else
                    {

                    Console.Write("No record is found... Would you like to create a profile? [y] or any other key to exit: ");
                    string choiceToCreateAProfile = Console.ReadLine().Trim().ToLower();
                        ClearTimer(1000);
                        if (choiceToCreateAProfile == "y")
                        {
                            Console.Write(
                                $"Please confirm that your first name is {firstName.ToUpper()} and your last name is {lastName.ToUpper()}: ");
                        Console.Write("Hit any key to confirm or (n) to update info: ");
                        string confirmName = Console.ReadLine().ToLower().Trim();
                            ClearTimer(1000);
                            if (confirmName == "n")
                            {
                                Console.Clear();
                                Console.Write("Enter your first name: ");
                                firstName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(firstName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    firstName = Console.ReadLine().ToLower().Trim();
                                }

                                Console.Write("Enter your last name: ");
                                lastName = Console.ReadLine().ToLower().Trim();

                                while (string.IsNullOrEmpty(lastName))
                                {
                                    Console.Write("Input can't be empty! Enter your input once more: ");
                                    lastName = Console.ReadLine().ToLower().Trim();
                                }

                                fullUserPath = FileReaderWriter.UpdateUserRepoPath(firstName, lastName, workingPath);

                                ClearTimer(1000);
                            }


                            Console.WriteLine("Great, lets add your first time sheet entry.");
                            ClearTimer(1000);
                            Console.Write("Enter Hours: ");
                            string staffHours = Console.ReadLine().ToLower().Trim();

                            while (string.IsNullOrEmpty(staffHours))
                            {
                                Console.Write("Input can't be empty! Enter your input once more: ");
                                staffHours = Console.ReadLine().ToLower().Trim();
                            }

                        ClearTimer(1000);
                            FileReaderWriter.WriteToUserFile(fullUserPath, staffHours);

                            Console.WriteLine("Thank you for your entry, please log back in to get user features.");

                        }

                    }
                } 
            


            Console.WriteLine("Press an key to exit");
            Console.ReadLine();
        }

        private static void ClearTimer(int time)
        {
            Thread.Sleep(time);
            Console.Clear();
        }
    }
}
