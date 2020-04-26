using System;

namespace PayrollApp
{
    public class PrintStaffReport
    {
        private readonly string employeePath = "C:\\Users\\hphifer\\source\\repos\\PayrollApp\\PayrollApp\\text_files\\employee.txt";
        private readonly string managerPath = "C:\\Users\\hphifer\\source\\repos\\PayrollApp\\PayrollApp\\text_files\\manager.txt";
        private readonly string contractorPath = "C:\\Users\\hphifer\\source\\repos\\PayrollApp\\PayrollApp\\text_files\\contractor.txt";

        readonly FileReaderWriter fileReader = new FileReaderWriter();


        public void PrintEmployeeReport()
        {
            var employeeList = fileReader.GetEmployeeList(employeePath);


            foreach (var item in employeeList)
            {
                Console.WriteLine($"{item.Name} will earn {item.CalculateTotalPay()} this pay period.");
            }
        }

        public void PrintManagerReport()
        {
            var managerList = fileReader.GetManagerList(managerPath);


            foreach (var item in managerList)
            {
                Console.WriteLine($"{item.Name} will earn {item.CalculateTotalPay()} this pay period.");
            }

        }

        public void PrintContractorReport()
        {
            var contractorList = fileReader.GetContractorList(contractorPath);

            foreach (var item in contractorList)
            {
                Console.WriteLine($"{item.Name} will earn {item.CalculateTotalPay()} this pay period.");
            }
        }

    }
}
