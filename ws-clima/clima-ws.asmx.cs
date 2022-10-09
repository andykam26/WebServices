using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using WSNegocios;



namespace ws_clima
{
    /// <summary>
    /// Descripción breve de clima_ws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class clima_ws : System.Web.Services.WebService
    {
        [WebMethod]
        public DataSet SelectAllCity()
        {
            
            WeatherSelectByIdBussines SelectPrnostic = new WeatherSelectByIdBussines();
       
            return SelectPrnostic.GetAllCity();
        }
        [WebMethod]
        public DataSet SelectListCity()
        {

            WeatherSelectByIdBussines SelectPrnostic = new WeatherSelectByIdBussines();

            return SelectPrnostic.GetlistCity();
        }
        [WebMethod]
        public DataSet SelectCityById(int ID)
        {
        
            WeatherSelectByIdBussines SelectPrnostic = new WeatherSelectByIdBussines();
            
            return SelectPrnostic.GetcityByID(ID);
        }


        [WebMethod]
        public int InsertPronostic(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int InsertRecord = 0;
            WeatherSelectByIdBussines insert = new WeatherSelectByIdBussines();
            InsertRecord = insert.InsertPronosticBS(id_ciudad, id_clima, velocidad_viento, temperatura, Posibilidad_lluvia, Direccion_viento);

            return InsertRecord;
        }


        [WebMethod]
        public int UpdatePronostic(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int InsertRecord = 0;
            WeatherSelectByIdBussines insert = new WeatherSelectByIdBussines();
            InsertRecord = insert.UpdatePronosticBS(id_ciudad, id_clima, velocidad_viento, temperatura, Posibilidad_lluvia, Direccion_viento);

            return InsertRecord;
        }

        [WebMethod]
        public DataSet ValidateUserws(string Usuario, string Contrasenia)
        {
            string patron = "colombia";
            WeatherSelectByIdBussines UserValidate = new WeatherSelectByIdBussines();

            return UserValidate.ValidateUserBs(Usuario,Contrasenia, patron);
        }
    }
}
