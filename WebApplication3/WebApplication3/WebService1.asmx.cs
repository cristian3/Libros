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
            public int NuevoLibro(string nombre, String categoria, String descripcion)
            {
               SqlConnection con =
                    new SqlConnection(@"Data Source=1fbb1ef7-3ab6-440e-b714-a3ee0010dc18.sqlserver.sequelizer.com;Initial Catalog=db1fbb1ef73ab6440eb714a3ee0010dc18;User ID=pdbzjhhhipccekmj;Password=EY7V2wNGCFLfWgpZhypvWHZAsQuf4FJ8GFoHjUmnBDyXMkDnvm6ShhH67DBkbGM6;Integrated Security=False");

                con.Open();

                string sql = "INSERT INTO LIBRO (Nombre,Categoria,Descripcion) VALUES (@nombre, @categoria,@descripcion)";

                SqlCommand cmd = new SqlCommand(sql, con);
              
                cmd.Parameters.Add("@nombre", System.Data.SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("@categoria", System.Data.SqlDbType.NVarChar).Value = categoria;
                cmd.Parameters.Add("@descripcion", System.Data.SqlDbType.NVarChar).Value = descripcion;
              
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

                string sql = "SELECT Nombre, Categoria, Descripcion FROM LIBRO";

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader reader = cmd.ExecuteReader();

                List<String> lista = new List<String>();

                while (reader.Read())
                {
                    lista.Add(
                        new Class1(reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2)).String());
                }

                con.Close();

                return lista.ToArray();
            }
    }
}
