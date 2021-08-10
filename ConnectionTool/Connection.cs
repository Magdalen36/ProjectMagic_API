using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionTool
{
    public class Connection
    {
        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public Connection(string connectionString)
        {
            _connectionString = connectionString;
            using (SqlConnection connection = CreateConnection())
            {

                connection.Open();
            }
        }

        public object ExecuteScalar(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return (result is DBNull) ? null : result;
                }
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetDataTable(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            List<TResult> results = new List<TResult>();
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return selector(reader);
                        }
                    }
                }
            }
        }


        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = command.Query;
            if (command.Stored)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            foreach (KeyValuePair<string, object> kvp in command.Params)
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value;

                cmd.Parameters.Add(parameter);
            }
            return cmd;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnectionString;
            return sqlConnection;
        }
    }
}
