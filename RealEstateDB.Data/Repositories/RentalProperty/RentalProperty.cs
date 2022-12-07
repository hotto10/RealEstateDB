using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class RentalProperty
    {
        public int AddrID { get; set; }
        public string ?Address1 { get; set; }
        public string ?Address2 { get; set; }
        public string ?City { get; set; }
        public string ?StateAbr { get; set; }
        public int ZipCode { get; set; }

    }
}
