using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class appTemp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
                form1.InnerHtml = "Area restringida";
            else
                Label1.Text = (String)Session["email"];
        }

        protected void CerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session["email"] = null;
            Response.Redirect("index.aspx");

        }
    }
}