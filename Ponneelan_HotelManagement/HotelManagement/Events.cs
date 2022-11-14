using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public delegate void MyDelegate();
    public static partial class Operations
    {
        public static event MyDelegate eventLink;
        public static event MyDelegate registration,login,subMenu,showProfile,bookRoom,cancelRoom,showBookingHistory,rechargeWallet;


        public static void Subscribe()
        {
            eventLink += new MyDelegate(CreateFiles);
            eventLink += new MyDelegate(ReadFiles);
            //eventLink += new MyDelegate(AddDefaultData);
            eventLink += new MyDelegate(MainMenu);
            eventLink += new MyDelegate(WriteFiles);
            registration += new MyDelegate(Registration);
            login = new MyDelegate(Login);
            subMenu = new MyDelegate(SubMenu);
            showProfile = new MyDelegate(ShowUserProfile);
            bookRoom = new MyDelegate(BookRoom);
            cancelRoom = new MyDelegate(CancelBooking);
            showBookingHistory = new MyDelegate(ShowBookingHistory);
            rechargeWallet = new MyDelegate(RechargeWallet);
        }

        public static void StartApplication()
        {
            Subscribe();
            eventLink();
        }
    }
}