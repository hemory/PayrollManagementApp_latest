using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PayrollApp;

namespace PayRollApp.UnitTests
{
    [TestFixture()]
    class FileReaderWriterTests
    {
        [Test]
        public void GetEmployeeListAlwaysReturnsExpectedResult()
        {
            //arrange
            FileReaderWriter sut = new FileReaderWriter();
         string employeePath = @"C:\Users\hphifer\source\repos\PayRollApp\PayrollAppCSharp\PayrollApp\text_files\employee.txt";

         //act

        List<Employee> actualEmployList = sut.GetEmployeeList(employeePath);
        bool isPopulated = actualEmployList.Count > 0;

        //assert
        Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void GetManagerListAlwaysReturnsExpectedResult()
        {
            //arrange
            FileReaderWriter sut = new FileReaderWriter();
            string managerPath = @"C:\Users\hphifer\source\repos\PayRollApp\PayrollAppCSharp\PayrollApp\text_files\manager.txt";
        

            //act

            List<Manager> actualManagerList = sut.GetManagerList(managerPath);
            bool isPopulated = actualManagerList.Count > 0;

            //assert
            Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void GetContractorListAlwaysReturnsExpectedResult()
        {
            //arrange
            FileReaderWriter sut = new FileReaderWriter();
           
            string contractorPath = @"C:\Users\hphifer\source\repos\PayRollApp\PayrollAppCSharp\PayrollApp\text_files\contractor.txt";

            //act

            List<Contractor> actualContractorList = sut.GetContractorList(contractorPath);
            bool isPopulated = actualContractorList.Count > 0;

            //assert
            Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void WriteStaffHoursToTextFile()
        {
            //arrange
            FileReaderWriter sut = new FileReaderWriter();
            string managerPath = @"C:\Users\hphifer\source\repos\PayRollApp\PayrollAppCSharp\PayrollApp\text_files\manager.txt";

            //act
            sut.WriteStaffHoursToTextFile("m", "frijole", "40");
           List<Manager> actualManagerList = sut.GetManagerList(managerPath);

            //assert

            bool didWrite = false;

            foreach (var manager in actualManagerList)
            {
                if (manager.Name == "frijole" && manager.HoursWorked == 40)
                {
                    didWrite = true;
                }
            }

            Assert.That(didWrite, Is.EqualTo(true));
        }
    }
}
