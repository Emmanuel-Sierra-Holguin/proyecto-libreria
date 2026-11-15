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
        public string LibroTitulo {get; set;} = string.Empty;
        public string UsuarioNombre {get; set;} = string.Empty;
        //FECHAS
        public DateTime FechaInicio {get; set;}  
        public DateTime FechaLimite {get; set;}  
        public DateTime? FechaDevolucion {get; set;} = null;
        // ESTADO Y CONTROL
        public  EstadoPrestamo Estado {get; set;} = EstadoPrestamo.Activo;
        public bool PrestamoActivo {get; set;} = true;

        //CONSTRUCTOR VACIO
        public Prestamo()
        {
        }


    }
}