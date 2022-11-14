using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum Status {Default,Initiate,Booked , Cancelled}
    public class RoomSelection
    {
        private static int s_selectionID = 1000;

        

        public string SelectionID { get; set; }
        
        public string RoomID { get; set; }
        
        public string BookingID { get; set; }
        
        public DateTime FromDate { get; set; }
        
        public DateTime ToDate { get; set; }
        
        public int Price { get; set; }
        
        public double NumberOfDays  { get; set; }
        public Status BookingStatus { get; set; }
        
        public RoomSelection(  string bookingID,string roomID, DateTime fromDate, DateTime toDate, int price, double numberOfDays, Status bookingStatus)
        {
            s_selectionID++;
            SelectionID = "SID" + s_selectionID;
            RoomID = roomID;
            BookingID = bookingID;
            FromDate = fromDate;
            ToDate = toDate;
            Price = price;
            NumberOfDays = numberOfDays;
            BookingStatus = bookingStatus;
        }

        public RoomSelection(string data)
        {
            string [] values = data.Split(",");
            s_selectionID = int.Parse(values[0].Remove(0,3));
            SelectionID = values[0];
            RoomID = values[2];
            BookingID = values[1];
            FromDate =  DateTime.ParseExact(values[3],"dd/MM/yyyy hh:mm tt",null);
            
            Price = int.Parse(values[5]);
            NumberOfDays = double.Parse(values[6]);
            BookingStatus = Enum.Parse<Status>(values[7]);
        }
    }
}