using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public class PersonalDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        
        public PersonalDetails(string name, int age, long phoneNumber)
        {
            Name = name;
            Age = age;
            PhoneNumber = phoneNumber;
        }
        
    }
}