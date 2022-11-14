using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccounts;

public class TransactionDetails
{
    private static int s_TID;
    public string TransanctionID { get; }
    public string FromAccount { get; set; }
    public string ToAccount { get; set; }
    public Enum AccountType { get; set; }
    public Enum TransactionType { get; set; }
    public int  TransferedAmount { get; set; }
    public DateTime TransactionDate { get; set; }
    
    public TransactionDetails(string fromAccount, string toAccount, Enum accType, Enum transactionType, int amountTransfered, DateTime transactionDate)
    {
        s_TID++;
        TransanctionID = "TID" + s_TID;
        FromAccount = fromAccount;
        ToAccount = toAccount;
        AccountType = accType;
        TransactionType = transactionType;
        TransferedAmount = amountTransfered;
        TransactionDate = transactionDate;
    }
    
    
    
    
    
    
    
    
    
    
    
    
}
