using System;


namespace OnlineLibraryManegement;

public class UserDetails
{
    private static int noOFBooksGeted = 0;
    public int NoOFBooksTaken {get; set;}
    private static int s_UserID = 1000;
    public string UserID { get; }
    public string UserName { get; set; }
    public Enum Gender { get; set; }
    
    public long MobileNumber { get; set; }
    
    public Enum UserDepartment { get; set; }    
    
    public string MailID { get; set; }
    
   
    
    

    public UserDetails (string name, Enum gender, Enum departMent, long mobile,  string mail)
    {
        noOFBooksGeted++;
        s_UserID++;
        UserID = "LIB"  + s_UserID;
        UserName = name;
        Gender = gender;
        MobileNumber = mobile;
        UserDepartment = departMent;
        MailID = mail;
       
    }
    
    
}
