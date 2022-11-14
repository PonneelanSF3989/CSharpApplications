using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentPayRoll
{
    public class EmployeeDetails
    {
        private static int s_empID = 1000;
        public string EmployeeID { get;  }
        public string EmployeeName { get; set; }
        public string EmployeeRoll { get; set; }
        public Enum WorkLocation { get; set; }
        public string EmployeeTeamName { get; set; }
        public DateTime JoiningDate { get; set; }
        
        public EmployeeDetails (string name, string roll, Enum location, string teamName, DateTime doj )
        {
            s_empID++;
            EmployeeID = "" + s_empID;
            EmployeeName = name;
            EmployeeRoll = roll;
            WorkLocation = location;
            EmployeeTeamName = teamName;
            JoiningDate = doj;
        }
        public EmployeeDetails(){}
        
        public int  CalculateSalary(int totalWorkingsDaysInMonth, int leaveTakenInMonth)
        {
            int salary = (totalWorkingsDaysInMonth - leaveTakenInMonth) * 500;

            return salary;
        }
        
        
        
        
        
        
    }
}