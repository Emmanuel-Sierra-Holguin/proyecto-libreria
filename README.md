Proyecto Sintaxis en C# - Parte 1

Sistema de Gestión de Biblioteca (Navegación y Menús)

📋 Información General

Aprendiz: Emmanuel Sierra Holguín

Ficha: 3412768

Curso: Desarrollo C#

Instructor: Carlos Navia

Fecha / Hora de Inicio: 28/10/2026 - 14:04 PM

🎯 Descripción de la Actividad

Desarrollo de un sistema de consola en C# que implementa un menú interactivo y navegable para la gestión de una biblioteca. En esta Parte 1, el objetivo principal es estructurar la lógica de navegación (menús y submenús) mediante métodos estáticos y estructuras de control.

Nota: Cada opción invoca una función que imprime un mensaje descriptivo de la acción seleccionada. En esta etapa no se implementa POO, colecciones reales ni persistencia de datos (todo se simula por consola).

🛠️ Tecnologías Utilizadas

Lenguaje: C# (.NET)

IDE / Editor: Visual Studio Code

Control de Versiones: Git & GitHub

Metodología de Ramificación: Git Flow

⚙️ Reglas y Restricciones Técnicas

🟩 Permitido

Uso exclusivo de Main() y funciones/métodos estáticos (static void).

Estructuras de control condicionales e iterativas (if, switch/case, while, do-while, for).

Lectura y validación básica de entradas del usuario por consola.

🟥 No Permitido (Reservado para fases posteriores)

Clases de dominio u Orientación a Objetos (POO).

Colecciones reales (List, Dictionary, etc.).

Persistencia en archivos o bases de datos.

🌿 Estrategia de Ramificación (Git Flow)

El ciclo de desarrollo se gestionará mediante ramas feature/, las cuales se integrarán progresivamente a develop y finalmente a main:

main ─────────────────────────────────────────────────────────────► [Release Final]
  │                                                                 ▲
  └──► develop ───────────────────────────────────────────────────┤
         ├──► feature/project-bootstrap ────────────────────────┤
         ├──► feature/main-menu-navigation ─────────────────────┤
         ├──► feature/books-menu ───────────────────────────────┤
         ├──► feature/users-menu ───────────────────────────────┤
         ├──► feature/loans-menu ───────────────────────────────┤
         ├──► feature/search-reports-menu ──────────────────────┤
         ├──► feature/persistence-menu ─────────────────────────┤
         └──► feature/exit-flow ────────────────────────────────┘


Lista de Ramas de Trabajo:

feature/project-bootstrap: Estructura inicial y .gitignore.

feature/main-menu-navigation: Menú principal y ciclo de navegación básica.

feature/books-menu: Submenús y funciones simuladas para Libros.

feature/users-menu: Submenús y funciones simuladas para Usuarios.

feature/loans-menu: Submenús y funciones simuladas para Préstamos.

feature/search-reports-menu: Submenús de Búsquedas y Reportes.

feature/persistence-menu: Submenú de Guardar/Cargar/Reiniciar.

feature/exit-flow: Flujo de confirmación al salir.

🗺️ Estructura del Menú Interactivo

1. Libros
   1.1. Registrar libro
   1.2. Listar libros
        1.2.1. Listar todos
        1.2.2. Listar disponibles
        1.2.3. Listar prestados
   1.3. Ver detalle de libro (por ID/ISBN)
   1.4. Actualizar libro
        1.4.1. Editar título
        1.4.2. Editar autor
        1.4.3. Editar año / categoría
   1.5. Eliminar libro

2. Usuarios
   2.1. Registrar usuario
   2.2. Listar usuarios
   2.3. Ver detalle de usuario (por ID/documento)
   2.4. Actualizar usuario
        2.4.1. Editar nombre
        2.4.2. Editar contacto
        2.4.3. Activar / desactivar
   2.5. Eliminar usuario

3. Préstamos
   3.1. Crear préstamo
   3.2. Listar préstamos
        3.2.1. Todos
        3.2.2. Activos
        3.2.3. Cerrados (devueltos)
   3.3. Ver detalle de préstamo (por ID)
   3.4. Registrar devolución
   3.5. Eliminar préstamo

4. Búsquedas y Reportes
   4.1. Buscar libro (Título, Autor, ID/ISBN, Categoría)
   4.2. Buscar usuario (Nombre, ID/Documento)
   4.3. Reportes (Préstamos por usuario/libro, Vencidos, Resumen general)

5. Guardar / Cargar datos
   5.1. Guardar datos
   5.2. Cargar datos
   5.3. Reiniciar datos (vaciar todo)

0. Salir (con confirmación de guardado)


📐 Criterios de Evaluación

[x] Navegación clara entre menús y submenús.

[x] Validación de entradas por teclado para evitar fallos por tipo de dato.

[x] Invocación de funciones estáticas que notifican la acción seleccionada.

[x] Evidencia de commits y merges estructurados mediante Git Flow.

# 🚀 Fase inicial : Bootstrap del Proyecto (feature/project-bootstrap)

Se ha inicializado la estructura base del sistema de consola en C# para la biblioteca:
- **`BibliotecaMenu.csproj`**: Archivo de proyecto y configuración general de .NET.
- **`Program.cs`**: Archivo principal que contendrá el punto de entrada (`Main`) y la lógica de navegación procedural.
- **Carpetas `bin/` y `obj/`**: Directorios autogenerados por el compilador para el almacenamiento temporal de binarios.
- **`.gitignore`**: Configurado para omitir archivos de compilación, temporales del IDE y dependencias locales.
- **`README.md`**: Bitácora de seguimiento y documentación del desarrollo por iteraciones (Git Flow).