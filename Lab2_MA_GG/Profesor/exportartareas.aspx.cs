using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Alumno
{
    public partial class exportartareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];

            if (Page.IsPostBack)
            {
                GridView1.DataSource = logica.getDataViewFromCodasig(DropDownList1.SelectedValue);
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];

            string xml = logica.exportarXML(DropDownList1.SelectedValue, Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".xml"));

            Response.Clear();
            string fileName = String.Format(DropDownList1.SelectedValue + ".xml", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "filename=" + fileName);

            // write string data to Response.OutputStream here
            Response.Write(xml);

            Response.Flush();
            Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];

            string json = logica.exportarJSON(DropDownList1.SelectedValue, Server.MapPath("~/app_data/" + DropDownList1.SelectedValue + ".json"));

            Response.Clear();
            string fileName = String.Format(DropDownList1.SelectedValue + ".json", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("content-disposition", "filename=" + fileName);

            // write string data to Response.OutputStream here
            Response.Write(json);

            Response.Flush();
            Response.End();
        }
    }
}