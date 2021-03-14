using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Alumno
{
    public partial class TareasAlumno : System.Web.UI.Page
    {
        private SqlDataAdapter dAdapterTareasGenericas;
        private SqlDataAdapter dAdapterAsignaturas;
        private DataSet dSetTareasGenericas;
        private DataSet dSetAsignaturas;
        private DataTable dTareasGenericas;
        private DataRow dRow;
        protected void Page_Load(object sender, EventArgs e)
        {

            Logic logica = (Logic)Session["logic"];
            if (Page.IsPostBack)
            {
                dSetTareasGenericas = (DataSet)Session["datosTareasGenericas"];
                dAdapterTareasGenericas = (SqlDataAdapter)Session["adapterTareasGenericas"];
                dSetAsignaturas = (DataSet)Session["datosAsignaturas"];
                dAdapterAsignaturas = (SqlDataAdapter)Session["adapterAsignaturas"];

                DataView dv = new DataView(dSetTareasGenericas.Tables[0]);
                dv.RowFilter = "CodAsig='" + DropDownList1.SelectedValue + "'";
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
            else
            {
                dAdapterAsignaturas = new SqlDataAdapter("SELECT GruposClase.codigoasig FROM GruposClase with(nolock) INNER JOIN EstudiantesGrupo ON GruposClase.codigo = EstudiantesGrupo.Grupo WHERE (EstudiantesGrupo.Email = '" + (String)Session["email"] + "')", logica.getConnection());
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dAdapterAsignaturas);
                dAdapterAsignaturas.Fill(dSetAsignaturas = new DataSet());

                dAdapterTareasGenericas = new SqlDataAdapter("SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea FROM TareasGenericas with(nolock) WHERE Explotacion=1 AND(Codigo NOT IN (SELECT CodTarea FROM EstudiantesTareas AS EstudiantesTareas_1 with(nolock) WHERE (Email = @email))) AND (CodAsig IN (SELECT GruposClase.codigoasig FROM GruposClase with(nolock) INNER JOIN EstudiantesGrupo ON GruposClase.codigo = EstudiantesGrupo.Grupo WHERE (EstudiantesGrupo.Email = @email)))", logica.getConnection());
                commandBuilder = new SqlCommandBuilder(dAdapterTareasGenericas);
                dAdapterTareasGenericas.SelectCommand.Parameters.AddWithValue("@email", (string)Session["email"]);
                dAdapterTareasGenericas.Fill(dSetTareasGenericas = new DataSet());

                DropDownList1.DataSource = dSetAsignaturas.Tables[0];
                DropDownList1.DataTextField = "codigoasig";
                DropDownList1.DataValueField = "codigoasig";
                DropDownList1.DataBind();

                Session["datosAsignaturas"] = dSetAsignaturas;
                Session["adapterAsignaturas"] = dAdapterAsignaturas;
                Session["datosTareasGenericas"] = dSetTareasGenericas;
                Session["adapterTareasGenericas"] = dAdapterTareasGenericas;
            }
        }

        protected void instanciarBoton_Click(object sender, EventArgs e)
        {
            string cod = (sender as Button).CommandArgument;
            Response.Redirect("instanciartarea.aspx?cod=" + cod);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}