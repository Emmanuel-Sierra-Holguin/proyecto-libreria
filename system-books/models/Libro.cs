using System;

namespace system_books.Models
{
    public class libro
    {
        //PROPIEDADES
        public string id {get; set;}
        public string Titulo {get; set;}
         public string Autor {get; set;}
        public string Categoria {get; set;}
         public string Anio {get; set;}
        public bool Disponible {get; set;}
    }
}