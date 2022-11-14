namespace MetroCardManegement
{
    public delegate void EventHandler();
    public static partial class Operations
    {
        public static event EventHandler eventLink;
        public static event EventHandler registration,login,subMenu,checkBalance,rechargeWallet,showTravelHistroy,planTravel;

        public static void Subscribe()
        {
            eventLink += new EventHandler(AddDefaultData);
            eventLink += new EventHandler(MainMenu);
            registration = new EventHandler(Registration);
            login = new EventHandler(Login);
            subMenu = new EventHandler(SubMenu);
            checkBalance = new EventHandler(CheckBalance);
            rechargeWallet = new EventHandler(RechargeWallet);
            showTravelHistroy = new EventHandler(ShowTravelHistroy);
            planTravel = new EventHandler(PlanTravel);
        }
        public static void EventHolder()
        {
            Subscribe();
            eventLink();
        }
    }
}