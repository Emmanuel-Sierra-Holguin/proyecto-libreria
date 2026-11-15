using System;

namespace system_books.Models
{
    public class Libro
    {
        //PROPIEDADES
        public string Id {get; set;}
        public string Titulo {get; set;}
         public string Autor {get; set;}
        public string Categoria {get; set;}
         public string Anio {get; set;}
        public bool Disponible {get; set;}
        
        // CONSTRUCTOR VACIO
        public Libro()
        {
            Id = "";
            Titulo = "";
            Autor = "";
            Categoria = "";
            Anio = "";
            Disponible = true;
        }

        //CONSTRUCTOR COMPLETO
        public Libro(string id, string titulo, string autor, string categoria, string anio )
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            Anio = anio;
            Disponible = true;
        }

        //METODOS 
        public string ResumenCorto()
        {
            return $"[{Id}] {Titulo} - {Autor} ({Anio})";
        }
        public string DetalleCompleto()
        {
            string estadoTexto = Disponible ? "Si" : "No";
            return $@"
  ===========================
  DETALLE COMPLETO DEL LIBRO
  ===========================
  - ID: {Id}
  - Titulo: {Titulo}
  - Autor: {Autor}
  - Categoria: {Categoria}
  - Año: {Anio}
  - Disponible: {estadoTexto}
    ===========================
";
        }

        public override string ToString()
        {
            return ResumenCorto();
        }
    }
}