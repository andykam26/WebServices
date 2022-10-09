using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WSDatos
{
    public class WeatherSelectByIdData
    {
        //SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["wsclimaConnectionString"].ConnectionString);

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-FU83NIC\\SQLEXPRESS;Initial Catalog=wsclima;Persist Security Info=True;User ID=sa;Password=771026juan*");
   
        public SqlDataAdapter Getlistcitysa()
        {
            SqlDataAdapter sqladp = new SqlDataAdapter();
            using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_select", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("id_ciudad", SqlDbType.Int).Value = ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sqladp.SelectCommand = cmd;
                //adp.Fill(ds);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            return sqladp;
        }
        public SqlDataAdapter Getlistcity()
        {
            SqlDataAdapter sqladp = new SqlDataAdapter();
            using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_list", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("id_ciudad", SqlDbType.Int).Value = ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sqladp.SelectCommand = cmd;
                //adp.Fill(ds);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            return sqladp;
        }
        public SqlDataAdapter GetcityByIDsa(int ID)
        {
            SqlDataAdapter sqladp = new SqlDataAdapter();
            using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_select_ById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id_ciudad", SqlDbType.Int).Value = ID;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                sqladp.SelectCommand = cmd;
                //adp.Fill(ds);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


            return sqladp;
        }

        public int InsertPronostic(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int retRecord = 0;
            using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_insert", conn))
            {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_ciudad", SqlDbType.Int).Value = id_ciudad;
                    cmd.Parameters.Add("@id_clima", SqlDbType.Int).Value = id_clima;
                    cmd.Parameters.Add("@velocidad_viento", SqlDbType.Int).Value = velocidad_viento;
                    cmd.Parameters.Add("@temperatura", SqlDbType.Int).Value = temperatura;
                    cmd.Parameters.Add("@Posibilidad_lluvia", SqlDbType.Int).Value = Posibilidad_lluvia;
                    cmd.Parameters.Add("@Direccion_viento", SqlDbType.VarChar).Value = Direccion_viento;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                retRecord = cmd.ExecuteNonQuery();
                return retRecord;
            }

        }
        public int UpdatePronostic(int id_ciudad, int id_clima, int velocidad_viento, int temperatura, int Posibilidad_lluvia, string Direccion_viento)
        {
            int retRecord = 0;
            using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_update", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_ciudad", SqlDbType.Int).Value = id_ciudad;
                cmd.Parameters.Add("@id_clima", SqlDbType.Int).Value = id_clima;
                cmd.Parameters.Add("@velocidad_viento", SqlDbType.Int).Value = velocidad_viento;
                cmd.Parameters.Add("@temperatura", SqlDbType.Int).Value = temperatura;
                cmd.Parameters.Add("@Posibilidad_lluvia", SqlDbType.Int).Value = Posibilidad_lluvia;
                cmd.Parameters.Add("@Direccion_viento", SqlDbType.VarChar).Value = Direccion_viento;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                retRecord = cmd.ExecuteNonQuery();
                return retRecord;
            }

        }
    }
}


