using System;
using System.Collections.Generic;
using Microsoft.SqlServer.Server;

namespace PayrollApp
{
    public class Manager
    {
        public double HourlyRate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double BasePay { get; set; }
        public double TotalPay { get; set; }
        public double Bonus { get; set; }
        public List<UserTimeSheet> UserTimeSheets { get; set; }


        public Manager(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = 50.00;
            Bonus = 100.00;
            UserTimeSheets = new List<UserTimeSheet>();
        }

        public double CalculateTotalPay()
        {
            double totalHoursWorked = 0;
            foreach (var entry in UserTimeSheets)
            {
                totalHoursWorked += entry.HoursWorked;
            }

            BasePay = totalHoursWorked * HourlyRate;

            TotalPay = BasePay + Bonus;

            return TotalPay;
        }

        public void ViewManagerTimeSheet()
        {
            Console.WriteLine("---Timesheet---".PadLeft(20).PadRight(20));
            foreach (var timeSheet in UserTimeSheets)
            {
                Console.WriteLine(
                    $"Date: {timeSheet.DateOfWork.ToShortDateString()} Hours: {timeSheet.HoursWorked}");
            }
            Console.WriteLine("---------------".PadLeft(20).PadRight(20));
            Console.WriteLine($"Total take home is {CalculateTotalPay():C}");
        }

    }
}

