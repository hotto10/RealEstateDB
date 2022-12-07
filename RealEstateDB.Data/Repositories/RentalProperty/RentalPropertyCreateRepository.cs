using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class RentalPropertyCreateRepository : DBTester
    {
        //public int? AddrID { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? StateAbr { get; set; }
        public string ZipCode { get; set; }
        public List<RentalPropertyModel> DataResults { get; set; }

        public override void ExecuteSql()
        {
            string sqlState = $@"
                             DECLARE @retID int;

                             BEGIN TRANSACTION
                             INSERT INTO RentalProperty
                             (Address1, Address2, City, StateAbr, ZipCode)
                             VALUES ({Address1.FormatWhereVariableName()},{Address2.FormatWhereVariableName()},{City.FormatWhereVariableName()},{StateAbr.FormatWhereVariableName()},{ZipCode.FormatWhereVariableName()})
                             SET @retID = SCOPE_IDENTITY() -- GETS THE PRIMARY KEY FOR NEWLY CREATED RECORDS
                             COMMIT;

                             SELECT * FROM Tenant WHERE [PersonID] = @retID
                             ";
            DataResults = ExecuteSql<RentalPropertyModel>(sqlState);
        }
        public override List<T> ExecuteSql<T>(string sql)
        {
            
            return base.ExecuteSql<T>(sql);
        }
    }
}
