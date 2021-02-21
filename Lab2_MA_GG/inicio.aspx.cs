using System;
using System.Collections.Generic;
using DbClient;
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
            AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));
            String sql = "SELECT COUNT(*) FROM usuarios WHERE pass=@pass AND email=@email AND confirmado=1";
            List<String[]> argumentos = new List<String[]>();
            argumentos.Add(new string[2] { "@email", EmailTextBox.Text });
            argumentos.Add(new string[2] { "@pass", PassTextBox.Text });

            int result = (int)conection.ExecuteScalar(sql, argumentos);
            conection.close();

            if (result != 1)
                Feedback.Text = "No hay correo o contraseña incorrectos.";
            else
            {
                Session["email"] = EmailTextBox.Text;
                Response.Redirect("appTemp.aspx");
            }

        }
    }
}