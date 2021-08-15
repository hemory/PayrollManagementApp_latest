using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PayrollApp;
using System.Collections.Generic;
using System.IO;

namespace PayRollApp.UnitTests
{
    [TestFixture()]
    class FileReaderWriterTests
    {
        [Test]
        public void CreateNewUserAddsNewTextFile()
        {
            //arrange
            string userPath = @"C:\Users\hphif\RiderProjects\PayRoll_App\PayrollManagementApp\PayRollApp.UnitTests\TestTextFiles\janedoe.txt";

            //act

           FileReaderWriter.CreateNewUser(userPath,"40");

            //assert
            Assert.AreEqual(File.Exists(userPath), true);

            //Cleans up file
            File.Delete(userPath);
        }

        [Test]
        public void WriteToUserFileAddsEntryToTextFile()
        {
            //arrange
            string userPath = @"C:\Users\hphif\RiderProjects\PayRoll_App\PayrollManagementApp\PayRollApp.UnitTests\TestTextFiles\janedoe.txt";

            //act

            FileReaderWriter.WriteToUserFile(userPath,"40");
           string[] actual = File.ReadAllLines(userPath);

            //assert
            Assert.AreEqual(actual[actual.Length-1],$"{DateTime.Now.ToShortDateString()}|40");

        }

        [Test]
        public void GetTimeSheetDataReturnsTimeSheetData()
        {
            //arrange
            string userPath = @"C:\Users\hphif\RiderProjects\PayRoll_App\PayrollManagementApp\PayRollApp.UnitTests\TestTextFiles\janedoe.txt";

            //act

          List<UserTimeSheet> actualData = FileReaderWriter.GetTimeSheetData(userPath);

            //assert
            Assert.AreEqual(actualData[0].HoursWorked, 40);
        }

        [Test]
        public void UpdateUserRepoPathReturnsUpdatedPath()
        {
            //arrange
            string userPath = @"C:\Users\hphif\RiderProjects\PayRoll_App\PayrollManagementApp\PayRollApp.UnitTests\TestTextFiles\janedoe.txt";

            //act

            string actual = FileReaderWriter.UpdateUserRepoPath("janet", "doe", userPath);

            //assert
            Assert.AreEqual(actual, @"C:\Users\hphifer\source\repos\PayRollApp_v2\PayRollApp_v2\PayrollAppCSharp\PayRollApp.UnitTests\TestTextFiles\janetdoe.txt");
            
        }

        //todo test for AssignWorkingPath
        //todo test for CheckIfUserExistsInRepo

    }
}
