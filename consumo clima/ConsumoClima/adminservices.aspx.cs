using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConsumoClima
{
    public partial class adminservices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet dscity = Objws.GetlistcityByID();
            if (dscity.Tables[0] != null && dscity.Tables[0].Rows.Count > 0)
            {
                DL_City.DataSource = dscity.Tables[0];
                DL_City.DataTextField = dscity.Tables[0].Columns["nombre_ciudad"].ToString();
                DL_City.DataValueField = dscity.Tables[0].Columns["id_ciudad"].ToString();

                DL_City.DataBind();

            }


        }

        protected void DL_City_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}