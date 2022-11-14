using System;
using System.Collections.Generic;
namespace EcommersApplication ;

class Program
{

    public static void Main(string[] args)
    {

        //create the list to add the customer data

        List<CustomerDetails> customerData = new List<CustomerDetails>();
        List<ProductDetails> productData = new List<ProductDetails>();
        List<OrderDetails> orderData = new List<OrderDetails>();



        //create object to ProductDetals class
        ProductDetails product1 = new ProductDetails("Mobile",10000,10,3);
        ProductDetails product2 = new ProductDetails("Tablet",20000,8,4);
        ProductDetails product3 = new ProductDetails("iPad",30000,9,5);
        ProductDetails product4 = new ProductDetails("iPhone",500000,7,5);
        ProductDetails product5 = new ProductDetails("Camera",15000,4,7);
        ProductDetails product6 = new ProductDetails("Laptop",80000,6,10);

        //add product to the list in default 
        productData.Add(product1);
        productData.Add(product2);
        productData.Add(product3);
        productData.Add(product4);
        productData.Add(product5);
        productData.Add(product6);


        

        int choice;
        do
        {
            //display the menu
            Console.WriteLine("\n1. Registration");
            Console.WriteLine("2. Login and Purchase ");
            Console.WriteLine("3. Exit");

            //read the user choice
            Console.WriteLine("\nEnter choice :");
            choice = int.Parse(Console.ReadLine());

            //switch the user choice 
            switch(choice)
            {
                case 1:
                {
                    Registration();
                    break;
                }
                case 2:
                {
                    LoginAndPurchase();
                    break;
                }
                default :
                {
                    break;
                }
            }
        }while(choice <=2);



        void Registration()
        {
            char choice;
            do
            {
                //name
                Console.WriteLine();
                Console.WriteLine("Enter the customer Name");
                string name = Console.ReadLine(); 

                //city
                Console.WriteLine("Enter the customer city");
                string city = Console.ReadLine();

                //phome number
                Console.WriteLine("Enter the customer Mobile number");
                long mobile = long.Parse(Console.ReadLine());

                //mail Id
                Console.WriteLine("enter the customer Mail ID");
                string mail = Console.ReadLine();

                //initial wallet amount
                Console.WriteLine("Enter the Initial wallet Amount");
                int balance = int.Parse(Console.ReadLine());


                //create the object for the CustomerDetails class
                CustomerDetails customer = new CustomerDetails(name, city, mobile, mail, balance);

                //add the customer data to the List
                customerData.Add(customer);
                Console.WriteLine("Customer register successfully");

                //display the customer ID
                Console.WriteLine($"Your Customer ID is : {customer.CustomerID.ToString()}");

                //addd another user
                Console.WriteLine();
                Console.WriteLine("Do you want continue Press 'y' else press 'n' ");
                choice = char.Parse(Console.ReadLine().ToLower());
            }while( choice == 'y' );
        }
        


        //get product index
        int getProductIndex (string id)
        {
            int indexOfProduct = -1;
           foreach(ProductDetails x in productData)
           {
                 indexOfProduct++;
                if (x.ProductID == id)
                {
                   
                    return indexOfProduct;
                }
           }
           return -2;
        }
        //GET CUSTOMWR INDEX
        int getCustomerIndex (string id)
        {
            int indexOfCustomer = -1;
           foreach(CustomerDetails x in customerData)
           {
                indexOfCustomer++;
                if (x.CustomerID == id)
                {
                    
                    return indexOfCustomer;
                }
           }
           return -2;
        }



        //get product count
        
        //get product orice
        //get productId
        int getProductPrice(string id)
            {
                foreach(ProductDetails x in productData)
                {
                    if (id == x.ProductID)
                    {
                        return x.ProductPrice;
                    }
                }
                return -1;
            }
        
        void BookProduct(string cId,int amt,string pid,int items)
        {
            if (getCustomerIndex(cId) != -2)
            {
                if (customerData[getCustomerIndex(cId)].WalletAmount < amt)
                {
                    WalletInfo(cId);
                }
                else 
                {
                    customerData[getCustomerIndex(cId)].WalletAmount -= amt;
                    productData[getProductIndex(pid)].ProductStock -= items;


                    OrderDetails orders = new OrderDetails(cId,pid,amt,DateTime.Today,items,"Ordered");
                    orderData.Add(orders);

                    int deliveryIn = productData[getProductIndex(pid)].DeliveryDuration;
                    DateTime days = DateTime.Today.AddDays(deliveryIn);
                    Console.WriteLine($"Ordered Confirmed on {orders.PurchaseDate.ToString("dd/MM/yyyy")} and your order delivery in {deliveryIn} days");
                    Console.WriteLine("\nOrder placed ");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Customer ID");
            }
        }
        int WalletBalance (string id)
        {
            foreach (CustomerDetails x in customerData)
            {
                if (x.CustomerID == id)
                {
                    return x.WalletAmount;
                }
            }
            return -1;
        }
        //purchase
        void PurchaseProduct(string cId)
        {
            Console.WriteLine();
            Console.WriteLine("Avalable products are");
            foreach (ProductDetails product in productData)
            {
                Console.WriteLine($"\nProduct Id : {product.ProductID}  Product Name : {product.ProductName}  Product Price : {product.ProductPrice}  Availabe Stocks : {product.ProductStock}  Delevery Time : {product.DeliveryDuration}");
            }

            Console.WriteLine("\nEnter the Product Id to Continue Order :");
            string pId = Console.ReadLine();
            
            Console.WriteLine("Enter the number of Products");
            int noOfItems = int.Parse(Console.ReadLine());

            if (getProductIndex(pId) != -2)
            {
                if (productData[getProductIndex(pId)].ProductStock>noOfItems)
                {
                    int totalAmount = (noOfItems * getProductPrice(pId) ) + 50;
                    Console.WriteLine($"your total amount is {totalAmount}");
                    BookProduct(cId,totalAmount,pId,noOfItems);
                }
                else 
                {
                    Console.WriteLine($"\n Required Stock is not Available \nCurrent Stock Availability : {noOfItems} ");
                }
            } 
            else
            {
                Console.WriteLine("\nInvalid Product ID");
            }
        }

        //get order index
        int GetOrderIndex(string x)
        {
            int orderIndex = -1;
            foreach(OrderDetails i in orderData)
            {
                orderIndex++;
                if (i.OrderId == x)
                {
                    return orderIndex;
                     
                }
            }
            return -2;
        }
        //Calcel order
        void CalcelOrder(string id)
        {
            //OrderDetails z;
            foreach(OrderDetails x in orderData)
            {
               
                Console.WriteLine($"Order Id {x.OrderId} Status {x.OrderStatus} ProductId {x.ProductId} Order Date {x.PurchaseDate}");
            }
            Console.WriteLine("enter Orderid to cancel");
            string cancelId  = Console.ReadLine(); 
            orderData[GetOrderIndex(cancelId)].OrderStatus = "cancelled";
            customerData [getCustomerIndex(id)].WalletAmount += orderData[GetOrderIndex(cancelId)].TotalPrice;
           productData[getProductIndex(orderData[GetOrderIndex(cancelId)].ProductId)].ProductStock -= orderData[GetOrderIndex(cancelId)].Quantity;

        }


        //wallet
        void WalletInfo(string customerId)
        {
            if (WalletBalance(customerId) != -1)
                                {   
                                    int c;
                                    Console.WriteLine($"Wallet Balance is {WalletBalance(customerId)}");
                                    do
                                    {
                                        Console.WriteLine("1. Recharge");
                                        Console.WriteLine("2. exit");

                                        Console.WriteLine("\nEnter your choice");
                                        c = int.Parse(Console.ReadLine());
                                        switch(c)
                                        {
                                            case 1:
                                            {
                                                Console.WriteLine("Enter the amount to recharge");
                                                int amt =  int.Parse(Console.ReadLine());
                                                RechargeWallet(customerId,amt);
                                                break;
                                            }
                                        }
                                    }while(c<=1);
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Customer id ");
                                }
        } 



        //recharge wallet
        void RechargeWallet (string id,int amt)
        {
            customerData[getCustomerIndex(id)].WalletAmount += amt;
        }
        //order Histroy
        void DisplayOrder(string cid)
        {
            foreach(OrderDetails x in orderData)
            {
                   if (x.CustomerId == cid)
                   {
                    Console.WriteLine($"Product I {x.ProductId} Order Id {x.OrderId} order data {x.PurchaseDate} Status {x.OrderStatus}");
                   }
                
            }
        }
        
        void LoginAndPurchase()
        {
            Console.WriteLine("\nEnter the Customer ID :");
            string customerId = Console.ReadLine();

            foreach(CustomerDetails data in customerData)
            {
                if (customerId == data.CustomerID)
                {
                    int choice;
                    do
                    {
                        Console.WriteLine("\n1. Purchase");
                        Console.WriteLine("2. Order History");
                        Console.WriteLine("3. Cancel Order");
                        Console.WriteLine("4. Wallet Balance");
                        Console.WriteLine("5. Exit");

                        Console.WriteLine("\nEnter your choice");
                        choice = int.Parse(Console.ReadLine());

                        switch(choice)
                        {
                            case 1:
                            {
                                PurchaseProduct(customerId);
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine("Your Orders");
                                DisplayOrder(customerId);
                                break;
                            }
                            case 3:
                            {
                                CalcelOrder(customerId);
                                break;
                            }
                            case 4:
                            {
                                WalletInfo(customerId);
                                break;
                            }
                           
                        }
                    }
                    while(choice <= 4);
                    
                }
            }
        }

    }




}