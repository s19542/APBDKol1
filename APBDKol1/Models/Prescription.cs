using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKol1.Models
{
    public class Prescription
    {

        //IdPrescription, Date, DueDate, PatientLastName, DoctorLastName
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorLastName { get; set; }

    }
}
