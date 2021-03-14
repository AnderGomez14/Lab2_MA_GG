using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((String)Session["tipo"] != "alumno")
                Response.Redirect("~/index.aspx"); //Cambiar a 404
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["email"] = null;
            Session["tipo"] = null;
            Response.Redirect("~/index.aspx");
        }
    }
}