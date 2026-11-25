using System;
using System.Linq.Expressions;
using BibliotecaMenu.Models;
using BibliotecaMenu.Services;


namespace Bibliotecamenu
{
    class Program
    {
        // variables globales de libros
        static String libroID = "";
        static String libroTitulo = "";
        static String libroAutor = "";
        static String libroCategoria = "";
        static String libroAño = "";
        static bool libroDisponible = false;
        // variables globales del modulo usuarios
        static String usuarioID = "";
        static String usuarioNombre = "";
        static String usuarioContacto = "";
        static bool usuarioActivo;
        // variables globales prestamo
        static string prestamoID = "";
        static bool prestamoActivo = false;
        static String fechaInicio = "";
        static String fechaLimite = "";
        static String fechaDevolucion = "N/A";
        static String estadoprestamo = "inactivo";
        //variables globales guardar datos
  static string archivoLibros = "libros.txt";
   static string archivoUsuarios = "usuarios.txt";
  static string archivoPrestamos = "prestamos.txt";

        //variables global general
        static bool datosGuardados = false;

        // INSTANCIAS DE SERVICIOS (administran las listas de cada módulo)
        static LibroService libroService = new LibroService();
        static UsuarioService usuarioService = new UsuarioService();
        static PrestamoService prestamoService = new PrestamoService();
        static void Main(string[] args){
        ShowMainMenu();
        }
        // Funcion de menu principal 

    static void ShowMainMenu()
        {
            bool Exit = false;
            while (!Exit){
                Console.Clear();
                Console.WriteLine(@" 
=== MENÚ PRINCIPAL BIBLIOTECA ===
OPCIONES:
1. Libros
2. Usuarios
3. Préstamos
4. Búsquedas y reportes
5. Guardar / Cargar datos
6. Salir
=====================  ");
                Console.Write("Seleccionar una opcion: ");
                String bibliotecario = Console.ReadLine() ?? "";

                    switch (bibliotecario)
                    {
                         case "1":
                         ShowBooksMenu();
                        break;
                         case "2":
                         ShowUsersMenu();
                        break;
                         case "3":
                         ShowloansMenu();
                        break;
                         case "4":
                         ShowSearchReportsMenu();
                        break;
                         case "5":
                         showSavedatamenu();
                        break;
                         case "6":
                          ConfirmExitAndSave();
                          Exit = true;
                        break;
                        default:
                        Console.Clear();
                        Console.WriteLine("ERROR!: Opcion no valida");
                        ShowReturnMenu();
                        break;
                    }
                }
            }
        

        // MODULO LIBROS MENU
static void ShowBooksMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== MENÚ LIBROS ===
OPCIONES:
1. Registrar libro
2. Listar libros
3. Ver detalle de libro
4. Actualizar libro
5. Eliminar libro
6. volver al menu
=====================
                ");

                Console.Write("seleccionar una opcion: ");
                String bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case "1":
                    RegisterBook();
                    break;
                    case "2":
                    ListBookMenu();
                    break;
                    case "3":
                    ViewBookDetail();
                    break;
                    case "4":
                    UpdateBookMenu();
                    break;
                    case "5":
                    DeleteBook();
                    break;
                    case "6":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }               
            }
        }

        // Modulo registro Libro       
        static void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO LIBRO ===");

            // Variables temporales
             Console.Write("Titulo: ");
            string Titulo = (Console.ReadLine() ?? "").Trim();
             Console.Write("Autor: ");
            string Autor = (Console.ReadLine() ?? "").Trim();
             Console.Write("Categoria: ");
            string Categoria = (Console.ReadLine() ?? "").Trim();
             Console.Write("Año: ");
            string Anio = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrWhiteSpace(Titulo) || string.IsNullOrWhiteSpace(Autor) || string.IsNullOrWhiteSpace(Categoria)) 
            {
                Console.WriteLine("\nERROR!: campo vacio, porfavor diligenciar lo solicitado.");
                ShowReturnMenu();
                return;
            }


            // int.TryParse intenta convertir texto a int sin lanzar excepción si escriben letras
            if(!int.TryParse(Anio, out int anio))
            {
                Console.WriteLine("\nERROR!: El año debe ser un numero entero valido.");
                ShowReturnMenu();
                return;
            }

            // Instanciamos el modelo Libro (genera Id automáticamente y Disponible = true)
            Libro nuevoLibro = new  Libro(Titulo,Autor,Categoria,anio);
             
             // Lo guardamos en la lista privada dentro de LibroService
            libroService.AgregarLibro(nuevoLibro);

            Console.WriteLine("\n¡libro registrado exitosamente!");
            Console.WriteLine(nuevoLibro.ToString());
            ShowReturnMenu(); 
        }

        // Modulo lista Libro Menu
        static void ListBookMenu()
        {
             bool volverMenu = false;
            while (!volverMenu)
            {
            Console.Clear();
            Console.WriteLine(@"
=== MENU LISTA ===
1 Listar todos
2 Listar disponibles
3 Listar prestados
4 volver menu
=====================");

            Console.Write("selecciona la opcion: ");
            string bibliotecario = Console.ReadLine() ?? "";
            switch (bibliotecario)
            {
                case "1":
                ListBooksAll();
                break;
                case "2":
                ListBooksAvailable();
                break;
                case "3":
                ListBooksBorrowed();
                break;
                case "4":
                volverMenu = true;
                break;
                default:
                Console.Clear();
                Console.WriteLine("ERROR!: Opcion no valida");
                ShowReturnMenu();
                break;
            }

            }
        }

        //SUBMODULO LISTA TODOS LOS LIBROS
        static void ListBooksAll()
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR TODOS LOS LIBROS ===");

            //llamamos a la lista de libros.service
            List<Libro> listaLibros = libroService.ObtenerTodos();

            // verificamos que tengamos libros registrados.
            if(listaLibros.Count == 0)
            {
                Console.WriteLine("\nERROR!: No hay libros registrados por el momento.");
            }
            else
            {
                // si tenemos libros registrados, pasamos a leer los libros en la lista y mostrar su detallecompleto
                foreach(Libro libro in listaLibros)
                {
                    Console.WriteLine(libro.DetalleCompleto());
                }
            }
            ShowReturnMenu();
        }

        // Submodulo Listar Libros Disponibles
      static void ListBooksAvailable()
        {
    Console.Clear();
    Console.WriteLine("=== lista todos los libros Disponibles ===");

    // Llamamos a la lista de LibroService
    List<Libro> listaLibros = libroService.ObtenerTodos();

    //  Primero verificamos si hay libros registrados en general
    if (listaLibros.Count == 0)
    {
        Console.WriteLine("\n[AVISO]: No hay libros registrados por el momento.");
        ShowReturnMenu();
        return;
    }

    int encontrados = 0;

    //  Recorremos la lista y mostramos solo los disponibles
    foreach (Libro libro in listaLibros)
    {
        if (libro.Disponible)
        {
            Console.WriteLine(libro.ResumenCorto());
            encontrados++;
        }
    }

    //  Si había libros registrados pero ninguno estaba disponible
    if (encontrados == 0)
    {
        Console.WriteLine("\n[AVISO]: Hay libros registrados, pero ninguno esta disponible en este momento.");
    }

    ShowReturnMenu();
         }
         // Submodulo Listar Libros Prestados
        static void ListBooksBorrowed()
        {

            Console.Clear();
            Console.WriteLine("=== LISTA LIBROS PRESTADOS ===");
         
          // Llamamos a la lista de LibroService
          List<Libro> listaLibros = libroService.ObtenerTodos();
          
        //  Primero verificamos si hay libros registrados en general
          if(listaLibros.Count == 0)
            {
                Console.WriteLine("\n[AVISO]: No hay libros registrados por el momento.");
                ShowReturnMenu();
                return;
            }

            int encontrados = 0;

             //  Recorremos la lista y mostramos solo los prestamos
            foreach(Libro libro in listaLibros)
            {
                if (!libro.Disponible)
                {
                    Console.WriteLine(libro.ResumenCorto());
                    encontrados++;
                }
            }

    //  Si había libros registrados pero ninguno tiene un prestamo

            if(encontrados == 0)
            {
                Console.WriteLine("\n[AVISO]: Hay libros registrados, pero ninguno tiene un prestamo en este momento.");                
            }


          
            ShowReturnMenu();
        }

// modulo detalle Libro
        static void ViewBookDetail()
        {
            Console.Clear();
            Console.WriteLine("=== DETALLE COMPLETO DE LIBRO ===");
            Console.Write("Buscar por ID (ej. LIB-101): ");
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // llamamos el modulo buscarporid
            Libro libro = libroService.BuscarPorId(BuscarId);

            //verificamos que tengamos libros registrados
            if(libro != null)
            {
               Console.WriteLine(libro.DetalleCompleto());
            }
            // encaso de no tener libros registrados o no encontrados.
            else
            {
                Console.WriteLine("\n[!AVISO] Libro no encontrado o registrado con esa id. ");
            }

            
            ShowReturnMenu();
        }

        // modulo actualizar
        static void UpdateBookMenu()
        {
            bool volverMenu = false;
            while(!volverMenu){
            Console.Clear();
            Console.WriteLine(@"
=== ACTUALIZAR ===
OPCIONES:
1 editar titulo
2 editar autor
3 editar año / categoria
4 volver menu
===================");
            Console.Write("seleccionar una opcion: ");
            string bibliotecario = Console.ReadLine() ?? "";
            switch (bibliotecario)
            {
                case "1":
                EditBookTitle();
                break;
                case "2":
                EditBookAuthor();
                break;
                case"3":
                EditBookYearCategory();
                break;
                case"4":
                volverMenu = true;
                break;
                default:
                Console.Clear();
                Console.WriteLine("ERROR!: Opcion no valida");
                ShowReturnMenu();
                break;
            }
        }
    }

// submodulos actualizacion libro
        // Actualizar titulo libro
        static void EditBookTitle()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR TITULO ==");
            Console.Write("Buscar por ID: ");
            // Limpia espacios sobrantes del ID ingresado
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el libro por ID en el servicio
            Libro libro = libroService.BuscarPorId(BuscarId);
            // Detiene el proceso si no se encuentra un libro con ese ID
            if (libro == null)
            {
                Console.WriteLine("\nlibro no encontrado.");
                ShowReturnMenu();
                return;
            }
            
            // procedemos a solicitar el nuevo titulo del libro
            Console.Write($"Titulo actual ({libro.Titulo}) - Nuevo titulo: ");
            string nuevoTitulo = (Console.ReadLine() ?? "").Trim();
            if (string.IsNullOrWhiteSpace(nuevoTitulo))
            {
                Console.WriteLine("\nERROR!: El titulo no puede quedar vacio.");
                ShowReturnMenu();
                return;
            }

            // el nuevo titulo se carga exitosamente, pero debemos establecer que propiedades contenia para mantener consistencia
            bool actualizado = libroService.ActualizarLibro(libro.Id, nuevoTitulo,libro.Autor, libro.Categoria, libro.Anio);
            // Muestra un mensaje segun si la actualizacion fue exitosa o no
            Console.WriteLine(actualizado ? "\n¡Libro editado con exito!" : "\nNo se pudo actualizar el libro.");
            ShowReturnMenu();
        }
        static void EditBookAuthor()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR AUTOR ==");
            Console.Write("buscar por ID: ");
            // Limpia espacios sobrantes del ID ingresado
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el libro por ID en el servicio
            Libro libro = libroService.BuscarPorId(BuscarId);
            // Detiene el proceso si no se encuentra un libro con ese ID
            if (libro == null)
            {
                Console.WriteLine("\nlibro no encontrado.");
                ShowReturnMenu();
                return;
            }
                // procedemos a solicitar el nuevo autor del libro
            Console.Write($"Autor actual ({libro.Autor}) - Nuevo Autor: ");
            string nuevoAutor = (Console.ReadLine() ?? "").Trim();
             if (string.IsNullOrWhiteSpace(nuevoAutor))
            {
                Console.WriteLine("\nERROR!: El Autor no puede quedar vacio.");
                ShowReturnMenu();
                return;
            }

            // el nuevo autor se carga exitosamente, pero debemos establecer que propiedades contenia para mantener consistencia
            bool actualizado = libroService.ActualizarLibro(libro.Id, libro.Titulo,nuevoAutor, libro.Categoria, libro.Anio);
            // verificamos mediante un operador ternario que la actualizacion fue un exito dependiendo el valor booleano.
            Console.WriteLine(actualizado ? "\n¡Libro editado con exito!" : "\nNo se pudo actualizar el libro.");
            ShowReturnMenu();
        }
        static void EditBookYearCategory()
        {
            Console.Clear();
            Console.WriteLine("== editar año / categoria ==");
            Console.Write("buscar por ID: ");
            // Limpia espacios sobrantes del ID ingresado
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el libro por ID en el servicio
            Libro libro = libroService.BuscarPorId(BuscarId);
            // Detiene el proceso si no se encuentra un libro con ese ID
            if (libro == null)
            {
                Console.WriteLine("\nlibro no encontrado.");
                ShowReturnMenu();
                return;
            }
            
            Console.WriteLine("Editar Año(1) o Categoria(2): ");
            Console.Write("cual editar: ");
            string opcion = (Console.ReadLine() ?? "").Trim();

            if(opcion == "1")
            {
                // procedemos a solicitar el nuevo año del libro
            Console.WriteLine($"Año actual ({libro.Anio}) - Nuevo Año: ");
            Console.Write("Editar Año: ");
            string textoAnio = (Console.ReadLine() ?? "").Trim();
            // convertimos string en int
            if(!int.TryParse(textoAnio, out int nuevoAnio))
                {
                    // en caso de quedar vacio el campo
                    Console.WriteLine("\nERROR!: Año invalido");
                    ShowReturnMenu();
                    return;
                }
            // Actualiza el libro conservando titulo, autor y categoria actuales
            bool actualizado = libroService.ActualizarLibro(libro.Id, libro.Titulo,libro.Autor, libro.Categoria, nuevoAnio);
            // verificamos mediante un operador ternario que la actualizacion fue un exito dependiendo el valor booleano.
            Console.WriteLine(actualizado ? "\n¡Libro editado con exito!" : "\nNo se pudo actualizar el libro.");
            }
            else if (opcion == "2")
            {
            // Solicita la nueva categoria conservando los demas datos del libro
            Console.WriteLine($"categoria actual ({libro.Categoria}) - Nueva Categoria: ");
            Console.Write("Editar Categoria: ");
            string nuevaCategoria = (Console.ReadLine() ?? "").Trim();
             if (string.IsNullOrWhiteSpace(nuevaCategoria))
            {
                // Corrige la concordancia de genero en el mensaje de categoria vacia
                Console.WriteLine("\nERROR!: La categoria no puede quedar vacia.");
                ShowReturnMenu();
                return;
            } 
            // Actualiza el libro conservando titulo, autor y año actuales
            bool actualizado = libroService.ActualizarLibro(libro.Id, libro.Titulo,libro.Autor, nuevaCategoria, libro.Anio);
            // verificamos mediante un operador ternario que la actualizacion fue un exito dependiendo el valor booleano.
            Console.WriteLine(actualizado ? "\n¡Libro editado con exito!" : "\nNo se pudo actualizar el libro.");
            }
            else
            {
                Console.WriteLine("\nERROR!: Opcion no valida.");
            }

            ShowReturnMenu();
        }
        // modulo eliminar libro
        static void DeleteBook()
        {
          Console.Clear();
          Console.WriteLine("=== ELIMINAR LIBRO ===");
          Console.Write("ingresar id: ");
          // Limpia espacios sobrantes del ID ingresado
          string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el libro por ID en el servicio
            Libro libro = libroService.BuscarPorId(BuscarId);
            // Detiene el proceso si no se encuentra un libro con ese ID
            if (libro == null)
            {
                Console.WriteLine("\nlibro no encontrado.");
                ShowReturnMenu();
                return;
            }
            if (!libro.Disponible)
            {
                Console.WriteLine("\n!ADVERTENCIA: No se puede eliminar un libro que esta prestado.");
                ShowReturnMenu();
                return;
            }

            // Muestra el libro encontrado y confirmacion de eliminacion.
            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine(libro.ResumenCorto());
            Console.Write("¿Seguro que deseas eliminarlo? (si/no): ");
            // Normaliza la confirmacion para aceptar mayusculas o espacios accidentales
            string confirmar = (Console.ReadLine() ?? "").Trim().ToLower();
            if (confirmar != "si")
            {
                Console.WriteLine("\nEliminacion cancelada.");
                ShowReturnMenu();
                return;
            }

            bool eliminado = libroService.EliminarLibro(BuscarId);
            Console.WriteLine(eliminado ? "\n¡Libro eliminado exitosamente!" : "\nNo se pudo eliminar el libro.");
            ShowReturnMenu();
        }
            // MODULO USUARIOS
            
            static void ShowUsersMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== MENU USUARIOS ===                
1.Registrar
2.Listar usuarios
3.Ver detaller usuario
4.Actualizar usuario
5.Eliminar usuario
6.regresar al menu
======================
");
                Console.Write("elegir Opcion:");   
                string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case"1":
                    RegisterUser();
                    break;
                    case"2":
                    ListUsers();
                    break;
                    case"3":
                    ViewUserDetail();
                    break;
                    case"4":
                    UpdateUserMenu();
                    break;
                    case"5":
                    DeleteUser();
                    break;
                    case "6":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }              
            }
        }

        // Modulo Registrar usuario
        static void RegisterUser()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR USUARIO ===");
            // Limpia espacios al inicio y al final en los campos ingresados
            Console.Write("Nombre: ");
            string nombre = (Console.ReadLine() ?? "").Trim();
            Console.Write("Correo: ");
            string correo = (Console.ReadLine() ?? "").Trim();
            Console.Write("Telefono: ");
            string telefono = (Console.ReadLine() ?? "").Trim();

            // Evita registrar si falta algun dato obligatorio
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(telefono))
            {
                Console.WriteLine("\nERROR!: campo vacio, porfavor diligenciar lo solicitado.");
                ShowReturnMenu();
                return;
            }

            // Crea la instancia del modelo con ID automatico y estado activo por defecto
            Usuario nuevoUsuario = new Usuario(nombre, correo, telefono);

            // Pregunta si desea dejar el usuario activo o inactivo al momento de crearlo
            Console.Write("¿activar usuario? (Si/No): ");
            string activo = (Console.ReadLine() ?? "").Trim().ToLower();
            nuevoUsuario.Activo = activo == "si";

            // Guarda el objeto en la lista privada administrada por el servicio
            usuarioService.AgregarUsuario(nuevoUsuario);

            Console.WriteLine("\nusuario registrado");
            Console.WriteLine(nuevoUsuario.ToString());
            ShowReturnMenu(); 
        }

        // Modulo listar usuarios
        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA USUARIO ===");
            // Obtiene la lista de usuarios almacenados en el servicio
            List<Usuario> listaUsuarios = usuarioService.ObtenerTodos();

            // Verifica si existen usuarios antes de intentar recorrerlos
            if (listaUsuarios.Count > 0)
            {
                // Recorre cada usuario guardado y muestra su informacion resumida
                foreach (Usuario usuario in listaUsuarios)
                {
                    Console.WriteLine(usuario.ResumenCorto());
                }
            }
            else
            {
                Console.WriteLine("no hay usuarios registrados");
            }
            ShowReturnMenu();
        }
        // Modulo detalle usuario
        static void ViewUserDetail()
        {
            Console.Clear();
            Console.WriteLine("== DETALLE USUARIO ==");
            Console.Write("ingresa el ID: ");
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el usuario correspondiente al ID en el servicio
            Usuario usuario = usuarioService.BuscarPorId(BuscarId);

            // Muestra la informacion completa si se encontro el usuario
            if (usuario != null)
            {
                Console.WriteLine(usuario.DetalleCompleto());
            }
            else
            {
                Console.WriteLine("usuario no encontrado");
            }
            ShowReturnMenu();
        }
        // Modulo actualizar usuario
        static void UpdateUserMenu()
        {
            bool volverMenu = false;
            while(!volverMenu){
                Console.Clear();
                Console.WriteLine(@"
=== ACTUALIZAR USUARIO ===
1. Editar Nombre
2. Editar Contacto
3. Activar/Desactivar
4. volver al menu
============================
");
                Console.Write("escribir opcion:");
                string bibliotecario = Console.ReadLine() ?? "";

                switch (bibliotecario)
                {
                    case"1":
                    EditUserName();
                    break;
                    case"2":
                    EditUserContact();
                    break;
                    case"3":
                    ToggleUserActiveStatus();
                    break;
                    case"4":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }
            }
        }
        // submodulos actualizacion usuario
        // submodulo editar nombre usuario
        static void EditUserName()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR NOMBRE ==");
            Console.Write("buscar usuario ID:");
            string BuscarId= (Console.ReadLine() ?? "").Trim();
           
           // Busca el usuario por ID en el servicio
            Usuario usuario = usuarioService.BuscarPorId(BuscarId);

            if (usuario != null)
            {
                Console.Write($"Nombre actual ({usuario.Nombre}) - Nuevo nombre: ");
                // Limpia espacios sobrantes del nuevo nombre
                string nuevoNombre = (Console.ReadLine() ?? "").Trim();

                // Evita guardar un nombre vacio o solo con espacios
                if (string.IsNullOrWhiteSpace(nuevoNombre))
                {
                    Console.WriteLine("\nERROR!: El nombre no puede quedar vacio.");
                    ShowReturnMenu();
                    return;
                }

                // Actualiza el nombre manteniendo correo y telefono actuales del usuario
                bool actualizado = usuarioService.ActualizarUsuario(usuario.Id, nuevoNombre, usuario.Correo, usuario.Telefono);
                Console.WriteLine(actualizado ? "Nombre actualizado con exito" : "No se pudo actualizar el usuario.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }
        //submodulo edita Contacto de usuario
        static void EditUserContact()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR CONTACTO ==");
            Console.Write("buscar usuario ID: ");
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el usuario por ID en el servicio
            Usuario usuario = usuarioService.BuscarPorId(BuscarId);
            if (usuario != null)
            {
                Console.Write($"Correo actual ({usuario.Correo}) - Nuevo correo (Enter para mantener): ");
                // Limpia espacios sobrantes de la entrada de correo
                string entradaCorreo = (Console.ReadLine() ?? "").Trim();
                // Conserva el correo actual si el campo se deja vacio
                string nuevoCorreo = string.IsNullOrWhiteSpace(entradaCorreo) ? usuario.Correo : entradaCorreo;

                Console.Write($"Telefono actual ({usuario.Telefono}) - Nuevo telefono (Enter para mantener): ");
                // Limpia espacios sobrantes de la entrada de telefono
                string entradaTelefono = (Console.ReadLine() ?? "").Trim();
                // Conserva el telefono actual si el campo se deja vacio
                string nuevoTelefono = string.IsNullOrWhiteSpace(entradaTelefono) ? usuario.Telefono : entradaTelefono;

                // Actualiza correo y telefono manteniendo el nombre actual del usuario
                bool actualizado = usuarioService.ActualizarUsuario(usuario.Id, usuario.Nombre, nuevoCorreo, nuevoTelefono);
                Console.WriteLine(actualizado ? "Contacto actualizado con exito" : "No se pudo actualizar el usuario.");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }
        //submodulo edita si esta activo o inactivo el usuario
        static void ToggleUserActiveStatus()
        {
            Console.Clear();
            Console.WriteLine("== CAMBIAR ESTADO ==");
            Console.Write("buscar usuario ID:");
            string BuscarId = (Console.ReadLine() ?? "").Trim();
            // Busca el usuario por ID en el servicio
            Usuario usuario = usuarioService.BuscarPorId(BuscarId);
            if (usuario != null)
            {
                // Invierte el estado activo/inactivo del usuario encontrado
                usuario.Activo = !usuario.Activo;
                string estado = usuario.Activo ? "activado" : "desactivado";
                Console.WriteLine($"Usuario estado:{estado}, actualizado con exito");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }
        // Modulo eliminar usuario
        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("== ELIMINAR USUARIO ==");
            Console.Write("ingresa el ID: ");
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Busca el usuario por ID en el servicio
            Usuario usuario = usuarioService.BuscarPorId(BuscarId);
            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                ShowReturnMenu();
                return;
            }

            // Bloquea el borrado si el usuario tiene un libro prestado sin devolver
            if (prestamoService.TienePrestamoActivoUsuario(usuario.Id))
            {
                Console.WriteLine("\n!ADVERTENCIA: No se puede eliminar un usuario con prestamos activos.");
                ShowReturnMenu();
                return;
            }

            // Muestra el usuario encontrado y solicita confirmacion antes de borrar
            Console.WriteLine("\nUsuario encontrado:");
            Console.WriteLine(usuario.ResumenCorto());
            Console.Write("¿Seguro que deseas eliminarlo? (si/no): ");
            // Normaliza la respuesta para aceptar mayusculas o espacios accidentales
            string confirmar = (Console.ReadLine() ?? "").Trim().ToLower();
            if (confirmar != "si")
            {
                Console.WriteLine("\nEliminacion cancelada.");
                ShowReturnMenu();
                return;
            }

            // Elimina el usuario de la lista en memoria a traves del servicio
            bool eliminado = usuarioService.EliminarUsuario(usuario.Id);
            Console.WriteLine(eliminado ? "\n¡Usuario eliminado con éxito!" : "\nNo se pudo eliminar el usuario.");
            ShowReturnMenu();
        }

            // MODULO PRESTAMOS
           static void ShowloansMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== MENU PRESTAMO ===                
OPCION:
1.Crear prestamo
2.Lista prestamos
3.Ver detalle de prestamo
4.Registrar devolucion
5.Eliminar prestamo
6.volver a menu       
======================= 
");
                Console.Write("elegir opcion: ");
                string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case"1":
                    CreateLoan();
                    break;
                    case"2":
                    ListLoansMenu();
                    break;
                    case"3":
                    ViewLoanDetail();
                    break;
                    case"4":
                    RegisterReturn();
                    break;
                    case"5":
                    DeleteLoan();
                    break;
                    case"6":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }
              
            }
        }
        // Modulo crear prestamos y validaciones
        static void CreateLoan()
        {
            Console.Clear();
            Console.WriteLine("== REGISTRAR PRESTAMO ==");

            // Busca el usuario por ID en el servicio en lugar de usar variables sueltas
            Console.Write("ingresar ID usuario: ");
            string usuarioId = (Console.ReadLine() ?? "").Trim();
            Usuario usuario = usuarioService.BuscarPorId(usuarioId);
            if (usuario == null)
            {
                Console.WriteLine("\nERROR: Usuario no encontrado.");
                ShowReturnMenu();
                return;
            }
            // Verifica que el usuario este activo antes de permitirle solicitar un libro
            if (!usuario.Activo)
            {
                Console.WriteLine("\nERROR: usuario desactivado");
                ShowReturnMenu();
                return;
            }

            // Busca el libro por ID en el servicio
            Console.Write("ingresar ID libro: ");
            string libroId = (Console.ReadLine() ?? "").Trim();
            Libro libro = libroService.BuscarPorId(libroId);
            if (libro == null)
            {
                Console.WriteLine("\nERROR: Libro no encontrado.");
                ShowReturnMenu();
                return;
            }
            // Verifica que el libro este disponible antes de prestarlo
            if (!libro.Disponible)
            {
                Console.WriteLine("\nERROR: libro no disponible");
                ShowReturnMenu();
                return;
            }

            // Solicita dias de plazo y usa 7 dias por defecto si se deja vacio o invalido
            Console.Write("dias de plazo (Enter para 7 dias): ");
            string textoDias = (Console.ReadLine() ?? "").Trim();
            int diasPlazo = 7;
            if (!string.IsNullOrWhiteSpace(textoDias) && (!int.TryParse(textoDias, out diasPlazo) || diasPlazo <= 0))
            {
                Console.WriteLine("\nERROR: Cantidad de dias invalida.");
                ShowReturnMenu();
                return;
            }

            // Registra el prestamo en el servicio y vincula libro y usuario
            bool creado = prestamoService.CrearPrestamo(libro, usuario, diasPlazo);
            if (creado)
            {
                Console.WriteLine("\nprestamo activado");
                Console.WriteLine($"Libro: {libro.Titulo} asignado a usuario:{usuario.Nombre}.");
            }
            else
            {
                Console.WriteLine("\nERROR: No se pudo registrar el prestamo.");
            }
            ShowReturnMenu();
        }
        // Modulo listar prestamos
        static void ListLoansMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                    Console.Clear();
                Console.WriteLine(@"
=== LISTAR PRESTAMOS ===                
OPCION:
1.TODOS 
2.ACTIVOS
3.Cerrados (devueltos)
4.volver a menu        
=========================
");
                Console.Write("elegir opcion: ");
                string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case"1":
                    ListLoansAll();
                    break;
                    case"2":
                    ListLoansActive();
                    break;
                    case"3":
                    ListLoansClosed();
                    break;
                    case"4":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }
            }
        }
        // subModulos listar
        // Submodulo Listar todos los prestamos
        static void ListLoansAll()
        {
            Console.Clear();
            Console.WriteLine("== LISTAR TODOS LOS PRESTAMOS ==");
            // Obtiene todos los prestamos registrados desde el servicio
            List<Prestamo> listaPrestamos = prestamoService.ObtenerTodos();

            // Verifica si existen prestamos antes de recorrer la lista
            if (listaPrestamos.Count > 0)
            {
                // Recorre cada prestamo y muestra su detalle completo
                foreach (Prestamo prestamo in listaPrestamos)
                {
                    Console.WriteLine(prestamo.DetalleCompleto());
                }
            }
            else
            {
                Console.WriteLine("No hay registros de préstamos en el sistema.");
            }
            ShowReturnMenu();
        }
        // Submodulo listar prestamos activos
        static void ListLoansActive()
        {
            Console.Clear();
            Console.WriteLine("== LISTAR PRESTAMOS ACTIVOS ==");
            // Obtiene unicamente los prestamos activos desde el servicio
            List<Prestamo> PrestamoActivos = prestamoService.ObtenerActivos();
            // Muestra elementos activos si la lista contiene registros
            if (PrestamoActivos.Count > 0)
            {
                // Recorre cada prestamo activo y muestra su detalle completo
                foreach (Prestamo prestamo in PrestamoActivos)
                {
                    Console.WriteLine(prestamo.DetalleCompleto());
                }
            }
            else
            {
                // Indica que no hay prestamos activos registrados
                Console.WriteLine("\nNo hay prestamos activos en este momento.");
            }

            ShowReturnMenu();
        }
        // Submodulo listar prestamos devueltos
        static void ListLoansClosed()
        {
            Console.Clear();
            Console.WriteLine("== LISTAR PRESTAMOS DEVUELTOS ==");
            // Obtiene unicamente los prestamos devueltos desde el servicio
            List<Prestamo> PrestamoDevueltos = prestamoService.ObtenerDevueltos();
            // Muestra elementos devueltos si la lista contiene registros
            if (PrestamoDevueltos.Count > 0)
            {
                // Recorre cada prestamo devuelto y muestra su detalle completo
                foreach (Prestamo prestamo in PrestamoDevueltos)
                {
                    Console.WriteLine(prestamo.DetalleCompleto());
                }
            }
            else
            {
                // Indica que no hay prestamos devueltos registrados
                Console.WriteLine("\nNo hay prestamos devueltos en este momento.");
            }

            ShowReturnMenu();
        }
        // Modulo Ver detalle prestamo
        static void ViewLoanDetail()
        {
            Console.Clear();
            Console.WriteLine("== DETALLE PRESTAMO ==");
            Console.Write("ingresa el ID: ");
            // Usa tipo string en minuscula para mantener consistencia
            string BuscarId = (Console.ReadLine() ?? "").Trim();
            Prestamo prestamo = prestamoService.BuscarPorId(BuscarId);

            // Muestra la informacion completa si se encontro el prestamo
            if (prestamo != null)
            {
                Console.WriteLine(prestamo.DetalleCompleto());
            }
            else
            {
                Console.WriteLine("Prestamo no encontrado");
            }

            ShowReturnMenu();
        }
        // Modulo Registrar Devolucion
        static void RegisterReturn()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR DEVOLUCION");
            Console.Write("ingresa el ID del prestamo: ");
            // Usa tipo string en minuscula para mantener consistencia
            string BuscarId = (Console.ReadLine() ?? "").Trim();

            // Registra la devolucion y libera el libro a traves del servicio
            bool devuelto = prestamoService.RegistrarDevolucion(BuscarId, libroService);
            if (devuelto)
            {
                // Recupera el prestamo ya actualizado para mostrar el titulo del libro
                Prestamo prestamo = prestamoService.BuscarPorId(BuscarId);
                string tituloLibro = prestamo != null ? prestamo.LibroTitulo : "Libro";
                Console.WriteLine("\n¡Devolución registrada con éxito!");
                Console.WriteLine($"El libro '{tituloLibro}' ha sido marcado nuevamente como disponible.");
            }
            else
            {
                Console.WriteLine("\nERROR: No se encontro el prestamo o ya fue devuelto.");
            }
            ShowReturnMenu();
        }
        // Modulo Eliminar prestamo
        static void DeleteLoan()
        {
            Console.Clear();
            Console.WriteLine("== ELIMINAR PRESTAMO ==");
            Console.Write("ID prestamo: ");
           string buscarID = (Console.ReadLine() ?? "").Trim();

            // Busca el prestamo por ID para mostrar su resumen antes de confirmar
            Prestamo prestamo = prestamoService.BuscarPorId(buscarID);
            if (prestamo == null)
            {
                Console.WriteLine("No se encontró ningún préstamo con ese ID.");
                ShowReturnMenu();
                return;
            }

            // Muestra el prestamo encontrado y solicita confirmacion antes de eliminarlo
            Console.WriteLine("\nPrestamo encontrado:");
            Console.WriteLine(prestamo.ResumenCorto());
            Console.Write("¿Seguro que deseas eliminarlo? (si/no): ");
            // Normaliza la respuesta para aceptar mayusculas o espacios accidentales
            string confirmar = (Console.ReadLine() ?? "").Trim().ToLower();
            if (confirmar != "si")
            {
                Console.WriteLine("\nEliminacion cancelada.");
                ShowReturnMenu();
                return;
            }

            // Elimina el registro en el servicio y devuelve el libro a disponible si estaba activo
            bool eliminado = prestamoService.EliminarPrestamo(prestamo.Id, libroService);
            if (eliminado)
            {
                Console.WriteLine("\n¡Registro de préstamo eliminado con éxito!");
            }
            else
            {
                Console.WriteLine("\nNo se pudo eliminar el préstamo.");
            }
            ShowReturnMenu();
        }
            // MENU BUSQUEDAS Y REPORTES
           static void ShowSearchReportsMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== BUSQUEDAS POR CRITERIO Y REPORTES ===
1.Buscar libro
2.Buscar usuario
3.Reportes
4.volver a menu principal      
=============================          
");
                Console.Write("elegir opcion: ");
                string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case"1":
                    SearchBook();
                    break;
                    case"2":
                    SearchUser();
                    break;
                    case"3":
                    ReportsMenu();
                    break;
                    case"4":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }             
            }
        }
            // Modulo Buscar libros
            static void SearchBook()
        {
            Console.Clear();
            Console.WriteLine(@"
=== BUSCAR LIBRO ===
1. Buscar por ID
2. Buscar por Titulo
3. Buscar por Autor
4. Buscar por Categoria o ordenar por año
====================");

            if (libroID == "")
            {
                Console.WriteLine("\n[AVISO]: No hay ningún libro registrado en el sistema actualmente.");
                ShowReturnMenu();
                return;
            }

            bool encontrado = false;
            Console.Write("elegir opcion: ");
            string opcion = Console.ReadLine() ?? "";
            switch (opcion)
            {
                case"1":
                Console.Write("Ingresar por ID: ");
                String LIBID = Console.ReadLine() ?? "";
                if (LIBID == libroID) encontrado = true;
                break;
                case"2":
                Console.Write("Ingresar por Titulo: ");
                String LIBTitulo = Console.ReadLine() ?? "";
                if (LIBTitulo == libroTitulo) encontrado = true;
                break;
                case"3":
                Console.Write("Ingresar por Autor: ");
                String LIBAutor = Console.ReadLine() ?? "";
                if (LIBAutor == libroAutor) encontrado = true;
                break;
                case"4":
                Console.Write("Ingresar la Categoria: ");
                String LIBCAT = Console.ReadLine() ?? "";
                if (LIBCAT == libroCategoria) encontrado = true;
                break;
                default:
                Console.WriteLine("ERROR!: Opcion no valida");
                break;
            }
            if (encontrado)
            {
                string estado = libroDisponible ? "Disponible" : "Prestado";
                Console.WriteLine($@"
[¡LIBRO ENCONTRADO!]:
- ID: {libroID}
- Título: {libroTitulo}
- Autor: {libroAutor}
- Categoría: {libroCategoria}
- Año: {libroAño}
- Estado: {estado}
- estado prestamo:{estadoprestamo}
");
            }
            else
            {
                Console.WriteLine("no se encontro ningun libro por ese dato");
            }
            ShowReturnMenu();
        }
            //Modulo buscar usuario
            static void SearchUser()
        {
            Console.Clear();
    Console.WriteLine(@"
=== 4.2 BUSCAR USUARIO ===
1. Buscar por ID / Documento
2. Buscar por Nombre o ordenar por nombre
============================");
    Console.Write("Seleccionar opcion: ");
    string opcion = Console.ReadLine() ?? "";

    if(usuarioID == "")
            {
            Console.WriteLine("\n[AVISO]: No hay ningún usuario registrado en el sistema actualmente.");
            ShowReturnMenu();
             return; 
            }
            bool encontrado = false;
            if(opcion == "1")
            {
                Console.Write("ingresa el ID: ");
                String USRID = Console.ReadLine() ?? "";
                if(USRID == usuarioID) encontrado = true;
            }
            else if(opcion == "2")
            {
                Console.Write("ingresa el Nombre: ");
                String USRNombre = Console.ReadLine() ?? "";
                if(USRNombre == usuarioNombre) encontrado = true;
            }
            if (encontrado)
    {
        string estadoU = usuarioActivo ? "Activado" : "Desactivado";
        Console.WriteLine($@"
[¡USUARIO ENCONTRADO!]:
- ID: {usuarioID}
- Nombre: {usuarioNombre}
- Contacto: {usuarioContacto}
- Estado: {estadoU}
- estado prestamo: {estadoprestamo}
");
    }
    else
    {
        Console.WriteLine("\n[RESULTADO]: No se encontró ningún usuario con ese criterio.");
    }
    ShowReturnMenu();
        }
        // Modulo Reportes
        static void ReportsMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== MENÚ DE REPORTES ===
1. Préstamos por usuario
2. Préstamos por libro
3. Préstamos vencidos
4. Resumen general o ordenar por fecha limite
5. Volver
========================
");
             Console.Write("Seleccionar opcion: ");
             string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case"1":
                    ReportByUser();
                    break;
                    case"2":
                    ReportByBook();
                    break;
                    case"3":
                    ReportOverdue();
                    break;
                    case"4":
                    ReportSummary();
                    break;
                    case"5":
                    volverMenu = true;
                    break;
                    default:
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    break;
                }
            }
        }
        // subModulos reportes
        static void ReportByUser()
        {
            Console.Clear();
    Console.WriteLine("=== REPORTE: PRÉSTAMOS POR USUARIO ===");
    Console.Write("Ingresa el ID del usuario: ");
    string buscarID = Console.ReadLine() ?? "";

    if (usuarioID != "" && buscarID == usuarioID)
    {
        if (prestamoActivo || !prestamoActivo)
        {
            Console.WriteLine($@"
==================================
- Usuario{usuarioNombre} 
- usuario ID: {usuarioID}
- ID Préstamo: {prestamoID}
- Fecha inicio: {fechaInicio} 
- Fecha límite: {fechaLimite}
- Estado del préstamo: {estadoprestamo}
======================================");
        }
        else
        {
            Console.WriteLine($"\nEl usuario '{usuarioNombre}' no tiene préstamos registrados.");
        }
    }
    else
    {
        Console.WriteLine("\nUsuario no encontrado.");
    }
    ShowReturnMenu();
        }
        static void ReportByBook()
        {
            Console.Clear();
    Console.WriteLine("=== REPORTE: PRÉSTAMOS POR LIBRO ===");
    Console.Write("Ingresa el ID del libro: ");
    string buscarID = Console.ReadLine() ?? "";

    if (libroID != "" && buscarID == usuarioID)
    {
        if (prestamoActivo || !prestamoActivo)
        {
Console.WriteLine($@"
===============================
- Libro: {libroTitulo} 
- Libro ID: {libroID}
- prestamo ID: {prestamoID}
- Fecha inicio: {fechaInicio}
- Fecha límite: {fechaLimite}
- Estado del préstamo: {estadoprestamo}
======================================");
        }
        else
        {
            Console.WriteLine($"\nEl libro: '{libroTitulo}' no tiene préstamos registrados.");
        }
    }
    else
    {
        Console.WriteLine("\nlibro no encontrado.");
    }
    ShowReturnMenu();
        }
        static void ReportOverdue()
        {
            Console.Clear();
            Console.WriteLine("=== REPORTE: PRÉSTAMOS VENCIDOS ===");

    if (prestamoActivo)
    {
Console.WriteLine($@"
===============================
Préstamo activo en seguimiento:
- ID Préstamo: {prestamoID}
- Usuario: {usuarioNombre}
- Libro: {libroTitulo}
- Fecha Límite registrada: {fechaLimite}
- Estado: {estadoprestamo}
=============================");
    }
    else
    {
        Console.WriteLine("\nNo hay préstamos activos pendientes de vencimiento en este momento.");
    }
    ShowReturnMenu();
        }
        static void ReportSummary()
        {
            Console.Clear();
    Console.WriteLine("=== REPORTE: RESUMEN GENERAL ===");

   
    int totalLibros = libroID != "" ? 1 : 0;
    int disponibles = (libroID != "" && libroDisponible) ? 1 : 0;
    int prestados = (libroID != "" && !libroDisponible) ? 1 : 0;

   
    string infoUsuario = "Ninguno";
    if (usuarioID != "")
    {
        string estadoUsr = usuarioActivo ? "Activo" : "Desactivado";
        infoUsuario = $"{usuarioNombre} ({estadoUsr})";
    }

  
    string infoPrestamo = "Ninguno";
    if (prestamoID != "")
    {
        infoPrestamo = $"{prestamoID} prestamo en curso. Estado del prestamo: {estadoprestamo}";
    }

  
    Console.WriteLine($@"
--------------------------------------------------
Total de libros en sistema: {totalLibros}
- Libros disponibles:       {disponibles}
- Libros prestados:         {prestados}

Usuario registrado:        {infoUsuario}
Préstamo en curso:         {infoPrestamo}
--------------------------------------------------");

    ShowReturnMenu();
        }

        // 5. MÓDULO GUARDAR / CARGAR DATOS (Simulado)

        static void showSavedatamenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== GUARDAR / CARGAR DATOS ===
1. Guardar datos
2. Cargar datos
3. Reiniciar datos (Vaciar todo)
4. Volver al menú principal
==============================");
                Console.Write("Selecciona una opción: ");
                string bibliotecario = Console.ReadLine() ?? "";
                switch (bibliotecario)
                {
                    case "1":
                        SaveData();
                        break;
                    case "2":
                        LoadData();
                        break;
                    case "3":
                        ResetData();
                        break;
                    case "4":
                        volverMenu = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("[ERROR]: Opción no válida.");
                        ShowReturnMenu();
                        break;
                }
            }
        }

        // Simulación de guardado
        static void SaveData()
        {
            Console.Clear();
            Console.WriteLine("=== GUARDAR DATOS ===");
            Console.WriteLine("[SIMULACIÓN]: Guardando el estado actual del sistema en memoria...");
            Console.WriteLine("¡Datos guardados con éxito de manera simulada!");
            datosGuardados = true;
            ShowReturnMenu();
        }

        // Simulación de carga
        static void LoadData()
        {
            Console.Clear();
            Console.WriteLine("=== CARGAR DATOS ===");
            Console.WriteLine("[SIMULACIÓN]: Leyendo registros simulados previamente...");
            Console.WriteLine("¡Datos cargados con éxito en el sistema!");
            datosGuardados = true;
            ShowReturnMenu();
        }

        // Simulación de reinicio con confirmación (S/N)
        static void ResetData()
        {
            Console.Clear();
            Console.WriteLine("=== REINICIAR DATOS ===");
            Console.Write("¿Está seguro de reiniciar y vaciar todos los datos del sistema? (Si/No): ");
            string confirmacion = Console.ReadLine() ?? "";

            if (confirmacion.ToLower() == "si")
            {
                // Limpiamos las variables globales en RAM
                libroID = ""; libroTitulo = ""; libroAutor = ""; libroCategoria = ""; libroAño = ""; libroDisponible = false;
                usuarioID = ""; usuarioNombre = ""; usuarioContacto = ""; usuarioActivo = false;
                prestamoID = ""; prestamoActivo = false; fechaInicio = ""; fechaLimite = ""; fechaDevolucion = "N/A"; estadoprestamo = "inactivo";

                datosGuardados = false;
                Console.WriteLine("\n[SIMULACIÓN]: ¡El sistema ha sido limpiado y reiniciado a cero con éxito!");
            }
            else
            {
                Console.WriteLine("\n[SIMULACIÓN]: Operación cancelada. Los datos no fueron modificados.");
            }
            ShowReturnMenu();
        }

        // ==========================================
        // 6. MÓDULO SALIDA INTELIGENTE CON RECIBO SIMULADO
        // ==========================================
        static void ConfirmExitAndSave()
        {
            Console.Clear();
            Console.WriteLine("=== SALIDA DEL SISTEMA ===");

            if (!datosGuardados)
            {
                Console.WriteLine("[AVISO]: Hay cambios recientes en el sistema que no se han guardado.");
                Console.Write("¿Deseas guardar los datos antes de salir? (Si/No): ");
                string respuesta = Console.ReadLine() ?? "";

                if (respuesta.ToLower() == "si")
                {
                    datosGuardados = true;
                    Console.Clear();
                    Console.WriteLine(@"
==================================================
        🧾 RECIBO DE GUARDADO Y CIERRE (SIMULACIÓN)
==================================================
 Estado: ¡Datos guardados correctamente en memoria!
- Libro registrado ID:  " + (libroID != "" ? libroID : "Ninguno") + @"
- Usuario registrado ID:" + (usuarioID != "" ? usuarioID : "Ninguno") + @"
- Préstamo en curso ID: " + (prestamoID != "" ? prestamoID : "Ninguno") + @"
==================================================");
                }
                else
                {
                    Console.WriteLine("\n[AVISO]: Saliendo sin guardar los cambios recientes...");
                }
            }
            else
            {
                Console.WriteLine("Los datos ya se encontraban guardados previamente en memoria.");
            }

            Console.WriteLine("\n--> Saliendo del sistema. ¡Hasta pronto!");
        }
            // PAUSA GENERAL
            static void ShowReturnMenu()
            {
                Console.WriteLine("\nvolver al menu anterior");
                Console.Write("presiona cualquier tecla: ");
                Console.ReadKey();
            }

   

        
    //           static void PruebaPoo()
    //     {
    //         Console.WriteLine(@"
    // ===================================
    // SISTEMA DE BIBLIOTECA - PRUEBAS POO
    // ===================================");

    //         // CREAR 2 LIBROS
    //         Libro libro1 = new Libro("Clean Code","Robert C. Martin","Ingenieria de Software", 2008);
    //         Libro libro2 = new Libro("Cien años de soledad", "Gabriel García Márquez", "Literatura", 1967);

    //         //CREAR 2 USUARIOS
    //         Usuario usuario1 = new Usuario("Emmanuel Sierra", "emmanuel.sierra@email.com", "3001234567");
    //         Usuario usuario2 = new Usuario("Sofía Ramírez", "sofia.ramirez@email.com", "3119876543");

    //         // PRUEBA
    //         Console.WriteLine("--- ESTADO INICIAL DE LOS OBJETOS ---");
    //         Console.WriteLine("\nRESUMEN LIBROS");
    //         Console.WriteLine(libro1.ToString());
    //         Console.WriteLine(libro2.ToString());
    //         Console.WriteLine("\nRESUMEN USUARIOS");
    //         Console.WriteLine(usuario1.ToString());
    //         Console.WriteLine(usuario2.ToString());
    //         Console.WriteLine("\nDETALLE LIBRO");
    //         Console.WriteLine(libro1.DetalleCompleto());
    //         Console.WriteLine("\nDETALLE USUARIO");
    //         Console.WriteLine(usuario1.DetalleCompleto());
    //         Console.WriteLine("\n----------------------------------------\n");

    //         //CREAR PRESTAMO
    //         Prestamo prestamo1 = new Prestamo(libro1,usuario1, 7);

    //         //VALIDACIONES
    //         Console.WriteLine("=== PRUEBAS Y VALIDACIONES ===\n");

    //         // Resumenes y Detalles
    //         Console.WriteLine("Resumen Corto: ");
    //         Console.WriteLine(prestamo1.ToString());

    //         Console.WriteLine("\nDetalle: ");
    //         Console.WriteLine(prestamo1.DetalleCompleto());

    //         Console.WriteLine("\n========================================");
    //         Console.WriteLine("   PRUEBAS FINALIZADAS CON ÉXITO        ");
    //         Console.WriteLine("========================================");
    //         ShowReturnMenu();
    //     }
        static void CargarDatosPrueba()
        {
            // Creamos libros
            Libro libro1 = new Libro("Clean Code", "Robert C. Martin", "Ingenieria de Software", 2008);
            Libro libro2 = new Libro("Cien años de soledad", "Gabriel Garcia Marquez", "Literatura", 1967);
            Libro libro3 = new Libro("El Principito", "Antoine de Saint-Exupery", "Fantasia", 1943);

            //Guardamos Libros en service
            libroService.AgregarLibro(libro1);
            libroService.AgregarLibro(libro2);
            libroService.AgregarLibro(libro3);

            // Usuarios crear
            Usuario usuario1 = new Usuario("Raul girardo","raul@gmail.com","3001234567");
            Usuario usuario2 = new Usuario("juan","juanin@gmail.com","3034876643");

            //Guardamos usuario en service
            usuarioService.AgregarUsuario(usuario1);
            usuarioService.AgregarUsuario(usuario2);

            // creamos prestamo
            prestamoService.CrearPrestamo(libro1, usuario1, 7);
        }

    }
}