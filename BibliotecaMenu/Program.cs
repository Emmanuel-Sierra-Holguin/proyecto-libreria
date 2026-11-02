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

                if(int.TryParse(bibliotecario, out int Menu))
                {
                    switch (Menu)
                    {
                         case 1:
                         ShowBooksMenu();
                        break;
                         case 2:
                         ShowUsersMenu();
                        break;
                         case 3:
                         ShowloansMenu();
                        break;
                         case 4:
                         ShowSearchReportsMenu();
                        break;
                         case 5:
                         showSavedatamenu();
                        break;
                         case 6:
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERROR!: Opcion no valida");
                    ShowReturnMenu();
                    continue;
                }
            }
        }

        // 
        static void ShowBooksMenu()
            {
                Console.Clear();
                Console.WriteLine("--> [Modulo de libros]");
                ShowReturnMenu();
            }
            static void ShowUsersMenu()
            {
                Console.Clear();
                Console.WriteLine("--> [Modulo de Usuarios]");
                ShowReturnMenu();
            }
            static void ShowloansMenu()
            {
                Console.Clear();
                Console.WriteLine("--> [Modulo de Prestamos]");
                ShowReturnMenu();
            }
            static void ShowSearchReportsMenu()
            {
                Console.Clear();
                Console.WriteLine("--> [Modulo de Busquedas y Reportes]");
                ShowReturnMenu();
            }
            static void showSavedatamenu()
            {
                Console.Clear();
                Console.WriteLine("--> [Modulo de Guardar / Cargar Datos]");
                ShowReturnMenu();
            }
            static void ConfirmExitAndSave()
            {
                Console.Clear();
                Console.WriteLine("--> Saliendo del sistema...");
            } 
            static void ShowReturnMenu()
            {
                Console.WriteLine("volver al menu");
                Console.Write("\npresiona cualquier tecla: ");
                Console.ReadKey();
            }
    }
}