using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab2_MA_GG
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> usuariosOnline = (Dictionary<string, string>)Application.Get("usuariosOnline");
            List<string> alumnos = new List<string>();
            List<string> profesores = new List<string>();

            foreach (KeyValuePair<string, string> tupla in usuariosOnline)
            {
                if (tupla.Value == "alumno")
                {
                    alumnos.Add(tupla.Key);
                }
                else if (tupla.Value == "profesor")
                {
                    profesores.Add(tupla.Key);

                }
                else { }
            }

            string tellesita = "";
            switch (alumnos.Count)
            {
                case 0:
                    break;
                case 1:
                    tellesita += "1 alumno";
                    break;
                default:
                    tellesita += alumnos.Count + " alumnos";
                    break;
            }
            if (tellesita != "" && profesores.Count > 0)
                tellesita += " y ";
            switch (profesores.Count)
            {
                case 0:
                    break;
                case 1:
                    tellesita += "1 profesor";
                    break;
                default:
                    tellesita += profesores.Count + " profesores";
                    break;
            }

            Label1.Text = tellesita;
            ListBoxAlumnos.DataSource = alumnos;
            ListBoxAlumnos.DataBind();
            ListBoxProfesores.DataSource = profesores;
            ListBoxProfesores.DataBind();
        }
    }
}