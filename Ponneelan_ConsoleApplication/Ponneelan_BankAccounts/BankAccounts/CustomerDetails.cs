using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccounts;

public class CustomerDetails
{
    private static int s_AID = 1000;
    public string AccountNumber { get; }
    public string CustomerName { get; set; }
    public Enum Gender { get; set; }
    
    public long MobileNumber { get; set; }
    
    public Enum AccountType { get; set; }
    
    public int Balance { get; set; }
    
    public DateTime DOB { get; set; }
    
    public string MailID { get; set; }
    
    public string Address { get; set; }
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="gender"></param>
    /// <param name="mobile"></param>
    /// <param name="accType"></param>
    /// <param name="bal"></param>
    /// <param name="dob"></param>
    /// <param name="mail"></param>
    /// <param name="address"></param>
    public CustomerDetails (string name, Enum gender, long mobile, Enum accType, int bal, DateTime dob, string mail, string address)
    {
        s_AID++;
        AccountNumber = "BANK"  + s_AID;
        CustomerName = name;
        Gender = gender;
        MobileNumber = mobile;
        AccountType = accType;
        Balance = bal;
        DOB = dob;
        MailID = mail;
        Address = address;
    }
    
    
}
