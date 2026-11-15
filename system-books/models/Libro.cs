using System;

namespace system_books.Models
{
    public class libro
    {
        //PROPIEDADES
        public string Id {get; set;}
        public string Titulo {get; set;}
         public string Autor {get; set;}
        public string Categoria {get; set;}
         public string Anio {get; set;}
        public bool Disponible {get; set;}
        
        // CONSTRUCTOR VACIO
        public libro()
        {
            Id = "";
            Titulo = "";
            Autor = "";
            Categoria = "";
            Anio = "";
            Disponible = true;
        }

        //CONSTRUCTOR COMPLETO
        public libro(string id, string titulo, string autor, string categoria, string anio )
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
        
    }
}