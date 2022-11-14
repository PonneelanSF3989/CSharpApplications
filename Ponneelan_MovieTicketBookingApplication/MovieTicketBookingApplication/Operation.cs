using System;
namespace MovieTicketBookingApplication
{
    public static partial class Operation
    {
        // Creating List store the suer  data
        public static List<UserDetails> usersList = new List<UserDetails>();

        // Creating List store the movie data
        public static List<MovieDetails> moviesList = new List<MovieDetails>();

        // Creating List store the Theater data
        public static List<TheaterDetails> theatersList = new List<TheaterDetails>();

        // Creating List store the screening data
        public static List<ScreeningDetails> screeningsList = new List<ScreeningDetails>();

        // Creating List store the booking data
        public static List<BookingDetails> bookingsList = new List<BookingDetails>();

        // create the object to the class UserDetails
        static UserDetails currentUser ;
        
        public static void AddDefaultdata()
        {
            // create the objects to the user details
            UserDetails user1 = new UserDetails("Ravichandran", 30,9987896709,1000);
            UserDetails user2 = new UserDetails("Baskaran", 30,8879088970,2000);
            
            // add the object to the list
            usersList.Add(user1);
            usersList.Add(user2);

            //create the object to the class Booking details
            BookingDetails booking1 = new BookingDetails("UID1001","MID501","TID301",1,200,Status.Booked);
            BookingDetails booking2 = new BookingDetails("UID1001","MID504","TID302",1,200,Status.Booked);
            BookingDetails booking3 = new BookingDetails("UID1002","MID504","TID302",1,300,Status.Booked);

            //add the object to list
            bookingsList.Add(booking1);
            bookingsList.Add(booking2);
            bookingsList.Add(booking3);

            TheaterDetails theater1 = new TheaterDetails("Inox","Anna Nagar");
            TheaterDetails theater2 = new TheaterDetails("Ega Theater","Chetpet");
            TheaterDetails theater3 = new TheaterDetails("Kamala","Vadapalani");

            theatersList.Add(theater1);
            theatersList.Add(theater2);
            theatersList.Add(theater3);

            ScreeningDetails screen1 = new ScreeningDetails("MID501","TID301",5,200);
            ScreeningDetails screen2 = new ScreeningDetails("MID502","TID301",2,300);
            ScreeningDetails screen3 = new ScreeningDetails("MID506","TID301",1,50);
            ScreeningDetails screen4 = new ScreeningDetails("MID501","TID302",11,400);
            ScreeningDetails screen5 = new ScreeningDetails("MID502","TID302",20,300);
            ScreeningDetails screen6 = new ScreeningDetails("MID504","TID302",2,500);
            ScreeningDetails screen7 = new ScreeningDetails("MID505","TID303",11,100);
            ScreeningDetails screen8 = new ScreeningDetails("MID502","TID303",20,200);
            ScreeningDetails screen9 = new ScreeningDetails("MID504","TID303",2,350);

            screeningsList.Add(screen1);
            screeningsList.Add(screen2);
            screeningsList.Add(screen3);
            screeningsList.Add(screen4);
            screeningsList.Add(screen5);
            screeningsList.Add(screen6);
            screeningsList.Add(screen7);
            screeningsList.Add(screen8);
            screeningsList.Add(screen9);

            MovieDetails movie1 = new MovieDetails("Love Today","Tamil");
            MovieDetails movie2 = new MovieDetails("Ponniyin Selvan","Tamil");
            MovieDetails movie3 = new MovieDetails("Prince","Tamil");
            MovieDetails movie4 = new MovieDetails("Nane Varuven","Tamil");
            MovieDetails movie5 = new MovieDetails("Vendu Thaninththu kadu","Tamil");
            MovieDetails movie6 = new MovieDetails("Vikram","Tamil");

            moviesList.Add(movie1);
            moviesList.Add(movie2);
            moviesList.Add(movie3);
            moviesList.Add(movie4);
            moviesList.Add(movie5);
            moviesList.Add(movie6);
       
        }

        public static void Registration()
        {
            Console.Clear();
            Console.WriteLine("Enter Following Details To New Registratio : \n\n");
            Console.Write("\nEnter Your Name : ");
            string name = Console.ReadLine();
            Console.Write("\nEnter Your Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Your Mobile Number : ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.Write("\nEnter Initial Wallet Amount : ");
            int amount = int.Parse(Console.ReadLine());
            UserDetails newUser = new UserDetails(name,age,mobileNumber,amount);
            usersList.Add(newUser);
            Console.Clear();
            Console.WriteLine($"\nRegistration Successfully And Your Registration ID Is : {newUser.UserID}\n");
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Movie Ticket Booking Application ");
            int choice;
            do
            {
                
                Console.WriteLine("\n1. New Registration\n2. Login\n3. Exit.\n\n");
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
                        break;
                    }
                    default : 
                    {
                        Console.WriteLine("\nInvalid Choice : ");
                        break;
                    }
                }
            }while(choice != 3);

        }

        public static void Login()
        {
            bool flag = false;
            Console.Clear();
            Console.Write("\nEnter User ID To Login : ");
            string userID = Console.ReadLine();

            foreach(UserDetails users in usersList)
            {
                if (users.UserID == userID)
                {
                    flag = true;
                    currentUser = users;
                    break;
                }
            }
            if (!flag)
            {
                Console.Clear();
                Console.WriteLine("\nInvalid user Id :");
            }
            else
            {
                subMenu();
            }
        }

        public static void SubMenu()
        {
            int choice;
            Console.Clear();
            Console.WriteLine($"Welcome {currentUser.Name}");

            do
            {
                Console.WriteLine("\n\n1. Ticket Booking\n2. Ticket Cancellation\n3. Booking Histroy\n4. Recharge Wallet\n5. Exit\n\n");
                Console.Write("Enter Your Choice : ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1 : 
                    {
                        bookTicket();
                        break;
                    }
                    case 2 : 
                    {
                        cancelTicket();
                        break;
                    }
                    case 3 : 
                    {
                        showBookingHistory();
                        break;
                    }
                    case 4 : 
                    {
                        rechargeWallet();
                        break;
                    }
                    case 5 : 
                    {
                        Console.Clear();
                        Console.WriteLine("Goto Main Menu \n\n\n");
                        break;
                    }
                    default : 
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid choice :");
                        break;
                    }

                }
            }while(choice != 5);
        }
    
        public static void BookingHistroy()
        {
            bool flag = false;
            Console.Clear();
            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            Console.WriteLine("|                                   Booking Histroy                                      |");
            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            Console.WriteLine("| Booking ID | User ID | Movie ID | Theater ID | Seat Count | Total Price |    Status    |");
            Console.WriteLine("+------------+---------+----------+------------+------------+-------------+--------------+");
            foreach(BookingDetails bookings in bookingsList)
            {
                if (currentUser.UserID == bookings.UserID)
                {
                    flag = true;
                    Console.WriteLine($"| {bookings.BookingID,-10} | {bookings.UserID,-7} | {bookings.MovieID,-8} | {bookings.TheaterID,-10} | {bookings.SeatCount,-10} | {bookings.TotalAmount,-11} | {bookings.BookingStatus,-12} |");
            Console.WriteLine ("+------------+---------+----------+------------+------------+-------------+--------------+");
                }
            }
            if (!flag)
            {
                Console.WriteLine("|                                                                                        |");
                Console.WriteLine("|                                    No bookings Found                                   |");
                Console.WriteLine("|                                                                                        |");
                Console.WriteLine("+----------------------------------------------------------------------------------------+");
            }
        }
        public static void RechargeWallet()
        {
            Console.Clear();
            Console.Write("Enter Amount To Recharge : ");
            int amount = int.Parse(Console.ReadLine());
            currentUser.RechargeWallet(amount);
            Console.Clear();
            Console.WriteLine("\n\nWallet Recharge Successfully  and Your Balance is "+ currentUser.WalletBalance);
        }
        public static void BookTicket()
        {
            bool ticketCountFlag = false;
            int avalableSeats = 0;
            double totalAmount = 0;
            bool walletFlag = false;
            bool theaterFlag = false;
            bool movieflag = false;
           
            Console.Clear();
            //display the theater list
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("|                 Theater Details              |");
            Console.WriteLine("+----------------------------------------------+");
            Console.WriteLine("| Theater ID | Theater Name | Theater Location |");
            Console.WriteLine("+------------+--------------+------------------+");
            foreach (TheaterDetails theater in theatersList)
            {
                Console.WriteLine($"| {theater.TheaterID,-10} | {theater.TheaterName,-12} | {theater.TheaterLocation,-16} |");
                Console.WriteLine("+------------+--------------+------------------+");

            }

            //get the theater id from user
            Console.Write("\n\n\nEnter Theater Id to Book Ticket : ");
            string theaterId = Console.ReadLine();

            Console.Clear();
            //diaplay the movie list
            Console.WriteLine("+-------------------------------------------+");
            Console.WriteLine("|                Movies Details             |");
            Console.WriteLine("+-------------------------------------------+");
            Console.WriteLine("| Movie ID |   Movie Name  | Movie Language |");
            Console.WriteLine("+----------+---------------+----------------+");
            foreach(TheaterDetails theater in theatersList)
            {
                if (theater.TheaterID == theaterId)
                {
                    theaterFlag = true;   
                    foreach(ScreeningDetails screens in screeningsList)
                    {
                        
                        if (screens.TheaterID == theaterId)
                        {
                            //Console.Write(2);
                            foreach(MovieDetails movies in moviesList)
                            {
                                
                                if (movies.MovieID == screens.MovieID)
                                {
                                    
                                    //Console.Write(3);
                                    Console.WriteLine($"| {movies.MovieID,-8} | {movies.MovieName,-13} | {movies.MovieLanguage,-14} |");
                                    Console.WriteLine("+----------+---------------+----------------+");
                                }
                                
                            }
                        }
                    }
                }
                
                
            }
            

            //get moive list from the user
            Console.Write("\n\n\nEnter the Movie Id to Book Ticket : ");
            string movieID = Console.ReadLine();

            //get the no of ticket count gfrom user
            Console.Write("\nEnter Count of seates : ");
            int ticketCount = int.Parse(Console.ReadLine());

            //book the ticket
            foreach(ScreeningDetails screens in screeningsList)
            {
                if (screens.TheaterID == theaterId && screens.MovieID == movieID)
                {
                    movieflag = true;
                    //set movie flag

                    avalableSeats = screens.NoOfSeatsAvailable;
                    if (screens.NoOfSeatsAvailable >= ticketCount)
                    {
                        ticketCountFlag = true;  //ser flag for available ticket
                        double tax = ((double)screens.TicketPrice * ticketCount) * 0.18;
                        totalAmount = ((double)screens.TicketPrice * ticketCount) + (int)tax;   //claculaye the total amount
                        if (currentUser.WalletBalance >= totalAmount)
                        {
                            walletFlag = true;      //set flag to waller balance 
                            currentUser.WalletBalance -= (int)totalAmount; //deduct total amount
                            screens.NoOfSeatsAvailable -= ticketCount; //deduct the seats count
                            //create the object to the booking details class
                            BookingDetails newBook = new BookingDetails(currentUser.UserID,movieID,theaterId,ticketCount,(int)totalAmount,Status.Booked);
                            //add the object to booking list
                            bookingsList.Add(newBook);
                            Console.Clear();
                            Console.WriteLine("\nMovie Ticket Book Successfully ");
                        }
                        if (!walletFlag)
                        {
                            Console.Clear();
                            Console.WriteLine("\nNot Enough Balance");
                        }
                    }
                }
            }
            
            if (!theaterFlag)
            {
                Console.Clear();
                Console.WriteLine("\nInvalid Theater Id");
            }
            if(!movieflag)
            {
                Console.Clear();
                Console.WriteLine("\nInvalid Movie ID");
            }
            if (!ticketCountFlag)
            {
                Console.Clear();
                Console.WriteLine("\nSeats not available , Current Availability : "+avalableSeats);
            }
            
        }
        public static void CancelTicket()
        {
            bool isValid = false;
            BookingHistroy(); 
            Console.WriteLine();
            do 
            {
                //Console.Clear();
                
                Console.Write("Enter The Booking ID to Cancel Booking : ");
                string bookingID = Console.ReadLine();

                foreach(BookingDetails bookings in bookingsList)
                {
                    if (bookings.BookingID == bookingID)
                    {
                        isValid = true;
                        if (bookings.BookingStatus == Status.Booked)
                        {
                            bookings.BookingStatus = Status.Cancelled;
                            currentUser.WalletBalance += bookings.TotalAmount - 20 ;
                            foreach (ScreeningDetails screens in screeningsList)
                            {
                                if (screens.TheaterID == bookings.TheaterID)
                                {
                                    if (screens.MovieID == bookings.MovieID)
                                    {
                                        screens.NoOfSeatsAvailable += bookings.SeatCount;
                                    }
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("Cancelled Successfully : ");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\nits already cancelled : ");
                        }
                    }
                }
                if (!isValid) 
                {
                    
                    Console.WriteLine("\n\n\nInvalid Booking ID");
                }
                
            }while(isValid != true);

        }
        
    }
}