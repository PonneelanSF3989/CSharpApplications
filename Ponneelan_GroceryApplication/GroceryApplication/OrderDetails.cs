using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; set; }
        
        public string BookingID { get; set; }
        
        public string ProductID { get; set; }
        
        public int ProductCount { get; set; }
        
        public int  Price { get; set; }

        public OrderDetails(string bookingID,string productID,int productCount,int price)
        {
            s_orderID++;
            OrderID = "OID"+s_orderID;
            BookingID = bookingID;
            ProductID = productID;
            ProductCount = productCount;
            Price = price;
        }
        public OrderDetails(string data)
        {
            string[] values = data.Split(",");
            s_orderID=int.Parse(values[0].Remove(0,3));
            OrderID=values[0];
            BookingID=values[1];
            ProductID=values[2];
            ProductCount = int.Parse(values[3]);
            Price = int.Parse(values[4]);
        }
        
        
    }
}