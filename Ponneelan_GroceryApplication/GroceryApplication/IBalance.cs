using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public interface IBalance
    {
        public int  Walletbalance { get; set; }
        
        public void WalletRecharge(int amount);
    }
}