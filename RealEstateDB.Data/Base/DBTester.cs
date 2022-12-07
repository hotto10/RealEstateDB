using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RealEstateDB.Data.Extensions;

namespace RealEstateDB.Data
{
    public abstract class DBTester : IDBTester
    {
        public DBTester()
        {
            this.ConnectionStr = "server=OTTOMATIC\\SQLEXPRESS;User Id=Edge2;Password=Div@isthebest1;database=RealEstateDB";
        }

        public string ConnectionStr { get ; set; }

        public virtual void ExecuteSql()
        {

        }
        public virtual List<T> ExecuteSql<T>(string sql)
        {
            using SqlConnection conn = new(this.ConnectionStr);
            using SqlCommand cmd = new SqlCommand(sql, conn);

            {

                cmd.CommandType = CommandType.Text;

                cmd.CommandTimeout = 0;

                DataTable dataTable = new();

                using (DataTable dt = dataTable)

                {

                    conn.Open();



                    SqlDataAdapter da = new(cmd);

                    da.Fill(dt);

                    SqlDataAdapter dr = da;



                    if (dt != null && dt.Rows != null && dt.Rows.Count > 0)

                    {
                        foreach (var row in dt.Rows)
                        {
                           // var Field1 = row[0];
                        }
                        return dt.ToJsonToList<T>();

                    }



                }

                if (conn.State == ConnectionState.Open)

                    conn.Close();

            }

            SqlConnection.ClearPool(conn);



            return default;

        }

    }
}
    


