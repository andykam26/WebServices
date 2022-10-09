using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WSDatos;

namespace WSNegocios
{
    public class WeatherSelectByIdBussines
    {
        public DataSet GetAllCity()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqladpt = new SqlDataAdapter();
            WeatherSelectByIdData pronosticosq = new WeatherSelectByIdData();
            sqladpt = pronosticosq.Getlistcitysa();
            //pronosticosq.GetlistcityByIDsa;
            sqladpt.Fill(ds);
            return ds;
        }
        public DataSet GetlistCity()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqladpt = new SqlDataAdapter();
            WeatherSelectByIdData pronosticosq = new WeatherSelectByIdData();
            sqladpt = pronosticosq.Getlistcity();
            //pronosticosq.GetlistcityByIDsa;
            sqladpt.Fill(ds);
            return ds;
        }
        public DataSet GetcityByID( int ID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sqladpt = new SqlDataAdapter();
            WeatherSelectByIdData pronosticosq = new WeatherSelectByIdData();
            sqladpt = pronosticosq.GetcityByIDsa(ID);
            //pronosticosq.GetlistcityByIDsa;
            sqladpt.Fill(ds);
            return ds;
        }

        public int InsertPronosticBS(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int retRecord = 0;
            WeatherSelectByIdData insertPronostic = new WeatherSelectByIdData();
            retRecord = insertPronostic.InsertPronostic(id_ciudad,id_clima,velocidad_viento,temperatura,Posibilidad_lluvia,Direccion_viento);
            return retRecord;
        }
        public int UpdatePronosticBS(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int retRecord = 0;
            WeatherSelectByIdData UpdatePronostic = new WeatherSelectByIdData();
            retRecord = UpdatePronostic.UpdatePronostic(id_ciudad, id_clima, velocidad_viento, temperatura, Posibilidad_lluvia, Direccion_viento);
            return retRecord;
        }
    }
}
