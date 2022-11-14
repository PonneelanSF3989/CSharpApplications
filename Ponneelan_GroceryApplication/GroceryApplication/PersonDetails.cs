using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public enum Gender {Default,Male,Female} 
    public class PersonDetails

    {
       
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public Gender CustomerGender { get; set; }
        public long  MobileNumber { get; set; }
        public DateTime DOB { get; set; }
        public string MailID { get; set; }
       
        
        
        
        public PersonDetails (string customerName,string fatherName,Gender customerGender, DateTime dob,long mobileNumber,string mailID)
        {
          
            CustomerName = customerName;
            FatherName = fatherName;
            CustomerGender = customerGender;
            MobileNumber = mobileNumber;
            DOB = dob;
            MailID = mailID;
            
        }
        public PersonDetails(){}
        
        
    }
}