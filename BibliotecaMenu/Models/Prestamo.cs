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

        //CONSTRUCTOR COMPLETO
        public Prestamo(Libro libro, Usuario usuario, int diasPlazo = 7)
        {
            contadorPrestamo++;
            Id = "PRE-" + contadorPrestamo;

            LibroId = libro.Id;
            UsuarioId = usuario.Id;
            LibroTitulo = libro.Titulo;
            UsuarioNombre = usuario.Nombre;

            FechaInicio = DateTime.Now;
            FechaLimite = FechaInicio.AddDays(diasPlazo);
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
            PrestamoActivo = true;

            libro.Disponible = false;
        }

        //METODOS
        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Activo && DateTime.Now > FechaLimite)
            {
                Estado = EstadoPrestamo.Activo;
                return true;
            }
            return Estado == EstadoPrestamo.Vencido;
        }

        public int DiasTranscurridos()
        {
            DateTime fechafin = FechaDevolucion ?? DateTime.Now;
            TimeSpan diferencia = fechafin - FechaInicio;
            return diferencia.Days;
        }

        public string Resumen()
        {
            EstaVencido();
            return $"[{Id}] Libro: {LibroTitulo} | Usuario: {UsuarioNombre} | Estado: {Estado}";
        }
    }
}