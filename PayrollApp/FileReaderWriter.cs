using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PayrollApp
{
    public class FileReaderWriter
    {

        private static readonly string EmployeeRepoPath = Path.Combine(Directory.GetCurrentDirectory(), "employee_repo");
        private static readonly string ContractorRepoPath = Path.Combine(Directory.GetCurrentDirectory(), "contractor_repo");
        private static readonly string ManagerRepoPath = Path.Combine(Directory.GetCurrentDirectory(), "manager_repo");

        public static void CreateNewUser(string fullUserPath, string staffHours)
        {
            string dateOfEntry = DateTime.Now.ToShortDateString();

            using (StreamWriter sw = File.AppendText(fullUserPath))
            {
                sw.WriteLine($"{dateOfEntry}|{staffHours}");
            }
        }

        public static void WriteToUserFile(string fullUserPath, string staffHours)
        {
            string dateOfEntry = DateTime.Now.ToShortDateString();

            using (StreamWriter sw = File.AppendText(fullUserPath))
            {
                sw.WriteLine($"{dateOfEntry}|{staffHours}");
            }
        }

        public static List<UserTimeSheet> GetTimeSheetData(string path)
        {
            List<UserTimeSheet> userTimeSheetData = new List<UserTimeSheet>();

            string[] lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                UserTimeSheet timeSheetEntry = new UserTimeSheet();

                string[] userTimeSheetArray = line.Split('|');

                timeSheetEntry.DateOfWork = Convert.ToDateTime(userTimeSheetArray[0]);
                timeSheetEntry.HoursWorked = Convert.ToDouble(userTimeSheetArray[1]);

                userTimeSheetData.Add(timeSheetEntry);
            }

            return userTimeSheetData;
        }

        public static bool CheckIfUserExistsInRepo(string firstName, string lastName, string repoPath,
            out string fullUserPath)
        {

            string pathToCheckFor =
                $@"{repoPath}\{firstName}{lastName}.txt";

            var filePaths = Directory.GetFiles(repoPath);

            fullUserPath = pathToCheckFor;

            if (filePaths.Contains(pathToCheckFor))
            {
                return true;
            }

            return false;
        }

        public static string UpdateUserRepoPath(string firstName, string lastName, string repoPath)
        {
            return $@"{repoPath}\{firstName}{lastName}.txt";
        }

        public static string AssignWorkingPath(string roleChoice)
        {
            string workingPath = "";

            if (roleChoice == "m")
            {
                workingPath = ManagerRepoPath;
            }

            if (roleChoice == "e")
            {
                workingPath = EmployeeRepoPath;
            }

            if (roleChoice == "c")
            {
                workingPath = ContractorRepoPath;
            }

            return workingPath;
        }
    }
}
