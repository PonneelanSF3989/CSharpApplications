using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class BookingDetails
    {
        private static int s_bookingID = 101;

        
        public string BookingID { get; set; }

        public string UserID { get; set; }
        
        public int TotalPrice { get; set; }
        
        public DateTime DateOfBooking { get; set; }
        
        public Status BookingStatus { get; set; }
        
        public BookingDetails( string userID, int totalPrice, DateTime dateOfBooking, Status bookingStatus)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            UserID = userID;
            TotalPrice = totalPrice;
            DateOfBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }

        public BookingDetails(string data)
        {
            string [] values = data.Split(",");
            s_bookingID = int.Parse(values[0].Remove(0,3));
            BookingID = values[0];
            UserID = values[1];
            TotalPrice = int.Parse(values[3]);
            DateOfBooking = DateTime.ParseExact(values[2],"dd/MM/yyyy hh:mm tt",null);
            BookingStatus = Enum.Parse<Status>(values[4]);
        }
    }
}