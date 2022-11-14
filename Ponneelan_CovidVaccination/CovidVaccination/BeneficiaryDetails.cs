using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum Gender {Default,male,female,transgender} 
    public class BeneficiaryDetails
    {
        private static int s_beneficiaryID = 1000;
        public string BenefiaceryID { get;  }
        public string BenefiaceryName { get; set; }
        
        public Gender BenefiacerGender { get; set; }
        
        public long MobileNumber { get; set; }
        
        public string City { get; set; }
        
        public int  Age { get; set; }
        
        public BeneficiaryDetails (string name,int age, Enum gender, long mobileNumber, string city)
        {

            s_beneficiaryID++;
            BenefiaceryID = "BID" + s_beneficiaryID;
            BenefiaceryName = name;
            MobileNumber = mobileNumber;
            City =city;
            Age = age;
        }
      
        
    }
}