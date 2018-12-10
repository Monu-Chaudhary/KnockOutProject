using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Utility
{
    public static class DAO
    {
        public static SqlConnection conn()
        {
            string connectionstrinng = ConfigurationManager.ConnectionStrings["Testko"].ConnectionString;
            SqlConnection connect = new SqlConnection(connectionstrinng);
            if (connect.State != ConnectionState.Open)
                connect.Open();
            return connect;
        }

        public static void close(SqlConnection con)
        {
            con.Close();
        }

        static DAO()
        {

        }

        public static DataSet gettable(string sp, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = DAO.conn())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = sp;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                    return ds;
                }
            }
        }
    }
}
