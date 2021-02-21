using System;
using System.Collections.Generic;
using DbClient;
using GmailClient;
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

                Random rnd = new Random();
                int cod = rnd.Next(0, 9999999);

                String sql = "INSERT INTO usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values (@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass)";
                List<String[]> argumentos = new List<String[]>();

                argumentos.Add(new string[2] { "@email", email });
                argumentos.Add(new string[2] { "@nombre", nombre });
                argumentos.Add(new string[2] { "@apellidos", apellido });
                argumentos.Add(new string[2] { "@numconfir", cod.ToString() });
                argumentos.Add(new string[2] { "@tipo", rol });
                argumentos.Add(new string[2] { "@pass", pw1 });

                AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));

                if (conection.ExecuteNonQuery(sql, argumentos) == -1)
                {
                    ErrorLabel.Text = "Ya hay un correo con esa cuenta.";
                    conection.close();
                }
                else
                {
                    string subject = "Confirmar cuenta en <pagina sin nombre todavia>";
                    string body = "Buenas, " + nombre + ".<br>Se ha registrado un usuario con este correo, para verificar el correo, entre en el siguiente enlace  <a style='color:blue' href='https://localhost:44388/confirmar.aspx?mbr=" + email + "&numconf=" + cod + "'>Verificar</a>";

                    MailService service = new MailService((string)Application.Get("emailAddress"), (string)Application.Get("password"));
                    service.send(email, subject, body);
                    conection.close();
                    Response.Redirect("inicio.aspx");
                }
            }

        }
    }
}