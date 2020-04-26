namespace PayrollApp
{
    public class Contractor
    {
        public double HourlyRate { get; set; }
        public double HoursWorked { get; set; }
        public string Name { get; set; }
        public double BasePay { get; set; }
        public double TotalPay { get; set; }
        public double OvertimeRate { get; set; }
        public double OvertimeHours { get; set; }

        public Contractor()
        {
            HourlyRate = 30;
        }

        public double CalculateTotalPay()
        {
            BasePay = HoursWorked * HourlyRate;
            TotalPay = BasePay + CalculateOvertimeRate();

            return TotalPay;
        }

        //Private because its only used in class
        private double CalculateOvertimeRate()
        {
            double overTimeTotal = 0;
            OvertimeRate = 30 * 1.5; 
            if (HoursWorked > 40)
            {
                OvertimeHours = HoursWorked - 40;
                overTimeTotal = OvertimeHours * OvertimeRate;
            }

            return overTimeTotal;
        }

    }
}
