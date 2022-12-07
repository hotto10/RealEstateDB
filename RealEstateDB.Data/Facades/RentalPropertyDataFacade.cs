using RealEstateDB.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data.Facades
{
    public static class RentalPropertyDataFacade
    {
        public static List<T> GetAllRentalProperties<T>() 
        {
            var read = new RentalPropertyReadRepository();
            read.ExecuteSql();
            return read.DataResults.ToJson().JsonToList<T>();
            
        }
        public static void SaveRecord(Object sender)
        {
            var model = sender.TransformModel<RentalPropertyUpdateRepository>();
            if(model.AddrID == null)
                CreateRecord(sender);
            else
                UpdateRecord(sender);
            
        }
        static void UpdateRecord(Object sender)
        {
            var model = sender.TransformModel<RentalPropertyUpdateRepository>();
            model.ExecuteSql();
        }
        static void CreateRecord(Object sender)
        {
            var model = sender.TransformModel<RentalPropertyCreateRepository>();
            model.ExecuteSql();
        }
        public static void DeleteRecord(Object sender)
        {
            var model = sender.TransformModel<RentalPropertyDeleteRepository>();
            model.ExecuteSql();
        }
    }
}
