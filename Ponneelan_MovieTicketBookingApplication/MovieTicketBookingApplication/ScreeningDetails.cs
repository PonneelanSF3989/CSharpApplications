using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public class ScreeningDetails
    {

        public string MovieID { get; set; }
        
        public string TheaterID { get; set; }
        
        public int NoOfSeatsAvailable { get; set; }
        
        public int TicketPrice { get; set; }
        

        public ScreeningDetails(string movieID, string theaterID, int noOfSeatsAvailable, int ticketPrice)
        {
            MovieID = movieID;
            TheaterID = theaterID;
            NoOfSeatsAvailable = noOfSeatsAvailable;
            TicketPrice = ticketPrice;
        }   
    }
}