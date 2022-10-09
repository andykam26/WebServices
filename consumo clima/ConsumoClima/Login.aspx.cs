using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoClima
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet ret = Objws.ValidateUserws(tbUsuario.Text, tbPassword.Text);
            if (ret.Tables.Count > 0)
            {
                if (ret.Tables[0].Rows.Count > 0)
                {
                    Session["usuariologueado"] = tbUsuario.Text;
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    lblError.Text = "Error de Usuario o Contrasenia";
                }
            }
           
        }
    }
}