using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

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

        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["wsclimaConnectionString"].ConnectionString);
     
    

        [WebMethod]
        public int InsertDetail(string PersonName, string PersonCity)
        {
            int retRecord = 0;
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertDetail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_ciudad", SqlDbType.Int).Value = PersonName;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    retRecord = cmd.ExecuteNonQuery();
                }

            }
            return retRecord;
        }
        [WebMethod]
        public int UpdateDetail(int PersonID, string PersonName, string PersonCity)
        {
            int retRecord = 0;
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateDetail", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("PersonID", SqlDbType.VarChar, 100).Value = PersonID;
                    cmd.Parameters.Add("PersonName", SqlDbType.VarChar, 100).Value = PersonName;
                    cmd.Parameters.Add("PersonCity", SqlDbType.VarChar, 100).Value = PersonCity;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    retRecord = cmd.ExecuteNonQuery();
                }

            }
            return retRecord;
        }
        [WebMethod]
        public int DeleteRecord(int PersonID)
        {
            int Rowupdate = 0;
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteDetialByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("PersonID", SqlDbType.Int).Value = PersonID;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    Rowupdate = cmd.ExecuteNonQuery();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
            return Rowupdate;
        }
        [WebMethod]
        public DataSet GetDetialByID(int ID)
        {
            DataSet ds = new DataSet();
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_select", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("id_ciudad", SqlDbType.Int).Value = ID;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
            return ds;
        }
        [WebMethod]
        public DataSet GetlistcityByID()
        {
            DataSet ds = new DataSet();
            //using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Pronostico_clima_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("id_ciudad", SqlDbType.Int).Value = ID;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlDataAdapter adp = new SqlDataAdapter();
                    adp.SelectCommand = cmd;
                    adp.Fill(ds);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }
            return ds;
        }
    }
}
