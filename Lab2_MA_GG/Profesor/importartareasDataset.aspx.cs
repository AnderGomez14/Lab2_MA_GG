using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Lab2_MA_GG.Profesor
{
    public partial class importartareasDataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (File.Exists(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml")))
                {
                    Xml1.DocumentSource = (Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml"));
                    Xml1.TransformSource = Server.MapPath("~/app_data/VerTablaTareas.xsl");
                }
                else
                {
                    Xml1.Dispose();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml")))
            {
                Logic logica = (Logic)Session["logic"];
                switch (logica.insertarTareasDataset(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml"), DropDownList1.SelectedValue))
                {
                    case 0:
                        Feedback.Text = "Todo correcto";
                        break;
                    default:
                        Feedback.Text = "Alguna de las tareas estan duplicadas";
                        break;
                }
            }
        }
    }
}