using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConsumoClima
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                serverweather.clima_ws Objwsdp = new serverweather.clima_ws();
                DataSet dscity = Objwsdp.GetlistcityByID();
                if (dscity.Tables[0] != null && dscity.Tables[0].Rows.Count > 0)
                {
                    DL_City.DataSource = dscity;
                    DL_City.DataTextField = "nombre_ciudad";

                    DL_City.DataValueField = "id_ciudad";
                    DL_City.DataBind();
                    DL_City.Items.Insert(0, new ListItem("Elija una Ciudad", "0"));
                    //Set the default item as selected.
                    DL_City.Items[0].Selected = true;

                    //Disable the default item.
                    DL_City.Items[0].Attributes["disabled"] = "disabled";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string valor = DL_City.SelectedItem.Text;
            //serverweather.clima_ws Objws = new serverweather.clima_ws();
            //DataSet ret = Objws.GetDetialByID(Convert.ToInt32(DL_City.SelectedValue));
            //if (ret.Tables.Count > 0)
            //{
            //    if (ret.Tables[0].Rows.Count > 0)
            //    {
            //        lblciudad.Text = ret.Tables[0].Rows[0]["nombre_ciudad"].ToString();
            //        lbldireccion.Text = ret.Tables[0].Rows[0]["tipo_clima"].ToString();
            //    }
            //    else
            //    {
            //        lblMessage.Text = "No hay datos";
            //    }
            //}
        }
    }
}