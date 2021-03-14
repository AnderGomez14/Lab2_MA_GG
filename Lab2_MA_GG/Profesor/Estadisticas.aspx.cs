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
    public partial class Estadisticas : System.Web.UI.Page
    {
        private SqlDataAdapter dAdapterTareasUsuarios;
        private DataSet dSetTareasUsuarios;
        private SqlDataAdapter dAdapterTareas;
        private DataSet dSetTareas;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            if (Page.IsPostBack)
            {
                dSetTareasUsuarios = (DataSet)Session["datosTareasUsuarios"];
                dAdapterTareasUsuarios = (SqlDataAdapter)Session["adapterTareasUsuarios"];
            }
            else
            {
                dAdapterTareasUsuarios = new SqlDataAdapter("SELECT email, COUNT(*), SUM (HReales)  FROM EstudiantesTareas with(nolock) GROUP BY email", logica.getConnection());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dAdapterTareasUsuarios);
                dAdapterTareasUsuarios.Fill(dSetTareasUsuarios = new DataSet());

                dAdapterTareas = new SqlDataAdapter("SELECT COUNT(*), SUM (HReales)  FROM EstudiantesTareas with(nolock)", logica.getConnection());
                commandBuilder = new SqlCommandBuilder(dAdapterTareas);
                dAdapterTareas.Fill(dSetTareas = new DataSet());

                TareasTotales.Text = dSetTareas.Tables[0].Rows[0].ItemArray[0].ToString();
                HorasTotal.Text = dSetTareas.Tables[0].Rows[0].ItemArray[1].ToString();

                Session["datosTareasUsuarios"] = dSetTareasUsuarios;
                Session["adapterTareasUsuarios"] = dAdapterTareasUsuarios;
            }
            TareasAlumno.Text = "0";
            HorasTotalAlumno.Text = "0";
            foreach (DataRow row in dSetTareasUsuarios.Tables[0].Rows)
            {
                if ((String)DropDownList1.SelectedValue == (String)row[0])
                {
                    TareasAlumno.Text = row[1].ToString();
                    HorasTotalAlumno.Text = row[2].ToString();
                    break;
                }
            }
        }
    }
}
