using System;
using System.Collections.Generic;
using GmailClient;
using DbClient;
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
                AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));
                String sql = "SELECT COUNT(*) FROM usuarios WHERE codpass=@codpass";
                List<String[]> argumentos = new List<String[]>();
                argumentos.Add(new string[2] { "@codpass", Request.QueryString["resetcod"] });
                int result = (int)conection.ExecuteScalar(sql, argumentos);
                conection.close();

                if (result != 1)
                    change.InnerHtml = "Enlace Invalido";
                request.Visible = false;
            }

        }

        protected void buttonReset_Click(object sender, EventArgs e)
        {
            Page.Validate("Resetear");
            if (Page.IsValid)
            {
                Random rnd = new Random();
                int cod = rnd.Next(0, 9999999);

                AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));
                string sql = "UPDATE usuarios SET codpass=@cod WHERE email=@email";
                List<String[]> argumentos = new List<String[]>();
                argumentos.Add(new string[2] { "@email", email.Text });
                argumentos.Add(new string[2] { "@cod", cod.ToString() });

                if (conection.ExecuteNonQuery(sql, argumentos) != 1)
                {
                    ErrorReset.Text = "No hay ningun usuario registrado con ese correo.";
                }
                else
                {
                    string subject = "Cambiar contraseña de en <pagina sin nombre todavia>";
                    string body = "Buenas,<br>Se ha registrado una solicitud para resetear la contraseña, Pinche  <a style='color:blue' href='https://localhost:44388/cambiarPassword.aspx?resetcod=" + cod + "'>Aqui</a> para cambiarla.";

                    MailService service = new MailService((string)Application.Get("emailAddress"), (string)Application.Get("password"));
                    service.send(email.Text, subject, body);

                    ErrorReset.Text = "Se ha enviado un correo para resetear su contraseña. ";
                }
                conection.close();

            }
        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            Page.Validate("CambiarPass");
            if (Page.IsValid)
            {
                AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));
                string sql = "UPDATE usuarios SET pass=@pass, codpass=NULL WHERE codpass=@codpass";
                List<String[]> argumentos = new List<String[]>();
                argumentos.Add(new string[2] { "@pass", password1.Text });
                argumentos.Add(new string[2] { "@codpass", Request.QueryString["resetcod"] });
                if (conection.ExecuteNonQuery(sql, argumentos) != 1)
                {
                    change.InnerHtml = "Algo ha ido mal";
                }
                else
                {
                    Response.Redirect("inicio.aspx");
                }
            }
        }
    }
}