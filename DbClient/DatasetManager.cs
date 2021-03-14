using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient
{
    class DatasetManager
    {

        public DatasetManager()
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
    }
}
