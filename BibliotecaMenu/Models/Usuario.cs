using System;

namespace BibliotecaMenu.Models
{
    public class Usuario
    {
        // CONTADOR ESTÁTICO GLOBAL (Para generar IDs automáticos)
        private static int contadorIsbn = 100;

        //PROPIEDADES
        public string Id {get; set;}
        public string Nombre {get; set;}
        public string Correo {get; set;}
        public string Telefono {get; set;}
        public bool Activo { get; set; }

        //CONSTRUCTOR VACIO
        public Usuario()
        {
            Id = "";
            Nombre = "";
            Correo = "";
            Telefono = "";
            Activo = true;
        }
        //CONSTRUCTOR COMPLETO
        public Usuario(string nombre,string correo,string telefono)
        {
            contadorIsbn++;
            Id = "USU-" + contadorIsbn;

            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Activo = true;
        }
        // METODOS
          public string ResumenCorto()
        {
            return $"[{Id}] {Nombre} - {Correo} ({Telefono})";
        }
    }
}