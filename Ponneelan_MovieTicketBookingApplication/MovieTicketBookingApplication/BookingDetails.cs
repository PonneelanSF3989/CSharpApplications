using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public enum Status {Default,Booked,Cancelled};
    public class BookingDetails
    {
        private static int s_bookingID = 7000;

        public string BookingID { get; set; }
        
        public string UserID { get; set; }
        public string MovieID { get; set; }
        
        public string TheaterID { get; set; }
        
        public int  SeatCount { get; set; }
        
        public int TotalAmount { get; set; }
        
        public Status BookingStatus { get; set; }
        
        public BookingDetails( string userID, string movieID, string theaterID, int seatCount, int totalAmount, Status bookingStatus)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            MovieID = movieID;
            TheaterID = theaterID;
            SeatCount = seatCount;
            TotalAmount = totalAmount;
            BookingStatus = bookingStatus;
        }
        
    }
}