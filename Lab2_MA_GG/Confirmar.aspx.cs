using System;
using System.Collections.Generic;
using LogicaNegocio;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class Confirmar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mbr"] == null || Request.QueryString["numconf"] == null)
                div.InnerHtml = "Faltan Argumentos";
            else
            {
                Logic logica = (Logic)Session["logic"];

                if (logica.confirmar(Request.QueryString["mbr"], Request.QueryString["numconf"]))
                    div.InnerHtml = "Cuenta verificada con exito, haga click <a href='inicio.aspx'>aqui</a> para iniciar sesion.<br/><br/><img src='https://media.giphy.com/media/m2Q7FEc0bEr4I/giphy.gif' style='display: block;margin-left: auto;margin-right: auto;'>";
                else
                    div.InnerHtml = "Algo ha ido mal, Enlace no valido<br/><br/><img src='https://media.giphy.com/media/3faT4z5qdm19t86ebI/giphy.gif' style='display: block;margin-left: auto;margin-right: auto;'>";

            }
        }
    }
}