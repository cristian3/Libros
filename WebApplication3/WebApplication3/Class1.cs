using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Class1
    {
        private int id { get; set; }
        private String nombre { get; set; }
        private String categoria { get; set; }
        private String descripcion { get; set; }
        private String URL { get; set; }
        private String foto { get; set; }
        private String user_id { get; set; }
        public Class1()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            URL = "";
        }
        public Class1(String nombre,String categoria, String descripcion, String URL,String user_id)
        {
            this.nombre = nombre;
            this.categoria = categoria;
            this.descripcion = descripcion;
            if (user_id != null)
            {
                this.user_id = user_id;
            }
            if (URL != null)
            {
                this.URL = URL;
            }
        }
        
        public String String()
        {
            return nombre+","+categoria+","+descripcion+","+URL+","+user_id;
        }
    }
}