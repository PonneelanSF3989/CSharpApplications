using System;


namespace OnlineLibraryManegement
{
    public class BorrowDetails
    {
        private int s_borrowId = 300;
        public string BorrowID { get; }
        public string BookID { get; set; }
        public string RegistrationID { get; set; }
        public DateTime BorrowDate { get; set; }
        public Enum Status { get; set; }
        public BorrowDetails(string RegID, string bookID, DateTime borrowDate, Enum staus)
        {
            s_borrowId++ ;
            BorrowID = "LB" + s_borrowId;
            RegistrationID = RegID;
            BookID = bookID;
            BorrowDate = borrowDate;
            Status = staus; 
        }
        
        
        
        
        
    }
}