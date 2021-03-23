using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG.Alumno
{
    public partial class instanciartarea : System.Web.UI.Page
    {
        private SqlDataAdapter dAdapterTareasRealizadas;
        private DataSet dSetTareasRealizadas;
        protected void Page_Load(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            if (logica.checkCodTareaInstanciar((String)Session["email"], Request["cod"]))
            {
                if (Page.IsPostBack)
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        dSetTareasRealizadas = (DataSet)Session["datosTareasRealizadas"];
                        dAdapterTareasRealizadas = (SqlDataAdapter)Session["adapterTareasRealizadas"];
                        DataTable table = dSetTareasRealizadas.Tables[0];
                        DataRow dr = table.NewRow();
                        dr["Email"] = (String)Session["email"];
                        dr["CodTarea"] = Request["cod"];
                        dr["HEstimadas"] = (int)Session["horas"];
                        dr["HReales"] = HorasDedicadasTextBox.Text;
                        table.Rows.Add(dr);
                        Feedback.Text = "Se ha insertado correctamente";
                        GridView1.DataSource = table;
                        GridView1.DataBind();
                        dAdapterTareasRealizadas.Update(dSetTareasRealizadas);
                        dSetTareasRealizadas.AcceptChanges();
                    }
                }
                else
                {
                    dAdapterTareasRealizadas = new SqlDataAdapter("SELECT * FROM EstudiantesTareas WHERE (Email = @email)", logica.getConnection());
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dAdapterTareasRealizadas);
                    dAdapterTareasRealizadas.SelectCommand.Parameters.AddWithValue("@email", (string)Session["email"]);
                    dAdapterTareasRealizadas.Fill(dSetTareasRealizadas = new DataSet());

                    GridView1.DataSource = dSetTareasRealizadas.Tables[0];
                    GridView1.DataBind();

                    DataSet dSetTareasGenericas = (DataSet)Session["datosTareasGenericas"];
                    int horas = -1;
                    foreach (DataRow row in dSetTareasGenericas.Tables[0].Rows)
                    {
                        if ((String)row[0] == (String)Request["cod"])
                        {
                            horas = (int)row[3];
                            break;
                        }
                    }
                    Session["horas"] = horas;
                    Session["datosTareasRealizadas"] = dSetTareasRealizadas;
                    Session["adapterTareasRealizadas"] = dAdapterTareasRealizadas;

                    HorasEstimadasTextBox.Text = horas.ToString();
                    EmailTextBox.Text = (String)Session["email"];
                    TareaTextBox.Text = Request["cod"];
                }

            }
            else
            {
                Response.Redirect("../index.aspx"); //404???
            }
        }
    }
}