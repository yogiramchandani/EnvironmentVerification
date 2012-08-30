using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Core
{
    public class DatabaseVerifier : AbstractResourceVerifier
    {
        private string ConnectionString = "ConnectionString";

        protected override VerificationResult Verify(Tuple<string, IDictionary<string, string>> dbConnectionItems)
        {
            ResultType resultType = ResultType.Failure;
            SqlConnection connection = null;
            try
            {
                string connectionString = string.Empty;
                if (!dbConnectionItems.Item2.TryGetValue(ConnectionString, out connectionString))
                {
                    return new VerificationResult { Type = ResultType.Failure, Message = string.Format("Key {0} not found", ConnectionString) };
                }

                connection = new SqlConnection(connectionString);
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
            return new VerificationResult { Type = resultType };
        }
    }
}