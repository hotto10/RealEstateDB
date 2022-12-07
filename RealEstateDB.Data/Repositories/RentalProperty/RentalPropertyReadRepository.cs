using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class RentalPropertyReadRepository : DBTester
    {
        public long? AddrID { get; set; }
        public string? Address1 { get; set; }
        public string Address2 { get; set; }
        public string? City { get; set; }
        public string? StateAbr { get; set; }
        public long? ZipCode { get; set; }
        public List<RentalPropertyModel> DataResults { get; set; }

        public RentalPropertyReadRepository():base()
        {

        }
        public override void ExecuteSql()
        {
            //string sqlState = "SELECT * FROM RentalProperty";
            //return ExecuteSql<T>(sqlState);
            string sqlState = $@"

                

               DECLARE @AddrID int = {AddrID.FormatWhereVariableName()}
               DECLARE @Address1 varchar(80) = {Address1.FormatWhereVariableName()}
               
               DECLARE @City varchar(30) = {City.FormatWhereVariableName()}
               DECLARE @StateAbr varchar(2) = {StateAbr.FormatWhereVariableName()}
               DECLARE @ZipCode nvarchar(5) = {ZipCode.FormatWhereVariableName()}

               SELECT
                tb.*
                FROM RentalProperty tb
                WHERE tb.AddrID = ISNULL(@AddrID,tb.AddrID)
                AND tb.Address1 = ISNULL(@Address1,tb.Address1)
               
                AND tb.City = ISNULL(@City,tb.City)
                AND tb.StateAbr = ISNULL(@StateAbr,tb.StateAbr)
                AND tb.ZipCode = ISNULL(@ZipCode,tb.ZipCode)
               ";
            this.DataResults = this.ExecuteSql<RentalPropertyModel>(sqlState);
        }

        public void Reset()
        {
            this.AddrID = null;
            this.Address1 = null;
            this.Address2 = null;
            this.City = null;
            this.StateAbr = null;
            this.ZipCode = null;
        }
        public override List<T> ExecuteSql<T>(string sql)
        {
            return base.ExecuteSql<T>(sql);
        }
    }
}
