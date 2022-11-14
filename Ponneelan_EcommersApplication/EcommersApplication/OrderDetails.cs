using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommersApplication;

public class OrderDetails
{
    private static int s_OrderId = 1000;
    public string OrderId { get; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
    public int TotalPrice { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Quantity { get; set; }
    public string OrderStatus { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId"> is used to get the date from called function </param>
    /// <param name="productId"></param>
    /// <param name="totalProductPrice"></param>
    /// <param name="shipingDate"></param>
    /// <param name="noOfProduct"></param>
    /// <param name="status"></param>
    public OrderDetails (string customerId, string productId, int totalProductPrice, DateTime shipingDate, int noOfProduct, string status)
    {
        s_OrderId++;
        OrderId = "OID" + s_OrderId;
        CustomerId = customerId;
        ProductId = productId;
        TotalPrice = totalProductPrice;
        PurchaseDate = shipingDate;
        Quantity = noOfProduct;
        OrderStatus = status; 

    }
    
    
    
    
    
    
    
    
    
    
    
}
