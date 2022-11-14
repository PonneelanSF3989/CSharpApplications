using System;
using System.Collections.Generic;

namespace GroceryApplication
{
    public static partial class Operations
    {
        public static List<CustomerDetails> customerData = new List<CustomerDetails>();
        public static List<ProductDeails> productData = new List<ProductDeails>();
        public static List<BookingDetails> bookingData = new List<BookingDetails>();
        public static List<OrderDetails> orderData = new List<OrderDetails>();
        public static ProductDeails products = new ProductDeails();
        public static List<OrderDetails> TempOrderList = new List<OrderDetails>(); 
        public static CustomerDetails currentCustomer;
        public static void MainMenu()
        {
            int choice;
            do 
            {
                Console.WriteLine("\n\nWelcome to Online Grocery Shop");
                Console.WriteLine("\n\n1. Register\n2. Login\n3. Exit\n\nEnter Your Choice :\n");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1: 
                    {
                        registration();
                        break;
                    }
                    case 2:
                    {
                        login();
                        break;
                    }
                    case 3: 
                    {
                        Console.WriteLine("\nExit!!");
                        break;
                    } 
                    default : 
                    {
                        Console.WriteLine("\nInvalid Choice");
                        break;
                    }
                }
            }while (choice != 3);

        }
        public static void Registration()
        {
            Console.WriteLine("\nEnter Your Name :");
            string customerName = Console.ReadLine();
            Console.WriteLine("\nEnter Father Name :");
            string fatherName = Console.ReadLine();
            Console.WriteLine("\nEnter Your Gender :");
            Gender customerGender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.WriteLine("\nEnter Your Date Of Birth :");
            DateTime dob =  DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("\nEnter your mobile Number :");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter You Mail ID :");
            string mailID = Console.ReadLine();
            Console.WriteLine("\nEnter Initial Wallet Amount :");
            int initialWalletAmount = int.Parse(Console.ReadLine());

            CustomerDetails newCustomer = new CustomerDetails(customerName,fatherName,customerGender,dob,mobileNumber,mailID,initialWalletAmount);
            customerData.Add(newCustomer);

            Console.WriteLine("\nRegistration Successfully\nAnd Your details Are");
            newCustomer.ShowCustomerDetails();
        }
        public static void Login()
        {
            bool flag = false;
            Console.WriteLine("\n****Login***");
            Console.WriteLine("\nEnter Your CustomerID to Login :");
            string customerId = Console.ReadLine();

            foreach(CustomerDetails customer in customerData)            
            {
                if (customer.CustomerID == customerId)
                {
                    flag = true;
                    currentCustomer = customer;

                }
            }
            if (flag)
            {
                subMenu();
            }
            else
            {
                Console.WriteLine("\nInvalid customer id");
            }

        }
        public static void SubMenu()
        {
            int choice ;
            do
            {
                Console.WriteLine("\n****Login Menu****");
                Console.WriteLine("\n\n1. Show Customer Details\n2. Show Product Details\n3. Wallet Recharge\n4. Take Order\n5. Modify Order\n6. Cancel Order\n7. Exit\n\nEnter Your Choice : ");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        showCustomers();
                        break;
                    }
                    case 2:
                    {
                        showProducts();
                        break;
                    }
                    case 3:
                    {
                        RechargeWallet();
                        break;
                    }
                    case 4:
                    {
                        takeOrder();
                        break;
                    }
                    case 5:
                    {
                        modifyOrder();
                        break;
                    }
                    case 6:
                    {
                        cancelBooking();
                        break;
                    }
                    case 7:
                    {
                        Console.WriteLine("\nGoto Main Menu");
                        break;
                    }
                }
            }while(choice != 7);
        }
        public static void ShowProducts()
        {
            foreach(ProductDeails products in productData )
            {
                Console.WriteLine($"Product ID : {products.ProductID}\nProduct Name : {products.ProductName}\nProduct Quantity : {products.ProductQuantity}\nProduct Price : {products.ProductPrice} \n\n");
            }
        }
        public static void RechargeWallet()
        {
            Console.WriteLine("\nEnter Amount to recharge");
            int amount = int.Parse(Console.ReadLine());
            currentCustomer.WalletRecharge(amount);
        }
        public static void AddDefaultData()
        {
            CustomerDetails customer1 = new CustomerDetails("Ponneelan","Ramanathan",Gender.Male, new DateTime(2000,05,13),90909090,"Ponneelan.com",10000);
            CustomerDetails customer2 = new CustomerDetails("Baskaran","Sethuramana",Gender.Male, new DateTime(1990,07,23),80808090,"sethuraman.com",10000);
            customerData.Add(customer1);
            customerData.Add(customer2);

            ProductDeails product1 = new ProductDeails("Tea",10,10);
            ProductDeails product2 = new ProductDeails("Coffe",15,15);
            ProductDeails product3 = new ProductDeails("Rise",100,50);
            ProductDeails product4 = new ProductDeails("Biscut",30,10);
            ProductDeails product5 = new ProductDeails("Oil",10,100);
            ProductDeails product6 = new ProductDeails("Soap",12,10);
            ProductDeails product7 = new ProductDeails("Ditergent",20,10);
            ProductDeails product8 = new ProductDeails("suger",15,10);
            ProductDeails product9 = new ProductDeails("salt",15,10);
            ProductDeails product10 = new ProductDeails("chilly powder",14,40);
            ProductDeails product11 = new ProductDeails("taniya powder",12,50);

            productData.Add(product1);
            productData.Add(product2);
            productData.Add(product3);
            productData.Add(product4);
            productData.Add(product5);
            productData.Add(product6);
            productData.Add(product7);
            productData.Add(product8);
            productData.Add(product9);
            productData.Add(product10);
            productData.Add(product11);



            OrderDetails order1 = new OrderDetails("BID1001","PID1001",2,20);
            OrderDetails order2 = new OrderDetails("BID1001","PID1002",4,60);
            OrderDetails order3 = new OrderDetails("BID1002","PID1003",2,100);
            OrderDetails order4 = new OrderDetails("BID1002","PID1004",5,50);
            OrderDetails order5 = new OrderDetails("BID1003","PID1005",2,200);
            OrderDetails order6 = new OrderDetails("BID1003","PID1006",5,50);

            orderData.Add(order1);
            orderData.Add(order2);
            orderData.Add(order3);
            orderData.Add(order4);
            orderData.Add(order4);
            orderData.Add(order5);

            BookingDetails booking1 = new BookingDetails("CUSID1001",new DateTime(2022,11,01),80,Status.Booked);
            BookingDetails booking2 = new BookingDetails("CUSID1002",new DateTime(2022,11,02),150,Status.Booked);
            BookingDetails booking3 = new BookingDetails("CUSID1003",new DateTime(2022,11,03),250,Status.Booked);
            BookingDetails booking4 = new BookingDetails("CUSID1001",new DateTime(2022,11,01),0,Status.Initiate);

            bookingData.Add(booking1);
            bookingData.Add(booking2);
            bookingData.Add(booking3);
            bookingData.Add(booking4);



        }
       
        public static void CancelOrder()
        {
            bool flag = false;
            bool flag2 = false;
            BookingDetails currentBookings = null;
            foreach(BookingDetails bookings in bookingData)
            {
                if (bookings.CustomerID == currentCustomer.CustomerID)
                {
                    if (bookings.BookingStatus == Status.Booked)
                    {
                        flag = true;
                        Console.WriteLine($"Booing Id : {bookings.BookingID}\nCustomer Id : {bookings.CustomerID}\nTotal price : {bookings.TotalPrice}\nBooing data : {bookings.DateOfBooking.ToString("dd/MM/yyyy")}\nTotal price : {bookings.TotalPrice}");
                    }
                }
            }
             if (!flag)
                {
                    Console.WriteLine("\nNo Orders found");
                }
                else 
                {
                    Console.WriteLine("\nEnter the booking id to cancel");
                    string bookingidToCancel = Console.ReadLine();
                    foreach(BookingDetails bookings in bookingData)
                    {
                        if (bookings.BookingID == bookingidToCancel)
                        {
                            flag2 = true;
                            currentBookings = bookings;
                            bookings.BookingStatus = Status.Cancelled;
                            currentCustomer.Walletbalance += bookings.TotalPrice;

                        }
                    }
                    if (!flag2)
                    {
                        Console.WriteLine("\ninvalid Booking id");
                    }
                    else
                    {
                        foreach (ProductDeails products in productData)
                        {
                            foreach(OrderDetails orders in orderData)
                            {
                                if (products.ProductID == orders.ProductID)
                            {
                               
                                if (orders.BookingID == currentBookings.BookingID)
                                {
                                    products.ProductQuantity +=orders.ProductCount;
                                    Console.WriteLine("\nOrder Cancel Successfully");
                                }
                                
                            }
                            }
                        }
                    }
                    
                    
                }
        }
        
        private static void ModifyOrder()
        {
            bool bookingCheck = false;
            BookingDetails modifyBook = null;
            foreach (BookingDetails booking in bookingData)
            {
                if (booking.CustomerID == currentCustomer.CustomerID && booking.BookingStatus == Status.Booked)
                {
                    bookingCheck = true;
                    System.Console.WriteLine("Booking Id :" + booking.BookingID);
                    System.Console.WriteLine("BOOking Price: " + booking.TotalPrice);
                    System.Console.WriteLine("Booking Date: " + booking.DateOfBooking);
                    System.Console.WriteLine(" ");
                }
            }
            if (!bookingCheck)
            {
                System.Console.WriteLine("No previous booking");
            }
            else
            {
                System.Console.Write("Enter a booking Id: ");
                string bookId = Console.ReadLine().ToUpper();
                bool flag = false;
                foreach (BookingDetails booking in bookingData)
                {
                    if (booking.CustomerID == currentCustomer.CustomerID && booking.BookingStatus == Status.Booked)
                    {
                        flag = true;
                        modifyBook = booking;
                    }
                }
                if (!flag)
                {
                    System.Console.WriteLine("Invalid Id ,Please valid   booking Id");
                }
                else
                {
                    foreach (OrderDetails order in orderData)
                    {
                        if (order.BookingID == modifyBook.BookingID)
                        {
                            System.Console.WriteLine("OrderId: " + order.OrderID);
                            System.Console.WriteLine("Product-Id: " + order.ProductID);
                            System.Console.WriteLine("Purchase Count: " + order.ProductCount);
                            System.Console.WriteLine("Price of Order: " + order.Price);
                            System.Console.WriteLine(" ");
                        }
                    }

                    System.Console.Write("Enter a orderId to modify");
                    string orderId = Console.ReadLine().ToUpper();
                    bool checkOrder = false;
                    foreach (OrderDetails order in orderData)
                    {
                        if (order.OrderID == orderId)
                        {
                            checkOrder = true;
                            System.Console.Write("Enter the new quantity of the product: ");
                            int quantity = int.Parse(Console.ReadLine());
                            int currentQuantity = order.ProductCount;
                            int currentPrice = order.Price;
                            int quantityDiff = quantity - currentQuantity;
                            int productPrice = currentPrice / currentPrice;
                            order.ProductCount = quantity;
                            order.Price = quantity * productPrice;
                            modifyBook.TotalPrice = modifyBook.TotalPrice + (quantityDiff * productPrice);
                            System.Console.WriteLine("Order Modified Successfully");
                        }
                    }
                    if (!checkOrder)
                    {
                        System.Console.WriteLine("Enter a valid Order-Id");
                        System.Console.WriteLine(" ");
                    }
                }

            }
        }
        private static void TakeOrder()
        {
            string endCheck = "";
            string purchase = "";
            List<OrderDetails> tempOrderList = new List<OrderDetails>();
            int totalAmount = 0;
            do
            {
                System.Console.Write("Do you want to continue:(yes/no) ");
                purchase = Console.ReadLine();

            } while (!(purchase == "yes" || purchase == "no"));
            if (purchase == "yes")
            {
                BookingDetails booking = new BookingDetails(currentCustomer.CustomerID, DateTime.Today,0, Status.Initiate);
                do
                {
                    ShowProducts();
                    System.Console.Write("Enter the product Id to purchase the product: ");
                    string productId = Console.ReadLine().ToUpper();
                    bool productCheck = false;

                    foreach (ProductDeails product in productData)
                    {
                        if (productId == product.ProductID)
                        {
                            productCheck = true;
                            System.Console.Write("Enter the number of quantity: ");
                            int quantity = int.Parse(Console.ReadLine());
                            if (quantity > product.ProductQuantity)
                            {
                                System.Console.WriteLine("Not enough Quantity");
                            }
                            else
                            {
                                OrderDetails order = new OrderDetails(booking.BookingID, productId, quantity, (product.ProductPrice * quantity));
                                tempOrderList.Add(order);
                                product.ProductQuantity -= quantity;
                                totalAmount += (product.ProductPrice * quantity);
                                System.Console.WriteLine("Product Successfully Added to the cart");
                                System.Console.Write("Do you want to continue:(yes/no) ");
                                endCheck = Console.ReadLine().ToLower();
                                while (!(endCheck == "yes" || endCheck == "no"))
                                {
                                    System.Console.Write("Enter yes/no: ");
                                    endCheck = Console.ReadLine().ToLower();
                                }
                            }
                        }
                    }
                    if (!productCheck)
                    {
                        System.Console.WriteLine("Invalid ProductId");
                    }
                } while ((endCheck == "yes"));
                if (endCheck == "no")
                {
                    System.Console.Write("Do you want to confirm the order: ");
                    string confireOrder = "";
                    do
                    {
                        System.Console.Write("Please select yes/no: ");
                        confireOrder = Console.ReadLine();

                    } while (!(confireOrder == "yes" || confireOrder == "no"));
                    if (confireOrder == "yes")
                    {
                        bool balanceCheck = false;
                        do
                        {
                            if (currentCustomer.Walletbalance < totalAmount)
                            {
                                System.Console.WriteLine("You don't have enough balance");
                                System.Console.WriteLine("Your Balance: " + currentCustomer.Walletbalance);
                                System.Console.WriteLine("Total Bill: " + totalAmount);
                                System.Console.Write("Enter the amount to recharge: ");
                                int recharge = int.Parse(Console.ReadLine());
                                currentCustomer.WalletRecharge(recharge);
                            }
                            else
                            {
                                balanceCheck = true;
                                 currentCustomer.Walletbalance -= totalAmount;
                                booking.BookingStatus = Status.Booked;
                                booking.TotalPrice = totalAmount;
                                bookingData.Add(booking);

                                foreach (OrderDetails order in tempOrderList)
                                {
                                    orderData.Add(order);
                                }
                                System.Console.WriteLine("Booking successful");
                            }
                        } while (!(balanceCheck));

                    }
                    else
                    {
                        foreach (OrderDetails order in tempOrderList)
                        {
                            foreach (ProductDeails product in productData)
                            {
                                if (order.ProductID == product.ProductID)
                                {
                                    product.ProductQuantity += order.ProductCount;
                                }
                            }
                        }
                        System.Console.WriteLine("Cart Removed Successfully");
                    }
                }
            }

        }
        private static void ShowCustomer()
        {
            currentCustomer.ShowCustomerDetails();
        }
    
    }
}