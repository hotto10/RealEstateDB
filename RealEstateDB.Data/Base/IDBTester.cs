using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateDB.Data
{
    public interface IDBTester
    {
        public string ConnectionStr { get; set; }
        public List<T> ExecuteSql<T>(string sql);
    }
}
