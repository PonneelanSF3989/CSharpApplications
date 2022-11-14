using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApplication
{
    public enum Status{Default,Initiate,Booked,Cancelled}
    public class BookingDetails
    {
        private static int s_bookingID = 1000;
        public string BookingID { get; set; }
        public string CustomerID { get; set; }
        public DateTime DateOfBooking { get; set; }
        public int TotalPrice { get; set; }
        public Status BookingStatus { get; set; }
        
        
        

        public BookingDetails(string customerID,DateTime dateOfBooking, int totalPrice,Status bookingStatus)
        {
            s_bookingID++;
            BookingID = "BID" + s_bookingID;
            CustomerID = customerID;
            DateOfBooking = dateOfBooking;
            TotalPrice = totalPrice;
            BookingStatus = bookingStatus;
           

        }
        public BookingDetails(string data)
        {
            string[] values = data.Split(",");
            s_bookingID=int.Parse(values[0].Remove(0,3));
            BookingID=values[0];
            CustomerID = values[1];
            TotalPrice=int.Parse(values[2]);
            DateOfBooking=DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            BookingStatus = Enum.Parse<Status>(values[4]);
        }

        public void ShowBookingData()
        {
            Console.WriteLine($"BookingID : {BookingID}\nCustomerID : {CustomerID}\nDate Of Booking : {DateOfBooking}\nTotal Price : {TotalPrice}\nBooking Status : {BookingStatus}\n\n");
        }
        
        
        
        
    }
}