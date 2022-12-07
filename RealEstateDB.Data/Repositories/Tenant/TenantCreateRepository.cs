using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class TenantCreateRepository : DBTester
    {
        #region Properties
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
        #endregion
        public TenantCreateRepository():base()
        {

        }
        public override void ExecuteSql()
        {
            string sqlState = $@"
                                DECLARE @retID int;

                                BEGIN TRANSACTION 

                                Insert into Tenant(
                                LastName, FirstName, MiddleName, PhoneNumber, 
                                EmailAddress, Address1, Address2, CIty, StateAbr, ZipCode,
                                DriverLicense)
                                VALUES 
                                ({FirstName.FormatWhereVariableName()},
                                {LastName.FormatWhereVariableName()},
                                {MiddleName.FormatWhereVariableName()}, 
                                {PhoneNumber.FormatWhereVariableName()}, 
                                {EmailAddress.FormatWhereVariableName()},
                                {Address1.FormatWhereVariableName()},
                                {Address2.FormatWhereVariableName()},
                                {City.FormatWhereVariableName()},
                                {StateAbr.FormatWhereVariableName()},
                                {ZipCode.FormatWhereVariableName()},
                                {DriverLicense.FormatWhereVariableName()}
                                )
                                

                                SET @retID = SCOPE_IDENTITY() -- GETS THE PRIMARY KEY FOR NEWLY CREATED RECORDS
                                COMMIT;

                                SELECT * FROM Tenant WHERE [PersonID]= @retID
                                ";
            this.DataResults = ExecuteSql<TenantModel>(sqlState);
        }
        public override List<T>ExecuteSql<T>(string sql)
        {
            
                
            return base.ExecuteSql<T>(sql);
        }
    }
}
