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
            //Timer2.Enabled = true;
            if (IsPostBack) {
                string Password = PassTextBox.Text;
                PassTextBox.Attributes.Add("value", Password);
                Page.Validate();
            }
               
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
                    case 2:
                        ErrorLabel.Text = "El correo no esta matriculado.";
                        break;
                    case 3:
                        ErrorLabel.Text = "La contraseña no es segura";
                        break;
                    default:
                        ErrorLabel.Text = "Error desconocido";
                        break;
                }

            }

        }

        private void comprobarMatricula()
        {
            Logic logica = (Logic)Session["logic"];
            if (logica.comprobarMatricula(EmailTextBox.Text))
            {
                Label1.Text = "";
                Button1.Enabled = true;
            }
            else
            {
                Label1.Text = "El correo no esta matriculado";
                Button1.Enabled = false;
            }
        }
        protected void Timer2_Tick(object sender, EventArgs e)
        {
            //comprobarMatricula();
        }

        protected void Timer2_Tick1(object sender, EventArgs e)
        {
            //comprobarMatricula();
        }

        protected void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            comprobarMatricula();
        }

        protected void PassTextBox_TextChanged(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            if (!logica.comprobarPass(PassTextBox.Text))
            {
                Label2.Text = "";
                Button1.Enabled = true;
            }
            else
            {
                Label2.Text = "La contraseña no es segura.";
                Button1.Enabled = false;
            }
        }

    }
}