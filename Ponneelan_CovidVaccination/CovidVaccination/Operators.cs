using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class Operators
    {
        private static List<BeneficiaryDetails> beneficiariesData = new List<BeneficiaryDetails>();
        private static List<VaccineDetails> vaccineData = new List<VaccineDetails>();
        private static List<VaccinationDetails> vaccinationData = new List<VaccinationDetails>();
        private static BeneficiaryDetails currentUser;
        public static void MainMenu()
        {
            int Choice;
           do{
            Console.WriteLine("\n1. Registration");
            Console.WriteLine("\n2. Login");
            Console.WriteLine("\n3. Get VAccine Info");
            Console.WriteLine("\n4. Exit");

            Console.WriteLine("\n\nEnter your Choice");
            Choice = int.Parse(Console.ReadLine());
            switch(Choice)
            {
                case 1 :
                {
                    Registration();
                    break;
                }
                case 2 :
                {
                    Login();
                    break;
                }
                case 3 :
                {
                    showVaccineInfo();
                    break;
                }
                default :
                {
                    Console.WriteLine("\nInvalid choce");
                    break;
                }
            }
           }while(Choice !=4);
        }
        public static void Registration()
        {
            Console.WriteLine("\nEnter your Name");
            string name  = Console.ReadLine();
            Console.WriteLine("\nEnter Age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Your Gender");
            Enum gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.WriteLine("\nEnter your Mobile Number");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter your City");
            string city = Console.ReadLine();

            BeneficiaryDetails newBeneficiary = new BeneficiaryDetails(name,age,gender,mobile,city);
            beneficiariesData.Add(newBeneficiary);

            Console.WriteLine("\nRegisration successfully \nYour Registration ID  :  "+newBeneficiary.BenefiaceryID);
        }
        public static void showVaccineInfo()
        {
            foreach(VaccineDetails vaccines in vaccineData)
            {
                Console.WriteLine("Vaccine ID : "+vaccines.VaccineID+"\nVaccine Name : "+vaccines.VaccineName+"\nVaccine Availability : "+vaccines.NoOfDoesAvailable);
            }
        }
        public static void Login()
        {
            bool flag = false;
            Console.WriteLine("\nEnter your Registration ID");
            string registrationID = Console.ReadLine().ToUpper();

            foreach(BeneficiaryDetails benefeciay in beneficiariesData)
            {
                if (benefeciay.BenefiaceryID == registrationID)
                {
                    currentUser = benefeciay;
                    flag = true;
                    LoginMenu();
                }
            }
            if(!flag)
            {
                Console.WriteLine("\nInvalid Benefeciary ID");
            }
        }
    
        public static void LoginMenu()
        {
            int Choice;
            do
            {
                Console.WriteLine("\nLOGIN MENU \n\n");
                Console.WriteLine("\n1. Show My Details");
                Console.WriteLine("\n2. Take Vaccination");
                Console.WriteLine("\n3. Show Vaccination Histroy");
                Console.WriteLine("\n4. Next Due Date");
                Console.WriteLine("\n5. Exit");

                Console.WriteLine("\n\nEnter your Option");
                Choice = int.Parse(Console.ReadLine());

                switch(Choice)
                {
                    case 1:
                    {
                        ShowUserDetails();
                        break;
                    }
                     case 2:
                    {
                    
                        break;
                    }
                     case 3:
                    {
                        VaccinationHistroy();
                        break;
                    }
                     case 4:
                    {
                        NextDueForVaccination();
                        break;
                    }
                }
            }while(Choice != 5);
        }
    
        public static void ShowUserDetails()
        {
            foreach(BeneficiaryDetails beneficiary in beneficiariesData)
            {
                if (beneficiary.BenefiaceryID == currentUser.BenefiaceryID)
                {
                    Console.WriteLine("\n\nBenefeciary Name : "+beneficiary.BenefiaceryName+ "\nBenefeciary Id : "+beneficiary.BenefiaceryID+"\nBenefeciary Age : "+beneficiary.Age+"\nbenefeciary Mobile Number : "+beneficiary.MobileNumber+"\nBenefeciary City : "+beneficiary.City);
                }
            }
        }
    
        public static void VaccinationHistroy()
        {
            bool flag = false;
            foreach(VaccinationDetails vaccinations in vaccinationData)
            {
                if (vaccinations.RegistrationNumber == currentUser.BenefiaceryID)
                {
                    flag = true;
                    Console.WriteLine("VaccinationID : "+vaccinations.VaccinationID+"\nVaccine ID : "+vaccinations.VaccineID+"\nVaccination Date : "+vaccinations.DateOfVaccination+"\nDoes of Vaccination"+vaccinations.DoseNumber);
                }
            }
            if (!flag)
            {
                Console.WriteLine("\n No results found");
            }
        }

        public static void DefaultData()
        {
            BeneficiaryDetails newBeneficiary1 = new BeneficiaryDetails("Vasanth",22,Gender.male,9898989898,"Pudukkottai");
            BeneficiaryDetails newBeneficiary2 = new BeneficiaryDetails("yc",22,Gender.male,9898989898,"trichy");
            BeneficiaryDetails newBeneficiary3 = new BeneficiaryDetails("deva",22,Gender.male,9898989898,"thiruvaroor");
            BeneficiaryDetails newBeneficiary4 = new BeneficiaryDetails("sakthi",22,Gender.male,9898989898,"chennai");

            beneficiariesData.Add(newBeneficiary1);
            beneficiariesData.Add(newBeneficiary2);
            beneficiariesData.Add(newBeneficiary3);
            beneficiariesData.Add(newBeneficiary4);

            VaccineDetails newVaccine1 = new VaccineDetails(VaccineName.covaccine,50);
            VaccineDetails newVaccine2 = new VaccineDetails(VaccineName.covishield,50);

            vaccineData.Add(newVaccine1);
            vaccineData.Add(newVaccine2);

            VaccinationDetails vaccination1 = new VaccinationDetails("BID1001","VID1001",1,new DateOnly(2022,01,01));
            VaccinationDetails vaccination2 = new VaccinationDetails("BID1002","VID1001",2,new DateOnly(2022,02,01));
            VaccinationDetails vaccination3 = new VaccinationDetails("BID1003","VID1001",3,new DateOnly(2022,03,01));
            VaccinationDetails vaccination4 = new VaccinationDetails("BID1004","VID1001",1,new DateOnly(2022,01,01));

            vaccinationData.Add(vaccination1);
            vaccinationData.Add(vaccination2);
            vaccinationData.Add(vaccination3);
            vaccinationData.Add(vaccination4);




        }
        public static void NextDueForVaccination()
        {
            foreach (VaccinationDetails vaccination in vaccinationData)
            {
                if (vaccination.RegistrationNumber == currentUser.BenefiaceryID)
                {
                    if (vaccination.DoseNumber == 0)
                    {
                        Console.WriteLine("\nyou can take vaccine now");
                    }
                    else if (vaccination.DoseNumber >=1 && vaccination.DoseNumber <=2)
                    {
                        DateOnly nextDue = vaccination.DateOfVaccination.AddDays(30);
                        Console.WriteLine("\nYou can Take Next Vaccination of : "+nextDue);
                    }
                    else
                    {
                        Console.WriteLine("\nYou have completed the vaccination course. \nThanks for your participation in the vaccination drive");
                    }
                }
            }
        }
    
    
    
    
    }
}