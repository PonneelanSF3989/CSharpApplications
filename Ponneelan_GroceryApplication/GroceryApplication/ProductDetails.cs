using System;


namespace GroceryApplication
{
    public class ProductDeails
    {
        private static int s_productID = 1000;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int  ProductQuantity { get; set; }
        public int ProductPrice { get; set; }

        public ProductDeails(string productName,int quantity,int price)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            ProductQuantity = quantity;
            ProductPrice = price;
        }
        public ProductDeails(){}
        public ProductDeails(string data)
        {
            string[] values = data.Split(",");
            s_productID=int.Parse(values[0].Remove(0,3));
            ProductID=values[0];
            ProductName=values[1];
            ProductQuantity=int.Parse(values[2]);
            ProductPrice=int.Parse(values[3]);
        }

        public void ShowProductDetails()
        {
            Operations.ShowProducts();
        }
        
        
        
    }
}