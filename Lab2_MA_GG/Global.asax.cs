using System;
using LogicaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Configuration;

namespace Lab2_MA_GG
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.js",
                DebugPath = "https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.9.0.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
            });
            string entorno;
            if (System.Configuration.ConfigurationManager.AppSettings["entorno"] != null)

                entorno = System.Configuration.ConfigurationManager.AppSettings["entorno"];
            else
                entorno = Properties.Settings.Default.entorno;
            Application.Set("entorno", entorno);
            Dictionary<string, string> usariosOnline = new Dictionary<string, string>();
            Application.Set("usuariosOnline", usariosOnline);


        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string stringSQL;
            if (ConfigurationManager.ConnectionStrings["AzureSQL"] != null) // Prioridad : SERVIDOR
                stringSQL = ConfigurationManager.ConnectionStrings["AzureSQL"].ConnectionString;
            else // Prioridad : LOCAL
                stringSQL = Properties.Settings.Default.AzureSQL;

            string emailAddress = Properties.Settings.Default.email;
            string password = Properties.Settings.Default.password;
            Session["logic"] = new Logic(stringSQL, emailAddress, password);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Dictionary<string, string> usuariosOnline = (Dictionary<string, string>)Application.Get("usuariosOnline");
            try
            {
                usuariosOnline.Remove((string)Session["email"]);
            }
            catch { }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}