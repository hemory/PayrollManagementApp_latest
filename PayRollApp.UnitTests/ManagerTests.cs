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
        public void CalculateTotalPayAlwaysReturnsCorrectTotalPay()
        {
            //arrange
            UserTimeSheet entry1 = new UserTimeSheet
            {
                DateOfWork = DateTime.Now,
                HoursWorked = 40

            };

            UserTimeSheet entry2 = new UserTimeSheet
            {
                DateOfWork = DateTime.Now,
                HoursWorked = 45

            };

            Manager sut = new Manager("john", "doe");
            sut.UserTimeSheets.Add(entry1);
            sut.UserTimeSheets.Add(entry2);

            //act
            double actual = sut.CalculateTotalPay();

            //assert
            Assert.AreEqual(4350, actual);
        }
    }
}
