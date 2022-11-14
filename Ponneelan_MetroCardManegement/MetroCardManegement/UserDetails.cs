using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManegement
{
    public class UserDetails
    {
        private static int s_cardID = 100;
        public string CardNumber { get; set; }
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        
        public int  Balance { get; set; }
        public UserDetails(string userName, long mobileNumber, int balance)
        {
            s_cardID++;
            CardNumber = "CMRL" + s_cardID;
            UserName = userName;
            MobileNumber = mobileNumber;
            Balance = balance;
        }
        
        public void ShowBalance()
        {
            Console.WriteLine($"\nYour Account Balance is : {Balance}");
        }
        
    }
}