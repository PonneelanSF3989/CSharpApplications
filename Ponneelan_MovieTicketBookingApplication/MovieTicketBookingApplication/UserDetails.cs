using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public class UserDetails : PersonalDetails,IWallet
    {
        public string UserID { get; set; }
        
        private static int s_userID = 1000;

        public int WalletBalance { get; set; }
        
        public UserDetails(string name, int  age, long phoneNumber,int walletBalance) : base(name, age, phoneNumber)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            WalletBalance = walletBalance;
        }

        public void RechargeWallet(int amount)
        {
            WalletBalance += amount ;
        }
        
        
    }
}