using System;

namespace BibliotecaMenu.Models
{
    public class Usuario
    {
        // CONTADOR ESTÁTICO GLOBAL (Para generar IDs automáticos)
        private static int contadorUsuario = 100;

        //PROPIEDADES
        public string Id {get; set;} = string.Empty;
        public string Nombre {get; set;} = string.Empty;
        public string Correo {get; set;} = string.Empty;
        public string Telefono {get; set;} = string.Empty;
        public bool Activo { get; set; } = true;

        //CONSTRUCTOR VACIO
        public Usuario()
        {
        }

        //CONSTRUCTOR COMPLETO
        public Usuario(string nombre,string correo,string telefono)
        {
            contadorUsuario++;
            Id = "USU-" + contadorUsuario;

            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Activo = true;
        }
        // METODOS
          public string ResumenCorto()
        {
            string estadoTexto = Activo ? "Activo" : "Inactivo"; 
            return $"[{Id}] {Nombre} - {Correo} ({estadoTexto})";
        }
         public string DetalleCompleto()
        {
            string estadoTexto = Activo ? "Si" : "No";
            return $@"
  ===========================
  DETALLE COMPLETO DE USUARIO
  ===========================
  - ID: {Id}
  - Nombre: {Nombre}
  - Correo: {Correo}
  - Telefono: {Telefono}
  - Activado: {estadoTexto}
    ===========================
";
        }
         public override string ToString()
        {
            return ResumenCorto();
        }
    }
}