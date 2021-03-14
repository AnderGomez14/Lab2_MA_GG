using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DbClient
{
    public class AzureConection
    {
        private SqlConnection connection;
        private string CadenaConexion;

        public AzureConection(string cadenaSql)
        {
            try
            {
                connection = new SqlConnection();
                CadenaConexion = cadenaSql;
            }
            catch (Exception e)
            {
                Console.WriteLine("No se ha podido abrir la conexion.");
            }
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(CadenaConexion);
        }

        public int login(string email, string password)
        {
            String sql = "SELECT tipo FROM usuarios WITH(nolock) WHERE pass=@pass AND email=@email AND confirmado=1";

            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            //string encrypted_pass = Encripta(password);
            argumentos.Add(new string[2] { "@pass", password });

            SqlDataReader reader = this.ExecuteReader(sql, argumentos);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetString(0) == "Profesor")
                    {
                        reader.Close();
                        return 2;
                    }
                    else
                    {
                        reader.Close();
                        return 1;
                    }

                }
            }
            reader.Close();
            return 0;
        }

        public int Register(string email, string nombre, string apellido, string rol, string pw1)
        {
            Random rnd = new Random();
            int cod = rnd.Next(0, 9999999);

            String sql = "INSERT INTO usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values (@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass)";
            List<String[]> argumentos = new List<String[]>();

            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@nombre", nombre });
            argumentos.Add(new string[2] { "@apellidos", apellido });
            argumentos.Add(new string[2] { "@numconfir", cod.ToString() });
            argumentos.Add(new string[2] { "@tipo", rol });

            //string encrypted_pass = Encripta(pw1);
            argumentos.Add(new string[2] { "@pass", pw1 });

            return (this.ExecuteNonQuery(sql, argumentos) == -1) ? -1 : cod;
        }

        public Boolean confirmar(string email, string cod)
        {
            String sql = "UPDATE usuarios SET confirmado=1 WHERE email=@email AND numconfir=@numconfir AND confirmado=0";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@numconfir", cod });

            int result = this.ExecuteNonQuery(sql, argumentos);

            return result == 1;
        }

        public Boolean checkCod(string codpass)
        {
            String sql = "SELECT COUNT(*) with(nolock) FROM usuarios WHERE codpass=@codpass";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@codpass", codpass });
            int result = (int)this.ExecuteScalar(sql, argumentos);
            return result == 1;
        }

        public DataTable getAsignaturas(string email)
        {
            String sql = "SELECT GruposClase.codigoasig FROM GruposClase with(nolock) INNER JOIN EstudiantesGrupo ON GruposClase.codigo = EstudiantesGrupo.Grupo WHERE (EstudiantesGrupo.Email = @email)";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });

            return this.ExecuteDataTable(sql, argumentos);
        }

        public DataTable getTareasFromAsignatura(string email, string codAsig)
        {
            String sql = "SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas with(nolock) WHERE (CodAsig = @cod) AND (Codigo NOT IN (SELECT CodTarea FROM EstudiantesTareas AS EstudiantesTareas_1 with(nolock) WHERE (Email = @email))) AND (CodAsig IN (SELECT GruposClase.codigoasig FROM GruposClase with(nolock) INNER JOIN EstudiantesGrupo ON GruposClase.codigo = EstudiantesGrupo.Grupo WHERE (EstudiantesGrupo.Email = @email)))";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@cod", codAsig });


            return this.ExecuteDataTable(sql, argumentos);
        }

        public DataTable getTareasInstanciadasFromEmail(string email)
        {
            String sql = "SELECT * FROM EstudiantesTareas WHERE (Email = @email)";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });

            return this.ExecuteDataTable(sql, argumentos);
        }

        public int getHoursofTareaGenerica(string tarea)
        {
            String sql = "SELECT HEstimadas FROM TareasGenericas WHERE (Codigo = @codigo)";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@codigo", tarea });

            SqlDataReader reader = this.ExecuteReader(sql, argumentos);

            if (reader.HasRows)
            {
                reader.Read();
                int valueReturn = reader.GetInt32(0);
                reader.Close();
                return valueReturn;

            }
            reader.Close();
            return -1;
        }

        public Boolean checkCodTareaInstanciar(string email, string cod)
        {
            String sql = "SELECT COUNT(*) FROM TareasGenericas with(nolock) WHERE (Codigo = @cod) AND Explotacion=1 AND (Codigo NOT IN (SELECT CodTarea FROM EstudiantesTareas AS EstudiantesTareas_1 with(nolock) WHERE (Email = @email))) AND (CodAsig IN (SELECT GruposClase.codigoasig FROM GruposClase with(nolock) INNER JOIN EstudiantesGrupo ON GruposClase.codigo = EstudiantesGrupo.Grupo WHERE (EstudiantesGrupo.Email = @email)))";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@cod", cod });
            int result = (int)this.ExecuteScalar(sql, argumentos);
            return result == 1;
        }

        public int instanciarTareaGenerica(string email, string cod, string tiempoDedicado)
        {
            if (!checkCodTareaInstanciar(email, cod))
                return 1;
            String sql = "INSERT INTO EstudiantesTareas(Email,CodTarea,HEstimadas,HReales) VALUES (@Email,@CodTarea,@HEstimadas,@HReales)";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@Email", email });
            argumentos.Add(new string[2] { "@CodTarea", cod });
            argumentos.Add(new string[2] { "@HEstimadas", this.getHoursofTareaGenerica(cod).ToString() });
            argumentos.Add(new string[2] { "@HReales", tiempoDedicado.ToString() });

            return (this.ExecuteNonQuery(sql, argumentos) == -1) ? 2 : 0;
        }
        public int sendResetMail(string email)
        {
            Random rnd = new Random();
            int cod = rnd.Next(0, 9999999);

            string sql = "UPDATE usuarios SET codpass=@cod WHERE email=@email";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", email });
            argumentos.Add(new string[2] { "@cod", cod.ToString() });

            return this.ExecuteNonQuery(sql, argumentos) != 1 ? -1 : cod;
        }

        public Boolean changePassword(string cod, string pass)
        {
            string sql = "UPDATE usuarios SET pass=@pass, codpass=NULL WHERE codpass=@codpass";
            List<String[]> argumentos = new List<String[]>();
            //string encrypted_pass = Encripta(pass);
            argumentos.Add(new string[2] { "@pass", pass });
            argumentos.Add(new string[2] { "@codpass", cod });
            return (this.ExecuteNonQuery(sql, argumentos) == 1);
        }

        public int crearTarea(Dictionary<string, object> argumentos)
        {
            return this.ExecuteProcedure("InsertarTarea", argumentos);
        }

        public object ExecuteScalar(string sentencia, List<String[]> argumentos)
        {
            object valReturn = null;
            try
            {
                if (connection is null)
                    return valReturn;

                using (connection)
                {

                    // Establer la conexion
                    connection.ConnectionString = CadenaConexion; // Establece la conexion con la cadena de conexion

                    connection.Open(); // la abre
                    SqlCommand command = new SqlCommand(sentencia, connection);
                    if (argumentos != null)
                    {
                        foreach (string[] argument in argumentos)
                            command.Parameters.AddWithValue(argument[0], argument[1]);
                    }
                    valReturn = command.ExecuteScalar();
                }// Libera todos los recursos de la conexion
            }
            catch { }
            return valReturn;
        }

        public int ExecuteNonQuery(string sentencia, List<String[]> argumentos)
        {
            int valReturn = -1;
            try
            {
                if (connection is null)
                    return valReturn;

                using (connection)
                {

                    // Establer la conexion
                    connection.ConnectionString = CadenaConexion; // Establece la conexion con la cadena de conexion

                    connection.Open(); // la abre
                    SqlCommand command = new SqlCommand(sentencia, connection);
                    if (argumentos != null)
                    {
                        foreach (string[] argument in argumentos)
                            command.Parameters.AddWithValue(argument[0], argument[1]);
                    }
                    valReturn = command.ExecuteNonQuery();
                }// Libera todos los recursos de la conexion
            }
            catch { }
            return valReturn;
        }

        public SqlDataReader ExecuteReader(string sentencia, List<String[]> argumentos)
        {
            SqlDataReader valReturn = null;
            try
            {
                if (connection is null)
                    return valReturn;

                // Establer la conexion
                connection.ConnectionString = CadenaConexion; // Establece la conexion con la cadena de conexion

                connection.Open(); // la abre
                SqlCommand command = new SqlCommand(sentencia, connection);
                if (argumentos != null)
                {
                    foreach (string[] argument in argumentos)
                        command.Parameters.AddWithValue(argument[0], argument[1]);
                }
                valReturn = command.ExecuteReader(CommandBehavior.CloseConnection);// Libera todos los recursos de la conexion cuando el reader se cierre
            }
            catch { }
            return valReturn;

        }

        public DataTable ExecuteDataTable(string sentencia, List<String[]> argumentos)
        {
            DataTable valReturn = null;
            try
            {
                using (connection)
                {
                    if (connection is null)
                        return valReturn;

                    // Establer la conexion
                    connection.ConnectionString = CadenaConexion; // Establece la conexion con la cadena de conexion

                    connection.Open(); // la abre
                    SqlCommand command = new SqlCommand(sentencia, connection);
                    if (argumentos != null)
                    {
                        foreach (string[] argument in argumentos)
                            command.Parameters.AddWithValue(argument[0], argument[1]);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    valReturn = table;
                }// Libera todos los recursos de la conexion cuando el reader se cierre
            }
            catch { }
            return valReturn;

        }

        public int ExecuteProcedure(string sentencia, Dictionary<string, object> argumentos)
        {
            int valReturn = -1;

            try
            {
                using (connection)
                {
                    // Establer la conexion
                    connection.ConnectionString = CadenaConexion; // Establece la conexion con la cadena de conexion
                    connection.Open();
                    SqlCommand command = new SqlCommand(sentencia, connection);

                    if (!(argumentos is null))
                    {
                        foreach (KeyValuePair<string, object> argument in argumentos)
                        {
                            command.Parameters.AddWithValue(argument.Key, argument.Value);
                        }
                    }

                    valReturn = command.ExecuteNonQuery();  // Ejecutar
                } // Libera todos los recursos de la conexion
            }
            catch { }

            return valReturn;
        }
    }
}
