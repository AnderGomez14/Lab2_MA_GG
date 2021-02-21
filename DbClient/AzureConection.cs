using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DbClient
{
    public class AzureConection
    {
        private SqlConnection connection;

        public AzureConection(string cadenaSql)
        {
            try
            {
                connection = new SqlConnection(cadenaSql);
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido abrir la conexion.");
            }
        }


        public object ExecuteScalar(string sentencia, List<String[]> argumentos)
        {
            SqlCommand command = new SqlCommand(sentencia, connection);
            if (argumentos != null)
            {
                foreach (string[] argument in argumentos)
                {
                    command.Parameters.AddWithValue(argument[0], argument[1]);
                }
            }
            return command.ExecuteScalar();
        }

        public int ExecuteNonQuery(string sentencia, List<String[]> argumentos)
        {
            try
            {
                SqlCommand command = new SqlCommand(sentencia, connection);
                if (argumentos != null)
                {
                    foreach (string[] argument in argumentos)
                    {
                        command.Parameters.AddWithValue(argument[0], argument[1]);
                    }
                }
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }

        }

        public SqlDataReader ExecuteReader(string sentencia, List<String[]> argumentos)
        {
            SqlCommand command = new SqlCommand(sentencia, connection);
            if (argumentos != null)
            {
                foreach (string[] argument in argumentos)
                {
                    command.Parameters.AddWithValue(argument[0], argument[1]);
                }
            }
            return command.ExecuteReader();
        }

        public void close()
        {
            connection.Close();
        }
    }
}
