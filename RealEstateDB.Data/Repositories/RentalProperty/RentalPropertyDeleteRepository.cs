using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class RentalPropertyDeleteRepository : DBTester
    {
        public int AddrID { get; set; }

        public RentalPropertyDeleteRepository():base()
        {

        }
        public override void ExecuteSql()
        {
            string sqlState = $"DELETE FROM RentalProperty WHERE [AddrID] = {AddrID}";
            ExecuteSql<RentalPropertyModel>(sqlState);
        }
        public override List<T> ExecuteSql<T>(string sql)
        {
            

            return base.ExecuteSql<T>(sql);
        }
    }
}
