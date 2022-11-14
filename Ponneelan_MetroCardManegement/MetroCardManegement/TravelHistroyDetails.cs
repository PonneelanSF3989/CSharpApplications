using System;


namespace MetroCardManegement
{
    public enum Stations {Default,Airport,Alandur,Koyambedu,Vadapalani,Arumbakkam,Egmore,Thirumangalam};
    public class TravelHistroyDetails
    {
        private static int s_travelID = 100;
        public string TravelID { get; set; }
        public string CardNumber { get; set; }
        public Stations FromLocation { get; set; }
        public Stations ToLocation { get; set; }
        public DateOnly DateOfTravel { get; set; }
        public int  TravelCost { get; set; }
        
        public TravelHistroyDetails( string cardNumber, Stations fromLocation, Stations toLocation, DateOnly dateOfTravel, int travelCost)
        {
            s_travelID++;
            TravelID = "TID" + s_travelID;
            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            DateOfTravel = dateOfTravel;
            TravelCost = travelCost;
        }
        
        
        
        
        
        
        
        
    }
}