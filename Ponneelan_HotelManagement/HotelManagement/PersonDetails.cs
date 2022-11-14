using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum Gender {Default, Male,Female,TransGender}
    public enum Food {Default, Veg,NonVeg}
    public class PersonDetails
    {
    
        public string Name { get; set; }
        
        public long MobileNumber { get; set; }
        
        public long Aadhar { get; set; }
        
        public string Address { get; set; }
        
        public Gender PersonGender { get; set; }
        public Food FoodType {get; set;}


        public PersonDetails(string name, long mobileNumber, long aadhar, string address, Gender personGender, Food foodType)
        {
            Name = name;
            MobileNumber = mobileNumber;
            Aadhar = aadhar;
            Address = address;
            PersonGender = personGender;
            FoodType = foodType;
        }
        public PersonDetails(){}
        
        
    }
}