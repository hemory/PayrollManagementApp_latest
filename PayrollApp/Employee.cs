using System;
using System.Collections.Generic;

namespace PayrollApp
{
    public class Employee
    {
        public double HourlyRate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double TotalPay { get; set; }
        public List<UserTimeSheet> UserTimeSheets { get; set; }

        public Employee(string firstName, string lastName)
        {
            HourlyRate = 20.75;
            FirstName = firstName;
            LastName = lastName;
            UserTimeSheets = new List<UserTimeSheet>();
        }


        public double CalculateTotalPay()
        {
            double totalHoursWorked = 0;
            foreach (var entry in UserTimeSheets)
            {
                totalHoursWorked += entry.HoursWorked;
            }


            TotalPay = totalHoursWorked * HourlyRate;
            return TotalPay;
        }

        public void ViewEmployeeTimeSheet()
        {
            foreach (var entry in UserTimeSheets)
            {
                Console.WriteLine(
                    $"Date: {entry.DateOfWork.ToShortDateString()} Hours: {entry.HoursWorked}");
            }

            Console.WriteLine($"Total take home is {CalculateTotalPay():C}");
        }

    }
}
