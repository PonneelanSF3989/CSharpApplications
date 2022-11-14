using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommersApplication;

public class CustomerDetails
{
    private static int UniqueID = 1000;
    public string CustomerID { get; }
    public string CustomerName { get; set; }
    public string CustomerCity { get; set; }
    public long CustomerMobileNumber { get; set; }
    public string CustomerMailID { get; set; }
    public int WalletAmount { get; set; }
    
    
    public CustomerDetails(string name, string city, long mobile, string mail, int initialAmount)
    {
        UniqueID++;
        CustomerID = "CUS" + UniqueID;
        CustomerName = name;
        CustomerCity = city;
        CustomerMobileNumber = mobile;
        CustomerMailID = mail;
        WalletAmount = initialAmount;
    }

    public void Recharge(int amount)
    {
        WalletAmount += amount;
    }
    
    
    
    
    
    
    
    
    
}
