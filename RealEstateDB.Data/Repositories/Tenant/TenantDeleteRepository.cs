using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class TenantDeleteRepository : DBTester
    {
        public int PersonID { get; set; }
        
        public TenantDeleteRepository():base()
        {

        }
        public override List<T> ExecuteSql<T>(string sql)
        {
            
            return base.ExecuteSql<T>(sql);
        }
        public override void ExecuteSql()
        {
            string sqlState = $"DELETE FROM Tenant WHERE [PersonID] = {PersonID}";
            ExecuteSql<TenantModel>(sqlState);
        }

    }
}
