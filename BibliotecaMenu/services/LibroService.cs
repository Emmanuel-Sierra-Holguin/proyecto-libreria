using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class LibroService
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

        //ELIMINAR LIBRO POR ID
        public bool EliminarLibro(string id)
        {
            Libro libroEncontrado = BuscarPorId(id);

            if(libroEncontrado != null)
            {
                libros.Remove(libroEncontrado);
                return true;
            }
            return false;
        }
        
        // ORDENAR POR AÑO 
        public List<Libro> OrdenarPorAnio()
        {
            // Hacemos una copia de la lista para no desordenar la original
            List<Libro> listaOrdenada = new List<Libro>(libros);
            listaOrdenada.Sort((a, b) => a.Anio.CompareTo(b.Anio));
            return listaOrdenada;
        }

        // KPI (Contadores)
        public int TotalLibros()
        {
            return libros.Count;
        }

        public int LibrosDisponibles()
        {
            int contador = 0;
            foreach (Libro libro in libros)
            {
                if(libro.Disponible == true)
                {
                    contador++;
                }
            }
            return contador;
        }

        public int LibrosPrestados()
        {
            int contador = 0;
            foreach (Libro libro in libros)
            {
                if(libro.Disponible == false)
                {
                    contador++;
                }
            }
            return contador;
        }

    }
}