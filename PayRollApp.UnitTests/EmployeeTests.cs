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
        public void CalculateTotalPayAlwaysReturnsExpectedResult()
        {
            //arrange
          Employee sut = new Employee
          {
              HourlyRate = 20.75,
              HoursWorked = 40
          };

            //act
            double answer = sut.CalculateTotalPay();

            //assert
            Assert.That(answer, Is.EqualTo(830));
        }
    }
}
