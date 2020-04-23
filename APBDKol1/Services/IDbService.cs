using APBDKol1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBDKol1.Services
{
    public interface IDbService
    {
        public ICollection<Prescription> GetPrescriptions(string lastName);


    }
}
