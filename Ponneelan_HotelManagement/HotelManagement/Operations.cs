using System;
namespace HotelManagement
{
    public static partial class Operations
    {
        public static List<UserDetails> usersList = new List<UserDetails>();
        public static List<BookingDetails> bookingsList = new List<BookingDetails>();
        public static List<RoomSelection> selectionsList = new List<RoomSelection>();
        public static List<RoomDetails> roomsList = new List<RoomDetails>();
        static UserDetails currentUser ;
        public static void AddDefaultData()
        {
            //creating object to user Details class 
            UserDetails user1 = new UserDetails("Ravichandran",78786887987,347777378383,"Chennai",Gender.Male,Food.Veg,5000);
            UserDetails user2 = new UserDetails("Baskaran",9898989898,474777477477,"Chennai",Gender.Male,Food.NonVeg,6000);
            
            //add the users object to the users list 
            usersList.Add(user1);
            usersList.Add(user2);

            //creating object to the booking details class
            BookingDetails booking1 = new BookingDetails("SF1001",1450,new DateTime(2022,10,11),Status.Booked);
            BookingDetails booking2 = new BookingDetails("SF1002",2000,new DateTime(2022,10,11),Status.Cancelled);

            //add to the bookingsDetails list
            bookingsList.Add(booking1);
            bookingsList.Add(booking2);

            //createing objcet to the roomDetails class
            RoomDetails room1 = new RoomDetails(Type.Standart,2,500); 
            RoomDetails room2 = new RoomDetails(Type.Standart,4,700); 
            RoomDetails room3 = new RoomDetails(Type.Standart,2,500); 
            RoomDetails room4 = new RoomDetails(Type.Standart,2,500); 
            RoomDetails room5 = new RoomDetails(Type.Standart,2,500); 
            RoomDetails room6 = new RoomDetails(Type.Dulex,2,1000); 
            RoomDetails room7 = new RoomDetails(Type.Dulex,2,1000);
            RoomDetails room8 = new RoomDetails(Type.Dulex,4,1400);
            RoomDetails room9 = new RoomDetails(Type.Dulex,4,1400);
            RoomDetails room10 = new RoomDetails(Type.Suit,2,2000);
            RoomDetails room11 = new RoomDetails(Type.Suit,2,2000);
            RoomDetails room12 = new RoomDetails(Type.Suit,2,2000);
            RoomDetails room13 = new RoomDetails(Type.Suit,4,2500);

            //add to the RoomsDetails list
            roomsList.Add(room1);
            roomsList.Add(room2);
            roomsList.Add(room3);
            roomsList.Add(room4);
            roomsList.Add(room5);
            roomsList.Add(room6);
            roomsList.Add(room7);
            roomsList.Add(room8);
            roomsList.Add(room9);
            roomsList.Add(room10);
            roomsList.Add(room11);
            roomsList.Add(room12);
            roomsList.Add(room13);

            //creating object to the selectionDetails class
            RoomSelection selection1 = new RoomSelection("BID101","RID101",new DateTime(2022,11,11),new DateTime(2022,11,12),750,1.5,Status.Booked);
            RoomSelection selection2 = new RoomSelection("BID101","RID102",new DateTime(2022,11,11),new DateTime(2022,11,12),700,1,Status.Booked);
            RoomSelection selection3 = new RoomSelection("BID102","RID103",new DateTime(2022,11,12),new DateTime(2022,11,13),500,1,Status.Cancelled);
            RoomSelection selection4 = new RoomSelection("BID102","RID106",new DateTime(2022,11,12),new DateTime(2022,11,13),1500,1.5,Status.Cancelled);

            //add the selectionDetails object to the selectionList
            selectionsList.Add(selection1);
            selectionsList.Add(selection2);
            selectionsList.Add(selection3);
            selectionsList.Add(selection4);

            
        }

        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|   Online Hotel Booking Application   |");
            Console.WriteLine("+--------------------------------------+");
        }
        public static void MainMenu()
        {
            
            int choice;
            do 
            {
                Welcome();   
                Console.WriteLine("\n+--------------------------------------+");
                Console.WriteLine("\n\n    1. Register New User\n\n    2. Login\n\n    3. Exit\n\n");
                Console.WriteLine("+--------------------------------------+\n");
                Console.Write("\nEnter Your Choice : ");
                choice = int.Parse(Console.ReadLine());

                switch(choice )
                {
                    case 1 :
                    {
                        registration();
                        break;
                    } 
                    case 2 :
                    {
                       login();
                        break;
                    } 
                    case 3 :
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nExit !\n\n");
                        break;
                    } 
                    default : 
                    {
                        Console.WriteLine("\n\nInvalid Choice : \n\n");
                        break;
                    }
                }
            }while(choice != 3);
        }

        public static void Login()
        {
            Welcome();
            bool flag = false;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|              Login Page              |");
            Console.WriteLine("+--------------------------------------+");
            Console.Write("\n   Enter User ID to Login : ");
            string userID = Console.ReadLine();
            foreach(UserDetails user in usersList)
            {
                if (user.UserID == userID)
                {
                    flag = true;
                    currentUser = user;
                    subMenu();
                    break;
                }
            }
            if(!flag)
            {
                Console.Clear();
                Console.WriteLine("\n\n       Invalid User ID \n");
            }
            GoBack();
        }

        public static void Registration()
        {
            Welcome();
            Console.WriteLine("\n+--------------------------------------+");
            Console.WriteLine("|          Registration Page :         |");
            Console.WriteLine("+--------------------------------------+\n");
            Console.Write("\n\n     Enter Your Name :");
            string name = Console.ReadLine();
            Console.Write("\n\n     Enter Your Mobile Number : ");
            long mobileNumner = long.Parse(Console.ReadLine());
            Console.Write("\n\n     Enter Your Aadhar Number : ");
            long aadharNumber = long.Parse(Console.ReadLine());
            Console.Write("\n\n     Enter Your Address : ");
            string address = Console.ReadLine();
            Console.Write("\n\n     Enter Your Gender ( Male : Female : Transgender ) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("\n\n     Which Type Of Food You Wish (Veg or NonVeg) : ");
            Food foodType = Enum.Parse<Food>(Console.ReadLine(),true);
            Console.Write("\n\n     Enter Initial Wallet Balance : ");
            int amount = int.Parse(Console.ReadLine());

            UserDetails newUser = new UserDetails(name,mobileNumner,aadharNumber,address,gender,foodType,amount);
            usersList.Add(newUser);
            Console.Clear();
            Console.WriteLine("\n+------------------------------------------------------------------+");
            Console.WriteLine($"|   Registration Successfully, Your Registration ID is : {newUser.UserID}    |");
            Console.WriteLine("+------------------------------------------------------------------+");

            GoBack();
        }
        public static void SubMenu()
        {
            Welcome();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine($"|        Welcome {currentUser.Name,-14}        |");
            Console.WriteLine("+--------------------------------------+");
            int choice;
            do
            {
                Console.WriteLine("\n\n      1. View Customer Profile\n      2. Book Room\n      3. Cancle Room\n      4. Recharge Wallet\n      5. Booking History\n      6. Exit\n");
                Console.Write("\n\n      Enter your Choice : ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                    {
                        showProfile();
                        break;
                    }
                    case 2:
                    {
                        bookRoom();
                        break;
                    }
                    case 3:
                    {
                        cancelRoom();
                        break;
                    }
                    case 4:
                    {
                        rechargeWallet();
                        break;
                    }
                    case 5:
                    {
                        showBookingHistory();
                        break;
                    }
                    case 6:
                    {
                        Console.Clear();
                        break;
                    }
                    default : 
                    {
                        Console.Clear();
                        Console.WriteLine("\nInvalid Choice :");
                        break;
                    }

                }
            }while(choice != 5);
        }

        public static void ShowUserProfile()
        {
            //Welcome();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("+-------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|                                        Users Details                                            |");
            Console.WriteLine("+-------------------------------------------------------------------------------------------------+");
            Console.WriteLine($"| {"Name",-14} | {"UserId",-7} | {"Mobile Number",-10} | {"Aadhar Number",12} | {"Address",-10} | {"Gender",-11} | {"Food Type",-7} |");
            Console.WriteLine("+-------------------------------------------------------------------------------------------------+");

            foreach(UserDetails user in usersList)
            {
                if (user.UserID == currentUser.UserID)
                {
                    Console.WriteLine($"| {currentUser.Name,-14} | {currentUser.UserID,-7} | {currentUser.MobileNumber,-13} | {currentUser.Aadhar,13} | {currentUser.Address,-10} | {currentUser.PersonGender,-11} | {currentUser.FoodType,-9} |");
                    Console.WriteLine("+-------------------------------------------------------------------------------------------------+");
                }
            }
            GoBack();
        }

        public static void ShowBookingHistory()
        {
            Console.Clear();
            //Welcome();
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                        Booking Histroy                      |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("| Booking ID | date Of Booking | Total Price | Booking Status |");
            Console.WriteLine("+------------+-----------------+-------------+----------------+");
            bool flag = false;
            bool bookigFlag = false;
            foreach(BookingDetails booking in bookingsList)
            {
                if (booking.UserID == currentUser.UserID)
                {
                    flag =true;
                    Console.WriteLine($"| {booking.BookingID,-10} | {booking.DateOfBooking.ToString("dd/MM/yyyy"),-15} | {booking.TotalPrice,-11} | {booking.BookingStatus,-14} |");
                    Console.WriteLine("+------------+-----------------+-------------+----------------+");
                }
            }
            if (!flag)
            {
                Console.WriteLine("|                        No Bookings Found                    |");
                Console.WriteLine("+------------+-----------------+-------------+----------------+");
            }
            else
            {
                Console.Write("\nEnter The Booking ID To show Booked selection : ");
                string bookingID = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("|                                                Room Selection Details                                                |");
                Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");
                Console.WriteLine("| Booking ID | Seletion ID | Room ID | Check In Date | Check Out Date | Numbers Of Days | Total Price | Booking Status |");
                Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------+");

                foreach(RoomSelection selection in selectionsList)
                {
                    if (selection.BookingID == bookingID )
                    {
                        bookigFlag = true; //////got to othes
                        Console.WriteLine($"| {selection.BookingID,-10} | {selection.SelectionID,-11} | {selection.RoomID,-7} | {selection.FromDate.ToString("dd/MM/yyyy"),-13} | {selection.ToDate.ToString("dd/MM/yyyy"),-14} | {selection.NumberOfDays,-15} | {selection.Price,-11} | {selection.BookingStatus,-14} |");
                        Console.WriteLine("+------------+-------------+---------+---------------+----------------+-----------------+-------------+----------------+");
                    }
                }
                if (!bookigFlag)
                {
                    Console.WriteLine("|                                            No Boookings Found                                                        |");
                    Console.WriteLine("+------------+-------------+---------+---------------+----------------+-----------------+-------------+----------------+");

                }
            }
            GoBack();
            
        }

        public static void CancelBooking()
        {
            string bookingID;
            Console.Clear();
            bool bookingIdFlag = false;
            bool bookingFound = false;
            BookingDetails currentBooking;

            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine("|                     Booking Deatails                 |");
            Console.WriteLine("+------------------------------------------------------+");
            Console.WriteLine("| Booking Id | Date Of Booking | Total Amount | Status |");
            Console.WriteLine("+------------+-----------------+--------------+--------+");
            //display the bookig details 
            foreach(BookingDetails booking in bookingsList)
            {
                if (booking.UserID == currentUser.UserID)
                {
                    if (booking.BookingStatus == Status.Booked)
                    {
                        bookingFound = true;
                        Console.WriteLine($"| {booking.BookingID,-10} | {booking.DateOfBooking.ToString("dd/MM/yyyy"),-15} | {booking.TotalPrice,12} | {booking.BookingStatus,-6} |");
                         Console.WriteLine("+------------+-----------------+--------------+--------+");
                    }
                }
            }

            if (bookingFound)
            {
                //geting booking id from user
                Console.Write("\n\nEnter Booking ID to cancel : ");
                bookingID = Console.ReadLine();
                

                //validate booking id
                foreach(BookingDetails booking in bookingsList)
                {
                    if (booking.UserID == currentUser.UserID)
                    {
                        if (booking.BookingID == bookingID)
                        {
                            currentBooking = booking;
                            bookingIdFlag = true;
                            booking.BookingStatus = Status.Cancelled;
                            int totalAmount = booking.TotalPrice;
                            currentUser.DetectAmountToWallet(totalAmount);
                            foreach(RoomSelection selection in selectionsList)
                            {
                                if (selection.BookingID == bookingID)
                                {
                                    selection.BookingStatus = Status.Cancelled;
                                    
                                }
                            }
                            Console.WriteLine("\nBooking Cancel Successfully");
                        }
                    }
                }
                
            }
            else
            {
                Console.WriteLine("|                    Booking Not Found                  |");
                Console.WriteLine("+------------+-----------------+--------------+--------+");
            }
            if (bookingFound && !bookingIdFlag)
            {
                //Console.Clear();
                Console.WriteLine("\n\nInvalid Booking ID");
                
            }
           
            GoBack();
        }

        public static void GoBack()
        {
            Console.Write("\n\n\nPress any key To Go Back : ");
            var key = Console.ReadKey();
            Console.Clear();
           
        }

        public static void BookRoom()
        {
            Console.Clear();

            int totalRent = 0;
            double roomRent = 0;

            
            bool roomIdIsValid = false;

            RoomDetails currentRoom = null;

            BookingDetails newBooking = new BookingDetails(currentUser.UserID,0,DateTime.Today,Status.Initiate);
            List<RoomSelection> tempSelectionList = new List<RoomSelection>();
           
            
            string isRepeat;
            do
            {
                Console.Clear();
                Console.WriteLine("+--------------------------------------------------------------+");
                Console.WriteLine("|                         Rooms Details                        |");
                Console.WriteLine("+--------------------------------------------------------------+");
                Console.WriteLine("|  Room ID  |  Room Type  |  Number Of Beds  |  Price Per Day  |");
                Console.WriteLine("+-----------+-------------+------------------+-----------------+");
                bool isBooked = false;
                bool roomIsNotBooked = true;
                foreach(RoomDetails rooms in roomsList)
                {
                    Console.WriteLine($"|  {rooms.RoomID,-7}  |  {rooms.RoomType,-9}  |  {rooms.NumnerOfBes,-14}  |  {rooms.PricePerDay,-13}  |");
                    Console.WriteLine("+-----------+-------------+------------------+-----------------+");
                }


                Console.Write("\n\n\nEnter the Room ID : ");
                string roomId = Console.ReadLine();

                Console.Write("\nWhen Your Want Room Please Enter Date in this format ( dd/MM/yyyy hh:mm tt ): ");
                DateTime checkInDate = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy hh:mm tt",null);

                Console.Write("\nHow many Days You Want Room : ");
                double noOfDays = double.Parse(Console.ReadLine());

                DateTime checkOutDate = checkInDate.AddDays(noOfDays);

                foreach(RoomDetails rooms in roomsList)
                {
                    if (rooms.RoomID == roomId)
                    {
                        roomIdIsValid = true;
                        currentRoom = rooms;
                    }
                }
                foreach(RoomSelection selection in selectionsList)
                {
                    if (selection.RoomID == roomId)
                    {
                        roomIsNotBooked = false;
                        if (selection.BookingStatus != Status.Booked)
                        {
                            isBooked = true;
                        }
                    }
                }

                if(roomIdIsValid)
                {
                    if (isBooked || roomIsNotBooked)
                    {
                        roomRent = currentRoom.PricePerDay * noOfDays;
                        RoomSelection newSelection = new RoomSelection(newBooking.BookingID,roomId,checkInDate,checkOutDate,(int)roomRent,noOfDays,Status.Booked);
                        tempSelectionList.Add(newSelection);
                        Console.WriteLine("This Room Added to card ");
                        
                    }
                    else
                    {
                        Console.WriteLine("\n\nRoom Already booked");
                    }
                }
                else
                {
                    Console.WriteLine("\n\nRoom ID Invalid ");
                }



                Console.Write("\n\ndo You Want Book Another Room Press 'yes' : ");
                isRepeat = Console.ReadLine().ToLower();
            }while(isRepeat == "yes");
            
            foreach(RoomSelection selection1 in tempSelectionList)
            {
                totalRent += selection1.Price; 
            }
            newBooking.BookingStatus = Status.Booked;
            newBooking.TotalPrice = totalRent;

            do
            {
                if (currentUser.WalletBalance >= totalRent )
                {
                    selectionsList.AddRange(tempSelectionList);
                    bookingsList.Add(newBooking);
                    currentUser.DetectAmountToWallet(totalRent);
                    Console.Clear();
                    Console.WriteLine($"\n\nRoom Booked Successfully : Your Booking ID {newBooking.BookingID}");
                    break;
                }
                else
                {
                    Console.Write("\n\nInsuffucient Balance ! Do you he want to proceed booking after recharge Press 'yes' :");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "yes")
                    {
                        Console.WriteLine($"\n\n You Need {totalRent - currentUser.WalletBalance} Rubees to Book Room");
                        RechargeWallet();
                    }
                }
            }while(currentUser.WalletBalance >= totalRent);
            
            GoBack();
        }
   
        public static void RechargeWallet()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.WriteLine("|                            Wallet Recharge                       |");
            Console.WriteLine("+------------------------------------------------------------------+");
            Console.WriteLine("\n\n");
            Console.Write($"        Enter the Amount To Recharge Your Wallet : ");
            int amount = int.Parse(Console.ReadLine());
            currentUser.AddAmountToWallet(amount);
            Console.WriteLine($"\n\n        Wallet Recharge Successfully Your Wallet Balance {currentUser.WalletBalance}");
            GoBack();
        }
   
   
   
   
    }
}