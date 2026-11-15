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
    }
}