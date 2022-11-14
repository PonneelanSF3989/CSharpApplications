using System;
using System.Collections.Generic;
namespace BankAccounts;

/// <summary>
/// Enum for Gender
/// </summary>
/// 
public enum Gender{male,memale,trangender}

/// <summary>
/// Enum for Account Type
/// </summary>
public enum AccType{DEFAULT,CA,SB,RD,FD}

/// <summary>
/// Enum for Transaction Type
/// </summary>
public enum TransactionTypes {defalut,deposite,widthdraw,transfer} 

class Program
{
    public static void Main(string[] args)
    {
        List<TransactionDetails> transactionData = new List<TransactionDetails>();
        List<CustomerDetails> customerData = new List<CustomerDetails>();

        //create the object to the customer Details class
        CustomerDetails customer1 = new CustomerDetails("vasanth",Enum.Parse<Gender>("male"),9629641742,Enum.Parse<AccType>("SB"),1000,DateTime.ParseExact("13/05/2001","dd/MM/yyyy",null),"vasanth.com","Kothamangalam");
        CustomerDetails customer2 = new CustomerDetails("Ponneelan",Enum.Parse<Gender>("male"),1111111111,Enum.Parse<AccType>("RD"),2000,DateTime.ParseExact("20/09/2004","dd/MM/yyyy",null),"Ponneelan.com","pudukkottai");
        CustomerDetails customer3 = new CustomerDetails("Rilan",Enum.Parse<Gender>("male"),999999999,Enum.Parse<AccType>("CA"),3000,DateTime.ParseExact("10/11/2003","dd/MM/yyyy",null),"rilan.com","alangudi");

        //add the customers to the List
        customerData.Add(customer1);
        customerData.Add(customer2);
        customerData.Add(customer3);

        //create the object to the Transaction details class
        TransactionDetails transaction1 = new TransactionDetails("BANK1001","BANK1002",Enum.Parse<AccType>("SB"),Enum.Parse<TransactionTypes>("transfer"),1000,DateTime.ParseExact("11/11/1111","dd/MM/yyyy",null));
        TransactionDetails transaction2 = new TransactionDetails("BANK1001","BANK1001",Enum.Parse<AccType>("SB"),Enum.Parse<TransactionTypes>("deposite"),1000,DateTime.ParseExact("11/11/1111","dd/MM/yyyy",null));
        TransactionDetails transaction3 = new TransactionDetails("BANK1002","BANK1001",Enum.Parse<AccType>("FD"),Enum.Parse<TransactionTypes>("transfer"),1000,DateTime.ParseExact("11/11/1111","dd/MM/yyyy",null));
        TransactionDetails transaction4 = new TransactionDetails("BANK1002","BANK1003",Enum.Parse<AccType>("FD"),Enum.Parse<TransactionTypes>("transfer"),1000,DateTime.ParseExact("11/11/1111","dd/MM/yyyy",null));

        //add the Transaction to the TransactionData list
        transactionData.Add(transaction1);
        transactionData.Add(transaction2);
        transactionData.Add(transaction3);
        transactionData.Add(transaction4);



        //methods
        void CreateAccount()
        {
            Console.WriteLine("\nEnter the Holder Name");
            string holderName = Console.ReadLine(); 

            Console.WriteLine("\nEnter the Gender");
            Enum holderGender = Enum.Parse<Gender>(Console.ReadLine().ToLower());

            Console.WriteLine("\nEnter The Mobile Number");
            long mobileNum = long.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Account Type");
            Enum accType = Enum.Parse<AccType>(Console.ReadLine().ToUpper());

            Console.WriteLine("\nEnter the Initial Amount");
            int initialAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Date Of Birth");  
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);   

            Console.WriteLine("\nEnter the Mail Id");
            string mailID = Console.ReadLine();

            Console.WriteLine("\nEnter the Address");
            string addOfCustomer  = Console.ReadLine();

            //create object
            CustomerDetails customer = new CustomerDetails(holderName,holderGender,mobileNum,accType,initialAmount,dob,mailID,addOfCustomer);

            //add to the list
            customerData.Add(customer);    
            Console.WriteLine("\nAccount Create Succefully");
            Console.WriteLine($"\nYour Account Number  is {customer.AccountNumber}\n");
        }
        void Login()
        {
            bool customerIdIsTrue = false;
            do
            {
                Console.WriteLine("\nEnter Your Account Number");
                string accountNumber = Console.ReadLine();

                foreach(var customer in customerData)
                {
                    if (customer.AccountNumber == accountNumber)
                    {
                        LoginMenu(customer);
                        customerIdIsTrue = true;
                    }
                }
                Console.WriteLine("\nInvalid Account Number!");
                break;
            }while(customerIdIsTrue);
        }

        void LoginMenu(CustomerDetails obj)
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Show Account Details");
                Console.WriteLine("\n2. Deposite");
                Console.WriteLine("\n3. Widthdraw");
                Console.WriteLine("\n4. Show Balance");
                Console.WriteLine("\n5. Tranfer Amount");
                Console.WriteLine("\n6. Transaction History");
                Console.WriteLine("\n7. Exit");

                //read choice
                Console.WriteLine("\nEnter Your choice :");
                choice = choice=int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                    {
                        DisplayCustomerDetails(obj);
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Enter Amount To Deposite!");
                        int amount = int.Parse(Console.ReadLine());
                        Deposite(obj,amount);
                        Console.WriteLine("\nAmount Deposite Successfully");
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Enter Amount To Widthdraw!");
                        int amount = int.Parse(Console.ReadLine());
                        if (Widthdraw(obj,amount))
                        {
                        Console.WriteLine("\nAmount Widthdraw Successfully");
                        }
                       else
                       {
                        Console.WriteLine("\nInsuffiucient Balance:");
                       }
                        break;
                    }
                    case 4:
                    {
                        ShowBalance(obj);
                        break;
                    }
                    case 5:
                    {
                        TransferAmount(obj);
                        break;
                    }
                    case 6:
                    {
                        ShowTransactionHistroy(obj);
                        break;
                    }
                   
                }
            }while(choice<=6);
        }
        void DisplayCustomerDetails(CustomerDetails obj)
        {
            Console.WriteLine($"\nCustomer Name : {obj.CustomerName}");
            Console.WriteLine($"\nAccount Number : {obj.AccountNumber}");
            Console.WriteLine($"\nAccount Type : {obj.AccountType.ToString()}");
            Console.WriteLine($"\nAccount Balance : {obj.Balance}");
            Console.WriteLine($"\nDate Of Birth : {obj.DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"\nCustomer Mail ID : {obj.MailID}");
            Console.WriteLine($"\nCustomer Mobile Number : {obj.MobileNumber}");
            Console.WriteLine($"\nCustomer Address : {obj.Address}");


        }
        void Deposite(CustomerDetails obj,int amountToDeposite)
        {
            obj.Balance += amountToDeposite;
            TransactionDetails transaction = new TransactionDetails(obj.AccountNumber,obj.AccountNumber,Enum.Parse<AccType>($"{obj.AccountType.ToString()}"),Enum.Parse<TransactionTypes>("deposite"),amountToDeposite,DateTime.Today);
            transactionData.Add(transaction);
        }
        bool Widthdraw(CustomerDetails obj,int amountToWithdraw)
        {
            if (obj.Balance > amountToWithdraw)
            {
                obj.Balance -= amountToWithdraw;
                TransactionDetails transaction = new TransactionDetails(obj.AccountNumber,obj.AccountNumber,Enum.Parse<AccType>($"{obj.AccountType.ToString()}"),Enum.Parse<TransactionTypes>("widthdraw"),amountToWithdraw,DateTime.Today);
                transactionData.Add(transaction);
                return true;
            }
            else
            {
                return false;
            }
        }
        void ShowBalance(CustomerDetails obj)
        {
            Console.WriteLine($"\nYour Balance Is : {obj.Balance}");
        }
        void ShowTransactionHistroy(CustomerDetails obj)
        {
            foreach(TransactionDetails transaction in transactionData)
            {
                 if (obj.AccountNumber == transaction.FromAccount)
                 {
                    Console.WriteLine($"\nTransaction ID : {transaction.TransanctionID}");
                    Console.WriteLine($"\nTransaction Type : {transaction.TransactionType}");
                    Console.WriteLine($"\nFrom Account : {transaction.FromAccount}");
                    Console.WriteLine($"\nTo Account : {transaction.ToAccount}");
                    Console.WriteLine($"\nTransfres Amount : {transaction.TransferedAmount}");
                    Console.WriteLine("\n\n");

                }
            }
            //Console.WriteLine("\nNo Transaction Found");
        }
        void TransferAmount(CustomerDetails obj)
        {
            int transferAmount;
            Console.WriteLine("\nEnter the Reciver Account Number");
            string reciverAccountNumber  = Console.ReadLine();
            Console.WriteLine("\nEnter the Reciver Account Type");
            Enum reciverAccountType = Enum.Parse<AccType>(Console.ReadLine());
            foreach(CustomerDetails customer in customerData )
            {
                if (customer.AccountNumber == reciverAccountNumber)
                {

                    Console.WriteLine("\nEnter the Amount To Transfer");
                    transferAmount = int.Parse(Console.ReadLine());
                    customer.Balance += transferAmount;
                    obj.Balance -= transferAmount;
                    Console.WriteLine("\nTransfer Amount Successfully");
                    TransactionDetails transaction = new TransactionDetails(obj.AccountNumber,customer.AccountNumber,Enum.Parse<AccType>($"{customer.AccountType.ToString()}"),Enum.Parse<TransactionTypes>("transfer"),transferAmount,DateTime.Today);
                    transactionData.Add(transaction);
                }
            }
            
        }
        //Display the Main Menu
        int choice;
        do
        {
            Console.WriteLine("\n1. Register");
            Console.WriteLine("\n2. Login");
            Console.WriteLine("\n3. Exit");

            Console.WriteLine("\nEnter the Choice :");
            choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                {
                    CreateAccount();
                    break;
                }
                case 2:
                {
                    Login();
                    break;
                }
            }
        }while(choice <=2);

    }
    
}