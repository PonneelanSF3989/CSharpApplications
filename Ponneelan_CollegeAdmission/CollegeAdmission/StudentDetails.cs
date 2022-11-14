using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class StudentDetails
    {
        private static int s_registrationId = 3000;         //feild
        public string RegistraionId { get; }        //property
        public string StudentName { get; set; }     //autoproperty
        public string FatherName { get; set; }
        public DateTime Dob { get; set; }
        public string StudentGender { get; set; }
        public string MailId { get; set; }
        public int PhysicsMark { get; set; }
        public int ChemistryMark { get; set; }
        public int MathsMark { get; set; }
        
        
        // public StudentDetails()
        // {
        //     Console.WriteLine("default constructor initialized");
        // }

        public StudentDetails(string studentName,string fatherName,DateTime dob,string gender,string mailId,int physicsName,int chemeistryMark,int mathMark)
        {
            //Console.WriteLine("parameter constructor initialized");
            s_registrationId++;
            RegistraionId = "SF" + s_registrationId;
            StudentName = studentName;
            FatherName = fatherName;
            Dob = dob;
            StudentGender = gender;
            MailId = mailId;
            PhysicsMark = physicsName;
            ChemistryMark = chemeistryMark;
            MathsMark = mathMark;
        }


        public bool CheckedEligibility(double cutOff)
        {
            double average = (double)(PhysicsMark+ChemistryMark+MathsMark)/3.0;
            if (average>cutOff)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
    }
}