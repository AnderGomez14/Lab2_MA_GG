using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class Service1 : IService1
    {
        public bool Comprobar(string pass, string clave)
        {
            if (clave != "tenia_que_haber_satelites") return false;
            try
            {
                string[] insecurePasswords = File.ReadAllLines(System.Web.HttpContext.Current.Server
.MapPath("~/best1050.txt"));
                foreach (string insecurePassword in insecurePasswords)
                {
                    if (insecurePassword == pass) return true;
                }
                return false;
            }
            catch { return true; }
        }
    }
}
