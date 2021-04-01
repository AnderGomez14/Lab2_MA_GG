using System;
using LogicaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Logic logica = (Logic)Session["logic"];

                switch (logica.login(EmailTextBox.Text, PassTextBox.Text))
                {
                    case 1:
                        Session["email"] = EmailTextBox.Text;
                        Session["tipo"] = "alumno";
                        System.Web.Security.FormsAuthentication.SetAuthCookie("alumno", true);
                        Response.Redirect("~/Alumno/alumno.aspx");
                        break;
                    case 2:
                        Session["email"] = EmailTextBox.Text;
                        Session["tipo"] = "profesor";
                        System.Web.Security.FormsAuthentication.SetAuthCookie("profesor", true);
                        Response.Redirect("~/Profesor/profesor.aspx");
                        break;
                    case 3:
                        Session["email"] = EmailTextBox.Text;
                        Session["tipo"] = "superprofesor";
                        System.Web.Security.FormsAuthentication.SetAuthCookie("superprofesor", true);
                        Response.Redirect("~/Profesor/profesor.aspx");
                        break;
                    case 4:
                        Session["email"] = EmailTextBox.Text;
                        Session["tipo"] = "admin";
                        System.Web.Security.FormsAuthentication.SetAuthCookie("admin", true);
                        Response.Redirect("~/Admin/InicioAdmin.aspx");
                        break;
                    default:
                        Feedback.Text = "Correo o contraseña incorrectos.";
                        break;
                }

            }
        }
    }
}