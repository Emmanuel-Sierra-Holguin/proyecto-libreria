using System;

namespace BibliotecaMenu.Models
{
    public class Libro
    {
        // CONTADOR ESTÁTICO GLOBAL (Para generar IDs automáticos)
        private static int contadorIsbn = 100;

        //PROPIEDADES
        public string Id {get; set;} = string.Empty;
        public string Titulo {get; set;} = string.Empty;
         public string Autor {get; set;} = string.Empty;
        public string Categoria {get; set;} = string.Empty;
         public string Anio {get; set;} = string.Empty;
        public bool Disponible {get; set;} = true;
        
        // CONSTRUCTOR VACIO
        public Libro()
        {
        }

        //CONSTRUCTOR COMPLETO
        public Libro( string titulo, string autor, string categoria, string anio )
        {
            contadorIsbn++;
            Id = "LIB-" + contadorIsbn;

            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
            Anio = anio;
            Disponible = true;
        }

        //METODOS 
        public string ResumenCorto()
        {
            string estadoTexto = Disponible ? "Si" : "No";
            return $"[{Id}] {Titulo} - {Autor} ({estadoTexto})";
        }
        public string DetalleCompleto()
        {
            string estadoTexto = Disponible ? "Si" : "No";
            return $@"
  ===========================
  DETALLE COMPLETO DE LIBRO
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