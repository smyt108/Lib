using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BasicLibrary
{
    public class DBConnHelper
    {
        private readonly string _connString;

        public DBConnHelper(string connString)
        {
            _connString = connString;
        }

        public DataSet ExecQuery(String query, int timeout=60)
        {
            DataSet result = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandTimeout = timeout;

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        result = new DataSet();
                        adapter.Fill(result);
                        result.DataSetName = query;
                        result.Tables[0].TableName = query;

                        return result;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataSet ExecStoreProc(String spName, int timeout = 60)
        {
            DataSet result = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(spName, connection))
                    {
                        cmd.CommandTimeout = timeout;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.Add()

                        return result;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
