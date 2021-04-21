using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Lab2_MA_GG.Manage
{
    public partial class coordinador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Logic logica = (Logic)Session["logic"];
                Label2.Text = logica.calcularMedia(DropAsignaturas.SelectedValue).ToString();
            }

        }

        protected void DropAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logic logica = (Logic)Session["logic"];
            Label2.Text = logica.calcularMedia(DropAsignaturas.SelectedValue).ToString();
        }
    }
}