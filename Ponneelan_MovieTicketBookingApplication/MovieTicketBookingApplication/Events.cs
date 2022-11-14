using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBookingApplication
{
    public delegate void MovieApplicationDelegate();
    public static partial class Operation
    {
        public static event MovieApplicationDelegate eventLink;
        public static event MovieApplicationDelegate registration,login,subMenu,bookTicket,cancelTicket,rechargeWallet,showBookingHistory;

        public static  void Subscribe()
        {
            eventLink += new MovieApplicationDelegate(CreateFiles);
            //eventLink += new MovieApplicationDelegate(AddDefaultdata);
            eventLink += new MovieApplicationDelegate(MainMenu);
            eventLink += new MovieApplicationDelegate(WriteFiles);

            registration = new MovieApplicationDelegate(Registration);
            login = new MovieApplicationDelegate(Login);
            subMenu = new MovieApplicationDelegate(SubMenu);
            bookTicket = new MovieApplicationDelegate(BookTicket);
            cancelTicket = new MovieApplicationDelegate(CancelTicket);
            rechargeWallet = new MovieApplicationDelegate(RechargeWallet);
            showBookingHistory = new MovieApplicationDelegate(BookingHistroy);
        }

        public static void EventHolder()
        {
            Subscribe();
            eventLink();
        }
    }
}