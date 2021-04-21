using DbClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServicioCalcularMedia
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://serviciocalcularmedia.azurewebsites.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWebMedias : System.Web.Services.WebService
    {

        [WebMethod]
        public double DedicacionMedia(string codAsig)
        {
            string CadenaConexion = "Server=tcp:hads21-10.database.windows.net,1433;Initial Catalog=HADS21-10;Persist Security Info=False;User ID=garcitxiki@gmail.com@hads21-10;Password=Rumble10;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            AzureConection db = new AzureConection(CadenaConexion);
            List<int> lista = db.DedicacionesByCodAsig(codAsig);
            try
            {
                int suma = 0;
                foreach (int i in lista)
                {
                    suma += i;
                }

                return suma / lista.Count;
            }
            catch { return 0; }
        }
    }
}
