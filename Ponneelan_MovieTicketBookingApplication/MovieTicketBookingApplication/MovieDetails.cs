using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public class MovieDetails
    {
        private static int s_movieID = 501;

        public string MovieID { get; set; }
        
        public string MovieName { get; set; }
        
        public string MovieLanguage { get; set; }
        
        public MovieDetails( string movieName, string movieLanguage)
        {
            s_movieID++;
            MovieID = "MID" + s_movieID;
            MovieName = movieName;
            MovieLanguage = movieLanguage;
        }
        
    }
}