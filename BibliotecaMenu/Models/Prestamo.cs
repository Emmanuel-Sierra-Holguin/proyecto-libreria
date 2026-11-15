using System;

namespace BibliotecaMenu.Models
{
    public class Prestamo
    {
         // CONTADOR ESTÁTICO GLOBAL (Para generar IDs automáticos)
        private static int contadorPrestamo = 100;
         //PROPIEDADES
        public string Id {get; set;} = string.Empty;
        public string LibroId {get; set;} = string.Empty;
        public string UsuarioId {get; set;} = string.Empty;
        public string libroTitulo {get; set;} = string.Empty;
        public string usuarioNombre {get; set;} = string.Empty;
        public string fechaInicio {get; set;} = string.Empty;
        public string fechaLimite {get; set;} = string.Empty;
        public string fechaDevolucion {get; set;} = "Pendiente";
        public  EstadoPrestamo Estado {get; set;} = EstadoPrestamo.Activo;
        public bool prestamoActivo {get; set;} = true;

        


    }
}