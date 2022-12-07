using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class RentalPropertyUpdateRepository : DBTester
    {
        public long? AddrID { get; set; }
        public string? Address1 { get; set; }
        public string Address2 { get; set; }
        public string? City { get; set; }
        public string? StateAbr { get; set; }
        public long? ZipCode { get; set; }

        public List<RentalPropertyModel> DataResults { get; set; }


        public RentalPropertyUpdateRepository():base()
        {

        }
        public override void ExecuteSql()
        {
            string sqlState = $@"

                

                BEGIN Transaction
                Update RentalProperty SET
                [Address1] = {Address1.FormatWhereVariableName()},
                [Address2] = {Address2.FormatWhereVariableName()},
                [City] = {City.FormatWhereVariableName()},
                [StateAbr] = {StateAbr.FormatWhereVariableName()},
                [ZipCode] = {ZipCode.FormatWhereVariableName()}
                
            
                WHERE [AddrID] = {AddrID};
                COMMIT;

                SELECT * FROM RentalProperty WHERE [AddrID] = {AddrID}
                ";
            this.DataResults = this.ExecuteSql<RentalPropertyModel>(sqlState);
        }

        public override List<T> ExecuteSql<T>(string sql)
        {
           
            return base.ExecuteSql<T>(sql);
        }
    }
}
