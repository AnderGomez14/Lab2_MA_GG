using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Alumno
{
    public partial class instanciartarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            if (logica.checkCodTareaInstanciar((String)Session["email"], Request["cod"]))
            {
                if (Page.IsPostBack)
                {
                    switch (logica.instanciarTareaGenerica((String)Session["email"], Request["cod"], HorasDedicadasTextBox.Text))
                    {
                        case 0:
                            Feedback.Text = "Se ha insertado correctamente";
                            GridView1.DataSource = logica.getTareasInstanciadasFromEmail((String)Session["email"]);
                            GridView1.DataBind();
                            break;
                        default:
                            Feedback.Text = "Algo ha ido mal";
                            break;
                    }
                }
                else
                {
                    GridView1.DataSource = logica.getTareasInstanciadasFromEmail((String)Session["email"]);
                    GridView1.DataBind();
                    HorasEstimadasTextBox.Text = logica.getHoursofTareaGenerica(Request["cod"]).ToString();
                    EmailTextBox.Text = (String)Session["email"];
                    TareaTextBox.Text = Request["cod"];
                }

            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}