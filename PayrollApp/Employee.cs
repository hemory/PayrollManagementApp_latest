namespace PayrollApp
{
    public class Employee
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public string Name { get; set; }
        public double TotalPay { get; set; }

        public Employee()
        {
            HourlyRate = 20.75;
        }

        public double CalculateTotalPay()
        {
            TotalPay = HoursWorked * HourlyRate;
            return TotalPay;
        }

    }
}
