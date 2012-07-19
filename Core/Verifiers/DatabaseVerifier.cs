using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class DatabaseVerifier : AbstractResourceVerifier
    {
        protected override ResultType Verify(Tuple<string, string> tuple)
        {
            ResultType resultType = ResultType.Failure;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(tuple.Item2);
                using (connection)
                {
                    connection.Open();
                    if ((connection.State & ConnectionState.Open) > 0)
                    {
                        resultType = ResultType.Success;
                    }
                }
            }
            catch{}
            finally
            {
                if (connection != null) connection.Close();
            }
            return resultType;
        }

        protected override string ConstructMessage(Tuple<string, string> tuple, ResultType resultType)
        {

            return string.Format("{0} connecting to {1}, connection string : {2}", resultType.ToString(), tuple.Item1, tuple.Item2);
        }
    }
}