using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Alumno
{
    public partial class TareasAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            if (Page.IsPostBack)
            {
                DataTable dt = logica.getTareasFromAsignatura((string)Session["email"], DropDownList1.SelectedValue);
                dt.Columns.Add("Instanciar", typeof(String));
                foreach (DataRow row in dt.Rows)
                {
                    row["Instanciar"] = "<a href=\"" + (String)Application.Get("entorno") + "Alumno/instanciartarea.aspx?cod=" + row["Codigo"].ToString() + "\">Instanciar</a>";
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                DropDownList1.DataSource = logica.getAsignaturas((string)Session["email"]);
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataBind();
            }
        }
    }
}