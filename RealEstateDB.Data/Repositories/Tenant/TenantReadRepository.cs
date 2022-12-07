using RealEstateDB.Data.Extensions;
using RealEstateDB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public class TenantReadRepository : DBTester
    {
        #region Properties
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

        #endregion
        public TenantReadRepository():base()
        {

        }
        public override void ExecuteSql()
        {
             string sqlState = $@"

                DECLARE @PersonID int = {PersonID.FormatWhereVariableName()}
                DECLARE @FirstName varchar(50) = {FirstName.FormatWhereVariableName()}
                DECLARE @LastName varchar(50) = {LastName.FormatWhereVariableName()}
                DECLARE @MiddleName varchar(50) = {MiddleName.FormatWhereVariableName()}
                DECLARE @Address1 varchar(80) = {Address1.FormatWhereVariableName()}
                DECLARE @Address2 varchar(80) = {Address2.FormatWhereVariableName()}
                DECLARE @City varchar(30) = {City.FormatWhereVariableName()}
                DECLARE @StateAbr varchar(2) = {StateAbr.FormatWhereVariableName()}
                DECLARE @ZipCode varchar(5) = {ZipCode.FormatWhereVariableName()}
                DECLARE @EmailAddress varchar(40) = {EmailAddress.FormatWhereVariableName()}
                DECLARE @PhoneNumber nvarchar(10) = {PhoneNumber.FormatWhereVariableName()}
                DECLARE @DriverLicense varchar(20) = {DriverLicense.FormatWhereVariableName()}
                
                SELECT 
                tb.* 
                FROM Tenant tb
                WHERE tb.PersonID = ISNULL(@PersonID,tb.PersonID)
                AND tb.FirstName = ISNULL(@FirstName,tb.FirstName)
                AND tb.LastName = ISNULL(@LastName,tb.LastName)
                AND tb.Address1 = ISNULL(@Address1,tb.Address1)
                AND tb.City = ISNULL(@City,tb.City)
                AND tb.StateAbr = ISNULL(@StateAbr,tb.StateAbr)
                AND tb.ZipCode = ISNULL(@ZipCode,tb.ZipCode)
                --AND tb.PhoneNumber = ISNULL(@PhoneNumber,tb.PhoneNumber)
                --AND tb.DriverLicense = ISNULL(@DriverLicense,tb.DriverLicense)
                ";
            this.DataResults = this.ExecuteSql<TenantModel>(sqlState);
        }
        public void Reset()
        {
            this.PersonID = null;
            this.FirstName = null;
            this.LastName = null;
            this.MiddleName = null;
            this.Address1 = null;
            this.Address2 = null;
            this.StateAbr = null;
            this.ZipCode = null;
            this.EmailAddress = null;
            this.PhoneNumber = null;
            this.DriverLicense = null;


        }
        public override List<T>ExecuteSql<T>(string sql)
        {
            return base.ExecuteSql<T>(sql);
        }
    }
}
