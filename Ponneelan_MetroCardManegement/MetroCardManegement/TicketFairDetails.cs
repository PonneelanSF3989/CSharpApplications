namespace MetroCardManegement
{
    public class TicketFairDetails
    {
        private static int s_ticketID = 100;
        public string TicketID { get; set; }
        public Stations FromLocation { get; set; }
        public Stations ToLocation { get; set; }
        public int CostOfTicket { get; set; }
        public TicketFairDetails( Stations fromLocation, Stations toLocation, int costOfTicket)
        {
            s_ticketID++;
            TicketID = "MR" + s_ticketID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            CostOfTicket = costOfTicket;
        }
        
        
        
    }
}