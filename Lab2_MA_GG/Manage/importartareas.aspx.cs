using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;

namespace Lab2_MA_GG.Profesor
{
    public partial class importartareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                if (File.Exists(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml")))
                {
                    Xml1.DocumentSource = Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml");
                    Xml1.TransformSource = Server.MapPath("~/app_data/VerTablaTareas_" + DropDownList2.SelectedValue + ".xsl");
                    Feedback.Text = "O añade el JSON a continuacion.";
                }
                else
                {
                    Xml1.Dispose();
                    Feedback.Text = "No hay un XML en la base de datos, puedes añadir un XML o un JSON a continuacion.";
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml")))
            {
                XmlDocument MartyMcDoc = new XmlDocument();
                MartyMcDoc.Load(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml"));
                Logic logica = (Logic)Session["logic"];
                switch (logica.insertarTareas(MartyMcDoc, DropDownList1.SelectedValue))
                {
                    case 0:
                        Feedback.Text = "Todo correcto";
                        break;
                    default:
                        Feedback.Text = "Algo ha ido mal";
                        break;
                }
            }
            else
            {
                if (this.subirTemp("xml"))
                {
                    Logic logica = (Logic)Session["logic"];

                    XmlDocument MartyMcDoc = new XmlDocument();
                    MartyMcDoc.Load("~/app_data/" + DropDownList1.SelectedValue + "_temp.xml");

                    //ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                    // the following call to Validate succeeds.
                    //MartyMcDoc.Validate(eventHandler);
                    switch (logica.insertarTareas(MartyMcDoc, DropDownList1.SelectedValue))
                    {
                        case 0:
                            Feedback.Text = "Todo correcto";
                            break;
                        default:
                            Feedback.Text = "Algo ha ido mal";
                            break;
                    }
                    File.Delete(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + "_temp.xml"));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.subirTemp("json"))
            {
                Logic logica = (Logic)Session["logic"];
                string Json = File.ReadAllText(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + "_temp.json"));
                switch (logica.insertarTareasJSON(Json, DropDownList1.SelectedValue))
                {
                    case 0:
                        Feedback.Text = "Todo correcto";
                        break;
                    default:
                        Feedback.Text = "Algo ha ido mal";
                        break;
                }
                File.Delete(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + "_temp.json"));

            }
        }

        private Boolean subirTemp(string extension)
        {
            string nombre = file.PostedFile.FileName;
            nombre = Path.GetFileName(nombre);
            if (file.Value != "")
            {
                file.PostedFile.SaveAs(Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + "_temp." + extension));
                return true;
            }
            else
            {
                Feedback.Text = "Selecciona un archivo melon";
                return false;
            }
        }
    }
}