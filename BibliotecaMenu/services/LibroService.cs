using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class LibroServicio
    {
        // LISTA PRIVADA
        private List<Libro> libros = new List<Libro>();

        // AGREGAR LIBRO
        public void AgregarLibro(Libro libro)
        {
            if(libro != null)
            {
                libros.Add(libro);
            }
        } 
        // OBTENER TODOS LOS LIBROS
        public List<Libro> ObtenerTodos()
        {
            return libros;
        }
    }
}