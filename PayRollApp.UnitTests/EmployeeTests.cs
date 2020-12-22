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
    class EmployeeTests
    {
        [Test]
        public void CalculateTotalPayAlwaysReturnsCorrectTotalPay()
        {
            //arrange
            UserTimeSheet entry1 = new UserTimeSheet
            {
                DateOfWork = DateTime.Now,
                HoursWorked = 40

            };

            Employee sut = new Employee("john", "doe");
            sut.UserTimeSheets.Add(entry1);

            //act
            double actual = sut.CalculateTotalPay();

            //assert
            Assert.AreEqual(830, actual);
        }

    }
}
