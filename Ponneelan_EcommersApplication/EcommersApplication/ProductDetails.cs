using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommersApplication;

public class ProductDetails
{
    private static int s_QuniqeId = 1000;
    public string ProductID { get; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public int DeliveryDuration { get; set; }


    
    public ProductDetails(string name, int price, int stock, int time)
    {
        s_QuniqeId++;
        ProductID = "PID" + s_QuniqeId;
        ProductName = name;
        ProductPrice = price;
        ProductStock = stock;
        DeliveryDuration = time;
    }
    public ProductDetails(){}
    
}
