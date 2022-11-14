using System;
using System.IO;


namespace HotelManagement
{
    public static partial class Operations
    {
        public static void CreateFiles()
        {
            if (!Directory.Exists("Files/"))
            {
                Directory.CreateDirectory("Files/");
            }
            if (!File.Exists("Files/UsersData.csv"))
            {
                var file = File.Create("Files/UsersData.csv");
                file.Close();
            }
            if (!File.Exists("Files/BookingData.csv"))
            {
                var file = File.Create("Files/BookingData.csv");
                file.Close();
            }
            if (!File.Exists("Files/RoomDetailsData.csv"))
            {
                var file = File.Create("Files/RoomDetailData.csv");
                file.Close();
            }
            if (!File.Exists("Files/SelectionData.csv"))
            {
                var file = File.Create("Files/SelectionData.csv");
                file.Close();
            }
        }

        public static void ReadFiles()
        {
            string [] userData = File.ReadAllLines("Files/UsersData.csv");
            string [] BookingData = File.ReadAllLines("Files/BookingData.csv");
            string [] SelectionData = File.ReadAllLines("Files/SelectionData.csv");
            string [] RoomData = File.ReadAllLines("Files\\RoomDetailData.csv");

            foreach (string users in userData)
            {
                
                UserDetails user = new UserDetails(users);
                Operations.usersList.Add(user);
            }

            foreach(string bookings in BookingData)
            {
                BookingDetails booking = new BookingDetails(bookings);
                Operations.bookingsList.Add(booking);

            }
            foreach(string rooms in RoomData)
            {
                RoomDetails room = new RoomDetails(rooms);
                Operations.roomsList.Add(room);
            }
            foreach(string selections in SelectionData)
            {
                RoomSelection selection = new RoomSelection(selections);
                Operations.selectionsList.Add(selection);
            }

        }

        public static void WriteFiles()
        {
            string [] userData = new string[usersList.Count];
            for (int i = 0 ; i < usersList.Count ; i ++)
            {
                userData[i] = usersList[i].UserID +","+ usersList[i].Name +","+usersList[i].MobileNumber +","+ usersList[i].Aadhar +","+usersList[i].Address +","+usersList[i].PersonGender +","+usersList[i].FoodType+","+usersList[i].WalletBalance;
            }
            File.WriteAllLines("Files/usersData.csv",userData);

            string[] bookingData = new string[bookingsList.Count];
            for (int i = 0 ; i < bookingsList.Count ; i ++)
            {
                bookingData[i] = bookingsList[i].BookingID+","+bookingsList[i].UserID+","+bookingsList[i].DateOfBooking.ToString("dd/MM/yyyy hh:mm tt")+","+bookingsList[i].TotalPrice+","+bookingsList[i].BookingStatus;
            }
            File.WriteAllLines("Files/BookingData.csv",bookingData);

            string [] selectionData = new string[selectionsList.Count];
            for (int i = 0 ; i < selectionsList.Count ; i ++)
            {
                selectionData[i] = selectionsList[i].SelectionID+","+selectionsList[i].BookingID+","+selectionsList[i].RoomID+","+selectionsList[i].FromDate.ToString("dd/MM/yyyy hh:mm tt")+","+selectionsList[i].ToDate.ToString("dd/MM/yyyy hh:mm tt")+","+selectionsList[i].Price+","+selectionsList[i].NumberOfDays+","+selectionsList[i].BookingStatus;
            }
            File.WriteAllLines("Files/SelectionData.csv",selectionData);   

            string[] roomData = new string[roomsList.Count];
             for (int i = 0 ; i < roomsList.Count ; i ++)
            {
                roomData[i] = roomsList[i].RoomID+","+roomsList[i].RoomType+","+roomsList[i].NumnerOfBes+","+roomsList[i].PricePerDay;
            }
            File.WriteAllLines("Files\\RoomDetailData.csv",roomData);   


        }
    
    
    }
}