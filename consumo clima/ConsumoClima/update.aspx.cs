using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoClima
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                serverweather.clima_ws Objwsdp = new serverweather.clima_ws();
                DataSet dscitydp = Objwsdp.SelectListCity();
                if (dscitydp.Tables[0] != null && dscitydp.Tables[0].Rows.Count > 0)
                {
                    DL_City.DataSource = dscitydp.Tables[0];
                    DL_City.DataTextField = dscitydp.Tables[0].Columns["nombre_ciudad"].ToString();
                    DL_City.DataValueField = dscitydp.Tables[0].Columns["id_ciudad"].ToString();

                    DL_City.DataBind();
                    DL_City.Items.Insert(0, new ListItem("Elija una Ciudad . . .", "0"));
                    //Set the default item as selected.
                    DL_City.Items[0].Selected = true;

                    //Disable the default item.
                    DL_City.Items[0].Attributes["disabled"] = "disabled";



                }
            }
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Update";
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

        protected void DL_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            //el dropdown es el disparador para actualizar la informacion de cada ciudad
            // consume el webservices enviando el ID de la ciudad

            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet ret = Objws.SelectCityById(Convert.ToInt32(DL_City.SelectedItem.Value));

            if (ret.Tables.Count > 0)
            {
                if (ret.Tables[0].Rows.Count > 0)
                {
                    txt_Temperatura.Value = ret.Tables[0].Rows[0]["temperatura"].ToString();
                    txt_posibilidad_lluvia.Value = ret.Tables[0].Rows[0]["Posibilidad_lluvia"].ToString();
                    txt_velocidad_viento.Value = ret.Tables[0].Rows[0]["velocidad_viento"].ToString();

                }
            }
        }

        protected void Btn_save_Click(object sender, EventArgs e)
        {
            
                int id_ciudad = Convert.ToInt32(DL_City.SelectedItem.Value);
                int id_clima = Convert.ToInt32(Ddl_clima.SelectedItem.Value);
                int temperatura = Convert.ToInt32(txt_Temperatura.Value);
                int posibilidad_lluvia = Convert.ToInt32(txt_posibilidad_lluvia.Value);
                int velocidad_viento = Convert.ToInt32(txt_velocidad_viento.Value);
                string direccion_viento = Ddl_direccion_viento.SelectedValue;
                serverweather.clima_ws objupdt = new serverweather.clima_ws();
               int updt= objupdt.UpdatePronostic(id_ciudad, id_clima, velocidad_viento, temperatura, posibilidad_lluvia, direccion_viento);
            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet dscity = Objws.SelectAllCity();
            DataTable dt = dscity.Tables[0];
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "exitoupdate()", true);
            
        }
    }
}