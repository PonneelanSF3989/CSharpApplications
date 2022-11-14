using System;

namespace GroceryApplication
{
    public class CustomerDetails : PersonDetails,IBalance
    {
        private static int s_customerID = 1000;
        public string CustomerID { get; set; }
        public int Walletbalance { get; set; }

        public void WalletRecharge(int amount)
        {
            Walletbalance += amount; 
            Console.WriteLine("\nyour Wallet Balance is "+Walletbalance);
        }

        public CustomerDetails(string customerName,string fatherName,Gender customerGender, DateTime dob,long mobileNumber,string mailID,int walletBalance) : base(customerName,fatherName,customerGender,dob,mobileNumber,mailID)
        {
            s_customerID++;
            CustomerID = "CUSID" + s_customerID;
            Walletbalance = walletBalance;
        }
        public CustomerDetails(string data)
        {
            string[] values = data.Split(",");
            s_customerID=int.Parse(values[0].Remove(0,5));
            Walletbalance=int.Parse(values[1]);
            CustomerID=values[0];
            CustomerName=values[2];
            FatherName=values[3];
            CustomerGender=Enum.Parse<Gender>(values[4],true);
            MobileNumber=long.Parse(values[5]);
            DOB=DateTime.ParseExact(values[6],"dd/MM/yyyy",null);
            MailID = values[7];
        }
        
        public void ShowCustomerDetails()
        {
            Console.WriteLine($"Customer Name : {CustomerName}\nCustomer ID : {CustomerID}\nFather Name : {FatherName}\nGender : {CustomerGender}\nDate Of Birth : {DOB}\nMobile Number : {MobileNumber}\nmail Id : {MailID}\nWallet Balance : {Walletbalance}");
        }
    }
}