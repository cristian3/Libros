using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace WebApplication3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://sgoliver.net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        /// <summary>
        /// Descripción breve de WebService1
        /// </summary>
   
        // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
        // [System.Web.Script.Services.ScriptService]
        
            [WebMethod]
            public int NuevoLibro(string nombre, String categoria, String descripcion,String URL,String user_id,String foto)
            {
               SqlConnection con =
                    new SqlConnection(@"Data Source=1fbb1ef7-3ab6-440e-b714-a3ee0010dc18.sqlserver.sequelizer.com;Initial Catalog=db1fbb1ef73ab6440eb714a3ee0010dc18;User ID=pdbzjhhhipccekmj;Password=EY7V2wNGCFLfWgpZhypvWHZAsQuf4FJ8GFoHjUmnBDyXMkDnvm6ShhH67DBkbGM6;Integrated Security=False");

                con.Open();

                string sql = "INSERT INTO LIB (Nombre,Categoria,Descripcion,URL,user_id,foto) VALUES (@nombre, @categoria,@descripcion,@URL,@user_id,@foto)";

                SqlCommand cmd = new SqlCommand(sql, con);
              
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@categoria", System.Data.SqlDbType.NVarChar).Value = categoria;
                cmd.Parameters.Add("@descripcion", System.Data.SqlDbType.NVarChar).Value = descripcion;
                cmd.Parameters.Add("@URL", System.Data.SqlDbType.NVarChar).Value = URL;
                cmd.Parameters.Add("@user_id",System.Data.SqlDbType.NVarChar).Value=user_id;
                cmd.Parameters.Add("@foto", System.Data.SqlDbType.NVarChar).Value = foto;
                int res = cmd.ExecuteNonQuery();

                con.Close();

                return res;
            
        }
            [WebMethod]
            public String[] ListadoClientes()
            {
                SqlConnection con =
                    new SqlConnection(@"Data Source=1fbb1ef7-3ab6-440e-b714-a3ee0010dc18.sqlserver.sequelizer.com;Initial Catalog=db1fbb1ef73ab6440eb714a3ee0010dc18;User ID=pdbzjhhhipccekmj;Password=EY7V2wNGCFLfWgpZhypvWHZAsQuf4FJ8GFoHjUmnBDyXMkDnvm6ShhH67DBkbGM6;Integrated Security=False");

                con.Open();
                string sql = "SELECT Nombre, Categoria, Descripcion,URL,user_id,foto FROM LIB";

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader reader = cmd.ExecuteReader();

                List<String> lista = new List<String>();

                while (reader.Read())
                {
                    
                        lista.Add(
                       new Class1(reader.GetString(0),
                                   reader.GetString(1),
                                   reader.GetString(2), reader.GetString(3), reader.GetString(4), "").String());
                
                }

                con.Close();

                return lista.ToArray();
            }
    }
}
