using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class PrestamoService
    {
        //LISTA PRIVADA
        private List<Prestamo> prestamos = new List<Prestamo>();

        //  CREAR / REGISTRAR PRESTAMO
        public bool CrearPrestamo(Libro libro, Usuario usuario, int diasPlazo = 7)
        {
            if (libro == null || usuario == null)
            {
                return false;
            }

            if (usuario.Activo == false || libro.Disponible == false)
            {
                return false;
            }

            Prestamo nuevoPrestamo = new Prestamo(libro, usuario, diasPlazo);
            prestamos.Add(nuevoPrestamo);
            return true;
        }
        //  OBTENER TODOS LOS PRESTAMOS
        public List<Prestamo> ObtenerTodos()
        {
            foreach (Prestamo prestamo in prestamos)
            {
                prestamo.EstaVencido();
            }

            return prestamos;
        }
        // BUSQUEDAS POR CRITERIOS
        public List<Prestamo> ObtenerActivos()
        {
            List<Prestamo> activos = new List<Prestamo>();

            foreach (Prestamo prestamo in prestamos)
            {
                prestamo.EstaVencido();

                if (prestamo.PrestamoActivo == true && prestamo.Estado == EstadoPrestamo.Activo)
                {
                    activos.Add(prestamo);
                }
            }

            return activos;
        }

        public List<Prestamo> ObtenerDevueltos()
        {
            List<Prestamo> devueltos = new List<Prestamo>();

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.Devuelto)
                {
                    devueltos.Add(prestamo);
                }
            }

            return devueltos;
        }

        
        public List<Prestamo> ObtenerVencidos()
        {
            List<Prestamo> vencidos = new List<Prestamo>();

            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.EstaVencido())
                {
                    vencidos.Add(prestamo);
                }
            }

            return vencidos;
        }

        
        public Prestamo BuscarPorId(string id)
        {
            foreach (Prestamo prestamo in prestamos)
            {
                if (prestamo.Id.ToLower() == id.ToLower())
                {
                    prestamo.EstaVencido();
                    return prestamo;
                }
            }

            return null;
        }
        // ORDENAR PRESTAMOS POR FECHA LIMITE
        public List<Prestamo> OrdenarPorFechaLimite()
        {
            // Hacemos una copia de la lista para no desordenar la original
            List<Prestamo> listaOrdenada = new List<Prestamo>(prestamos);
            listaOrdenada.Sort((a, b) => a.FechaLimite.CompareTo(b.FechaLimite));
            return listaOrdenada;
        }
        // REGISTRAR DEVOLUCION
        public bool RegistrarDevolucion(string idPrestamo, LibroService libroService)
        {
            Prestamo encontrado = BuscarPorId(idPrestamo);

            if (encontrado == null)
            {
                return false;
            }

            if (encontrado.Estado == EstadoPrestamo.Devuelto || encontrado.PrestamoActivo == false)
            {
                return false;
            }

            encontrado.FechaDevolucion = DateTime.Now;
            encontrado.Estado = EstadoPrestamo.Devuelto;
            encontrado.PrestamoActivo = false;

            if (libroService != null)
            {
                Libro libro = libroService.BuscarPorId(encontrado.LibroId);
                if (libro != null)
                {
                    libro.Disponible = true;
                }
            }

            return true;
        }
        
    }
}