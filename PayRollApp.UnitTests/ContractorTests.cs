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
    [TestFixture]
    class ContractorTests
    {
        [Test]
        public void CalculateTotalPayAlwaysReturnsTotalPay()
        {
            //arrange
            Contractor sut = new Contractor
            {
                HoursWorked = 40,
                HourlyRate = 30
            };


            //act
            double answer = sut.CalculateTotalPay();

            //assert
            Assert.That(answer,Is.EqualTo(1200));
        }

        [Test]
        public void CalculateTotalPayAlwaysReturnsTotalPayWithOverTime()
        {
            //arrange
            Contractor sut = new Contractor
            {
                HoursWorked = 45,
                HourlyRate = 30
            };


            //act
            double answer = sut.CalculateTotalPay();

            //assert
            Assert.That(answer, Is.EqualTo(1575));
        }

    }
}
