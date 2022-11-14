using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccination
{
    public enum VaccineName {Default, covaccine,covishield}
    public class VaccineDetails
    {
        private static int s_VaccineID = 1000;
        public Enum VaccineName { get; set; }
        
        public string VaccineID { get; set; }
        
        public int NoOfDoesAvailable { get; set; }
        
        public VaccineDetails (Enum vaccineName, int noOdDoes)
        {
            s_VaccineID++;
            VaccineID = "VID" + s_VaccineID;
            VaccineName = vaccineName;
            NoOfDoesAvailable = noOdDoes;

        }
    }
}