using NUnit.Framework;
using NUnit.Framework.Internal;
using PayrollApp;
using System.Collections.Generic;

namespace PayRollApp.UnitTests
{
    [TestFixture()]
    class FileReaderWriterTests
    {
        [Test]
        public void GetEmployeeListAlwaysReturnsExpectedResult()
        {
            //arrange
            string employeePath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\employeeTest.txt";

            //act

            List<Employee> actualEmployList = FileReaderWriter.GetEmployeeList(employeePath);
            bool isPopulated = actualEmployList.Count > 0;

            //assert
            Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void GetManagerListAlwaysReturnsExpectedResult()
        {
            //arrange
            string managerPath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\managerTest.txt";


            //act

            List<Manager> actualManagerList = FileReaderWriter.GetManagerList(managerPath);
            bool isPopulated = actualManagerList.Count > 0;

            //assert
            Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void GetContractorListAlwaysReturnsExpectedResult()
        {
            //arrange

            string contractorPath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\contractorTest.txt";

            //act

            List<Contractor> actualContractorList = FileReaderWriter.GetContractorList(contractorPath);
            bool isPopulated = actualContractorList.Count > 0;

            //assert
            Assert.That(isPopulated, Is.EqualTo(true));
        }

        [Test]
        public void WriteStaffHoursToTextFile()
        {
            //arrange
            string managerPath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\writerTest.txt";

            string contractorPath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\writerTest.txt";

            string employeePath = @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\writerTest.txt";

            //act
            FileReaderWriter.WriteStaffHoursToTextFile("m", "frijole", "40",managerPath,employeePath,contractorPath);
            List<Manager> actualManagerList = FileReaderWriter.GetManagerList(managerPath);

            bool didWrite = false;

            foreach (var manager in actualManagerList)
            {
                if (manager.Name == "frijole" && manager.HoursWorked == 40)
                {
                    didWrite = true;
                }
            }

            //assert

            Assert.IsTrue(didWrite);
        }
    }
}
