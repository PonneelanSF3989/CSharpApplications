using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum Type {Defaule,Standart , Dulex, Suit }
    public class RoomDetails
    {
        private static int s_roomID = 100;

        

        public string RoomID { get; set; }
        public Type RoomType { get; set; }
        
        public int NumnerOfBes { get; set; }
        
        public int PricePerDay { get; set; }
        
        public RoomDetails( Type roomType, int numnerOfBes, int pricePerDay)
        {
            s_roomID++;
            RoomID = "RID" + s_roomID ;
            RoomType = roomType;
            NumnerOfBes = numnerOfBes;
            PricePerDay = pricePerDay;
        }

        public RoomDetails(string data)
        {
            string [] values = data.Split(",");
            s_roomID = int.Parse(values[0].Remove(0,3));
            RoomID = values[0];
            RoomType = Enum.Parse<Type>(values[1]);
            NumnerOfBes = int.Parse(values[2]);
            PricePerDay = int.Parse(values[3]);
        }
    }
}