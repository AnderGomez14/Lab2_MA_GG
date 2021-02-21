using System;
using System.Collections.Generic;
using DbClient;
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
                Feedback.Text = "Faltan Argumentos";
            else
            {
                String sql = "UPDATE usuarios SET confirmado=1 WHERE email=@email AND numconfir=@numconfir AND confirmado=0";
                List<String[]> argumentos = new List<String[]>();
                argumentos.Add(new string[2] { "@email", Request.QueryString["mbr"] });
                argumentos.Add(new string[2] { "@numconfir", Request.QueryString["numconf"] });

                AzureConection conection = new DbClient.AzureConection((String)Application.Get("stringSQL"));
                int result = conection.ExecuteNonQuery(sql, argumentos);
                conection.close();

                if (result != 1)
                    Feedback.Text = "Algo ha ido mal, Enlace no valido";
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}