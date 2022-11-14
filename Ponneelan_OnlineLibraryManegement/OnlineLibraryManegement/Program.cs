using System;
using System.Collections.Generic;
namespace OnlineLibraryManegement;

public enum Gender {MALE,FEMALE,TRANSGENDER}
public enum Department {CSE,ECE,EEE}
public enum Status {DEFAULT,BORROWED,RETURNED }
class Program
{
    private static List<UserDetails> userData = new List<UserDetails>();
    private static List<BookDetails> bookData = new List<BookDetails>();
    private static List<BorrowDetails> borrowData = new List<BorrowDetails>();
      

   public static  void Main(string[] args)
    {
    

    BookDetails book1 = new BookDetails("C#","Vasanth",5);
    BookDetails book2 = new BookDetails("java","pon",4);
    BookDetails book3 = new BookDetails("python","jemes",2);
    BookDetails book4 = new BookDetails("php","con",1);

    bookData.Add(book1);
    bookData.Add(book2);
    bookData.Add(book3);
    bookData.Add(book4);

    UserDetails user1 = new UserDetails("Ponneelan",Enum.Parse<Gender>("MALE"),Enum.Parse<Department>("CSE"),9999999999,"ponneelan.com");
    UserDetails user2 = new UserDetails("Deva",Enum.Parse<Gender>("MALE"),Enum.Parse<Department>("EEE"),9999999999,"deva.com");
    UserDetails user3 = new UserDetails("Power",Enum.Parse<Gender>("MALE"),Enum.Parse<Department>("ECE"),9999999999,"power.com");

    userData.Add(user1);
    userData.Add(user2);
    userData.Add(user3);


        int choice;
        do
        {
            Console.WriteLine("\n1. Register");
            Console.WriteLine("\n2. Login");
            Console.WriteLine("\n3. Exit");

            Console.WriteLine("\nEnter the Choice :");
            choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                {
                    CreateAccount();
                    break;
                }
                case 2:
                {
                    Login();
                    break;
                }
            }
        }while(choice <=2);
    }

    static  void CreateAccount()
        {
            Console.WriteLine("\nEnter the User Name");
            string userName = Console.ReadLine(); 

            Console.WriteLine("\nEnter the Gender");
            Enum userGender = Enum.Parse<Gender>(Console.ReadLine().ToUpper());

            Console.WriteLine("\nEnter The Mobile Number");
            long mobileNumber = long.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Department");
            Enum departMent = Enum.Parse<Department>(Console.ReadLine().ToUpper());

            Console.WriteLine("\nEnter the Mail ID");
            string mailID =Console.ReadLine();

            
            //create object
            UserDetails user = new UserDetails(userName,userGender,departMent,mobileNumber,mailID);
            //add to the list
            userData.Add(user);
            
            Console.WriteLine("\nAccount Create Succefully");
            Console.WriteLine($"\nYour Account Number  is {user.UserID}\n");
        }
    static  void Login()
        {
            bool customerIdIsTrue = false;
            do
            {
                Console.WriteLine("\nEnter Your User ID");
                string uID  = Console.ReadLine();

                foreach(UserDetails user in userData)
                {
                    if (user.UserID == uID)
                    {
                        LoginMenu(user);
                    }
                }
                
                break;
            }while(customerIdIsTrue);
        }
     static void LoginMenu(UserDetails obj)
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Borrow Book");
                Console.WriteLine("\n2. Show Borrow Book");
                Console.WriteLine("\n3. Return Book");
                Console.WriteLine("\n7. Exit");

                //read choice
                Console.WriteLine("\nEnter Your choice :");
                choice = choice=int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                    {
                        BorrowBook(obj);
                        break;
                    }
                    case 2:
                    {
                        ShowBorrowedBook(obj);
                        break;
                    }
                    case 3:
                    {
                        ReturnBook(obj);
                        break;
                    }
                    
                   
                }
            }while(choice<=3);
        }

    static  void ShowBorrowedBook(UserDetails obj)
        {
            foreach(BorrowDetails borrow in borrowData)
            {
                //  if (obj.UserID == borrow.RegistrationID)
                //  {
                    Console.WriteLine($"\nBorrow ID : {borrow.BookID}");
                    Console.WriteLine($"\nBookName : {borrow.BookID}");
                    Console.WriteLine($"\nBorrow Date : {borrow.BorrowDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"\nBorrow Status : {borrow.Status}");
                    Console.WriteLine("\n\n");

                //}
            }
            Console.WriteLine("\nNo Histror Found");
        }
    static  void ReturnBook(UserDetails obj)
    {
        bool isTrue= false;
        int fineAmount = 0;
        string bookIdtoReturn;
        foreach(BorrowDetails borrow in borrowData)
        {
            if (obj.UserID == borrow.RegistrationID)
            {
                if (borrow.Status.ToString() == Status.BORROWED.ToString())
                {
                    
                    TimeSpan noOFDays =DateTime.Today - borrow.BorrowDate;
                    int days = noOFDays.Days;
                    if (days>15)
                    {
                        fineAmount = days *1;
                    }
                    else 
                    {
                        fineAmount = 0;
                    }
                    Console.WriteLine($"\nBook ID : {borrow.BookID}");
                    Console.WriteLine($"Borrowed Status : {borrow.Status}");
                    Console.WriteLine($"\nBook Borrowed Date : {borrow.BorrowDate.ToString("dd/MM/yyyy")}");
                    Console.WriteLine($"\nFine Amount : {fineAmount}");
                }

            }
        }
         do 
        {
            
            Console.WriteLine("Enter the Book ID to Return");
            bookIdtoReturn = Console.ReadLine();
            if (ValiDateBook(bookIdtoReturn))
            {
                isTrue = true;
                break;
            }
            
        }while(isTrue);

        
        foreach(BorrowDetails borrow in borrowData)
        {
            if (borrow.BookID == bookIdtoReturn)
            {
                Console.WriteLine($"\nENter the Amount");
                int amount = int.Parse(Console.ReadLine());

                if (fineAmount == amount)
                {
                    borrow.Status = Enum.Parse<Status>("RETURNED");
                    Console.WriteLine("\nBook Returned");
                }
                else
                {
                    Console.WriteLine("\nInvalid");
                }
            }
           
        }
        
            
    
    }
    static  bool ValiDateBook(String bookId)
    {
       
            
            foreach(BorrowDetails borrow in borrowData)
            {
                if (borrow.BookID == bookId)
                {
                    return true;
                }
                else
                {
                    return false;
            
                }
            }
            return false;
    }

    static  void BorrowBook(UserDetails user)
    {
        string nextAvailability = "";
        foreach(BookDetails books in bookData)
        {
            Console.WriteLine($"\nBook Id : {books.BookID}");
            Console.WriteLine($"\nBook Name : {books.BookName}");
            Console.WriteLine($"\nAuthor Name : {books.AuthorName}");
            Console.WriteLine($"\nBook Count  : {books.BookCount}");
        }

        Console.WriteLine("\nEnter the Book ID to borrow");
        string bookid = Console.ReadLine();
        Console.WriteLine("\nEnter the No of Books");
        int noOfBooks = int.Parse(Console.ReadLine());

        foreach(BookDetails books in bookData)
        {
            if (books.BookID == bookid)
            {
                if (books.BookCount<noOfBooks)
                {
                    Console.WriteLine("Books are not available for the selected count");
                    foreach(BorrowDetails borrow in borrowData)
                    {
                        if (borrow.BookID == bookid)
                        {
                            var x = borrow.BorrowDate.AddDays(15).ToString("dd/MM/yyyy");
                            nextAvailability = x;
                        }
                    }
                    Console.WriteLine($"\nThe book will be available on {nextAvailability}");
                }
                else 
                {
                    if (user.NoOFBooksTaken>3)
                    {
                        Console.WriteLine("\nYou Already Taken 3 Books");
                    }
                    else
                    {
                        BorrowDetails booksToBorrow = new BorrowDetails(user.UserID,books.BookID,DateTime.Today,Enum.Parse<Status>("BORROWED"));
                        borrowData.Add(booksToBorrow);
                        books.BookCount -= noOfBooks;
                        Console.WriteLine("Book BorrowedSuccessfully");
                    }
                }
            }
        }
    }

}