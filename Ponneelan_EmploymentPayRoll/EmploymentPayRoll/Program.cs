using System;
using System.Collections.Generic;
namespace EmploymentPayRoll;

public static class Program
{
static List<EmployeeDetails> EmployeeData = new List<EmployeeDetails>();
public enum EmployeeWorkLocation {madura,eymard}
    public static void Main(string[] args)
    {

        int choice;
        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            Console.WriteLine();
            Console.WriteLine("Enter your Option");
            choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                {
                    Console.WriteLine();
                    GetDetails();
                    break;
                }
                case 2:
                {
                    Console.WriteLine();
                    Login();
                    break;
                }
            }

        }while(choice < 3);

    }
static void GetDetails()
        {
            char isRepeat;
            do
            {
                Console.WriteLine("Enter the Employee Name");
                string name = Console.ReadLine();

                //phone number
                Console.WriteLine("Enter the Employee Roll");
                string roll  = Console.ReadLine();

                //mail id
                Console.WriteLine("enter the Work Location");
                Enum location = Enum.Parse<EmployeeWorkLocation>(Console.ReadLine(),true);

                Console.WriteLine("enter the Team name");
                string team =  Console.ReadLine();


                //instance of the CustomerDetais class 
                EmployeeDetails employee = new EmployeeDetails(name, roll, location, team, DateTime.Today);

                //add the insance to list
                EmployeeData.Add(employee);

                //display the meter Id
                Console.WriteLine();
                Console.WriteLine($"Your Employee Id Is : {employee.EmployeeID}");
                Console.WriteLine();

                //add another user
                Console.WriteLine("Do you want add another user press 'y' else press 'n' ");
                isRepeat = char.Parse(Console.ReadLine().ToLower());
            }while(isRepeat == 'y');

        }

static void Login()
        {
            //call default custructor to access methos
            EmployeeDetails defaultConstructor = new EmployeeDetails();
            string employeeId;
            //get the meter id from user
                Console.WriteLine("Enter the customer Id ");
                employeeId = Console.ReadLine();

                foreach (EmployeeDetails emp in EmployeeData)
                {
                    if (employeeId == emp.EmployeeID)
                    {
                        int subMenuChoice;
                        do
                        {
                            Console.WriteLine();
                            Console.WriteLine("1. Calculate Salary");
                            Console.WriteLine("2. Diaplay Details");
                            Console.WriteLine("3. Exit");
                            Console.WriteLine();

                            //get choice
                            subMenuChoice = int.Parse(Console.ReadLine());
                            
                            switch(subMenuChoice)
                            {
                                case 1:
                                {
                                    //get the total unit used
                                    //double totalUnit;
                                    Console.WriteLine("Enter the Total Working Days in Month");
                                    int totaldays = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the Leave taken in the Month");
                                    int leaveTaken = int.Parse(Console.ReadLine());
                                    int monthSalary = defaultConstructor.CalculateSalary(totaldays,leaveTaken);
                                    Console.WriteLine($"Your this Month Salary is {monthSalary}");
                                    Console.WriteLine();
                                    break;
                                }
                                case 2:
                                {
                                   
                                    Console.WriteLine($"Emplyee ID {emp.EmployeeID}");
                                    Console.WriteLine($"Emplyee name {emp.EmployeeName}");
                                    Console.WriteLine($"Emplyee Roll {emp.EmployeeRoll}");
                                    Console.WriteLine($"Emplyee Wrok Place {emp.WorkLocation}");
                                    Console.WriteLine($"Emplyee Team Name {emp.EmployeeTeamName}");
                                    Console.WriteLine($"Emplyee Join Date {emp.JoiningDate.ToString("dd/MM/yyyy")}");
                                        
                                      
                                    break;
                                }
                            }
                        }while(subMenuChoice <=2);
                    }
                }

        }
}