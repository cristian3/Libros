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
        private String descripcion { get; set; }
        private String URL { get; set; }
        public Class1()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            URL = "";
        }
        public Class1(String nombre, String descripcion, String URL)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.URL = URL;
        }
    }
}