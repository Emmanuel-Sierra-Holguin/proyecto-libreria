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
        // BUSQUEDAS POR CRITERIO
        public Libro BuscarPorId(string id)
        {
            foreach(Libro libro in libros)
            {
                if(libro.Id.ToLower() == id.ToLower())
                {
                    return libro;
                }
            }
            return null;
        }
        public List<Libro> BuscarPorTitulo(string titulo)
        {
            List<Libro> resultados = new List<Libro>();

            foreach (Libro libro in libros)
            {
                if (libro.Titulo.ToLower().Contains(titulo.ToLower()))
                {
                    resultados.Add(libro);
                }
            }

            return resultados;
        }

         public List<Libro> BuscarPorAutor(string autor)
        {
            List<Libro> resultados = new List<Libro>();

            foreach (Libro libro in libros)
            {
                if (libro.Autor.ToLower().Contains(autor.ToLower()))
                {
                    resultados.Add(libro);
                }
            }

            return resultados;
        }

        
    }
}