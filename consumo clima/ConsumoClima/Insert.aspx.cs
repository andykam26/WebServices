using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoClima
{
    public partial class Insert : System.Web.UI.Page
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
                lblBienvenida.Text = "Insert";
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
                    //    lblciudad.Text = ret.Tables[0].Rows[0]["nombre_ciudad"].ToString();
                    //    lbldireccion.Text = ret.Tables[0].Rows[0]["tipo_clima"].ToString();
                    //    lbllluvia.Text = ret.Tables[0].Rows[0]["Posibilidad_lluvia"].ToString();
                    //    lbltemperatura.Text = ret.Tables[0].Rows[0]["temperatura"].ToString();
                    //    Lblviento.Text = ret.Tables[0].Rows[0]["velocidad_viento"].ToString();
                    //    lbldireccion.Text = ret.Tables[0].Rows[0]["Direccion_viento"].ToString();
                    //    tipo_clima = ret.Tables[0].Rows[0]["tipo_clima"].ToString();
                    //    if (tipo_clima == "Soleado")
                    //    {
                    //        img_principal.Src = "images/icons/icon-2.svg";

                    //    }
                    //    else if (tipo_clima == "Nublado")
                    //    {
                    //        img_principal.Src = "images/icons/icon-6.svg";
                    //    }
                    //    else if (tipo_clima == "Lloviznas")
                    //    {
                    //        img_principal.Src = "images/icons/icon-9.svg";
                    //    }
                    //    else
                    //    {
                    //        img_principal.Src = "images/icons/icon-11.svg";
                    //    }

                    //}
                    //else
                    //{
                    //    lblMessage.Text = "No hay datos";
                    //}
                }
            }
        }

        protected void Btn_save_Click(object sender, EventArgs e)
        {

        }
    }
}