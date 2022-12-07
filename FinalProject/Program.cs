using RealEstateDB.Data;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //"server=OTTOMATIC\SQLEXPRESS;User Id=Edge2;Password=Div@isthebest1;database=RealEstateDB";
            //DBTester.TestDBConnection();
            //TenantCreate();
            //TenantUpdate();
            //TenantRead();
            //TenantDelete();
            //RentalCreate();
            //RentalUpdate();
            //RentalRead();
            RentalDelete();
            
            
        }
        static void TenantCreate()
        {
            var test = new TenantCreateRepository()
                        {
                            FirstName = "Heather", 
                            LastName = "Otto",
                            MiddleName = "Marie", 
                            Address1 = "20705 W 225th Terr", 
                            EmailAddress = "heatherotto32@yahoo.com", 
                            PhoneNumber = "9139450071",
                            DriverLicense = "kdfjiewosk" 
                        };
            test.ExecuteSql();
        }
        static void TenantUpdate()
        {
            var model = new TenantUpdateRepository()
            {
                FirstName = "Heather1",
                LastName = "Otto2",
                MiddleName = "Mary",
                Address1 = "20705 W 225th st",
                EmailAddress = "heatherotto3@yahoo.com",
                PhoneNumber = "9139450061",
                DriverLicense = "kdfjiewosk"
            };
           model.PersonID = 11;
            
            
        }
        static void TenantRead()
        {
            //Read All Records
            var read = new TenantReadRepository();
            read.ExecuteSql();
            read.Reset();

            //Read By PersonID
            read.PersonID = 11;
            read.ExecuteSql();
            read.Reset();

            //Read By FirstName
            read.PersonID = null;
            read.FirstName = "Michelle";
            read.ExecuteSql();
            read.Reset();

            //Read By LastName
            read.PersonID = null;
            read.FirstName = null;
            read.LastName = "Otto";
            read.ExecuteSql();
            read.Reset();
        }
        static void TenantDelete()
        {
            var delete = new TenantDeleteRepository();
            
            delete.PersonID = 11;
            delete.ExecuteSql();
        }
        static void RentalCreate()
        {
            var create = new RentalPropertyCreateRepository()
            {
                Address1 = "4267 loli Ave",
                Address2 = "Apt 47",
                City = "Pensacola",
                StateAbr = "FL",
                ZipCode = "56789"

            };
            create.ExecuteSql<RentalProperty>("");
        }
         static void RentalUpdate()
        {
            var update = new RentalPropertyUpdateRepository()
            {
                Address1 = "7845 woman dr",
                Address2 = "Apt 67",
                City = "Sacremento",
                StateAbr = "CA",
                ZipCode = 89323
            };
            update.AddrID = 2;    
        } 
        static void RentalRead()
        {
            var read = new RentalPropertyReadRepository();
            {
                read.ExecuteSql();
                read.Reset();

                read.AddrID = 1;
                read.ExecuteSql();
                read.Reset();

                read.Address1 = "20705 W 225th Terr";
                read.ExecuteSql();
                read.Reset();

                read.AddrID = null;
                read.Address1 = null;
                read.Address2 = "apt 47";
                read.ExecuteSql();
                read.Reset();

                read.AddrID = null;
                read.Address1 = null;
                read.Address2 = null;
                read.City = "Olathe";
                read.ExecuteSql();
                read.Reset();

                read.AddrID = null;
                read.Address1 = null;
                read.Address2 = null;
                read.City = null;
                read.StateAbr = "CA";
                read.ExecuteSql();
                read.Reset();

                read.AddrID = null;
                read.Address1 = null;
                read.Address2 = null;
                read.City = null;
                read.StateAbr = null;
                read.ZipCode = 12345;
                read.ExecuteSql();
                read.Reset();

            };
        }
        static void RentalDelete()
        {
            var delete = new RentalPropertyDeleteRepository();
            delete.AddrID = 9;
            delete.ExecuteSql();
        }

    }
}