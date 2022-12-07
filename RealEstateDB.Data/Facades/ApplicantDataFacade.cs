using RealEstateDB.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data.Facades
{
    public static class ApplicantDataFacade
    {
        public static void SaveRecord(Object sender)
        {
            var model = sender.TransformModel<TenantUpdateRepository>();

            if(model.PersonID == null)
                CreateRecord(sender);
            else
                UpdateRecord(sender);
        }
        static void CreateRecord(Object sender)
        {
            var model = sender.TransformModel<TenantCreateRepository>();
            model.ExecuteSql();

        }
        static void UpdateRecord(Object sender)
        {
            var model = sender.TransformModel<TenantUpdateRepository>();
            model.ExecuteSql();

        }
        public static void DeleteRecord(Object sender)
        {
            var model = sender.TransformModel<TenantDeleteRepository>();
            model.ExecuteSql();

        }
        public static List<T> ReadAllRecord<T>()
        {
            var model = new TenantReadRepository();
            model.ExecuteSql();
            if(model.DataResults == null)
                return new List<T>();
            else
                return model.DataResults.ToJson().JsonToList<T>();

        }
    }
}
