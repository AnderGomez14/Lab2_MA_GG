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
                        Response.Redirect("~/Alumno/alumno.aspx");
                        break;
                    case 2:
                        Session["email"] = EmailTextBox.Text;
                        Session["tipo"] = "profesor";
                        Response.Redirect("appTemp.aspx");
                        break;
                    default:
                        Feedback.Text = "Correo o contraseña incorrectos.";
                        break;
                }

            }
        }
    }
}