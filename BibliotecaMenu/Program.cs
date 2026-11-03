using System;
using System.Linq.Expressions;

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
                Console.Write("Selecciona una opcion: ");
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
        

        // MODULO LIBROS
        static void ShowBooksMenu()
        {
            bool volverMenu = false;
            while (!volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
=== MENÚ PRINCIPAL BIBLIOTECA ===
OPCIONES:
1 Registrar libro
2 Listar libros
3 Ver detalle de libro
4 Actualizar libro
5 Eliminst libro
6 volver al menu
=====================
                ");

                Console.Write("seleccionar opcion: ");
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

        // Modulo registro       
        static void RegisterBook()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRO LIBRO ===");

             Console.Write("ID: ");
            libroID = Console.ReadLine() ?? "";
             Console.Write("Titulo: ");
            libroTitulo = Console.ReadLine() ?? "";
             Console.Write("Autor: ");
            libroAutor = Console.ReadLine() ?? "";
             Console.Write("Categoria: ");
            libroCategoria = Console.ReadLine() ?? "";
             Console.Write("Año: ");
            libroAño = Console.ReadLine() ?? "";

            libroDisponible = true;

            Console.WriteLine("libro registrado");
            ShowReturnMenu(); 
        }

        // Modulo lista
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

        //submodulos lista
        static void ListBooksAll()
        {
            Console.Clear();
            Console.WriteLine("== lista todos los libros");
            if(libroID != "")
            {
                string estado = libroDisponible ? "si" : "no";
string detalle = $@"
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: {estado} "; 
Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("libro no registrado todavia");
            }
            ShowReturnMenu();
        }
        static void ListBooksAvailable()
        {
            Console.Clear();
            Console.WriteLine("== lista todos los libros");
            if(libroID != "" && libroDisponible == true)
            {

string detalle = $@"
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: si "; 
                Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("libro no disponible");
            }
            ShowReturnMenu();
        }
        static void ListBooksBorrowed()
        {
            Console.Clear();
            Console.WriteLine("== lista todos los libros");
            if(libroID != "" && libroDisponible == false)
            {
string detalle = $@"
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: no "; 
                Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("libro no prestado");
            }
            ShowReturnMenu();
        }

// modulo detalle
        static void ViewBookDetail()
        {
            Console.Clear();
            Console.WriteLine("== DETALLE LIBRO ==");
            Console.Write("buscar por ID:");
            string buscarID = Console.ReadLine() ?? "";
            if(libroID != "" && buscarID == libroID)
            {
                string estado = libroDisponible ? "si" : "no";
string detalle = $@"
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: {estado}";
                Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("libro no encontrado");
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
            Console.Write("opcion:");
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

        static void EditBookTitle()
        {
            Console.Clear();
            Console.WriteLine("== editar titulo==");
            Console.Write("buscar por ID: ");
            string buscarID = Console.ReadLine() ?? "";
            if(libroID != "" && buscarID == libroID)
            {
                Console.Write("editar titulo:");
                 libroTitulo = Console.ReadLine() ?? "";
                Console.WriteLine("libro editado");
            }
            else
            {
                Console.WriteLine("libro no encontrado");
            }
            ShowReturnMenu();
        }
        static void EditBookAuthor()
        {
            Console.Clear();
            Console.WriteLine("== editar autor==");
            Console.Write("buscar por ID: ");
            string buscarID = Console.ReadLine() ?? "";
            if(libroID != "" && buscarID == libroID)
            {
                Console.Write("editar autor:");
                 libroAutor = Console.ReadLine() ?? "";
                Console.WriteLine("libro editado");
            }
            else
            {
                Console.WriteLine("libro no encontrado");
            }
            ShowReturnMenu();
        }
        static void EditBookYearCategory()
        {
            Console.Clear();
            Console.WriteLine("== editar año / categoria ==");
            Console.Write("buscar por ID: ");
            string buscarID = Console.ReadLine() ?? "";
            if(libroID != "" && buscarID == libroID)
            {
                Console.WriteLine("editar (1)año o (2)categoria");
                Console.Write("opcion: ");
                string opcion = Console.ReadLine() ?? "";
                if(opcion == "1")
                {
                    Console.Write("editar año: ");
                    libroAño =Console.ReadLine() ?? "";
                    Console.WriteLine("libro editado");
                }
                else if(opcion == "2")
                {
                    Console.Write("editar categoria: ");
                    libroCategoria =Console.ReadLine() ?? "";
                    Console.WriteLine("libro editado");
                }
            }
            else
            {
                Console.WriteLine("libro no encontrado");
            }
            ShowReturnMenu();
        }
        // modulo eliminar libro
        static void DeleteBook()
        {
          Console.Clear();
          Console.WriteLine("=== eliminar libro ===");
          Console.Write("ingresar id: ");
          string buscarid = Console.ReadLine() ?? "";
          if(libroID != "" && buscarid == libroID)
            {
            libroID = "";
            libroTitulo = "";
            libroAutor = "";
            libroCategoria = "";
            libroAño = "";
            libroDisponible = false;

            Console.WriteLine("¡Libro eliminado exitosamente!");
            }
            else
            {
                Console.WriteLine("Libro no encontrado o no hay registros.");
            }
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
2.Listar usuario
3.Ver detaller usuario
4.Actualizar usuario
5.Eliminar usuario
6. regresar al menu
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
            Console.WriteLine("=== REGISTRO USUARIO ===");

             Console.Write("ID: ");
            usuarioID = Console.ReadLine() ?? "";
             Console.Write("Nombre: ");
            usuarioNombre = Console.ReadLine() ?? "";
             Console.Write("Numero/correo: ");
            usuarioContacto = Console.ReadLine() ?? "";
            Console.WriteLine("¿activar usuario? (Si/No)");
            string activo = Console.ReadLine() ?? "";
            if(activo.ToLower() == "si")
            {
                usuarioActivo = true;
            }
            else
            {
                usuarioActivo = false;
            }

            Console.WriteLine("usuario registrado");
            ShowReturnMenu(); 
        }
        // Modulo listar usuarios
        static void ListUsers()
        {
            Console.Clear();
            Console.WriteLine("=== LISTA USUARIO ===");

            if(usuarioID != "")
            {
                string estado = usuarioActivo ? "activado" : "desactivado";
                string detalle = $@"
ID:{usuarioID}
Nombre:{usuarioNombre}
Contacto:{usuarioContacto}
estado:{estado}
";
              Console.WriteLine(detalle);
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
            Console.Write("ingresa el ID");
            string buscarID = Console.ReadLine() ?? "";

            if(usuarioID != "" && buscarID == usuarioID)
            {
                         string estado = usuarioActivo ? "activado" : "desactivado";
                string detalle = $@"
ID:{usuarioID}
Nombre:{usuarioNombre}
Contacto:{usuarioContacto}
estado:{estado}
";
            Console.WriteLine(detalle);
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
        static void EditUserName()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR NOMBRE ==");
            Console.Write("buscar usuario ID:");
            string buscarID = Console.ReadLine() ?? "";
            if(usuarioID != "" && buscarID == usuarioID)
            {
                Console.Write("Nuevo nombre: ");
                usuarioNombre = Console.ReadLine() ?? "";
                Console.WriteLine("Nombre actualizado con exito");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }
        static void EditUserContact()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR CONTACTO ==");
            Console.Write("buscar usuario ID:");
            string buscarID = Console.ReadLine() ?? "";
            if(usuarioID != "" && buscarID == usuarioID)
            {
                Console.Write("Nuevo Numero/Correo: ");
                usuarioContacto = Console.ReadLine() ?? "";
                Console.WriteLine("Contacto actualizado con exito");
            }
            else
            {
                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }
        static void ToggleUserActiveStatus()
        {
            Console.Clear();
            Console.WriteLine("== EDITAR ESTADO ==");
            Console.Write("buscar usuario ID:");
            string buscarID = Console.ReadLine() ?? "";
            if(usuarioID != "" && buscarID == usuarioID)
            {
                usuarioActivo = !usuarioActivo;
                string estado = usuarioActivo ? "activado" : "desactivado";
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
            string buscarID = Console.ReadLine() ?? "";
            if(usuarioID != "" && buscarID == usuarioID)
            {
                usuarioID = "";
                usuarioNombre = "";
                usuarioContacto = "";
                usuarioActivo = false;
                Console.WriteLine("¡Usuario eliminado con éxito!");
            }
            else
            {
                                Console.WriteLine("Usuario no encontrado.");
            }
            ShowReturnMenu();
        }

            // MODULO PRESTAMOS
           static void ShowloansMenu()
        {
            bool volverMenu = false;
            while (volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"");

                string bibliotecario = Console.ReadLine() ?? "";
              
            }
        }
            // MENU BUSQUEDAS Y REPORTES
           static void ShowSearchReportsMenu()
        {
            bool volverMenu = false;
            while (volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"");

                string bibliotecario = Console.ReadLine() ?? "";             
            }
        }

            //MODULO GUARDAR / CARGAR DATOS
           static void showSavedatamenu()
        {
            bool volverMenu = false;
            while (volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"");

                string bibliotecario = Console.ReadLine() ?? "";              
            }
        }

            // MODULO SALIDA
            static void ConfirmExitAndSave()
            {
                Console.Clear();
                Console.WriteLine("--> Saliendo del sistema...");
            } 

            // PAUSA GENERAL
            static void ShowReturnMenu()
            {
                Console.WriteLine("volver al menu anterior");
                Console.Write("presiona cualquier tecla: ");
                Console.ReadKey();
            }
    }
}