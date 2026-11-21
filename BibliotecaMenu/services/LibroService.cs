using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class LibroServicio
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            if(libro != null)
            {
                libros.Add(libro);
            }
        }

    }
}