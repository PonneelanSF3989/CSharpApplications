using System;
using System.Collections.Generic;
namespace CollegeAdmission;

//Student name
// father name
// dob 
// gender
// mailid
// phymark
// chemark
// mathsmark

class Program
{
    public static void Main(string[] args)
    {

        // StudentDetails student1 = new StudentDetails();
        // StudentDetails student2 = new StudentDetails();
        // StudentDetails student3 = new StudentDetails();

        // //Student details List
        // List<StudentDetails> studentList = new List<StudentDetails>();
 

        // // get details of student 1
        // Console.WriteLine();
        // Console.WriteLine("Enter the Student name");
        // student1.StudentName = Console.ReadLine();
        // Console.WriteLine("Enter the Student Father name ");
        // student1.FatherName = Console.ReadLine();
        // Console.WriteLine("Enter the Student DOB");
        // student1.Dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        // Console.WriteLine("Enter the student gender ");
        // student1.StudentGender  = Console.ReadLine();
        // Console.WriteLine("Enter the Student mail ID");
        // student1.MailId = Console.ReadLine();
        // Console.WriteLine("Enter the Physics Mark");
        // student1.PhysicsMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter the chemistry Mark");
        // student1.ChemistryMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter maths the Mark");
        // student1.MathsMark = int.Parse(Console.ReadLine());
        // //add to the list
        // studentList.Add(student1);



        // // get details of Student 2
        // Console.WriteLine();
        // Console.WriteLine("Enter the Student name");
        // student2.StudentName = Console.ReadLine();
        // Console.WriteLine("Enter the Student Father name ");
        // student2.FatherName = Console.ReadLine();
        // Console.WriteLine("Enter the Student DOB");
        // student2.Dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        // Console.WriteLine("Enter the student gender ");
        // student2.StudentGender  = Console.ReadLine();
        // Console.WriteLine("Enter the Student mail ID");
        // student2.MailId = Console.ReadLine();
        // Console.WriteLine("Enter the Physics Mark");
        // student2.PhysicsMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter the chemistry Mark");
        // student2.ChemistryMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter maths the Mark");
        // student2.MathsMark = int.Parse(Console.ReadLine());
        // //add to the list
        // studentList.Add(student2);

        

        // // get details of student3
        // Console.WriteLine();
        // Console.WriteLine("Enter the Student name");
        // student3.StudentName = Console.ReadLine();
        // Console.WriteLine("Enter the Student Father name ");
        // student3.FatherName = Console.ReadLine();
        // Console.WriteLine("Enter the Student DOB");
        // student3.Dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
        // Console.WriteLine("Enter the student gender ");
        // student3.StudentGender  = Console.ReadLine();
        // Console.WriteLine("Enter the Student mail ID");
        // student3.MailId = Console.ReadLine();
        // Console.WriteLine("Enter the Physics Mark");
        // student3.PhysicsMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter the chemistry Mark");
        // student3.ChemistryMark = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter maths the Mark");
        // student3.MathsMark = int.Parse(Console.ReadLine());
        // //add to the list
        // studentList.Add(student3);


        // // display details

        // foreach(StudentDetails student in studentList)
        // {
        //     Console.WriteLine();
        //     Console.WriteLine($"Student Name : {student.StudentName}");
        //     Console.WriteLine($"Fathee Name : {student.FatherName}");
        //     Console.WriteLine($"Date Of Birth : {student.Dob.Date.ToString("dd/MM/yyyy")}");
        //     Console.WriteLine($"Gender : {student.StudentGender}");
        //     Console.WriteLine($"Physics Mark : {student.PhysicsMark}");
        //     Console.WriteLine($"Chemistry Mark {student.ChemistryMark}");
        //     Console.WriteLine($"Maths Mark : {student.MathsMark}");
        // }



        

        // Student details List
        List<StudentDetails> studentList = new List<StudentDetails>();

        char choice ;

         do
         {
            
            // // get details of student 
            Console.WriteLine();
            Console.WriteLine("Enter the Student name");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter the Student Father name ");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter the Student DOB");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter the student gender ");
            string studentGender  = Console.ReadLine();
            Console.WriteLine("Enter the Student mail ID");
            string mailId = Console.ReadLine();
            Console.WriteLine("Enter the Physics Mark");
            int physicsMark = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the chemistry Mark");
            int chemistryMark = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter maths the Mark");
            int mathsMark = int.Parse(Console.ReadLine());

            StudentDetails student1 = new StudentDetails(studentName,fatherName,dob,studentGender,mailId,physicsMark,chemistryMark,mathsMark);

            //add to the list
            studentList.Add(student1);
            Console.WriteLine("Your registration id is "+student1.RegistraionId);
            //Console.WriteLine(student1);

            Console.WriteLine("Do you want contiue to add anothe user if yes press 'y' else press 'n'  :");
            choice = char.Parse(Console.ReadLine().ToLower());
         }while(choice =='y');

        Console.WriteLine("Enter the Student Registration ID :");
        string userId = Console.ReadLine().ToUpper();

        foreach(StudentDetails student in studentList)
        {
            if (userId == student.RegistraionId)
            {
                Console.WriteLine("User found");
                ShowDetails(student);
                if (student.CheckedEligibility(75.00))
                {
                    Console.WriteLine("Eligible for Admission");
                }
                else
                {
                    Console.WriteLine("Not eligible for Adminssion");
                }
            }
            else
            {
                Console.WriteLine("user not found");
            }
        }
        // // display details

        void ShowAllStudents()
        {
            foreach(StudentDetails student in studentList)
            {
                Console.WriteLine();
                Console.WriteLine($"Student Name : {student.StudentName}");
                Console.WriteLine($"Fathee Name : {student.FatherName}");
                Console.WriteLine($"Date Of Birth : {student.Dob.Date.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Gender : {student.StudentGender}");
                Console.WriteLine($"Physics Mark : {student.PhysicsMark}");
                Console.WriteLine($"Chemistry Mark {student.ChemistryMark}");
                Console.WriteLine($"Maths Mark : {student.MathsMark}");
            }
        }


        //display details function

        void ShowDetails(StudentDetails studentObject)
        {
            Console.WriteLine();
            Console.WriteLine($"Student Name : {studentObject.StudentName}");
            Console.WriteLine($"Fathee Name : {studentObject.FatherName}");
            Console.WriteLine($"Date Of Birth : {studentObject.Dob.Date.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Gender : {studentObject.StudentGender}");
            Console.WriteLine($"Physics Mark : {studentObject.PhysicsMark}");
            Console.WriteLine($"Chemistry Mark {studentObject.ChemistryMark}");
            Console.WriteLine($"Maths Mark : {studentObject.MathsMark}");
        }

    }
}