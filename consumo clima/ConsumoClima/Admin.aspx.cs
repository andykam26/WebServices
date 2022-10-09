using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoClima
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + usuariologueado;
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet dscity = Objws.SelectAllCity();
            DataTable dt = dscity.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("login.aspx");
        }
    }
}