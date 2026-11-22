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

            if (libro != null)
            {
                LibroId = libro.Id;
                LibroTitulo = libro.Titulo;
                libro.Disponible = false;
            }

            if (usuario != null)
            {
                UsuarioId = usuario.Id;
                UsuarioNombre = usuario.Nombre;
            }

            FechaInicio = DateTime.Now;
            FechaLimite = FechaInicio.AddDays(diasPlazo);
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
            PrestamoActivo = true;
        }

        //METODOS
        public bool EstaVencido()
        {
            if (Estado == EstadoPrestamo.Activo && DateTime.Now > FechaLimite)
            {
                Estado = EstadoPrestamo.Vencido;
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

        public string ResumenCorto()
        {
            EstaVencido();
            return $"[{Id}] Libro: {LibroTitulo} | Usuario: {UsuarioNombre} | Estado: {Estado}";
        }

          public string DetalleCompleto()
        {
            EstaVencido();
            string textoDevolucion = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToString("dd/MM/yyyy") : "pendiente";
            return $@"
  ===========================
  DETALLE COMPLETO DE PRESTAMO
  ===========================
  - ID: {Id}
  - LibroId: {LibroId} | Titulo: {LibroTitulo}
  - UsuarioId: {UsuarioId} | Nombre: {UsuarioNombre}
  - Fecha Inicio: {FechaInicio:dd/MM/yyyy}
  - Fecha Limite: {FechaLimite:dd/MM/yyyy}
  - Fecha Devolucion: {textoDevolucion}
  - Dias Transcurridos: {DiasTranscurridos()}
  - Estado Prestamo: {Estado}
    ===========================
";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}