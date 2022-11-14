using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbBillCalculation
{
    public class CustomerDetails
    {
        private static int s_uniquId = 1000;

        public string MeterId { get; }
        public string CustomerName { get; set; }
        public string CustomerMailId { get; set; }
        public long CustomerPhoneNumber { get; set; }
        public static double UnitUsed { get; set; }
        
        
        
        
        public CustomerDetails(string name,string mail,long phone)
        {
            s_uniquId++;
            MeterId = "EB" + s_uniquId;
            CustomerName = name;
            CustomerMailId = mail;
            CustomerPhoneNumber = phone;
            UnitUsed = 0;
        }
        public CustomerDetails()
        {}
        public double ClaculateAmount(double u)
        {
            double bill = (double)u*5;
            return bill;
        }

        public double CalculateUnit(double unit)
        {
            double units = unit - UnitUsed;
            UnitUsed += units; 
            return units;
        }
        
        
        
        
        
    }
}