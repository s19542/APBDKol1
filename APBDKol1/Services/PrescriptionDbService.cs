using APBDKol1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKol1.Services
{
    public class PrescriptionDbService : IDbService
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s19542;Integrated Security=True";
        public ICollection<Prescription> GetPrescriptions(string lastName)
        {
            string comText="";
//IdPrescription, Date, DueDate, PatientLastName, DoctorLastName
            if (lastName == null) {
               comText = "select IdPrescription, Date, DueDate, Patient.LastName, Doctor.LastName  from Prescription where Prescription.IdDoctor=Doctor.IdDoctor where  Prescription.IdPatient=Patient.IdPatient order by Date;";
            }


            var list = new List<Prescription>();

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText =comText;

                con.Open();

                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var per = new Prescription();

                    per.IdPrescription =(int) dr["IdPrescription"];
                    per.Date = (System.DateTime)dr["Date"];
                    per.DoctorLastName = dr["DoctorLastName"].ToString();
                    per.PatientLastName = dr["PatientLastName"].ToString();

                    per.DueDate = (System.DateTime)dr["DueDate"];
                    list.Add(per);

                }

            }

            return list;


            
        }
    }
}
