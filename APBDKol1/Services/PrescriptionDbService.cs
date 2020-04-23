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

            if (lastName == null) { 
            
           }


            var list = new List<Prescription>();

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select FirstName,LastName,BirthDate, Name, Semester from Student INNER JOIN Enrollment en ON Student.IdEnrollment = en.IdEnrollment INNER JOIN Studies st ON en.IdStudy = st.IdStudy;";

                con.Open();

                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var student = new Student();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = (System.DateTime)dr["BirthDate"];
                    student.Studies = dr["Name"].ToString();
                    student.Semester = dr["Semester"].ToString();

                    list.Add(student);

                }

            }

            return Ok(list);


            return null;
        }
    }
}
