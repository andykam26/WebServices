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
            //cargamos el dropdwn desde el web services actualizando las ciudades con informacion.
            if (!IsPostBack)
            {
                serverweather.clima_ws Objws = new serverweather.clima_ws();
                DataSet dscity = Objws.GetlistcityByID();
                if (dscity.Tables[0] != null && dscity.Tables[0].Rows.Count > 0)
                {
                    DL_City.DataSource = dscity.Tables[0];
                    DL_City.DataTextField = dscity.Tables[0].Columns["nombre_ciudad"].ToString();
                    DL_City.DataValueField = dscity.Tables[0].Columns["id_ciudad"].ToString();

                    DL_City.DataBind();
                    DL_City.Items.Insert(0, new ListItem("Elija una Ciudad . . .", "0"));
                    //Set the default item as selected.
                    DL_City.Items[0].Selected = true;

                    //Disable the default item.
                    DL_City.Items[0].Attributes["disabled"] = "disabled";
                    var dateAndTime = DateTime.Now;
                    var Date = dateAndTime.ToLongDateString();
              
                    lbldate.Text = Date;
                }
            }

        }

        protected void DL_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            //el dropdown es el disparador para actualizar la informacion de cada ciudad
            // consume el webservices enviando el ID de la ciudad
            string tipo_clima;
            serverweather.clima_ws Objws = new serverweather.clima_ws();
            DataSet ret = Objws.GetDetialByID(Convert.ToInt32(DL_City.SelectedItem.Value));

            if (ret.Tables.Count > 0)
            {
                if (ret.Tables[0].Rows.Count > 0)
                {
                    lblciudad.Text = ret.Tables[0].Rows[0]["nombre_ciudad"].ToString();
                    lbldireccion.Text = ret.Tables[0].Rows[0]["tipo_clima"].ToString();
                    lbllluvia.Text = ret.Tables[0].Rows[0]["Posibilidad_lluvia"].ToString();
                    lbltemperatura.Text = ret.Tables[0].Rows[0]["temperatura"].ToString();
                    Lblviento.Text = ret.Tables[0].Rows[0]["velocidad_viento"].ToString();
                    lbldireccion.Text = ret.Tables[0].Rows[0]["Direccion_viento"].ToString();
                    tipo_clima = ret.Tables[0].Rows[0]["tipo_clima"].ToString();
                    if (tipo_clima=="Soleado")
                    {
                        img_principal.Src = "images/icons/icon-2.svg";
                        
                    }
                    else if (tipo_clima == "Nublado")
                    {
                        img_principal.Src = "images/icons/icon-6.svg";
                    }
                    else if (tipo_clima == "Lloviznas")
                    {
                        img_principal.Src = "images/icons/icon-9.svg";
                    }
                    else
                    {
                        img_principal.Src = "images/icons/icon-11.svg";
                    }

                }
                else
                {
                    lblMessage.Text = "No hay datos";
                }
            }
        }

   
    }
}