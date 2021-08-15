using System;
using System.Collections.Generic;

namespace PayrollApp
{
    public class Employee :IWorker
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


        public virtual double CalculateTotalPay()
        {
            double totalHoursWorked = 0;
            foreach (var entry in UserTimeSheets)
            {
                totalHoursWorked += entry.HoursWorked;
            }


            TotalPay = totalHoursWorked * HourlyRate;
            return TotalPay;
        }

        public virtual void ViewTimeSheet()
        {
            Console.WriteLine("---Timesheet---".PadLeft(20).PadRight(20));
            foreach (var entry in UserTimeSheets)
            {
                Console.WriteLine(
                    $"Date: {entry.DateOfWork.ToShortDateString()} Hours: {entry.HoursWorked}");
            }
            Console.WriteLine("---------------".PadLeft(20).PadRight(20));
            Console.WriteLine($"Total take home is {CalculateTotalPay():C}");        }
    }
}
