using System;
using System.IO;

namespace MovieTicketBookingApplication
{
    public static partial class Operation
    {
        public static void CreateFiles()
        {
            if (!Directory.Exists("Files\\"))
            {
                Directory.CreateDirectory("Files\\");
            }


            if (!File.Exists("Files\\MovieData.csv"))
            {
                var file = File.Create("Files\\MovieData.csv");
                file.Close();
            }


            if (!File.Exists("Files\\TheaterData.csv"))
            {
                var file = File.Create("Files\\TheaterData.csv");
                file.Close();
            }


            if (!File.Exists("Files\\ScreeningData.csv"))
            {
                var file = File.Create("Files\\ScreeningData.csv");
                file.Close();
            }


            if (!File.Exists("Files\\UsersData.csv"))
            {
                var file = File.Create("Files\\UsersData.csv");
                file.Close();
            }


            if (!File.Exists("Files\\BookingData.csv"))
            {
                var file = File.Create("Files\\BookingData.csv");
                file.Close();
            }


            

        }
        

        //write the data from files
        public static void WriteFiles()
        {



            string[] userDetails = new string[ usersList.Count];
            for (int i = 0 ; i < usersList.Count ; i++)
            {
                userDetails[i] = usersList[i].UserID +","+usersList[i].Name+","+usersList[i].Age+","+usersList[i].PhoneNumber+","+usersList[i].WalletBalance;  
            }
            File.WriteAllLines("Files\\UsersData.csv",userDetails);




            string[] bookingDetails = new string[ bookingsList.Count];
            for (int i = 0 ; i < bookingsList.Count ; i++)
            {
                bookingDetails[i] = bookingsList[i].BookingID +","+bookingsList[i].UserID+","+bookingsList[i].TheaterID+","+bookingsList[i].MovieID+","+bookingsList[i].SeatCount+","+bookingsList[i].TotalAmount+","+bookingsList[i].BookingStatus;  
            }
            File.WriteAllLines("Files\\BookingData.csv",bookingDetails);




            string[] screeningDetails = new string[ screeningsList.Count];
            for (int i = 0 ; i < screeningsList.Count ; i++)
            {
                screeningDetails[i] = screeningsList[i].TheaterID +","+screeningsList[i].MovieID+","+screeningsList[i].TicketPrice+","+screeningsList[i].NoOfSeatsAvailable;  
            }
            File.WriteAllLines("Files\\ScreeningData.csv",screeningDetails);



            string[] theaterDetails = new string[ theatersList.Count];
            for (int i = 0 ; i < theatersList.Count ; i++)
            {
                theaterDetails[i] = theatersList[i].TheaterID +","+theatersList[i].TheaterName+","+theatersList[i].TheaterLocation;  
            }

            File.WriteAllLines("Files\\TheaterData.csv",theaterDetails);


            string[] movieDetails = new string[ theatersList.Count];
            for (int i = 0 ; i < theatersList.Count ; i++)
            {
                movieDetails[i] = moviesList[i].MovieID +","+moviesList[i].MovieName+","+moviesList[i].MovieLanguage;  
            }

            File.WriteAllLines("Files\\MovieData.csv",movieDetails);
        }
    
    }
}