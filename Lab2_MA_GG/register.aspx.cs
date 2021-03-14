using System;
using System.Collections.Generic;
using LogicaNegocio;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Lab2_MA_GG
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string email = EmailTextBox.Text;
                string nombre = NombreTextBox.Text;
                string apellido = ApellidoTextBox.Text;
                string pw1 = PassTextBox.Text;
                string rol = TipoButtonList.SelectedValue.ToString();

                Logic logica = (Logic)Session["logic"];
                int codigo = logica.Register(email, nombre, apellido, rol, pw1, (String)Application.Get("entorno"));
                switch (codigo)
                {
                    case 0:
                        form1.InnerHtml = "Se ha enviado un correo de verificacion. Compruebe su correo para continuar con el registro.";
                        break;
                    case 1:
                        ErrorLabel.Text = "Ya hay un correo con esa cuenta.";
                        break;
                    default:
                        ErrorLabel.Text = "Error desconocido";
                        break;
                }

            }

        }
    }
}