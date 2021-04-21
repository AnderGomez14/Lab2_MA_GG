using DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioMedia
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : ICalcularMedia
    {
        public double DedicacionMedia(string codAsig)
        {
            string CadenaConexion = "Server=tcp:hads21-10.database.windows.net,1433;Initial Catalog=HADS21-10;Persist Security Info=False;User ID=garcitxiki@gmail.com@hads21-10;Password=Rumble10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            AzureConection db = new AzureConection(CadenaConexion);
            List<int> lista = db.DedicacionesByCodAsig(codAsig);
            int suma = 0;
            foreach (int i in lista)
            {
                suma += i;
            }

            return suma / lista.Count;
        }
    }
}
