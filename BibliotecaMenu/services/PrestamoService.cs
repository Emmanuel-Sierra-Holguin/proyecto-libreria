using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class PrestamoService
    {
        //LISTA PRIVADA
        private List<Prestamo> prestamos = new List<Prestamo>();

        // 1. CREAR / REGISTRAR PRESTAMO
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
    }
}