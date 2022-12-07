using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class TenantUpdateRepository : DBTester
    {
        public long? PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string? StateAbr { get; set; }
        public string ZipCode { get; set; }
        public string? DriverLicense { get; set; }

        public List<TenantModel> DataResults { get; set; }

        public TenantUpdateRepository():base()
        {

        }

        public override void ExecuteSql()
        {
            string sqlState = $@"

                

                BEGIN Transaction
                Update Tenant SET
                [FirstName] = {FirstName.FormatWhereVariableName()},
                [LastName] = {LastName.FormatWhereVariableName()},
                [DriverLicense] = {DriverLicense.FormatWhereVariableName()},
                [MiddleName] = {MiddleName.FormatWhereVariableName()},
                [PhoneNumber] = {PhoneNumber.FormatWhereVariableName()},
                [EmailAddress] ={EmailAddress.FormatWhereVariableName()},
                [Address1] = {Address1.FormatWhereVariableName()},
                [Address2] = {Address2.FormatWhereVariableName()},
                [City] = {City.FormatWhereVariableName()},
                [StateAbr] = {StateAbr.FormatWhereVariableName()}
            
                WHERE [PersonID] = {PersonID}
                COMMIT;

                SELECT * FROM TENANT WHERE [PersonID] = {PersonID}
                ";
            this.DataResults = this.ExecuteSql<TenantModel>(sqlState);
        }
        public override List<T>ExecuteSql<T>(string sql)
        {
            return base.ExecuteSql<T>(sql);
        }

    }
}
