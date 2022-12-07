using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class Tenant
    {
        public int PersonID { get; set; }
        public string ?FirstName { get; set; }
        public string ?LastName { get; set; }
        public string ?MiddleName { get; set; }
        public string ?Address { get; set; }
        public string ?Address2 { get; set; }
        public string ?StateAbr { get; set; }
        public int ZipCode { get; set; }
        public int PhoneNumber { get; set; }
        public string ?LicenseNumber { get; set; }



    }
}
