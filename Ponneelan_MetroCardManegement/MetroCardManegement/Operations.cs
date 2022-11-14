using System;
using System.Collections.Generic;


namespace MetroCardManegement
{
    public static partial class Operations
    {
        public static UserDetails currentUser;
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<TravelHistroyDetails> travelList = new List<TravelHistroyDetails>();
        public static List<TicketFairDetails> ticketList = new List<TicketFairDetails>();
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nWelcome To Chennai Metro\n");
            int choice ;
            do 
            {
                Console.WriteLine("\nMain Menu \n\n1. New User Registration\n2. Login \n3. Exit\n");
                Console.Write("Enter Your Choice : ");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
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
                        Console.WriteLine("Thank You Visit Again");
                        break;
                    }
                }
            }while(choice != 3);
        }
        public static void Registration()
        {
            Console.Clear();
            Console.WriteLine("Enter Your Following Details\n\n");
            Console.Write("Your Name : ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Your Phone Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Initial Wallet Balance : ");
            int initialBalance = int.Parse(Console.ReadLine());

            UserDetails newUser = new UserDetails(name,mobileNumber,initialBalance);
            userList.Add(newUser);

            Console.Clear();
            Console.WriteLine($"Registration Successfully and Your Travel Card Number is : {newUser.CardNumber}");
        }
        public static void Login()
        {
            bool flag = false;
            Console.Clear();
            Console.Write("\nEnter Your Card Number To Login : ");
            string cardNumber = Console.ReadLine();
            foreach(UserDetails user in userList)
            {
                if (user.CardNumber == cardNumber)
                {
                    flag = true;
                    currentUser = user;
                    Console.Clear();
                    subMenu();
                    break;
                }
            }
            if (!flag)
            {
                Console.Clear();
                Console.WriteLine("Card Number Not Found!");
            }
        }
        public static void SubMenu()
        {
            Console.WriteLine($"\nWelcome {currentUser.UserName}\n");
            int choice ;
            do
            {   
                Console.WriteLine("Login Menu");
                Console.WriteLine("\n1. Wallet Balance\n2. Recharge Wallet\n3. Travel Histroy\n4. Plan Travel\n5. Goto Main Menu\n");
                Console.Write("Enter Your Choice : ");
                choice  = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1: 
                    {
                        
                        checkBalance();
                        break;
                    }
                    case 2: 
                    {
                        rechargeWallet();
                        break;
                    }
                    case 3: 
                    {
                        showTravelHistroy();
                        break;
                    }
                    case 4: 
                    {
                        planTravel();
                        break;
                    }
                    case 5: 
                    {
                        break;
                    }
                    default : 
                    {
                        Console.WriteLine("Invalid Entry\n");
                        break;
                    }
                }
            }while(choice != 5);
            Console.Clear();
        }
        public static void CheckBalance()
        {
            int choice;
            Console.Clear();
            currentUser.ShowBalance();
            Console.Write("\n\n\nEnter 99 To Go Back : ");
            choice = int.Parse(Console.ReadLine());
            while(choice != 99)
            {
                Console.Write("\nInvalid! Please Enter 99 To Go Back : ");
                choice = int.Parse(Console.ReadLine());
            }
            Console.Clear();
        }
        public static void RechargeWallet()
        {
            int choice;
            int amount;
            Console.Clear();
            Console.Write("Enter Amount To Recharge Your Wallet : ");
            amount = int.Parse(Console.ReadLine());
            Console.Clear();
            currentUser.Balance += amount;
            Console.WriteLine("Recharge Wallet Successfully ");
            Console.Write("\n\n\nEnter 99 To Go Back : ");
            choice = int.Parse(Console.ReadLine());
            while(choice != 99)
            {
                Console.Write("\nInvalid! Please Enter 99 To Go Back : ");
                choice = int.Parse(Console.ReadLine());
            }
            Console.Clear();
        }
        public static void ShowTravelHistroy()
        {
            int choice;
            bool flag = false;
            Console.Clear();
            foreach(TravelHistroyDetails travels in travelList)
            {
                if (travels.CardNumber == currentUser.CardNumber)
                {
                    flag = true;
                    Console.WriteLine($"Travel ID : {travels.TravelID}      Travel Date : {travels.DateOfTravel}       From : {travels.FromLocation}       To : {travels.ToLocation}       Cost Of Travel : {travels.TravelCost}\n");
                }
            }
            if (!flag)
            {
                Console.Clear();
                Console.WriteLine("No Travel Found");
            }

            Console.Write("\n\n\nEnter 99 To Go Back : ");
            choice = int.Parse(Console.ReadLine());
            while(choice != 99)
            {
                Console.Write("\nInvalid! Please Enter 99 To Go Back : ");
                choice = int.Parse(Console.ReadLine());
            }
            Console.Clear();

        }
        public static void PlanTravel()
        {
            bool flag = false;
            int choice;
            Console.Clear();
            Console.WriteLine("Book Your Ticket Now....\n");
            Console.WriteLine();
            foreach(TicketFairDetails tickets in ticketList)
            {
                    Console.WriteLine($"Ticket ID : {tickets.TicketID}       From : {tickets.FromLocation}       To : {tickets.ToLocation}       Cost Of Travel : {tickets.CostOfTicket}\n");
            }
            Console.WriteLine("\n\n\n");
            Console.Write("Enter The Ticket ID To Book Ticket : ");
            string ticketID = Console.ReadLine();
            foreach(TicketFairDetails tickets in ticketList)
            {
                if (tickets.TicketID == ticketID)
                {
                    flag = true;
                    if (currentUser.Balance >= tickets.CostOfTicket)
                    {
                        
                        currentUser.Balance -= tickets.CostOfTicket;
                        TravelHistroyDetails newTravel = new TravelHistroyDetails(currentUser.CardNumber,tickets.FromLocation,tickets.ToLocation,DateOnly.FromDateTime(DateTime.Today),tickets.CostOfTicket);
                        travelList.Add(newTravel);
                        Console.Clear();
                        Console.WriteLine($"Ticket Book Successfully And Your travel ID is : {newTravel.TravelID}");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Insufficiant Balance . Please Recharge ");
                    }
                }
            }
            if (!flag)
            {
                Console.Clear();
                Console.WriteLine("Invalid Ticket Id");
            }

            Console.Write("\n\n\nEnter 99 To Go Back : ");
            choice = int.Parse(Console.ReadLine());
            while(choice != 99)
            {
                Console.Write("\nInvalid! Please Enter 99 To Go Back : ");
                choice = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            
        }
        public static void AddDefaultData()
        {
            TravelHistroyDetails newTravel1 = new TravelHistroyDetails("CMRL101",Stations.Airport,Stations.Egmore,new DateOnly(2022,10,10),22);
            TravelHistroyDetails newTravel2 = new TravelHistroyDetails("CMRL101",Stations.Egmore,Stations.Koyambedu,new DateOnly(2022,10,10),22);
            TravelHistroyDetails newTravel3 = new TravelHistroyDetails("CMRL102",Stations.Alandur,Stations.Koyambedu,new DateOnly(2022,10,11),22);
            TravelHistroyDetails newTravel4 = new TravelHistroyDetails("CMRL102",Stations.Egmore,Stations.Thirumangalam,new DateOnly(2022,10,11),22);

            travelList.Add(newTravel1);
            travelList.Add(newTravel2);
            travelList.Add(newTravel3);
            travelList.Add(newTravel4);

            TicketFairDetails ticket1 = new TicketFairDetails(Stations.Airport,Stations.Egmore,55);
            TicketFairDetails ticket2 = new TicketFairDetails(Stations.Airport,Stations.Koyambedu,25);
            TicketFairDetails ticket3 = new TicketFairDetails(Stations.Alandur,Stations.Koyambedu,25);
            TicketFairDetails ticket4 = new TicketFairDetails(Stations.Koyambedu,Stations.Egmore,32);
            TicketFairDetails ticket5 = new TicketFairDetails(Stations.Vadapalani,Stations.Egmore,45);
            TicketFairDetails ticket6 = new TicketFairDetails(Stations.Arumbakkam,Stations.Egmore,25);
            TicketFairDetails ticket7 = new TicketFairDetails(Stations.Vadapalani,Stations.Koyambedu,25);
            TicketFairDetails ticket8 = new TicketFairDetails(Stations.Arumbakkam,Stations.Koyambedu,16);

            ticketList.Add(ticket1);
            ticketList.Add(ticket2);
            ticketList.Add(ticket3);
            ticketList.Add(ticket4);
            ticketList.Add(ticket5);
            ticketList.Add(ticket6);
            ticketList.Add(ticket7);
            ticketList.Add(ticket8);

            UserDetails user1 = new UserDetails("Baskaran",9090909090,1000);
            UserDetails user2 = new UserDetails("Ravi",8080808080,20);

            userList.Add(user1);
            userList.Add(user2);



        }
    }
}