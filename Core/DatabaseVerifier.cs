using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core
{
    public class DatabaseVerifier : IResourceVerifier
    {
        private IList<Tuple<string, string>> dbConnectionList;

        public DatabaseVerifier()
        {
            dbConnectionList = new List<Tuple<string, string>>();
        }

        public void AddConnectionToVerify(string key, string connection)
        {
            dbConnectionList.Add(new Tuple<string, string>(key, connection));
        }

        public List<VerificationResult> GetVerificationStatus()
        {
            List<VerificationResult> result = new List<VerificationResult>();
            SqlConnection connection = null;
            bool canConnect = false;

            foreach (var tuple in dbConnectionList)
            {

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
                }catch{}
                finally
                {
                    if (connection != null) connection.Close();
                }

                string message = string.Format("{0} connecting to {1}, connection string : {2}", canConnect ? "Passed" : "Failed", tuple.Item1, tuple.Item2);
                result.Add(new VerificationResult {CanConnect = canConnect, Message = message});
                canConnect = false;
            }
            return result;
        }
    }
}