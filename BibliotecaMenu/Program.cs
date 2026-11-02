using System;
using System.Linq.Expressions;

namespace Bibliotecamenu
{
    class Program
    {
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
            while (volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"
                ");

                string bibliotecario = Console.ReadLine() ?? "";               
            }
        }

            // MODULO USUARIOS
            
            static void ShowUsersMenu()
        {
            bool volverMenu = false;
            while (volverMenu)
            {
                Console.Clear();
                Console.WriteLine(@"");

                string bibliotecario = Console.ReadLine() ?? "";              
            }
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
                Console.WriteLine("volver al menu");
                Console.Write("\npresiona cualquier tecla: ");
                Console.ReadKey();
            }
    }
}