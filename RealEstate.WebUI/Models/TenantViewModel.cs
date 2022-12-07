namespace RealEstate.WebUI.Models
{
    public class TenantViewModel
    {
        #region Properties
        public int? PersonID { get; set; }
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
        #endregion
    }
}
