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
    class ManagerTests
    {
        [Test]
        public void CalculateTotalPayAlwaysReturnsExpectedResult()
        {
            //arrange
            Manager sut = new Manager
            {
                HourlyRate = 50,
                HoursWorked = 40,
                Allowances = 100
            };

            //act
            double answer = sut.CalculateTotalPay();

            //assert
            Assert.That(answer, Is.EqualTo(2100));
        }
    }
}
