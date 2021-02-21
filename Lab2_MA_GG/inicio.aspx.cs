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
                Logic logica = (Logic)Application["logic"];

                if (logica.login(EmailTextBox.Text, PassTextBox.Text))
                {
                    Session["email"] = EmailTextBox.Text;
                    Response.Redirect("appTemp.aspx");
                }
                else
                    Feedback.Text = "No hay correo o contraseña incorrectos.";
            }
        }
    }
}