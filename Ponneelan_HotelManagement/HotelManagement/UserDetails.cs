using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class UserDetails : PersonDetails, IWallet
    {
        
        private int _walletAmount;
        private static int s_userID = 1000;
        public string UserID { get; set; }
        
        public int WalletBalance { get{return _walletAmount;}  }

        public UserDetails(string name, long mobileNumber, long aadhar, string address, Gender personGender, Food foodType, int walletBalance) : base(name,mobileNumber,aadhar,address,personGender,foodType)
        {
            s_userID++;
            UserID = "SF"+s_userID;
            _walletAmount = walletBalance;
        }

        public UserDetails(string data)
        {
            string[] values  = data.Split(",");
            s_userID = int.Parse(values[0].Remove(0,2));
            UserID = values[0];
            Name = values[1];
            MobileNumber = long.Parse(values[2]);
            Aadhar = long.Parse(values[3]);
            Address = values[4];
            PersonGender = Enum.Parse<Gender>(values[5]);
            FoodType = Enum.Parse<Food>(values[6]);
            _walletAmount = int.Parse(values[7]);
        }

        public void AddAmountToWallet(int amount)
        {
            _walletAmount += amount;
        }
        public void DetectAmountToWallet(int amount)
        {
            _walletAmount -= amount;
        }
        
        
    }
}