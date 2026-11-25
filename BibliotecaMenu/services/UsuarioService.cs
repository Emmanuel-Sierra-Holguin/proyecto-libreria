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
         // OBTENER TODOS LOS USUARIOS
        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }
         // BUSQUEDAS POR CRITERIO
        public Usuario? BuscarPorId(string id)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Id.ToLower() == id.ToLower())
                {
                    return usuario;
                }
            }

            return null;
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            List<Usuario> resultados = new List<Usuario>();

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Nombre.ToLower().Contains(nombre.ToLower()))
                {
                    resultados.Add(usuario);
                }
            }

            return resultados;
        }
           // ACTUALIZAR USUARIO
        public bool ActualizarUsuario(string id, string nuevoNombre, string nuevoCorreo, string nuevoTelefono)
        {
            Usuario? usuarioEncontrado = BuscarPorId(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Nombre = nuevoNombre;
                usuarioEncontrado.Correo = nuevoCorreo;
                usuarioEncontrado.Telefono = nuevoTelefono;
                return true;
            }

            return false;
        }
          //ELIMINAR USUARIO POR ID
        public bool EliminarUsuario(string id)
        {
            Usuario? usuarioEncontrado = BuscarPorId(id);

            if(usuarioEncontrado != null)
            {
                usuarios.Remove(usuarioEncontrado);
                return true;
            }
            return false;
        }
        // ORDENAR POR NOMBRE
        public List<Usuario> OrdenarPorNombre()
        {
            // Hacemos una copia de la lista para no desordenar la original
            List<Usuario> listaOrdenada = new List<Usuario>(usuarios);
            listaOrdenada.Sort((a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase));
            return listaOrdenada;
        }
        // KPI (Contadores)
        public int TotalUsuarios()
        {
            return usuarios.Count;
        }

        public int UsuarioActivo()
        {
            int contador = 0;
            foreach (Usuario usuario in usuarios)
            {
                if(usuario.Activo == true)
                {
                    contador++;
                }
            }
            return contador;
        }

        public int UsuarioDesactivado()
        {
            int contador = 0;
            foreach (Usuario usuario in usuarios)
            {
                if(usuario.Activo == false)
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}