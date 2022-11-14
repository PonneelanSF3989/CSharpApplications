using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public interface IWallet
    {
        public int WalletBalance { get;  }
        
        public void AddAmountToWallet(int amount);
    }
}