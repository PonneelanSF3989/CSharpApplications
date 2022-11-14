using System.IO;

namespace GroceryApplication
{
     public class Files
    {
        public static void CreateFiles()
        {
            if(!Directory.Exists("GroceryApplication"))
            {
                Directory.CreateDirectory("GroceryApplication");
            }
            if(!File.Exists("GroceryApplication/CustomerDetails.csv"))
            {
                var file1 = File.Create("GroceryApplication/CustomerDetails.csv");
                file1.Close();
            }
            if(!File.Exists("GroceryApplication/ProductDetails.csv"))
            {
                var file2  = File.Create("GroceryApplication/ProductDetails.csv");
                file2.Close();
            }
            if(!File.Exists("GroceryApplication/BookingDetails.csv"))
            {
                var file3 = File.Create("GroceryApplication/BookingDetails.csv");
                file3.Close();

            }
            if(!File.Exists("GroceryApplication/OrderDetails.csv"))
            {
                var file4 = File.Create("GroceryApplication/OrderDetails.csv");
                file4.Close();
            }
        }
        public static void WriteToFiles()
        {
            string[] customerData = new string[Operations.customerData.Count];
            for(int i=0;i<Operations.customerData.Count;i++)
            {
                customerData[i] = Operations.customerData[i].CustomerID+","+Operations.customerData[i].Walletbalance+","+Operations.customerData[i].CustomerName+","+Operations.customerData[i].FatherName+","+Operations.customerData[i].CustomerGender+","+Operations.customerData[i].MobileNumber+","+Operations.customerData[i].DOB.ToString("dd/MM/yyyy")+","+Operations.customerData[i].MailID;

            }
            File.WriteAllLines("GroceryApplication/CustomerDetails.csv",customerData);

            string[] productData = new string[Operations.productData.Count];
            for(int i=0;i<Operations.productData.Count;i++)
            {
                productData[i]=Operations.productData[i].ProductID+","+Operations.productData[i].ProductName+","+Operations.productData[i].ProductQuantity+","+Operations.productData[i].ProductPrice;

            }
            File.WriteAllLines("GroceryApplication/ProductDetails.csv",productData);

            string[] bookingData = new string[Operations.bookingData.Count];
            for(int i=0;i<Operations.bookingData.Count;i++)
            {
                bookingData[i]=Operations.bookingData[i].BookingID+","+Operations.bookingData[i].CustomerID+","+Operations.bookingData[i].TotalPrice+","+Operations.bookingData[i].DateOfBooking.ToString("dd/MM/yyyy")+","+Operations.bookingData[i].BookingStatus;

            }
            File.WriteAllLines("GroceryApplication/BookingDetails.csv",bookingData);

            string[] orderData = new string[Operations.orderData.Count];
            for(int i=0;i<Operations.orderData.Count;i++)
            {
                orderData[i]=Operations.orderData[i].OrderID+","+Operations.orderData[i].BookingID+","+Operations.orderData[i].ProductID+","+Operations.orderData[i].ProductCount+","+Operations.orderData[i].Price;

            }
            File.WriteAllLines("GroceryApplication/OrderDetails.csv",orderData);
        }

        public static void ReadFiles()
        {
            string[] customerData = File.ReadAllLines("GroceryApplication/CustomerDetails.csv");
            foreach(string customer in customerData)
            {
                CustomerDetails newCustomer =  new CustomerDetails(customer);
                Operations.customerData.Add(newCustomer);
            }

            string[] productData = File.ReadAllLines("GroceryApplication/ProductDetails.csv");
            foreach(string product in productData)
            {
                ProductDeails newProduct = new ProductDeails(product);
                Operations.productData.Add(newProduct);
            }

            string[] bookingData = File.ReadAllLines("GroceryApplication/BookingDetails.csv");
            foreach(string booking in bookingData)
            {
                BookingDetails newBookings = new BookingDetails(booking);
                Operations.bookingData.Add(newBookings);
            }

            string[] orderData = File.ReadAllLines("GroceryApplication/OrderDetails.csv");
            foreach(string order in orderData)
            {
                OrderDetails newOrders = new OrderDetails(order);
                Operations.orderData.Add(newOrders);
            }
        }
    }
}