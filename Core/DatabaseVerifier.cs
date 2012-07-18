using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class DatabaseVerifier : ResourceVerifier
    {
        protected override bool Verify(Tuple<string, string> tuple)
        {
            bool canConnect = false;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(tuple.Item2);
                using (connection)
                {
                    connection.Open();
                    if ((connection.State & ConnectionState.Open) > 0)
                    {
                        canConnect = true;
                    }
                }
            }
            catch{}
            finally
            {
                if (connection != null) connection.Close();
            }
            return canConnect;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, bool canConnect)
        {
            return string.Format("{0} connecting to {1}, connection string : {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
        }
    }
}