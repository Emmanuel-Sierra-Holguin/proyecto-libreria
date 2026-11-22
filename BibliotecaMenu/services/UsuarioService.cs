using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class UsuarioService
    {
        // LISTA PRIVADA
        private List<Usuario> usuarios = new List<Usuario>();
        
               // AGREGAR USUARIO
        public void AgregarUsuario(Usuario usuario)
        {
            if(usuario != null)
            {
                usuarios.Add(usuario);
            }
        } 
    }
}