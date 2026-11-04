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
        // variables globales prestamo
        static string prestamoID = "";
        static bool prestamoActivo = false;
        static String fechaInicio = "";
        static String fechaLimite = "";
        static String fechaDevolucion = "N/A";
        static String estadoprestamo = "inactivo";



        //variables global general
        static bool datosGuardados = false;

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
        

        // MODULO LIBROS
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
===============================
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: {estado} 
estado prestamo:{estadoprestamo}
================================"; 
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
            if(libroID != "" && libroDisponible)
            {

string detalle = $@"
===============================
ID: {libroID},
Titulo: {libroTitulo},
Autor: {libroAutor},
Categoria: {libroCategoria},
Año: {libroAño},
Disponible: si 
estado prestamo:{estadoprestamo}
==============================="; 
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
            if(libroID != "" && !libroDisponible)
            {
string detalle = $@"
===============================
ID: {libroID}
Titulo: {libroTitulo}
Autor: {libroAutor}
Categoria: {libroCategoria}
Año: {libroAño}
Disponible: no 
estado prestamo:{estadoprestamo}
==============================="; 
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
===============================
ID: {libroID}
Titulo: {libroTitulo}
Autor: {libroAutor}
Categoria: {libroCategoria}
Año: {libroAño}
Disponible: {estado}
estado prestamo:{estadoprestamo}
===============================";

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
                if (prestamoActivo)
                {
                    Console.WriteLine("!ADVERTENCIA: prestamo activo");
                }
                else
                {
                                libroID = "";
            libroTitulo = "";
            libroAutor = "";
            libroCategoria = "";
            libroAño = "";
            libroDisponible = false;

            Console.WriteLine("¡Libro eliminado exitosamente!");
                }
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
estado de prestamo{estadoprestamo}
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
estado de prestamo:{estadoprestamo}
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
            Console.WriteLine("== CAMBIAR ESTADO ==");
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
                if (prestamoActivo)
                {
                    Console.WriteLine("!ADVERTENCIA: el prestamo esta activo.");
                }
                else
                {
                usuarioID = "";
                usuarioNombre = "";
                usuarioContacto = "";
                usuarioActivo = false;
                Console.WriteLine("¡Usuario eliminado con éxito!");
                }
              
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
                    ShowReturnMenu();
                    break;
                }
              
            }
        }
        // Modulo crear prestamos y validaciones
        static void CreateLoan()
        {
            if(usuarioID == "")
            {
                Console.WriteLine("ERROR: No hay ningún usuario registrado");                
            }
            else if (!usuarioActivo)
            {
                Console.WriteLine("ERROR: usuario desactivado");                
            }
            else if(libroID == "")
            {
                Console.WriteLine("ERROR: No hay ningún libro registrado");                
            }
            else if (!libroDisponible)
            {
                Console.WriteLine("ERROR: libro desactivado");                               
            }
            else if (prestamoActivo)
            {
                Console.WriteLine("!ERROR: prestamo ya activado");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("== REGISTRAR PRESTAMO ==");
                Console.Write("ingresar ID prestamo: ");
                prestamoID = Console.ReadLine() ?? "";
                libroDisponible = false;
                prestamoActivo = true;
                fechaInicio = DateTime.Now.ToString("dd/MM/yyyy");
                Console.Write("ingresar fecha limite(ej: 1/12/2026): ");
                fechaLimite = Console.ReadLine() ?? "";
                fechaDevolucion = "Pendiente";
                estadoprestamo = "activo";

                Console.WriteLine("prestamo activado");
                Console.WriteLine($"Libro: {libroTitulo} asignado a usuario:{usuarioNombre}.");

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
        static void ListLoansAll()
        {
            Console.Clear();
            Console.WriteLine("== LISTAR TODOS LOS PRESTAMOS ==");
            if(prestamoID != "")
            {
                string detalle = $@"
=================================
prestamo ID:{prestamoID}
usuario ID:{usuarioID}
libro ID:{libroID}
Usuario Nombre:{usuarioNombre}
libro Titulo:{libroTitulo}
Fecha inicio:{fechaInicio}
Fecha Limite:{fechaLimite}
fecha devolucion: {fechaDevolucion}
Estado prestamo:{estadoprestamo} 
===================================              
";
        Console.WriteLine(detalle);

            }
            else
            {
                Console.WriteLine("No hay registros de préstamos en el sistema.");
            }
            ShowReturnMenu();
        }
        static void ListLoansActive()
        {
                Console.Clear();
            Console.WriteLine("== LISTAR PRESTAMOS ACTIVOS ==");
            if(prestamoID != "" && prestamoActivo)
            {
                string detalle = $@"
================================
prestamo ID:{prestamoID}
usuario ID:{usuarioID}
libro ID:{libroID}
Usuario Nombre:{usuarioNombre}
libro Titulo:{libroTitulo}
Fecha inicio:{fechaInicio}
Fecha Limite:{fechaLimite}
fecha Devolucion:{fechaDevolucion}
Estado prestamo:{estadoprestamo}
==================================               
";
                 Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("No hay prestamos activos en este momento.");
            }
            ShowReturnMenu();
        }
        static void ListLoansClosed()
        {
             Console.Clear();
            Console.WriteLine("== LISTAR PRESTAMOS CERRADOS ==");
            if(prestamoID != "" && !prestamoActivo)
            {
                string detalle = $@"
=================================
prestamo ID:{prestamoID}
usuario ID:{usuarioID}
libro ID:{libroID}
Usuario Nombre:{usuarioNombre}
libro Titulo:{libroTitulo}
Fecha inicio:{fechaInicio}
Fecha devolucion:{fechaDevolucion}
Estado prestamo:{estadoprestamo}   
===================================            
";
                 Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("No hay registros de préstamos cerrados en este momento.");
            }
            ShowReturnMenu();
        }
        // Modulo Ver detalle prestamo
        static void ViewLoanDetail()
        {
            Console.Clear();
            Console.WriteLine("== DETALLE PRESTAMO ==");
            Console.Write("ingresa el ID: ");
            String buscarID = Console.ReadLine() ?? "";

            if(prestamoID != "" && buscarID == prestamoID)
            {
                string detalle = $@"                
prestamo ID:{prestamoID}
usuario ID:{usuarioID}
libro ID:{libroID}
Usuario Nombre:{usuarioNombre}
libro Titulo:{libroTitulo}
Fecha inicio:{fechaInicio}
Fecha Limite:{fechaLimite}
Fecha devolucion:{fechaDevolucion}
Estado prestamo:{estadoprestamo}               
";
                 Console.WriteLine(detalle);
            }
            else
            {
                Console.WriteLine("No hay registros de préstamos en el sistema con ese Numero.");
            }
            ShowReturnMenu();
        }
        // Modulo Registrar Devolucion
        static void RegisterReturn()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR DEVOLUCION");
            if (!prestamoActivo)
            {
                Console.WriteLine("ERROR: No hay ningún préstamo activo pendiente de devolución.");
            }
            else
            {
                libroDisponible = true;
                prestamoActivo = false;
                fechaDevolucion = DateTime.Now.ToString("dd/MM/yyyy");
                estadoprestamo = "Devuelto";

                Console.WriteLine("¡Devolución registrada con éxito!");
                Console.WriteLine($"El libro '{libroTitulo}' ha sido marcado nuevamente como disponible.");
            }
            ShowReturnMenu();
        }
        // Modulo Eliminar prestamo
        static void DeleteLoan()
        {
            Console.Clear();
            Console.WriteLine("== ELIMINAR PRESTAMO ==");
            Console.Write("ID prestamo: ");
            string buscarID = Console.ReadLine() ?? "";

            if (prestamoID != "" && buscarID == prestamoID)
            {
                if (prestamoActivo)
                {
                    libroDisponible = true;
                    Console.WriteLine("AVISO: El préstamo estaba activo. El libro asociado ha sido devuelto a disponible automáticamente.");
                }
                prestamoID = "";
                prestamoActivo = false;
                fechaInicio = "";
                fechaLimite = "";
                fechaDevolucion = "N/A";
                estadoprestamo = "Inactivo";

                Console.WriteLine("¡Registro de préstamo eliminado con éxito!");
            }
            else
            {
                Console.WriteLine("No se encontró ningún préstamo con ese ID.");
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
=== BUSQUEDAS Y REPORTES ===
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
4. Buscar por Categoria
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
2. Buscar por Nombre
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
4. Resumen general
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
  // ==========================================
        // 5. MÓDULO GUARDAR / CARGAR DATOS (Simulado)
        // ==========================================
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
    }
}