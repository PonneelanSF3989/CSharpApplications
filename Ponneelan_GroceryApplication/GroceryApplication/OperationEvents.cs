using System.Collections.Generic;


namespace GroceryApplication
{
    public delegate void EventManager();

    public  static partial class Operations

    {
            public static event EventManager start,registration,login,subMenu,showCustomers,showProducts,takeOrder,modifyOrder,cancelBooking;
            public static void Subscribe()
            {
                start+=new EventManager(Files.CreateFiles);
                start+=new EventManager(Operations.AddDefaultData);
                start+= new EventManager(Files.ReadFiles);
                start+= new EventManager(MainMenu);
                start+=new EventManager(Files.WriteToFiles);

                registration += new EventManager(Registration);
                login += new EventManager(Login);
                subMenu+=new EventManager(SubMenu);
                showCustomers+=new EventManager(ShowCustomer);
                showProducts+=new EventManager(ShowProducts);
                takeOrder+=new EventManager(TakeOrder);
                modifyOrder+=new EventManager(ModifyOrder);
                cancelBooking+=new EventManager(CancelOrder);
            }
            public static void Starter()
            {
                Subscribe();
                start();
            }
    }
}