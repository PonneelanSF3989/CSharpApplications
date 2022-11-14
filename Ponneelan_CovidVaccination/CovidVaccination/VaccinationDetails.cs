using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public class VaccinationDetails
    {
        private int s_VaccinationID =1000;
        public string RegistrationNumber { get; set; }
        
        public string VaccinationID { get; set; }
        public string VaccineID { get; set; }
        
        
        public int DoseNumber { get; set; }
        
        public DateOnly DateOfVaccination { get; set; }
        
        public  VaccinationDetails(string registrationID, string vaccineID, int doseNumber, DateOnly vaccinationDate)
        {
            s_VaccinationID++;
            VaccinationID = "VID" + s_VaccinationID;
            VaccineID = vaccineID;
            RegistrationNumber = registrationID;
            DoseNumber = doseNumber;
            DateOfVaccination = vaccinationDate;
        }
        
        
    }
}