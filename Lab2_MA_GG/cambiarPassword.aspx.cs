using System;
using System.Collections.Generic;
using LogicaNegocio;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["resetcod"] == null)
                change.Visible = false;
            else
            {
                Logic logica = (Logic)Session["logic"];

                if (!logica.checkCod(Request.QueryString["resetcod"]))
                    change.InnerHtml = "Enlace Invalido<br/><br/><img src='https://media.giphy.com/media/3faT4z5qdm19t86ebI/giphy.gif' style='display: block;margin-left: auto;margin-right: auto;'>";
                request.Visible = false;
            }

        }

        protected void buttonReset_Click(object sender, EventArgs e)
        {
            Page.Validate("Resetear");
            if (Page.IsValid)
            {
                Logic logica = (Logic)Session["logic"];

                if (logica.sendResetMail(email.Text))
                    ErrorReset.Text = "Se ha enviado un correo para resetear su contraseña. ";
                else
                    ErrorReset.Text = "No hay ningun usuario registrado con ese correo.";
            }
        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            Page.Validate("CambiarPass");
            if (Page.IsValid)
            {
                Logic logica = (Logic)Session["logic"];

                if (logica.changePassword(Request.QueryString["resetcod"], password1.Text))
                {
                    change.InnerHtml = "Contraseña restablecida con exito, haga click <a href='inicio.aspx'>aqui</a> para iniciar sesion.<br/><br/><img src='https://media.giphy.com/media/m2Q7FEc0bEr4I/giphy.gif' style='display: block;margin-left: auto;margin-right: auto;'>";
                }
                else
                {
                    change.InnerHtml = "Algo ha ido mal<br/><br/><img src='https://media.giphy.com/media/3faT4z5qdm19t86ebI/giphy.gif' style='display: block;margin-left: auto;margin-right: auto;'>";
                }
            }
        }
    }
}