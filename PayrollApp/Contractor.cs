using System;
using System.Collections.Generic;

namespace PayrollApp
{
    public class Contractor
    {
        public double HourlyRate { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double BasePay { get; set; }
        public double TotalPay { get; private set; }
        public double OvertimeRate { get; private set; }
        public List<UserTimeSheet> UserTimeSheets { get; set; }

        public Contractor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = 30;
            UserTimeSheets = new List<UserTimeSheet>();

        }

        public double CalculateTotalPay()
        {
            List<double> totalForEachEntryList = new List<double>();

            foreach (var entry in UserTimeSheets)
            {
                double hoursOver40 = entry.HoursWorked - 40;

                if (hoursOver40 < 0)
                {
                    hoursOver40 = 0;
                }

                BasePay = (entry.HoursWorked - hoursOver40) * HourlyRate;
                TotalPay = BasePay + CalculateOvertimeRate(hoursOver40);
                totalForEachEntryList.Add(TotalPay);
            }

            double timeSheetTotal = 0;


            foreach (var total in totalForEachEntryList)
            {
                timeSheetTotal += total;

            }


            return timeSheetTotal;
        }

        //Private because its only used in class
        private double CalculateOvertimeRate(double hoursOver40)
        {
            OvertimeRate = 30 * 1.5;

            double overTimeTotal = hoursOver40 * OvertimeRate;


            return overTimeTotal;
        }

        public void ViewContractorTimeSheet()
        {
            Console.WriteLine("---Timesheet---".PadLeft(20).PadRight(20));
            foreach (var entry in UserTimeSheets)
            {
                Console.WriteLine(
                    $"Date: {entry.DateOfWork.ToShortDateString()} Hours: {entry.HoursWorked}");
            }
            Console.WriteLine("---------------".PadLeft(20).PadRight(20));
            Console.WriteLine($"Total take home is {CalculateTotalPay():C}");
        }
    }
}