using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public interface IWallet
    {
        public int WalletBalance { get; set; }
        
        void RechargeWallet(int amount);
    }
}