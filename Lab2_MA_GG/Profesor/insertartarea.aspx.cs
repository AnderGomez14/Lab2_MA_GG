using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Profesor
{
    public partial class insertartarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AñadirTarea_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (Page.IsValid)
            {
                Logic logica = (Logic)Session["logic"];

                Dictionary<string, object> arguments = new Dictionary<string, object>();
                arguments.Add("@descripcion", DescripcionTextBox.Text);
                arguments.Add("@codasig", AsignaturasDropBox.SelectedValue);
                arguments.Add("@hestimadas", HorasTextBox.Text);
                arguments.Add("@explotacion", 1);
                arguments.Add("@tipotarea", TipoDropBox.SelectedValue);
                arguments.Add("@codigo", CodigoTextBox.Text);


                switch (logica.crearTarea(arguments))

                {
                    case 1:
                        Feedback.Text = "Insertado correctamente";
                        break;
                    default:
                        Feedback.Text = "Error desconocido";
                        break;
                }
            }
        }
    }
}