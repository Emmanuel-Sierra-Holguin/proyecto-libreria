Proyecto Sintaxis en C# - Parte 1

Sistema de Gestión de Biblioteca (Navegación y Menús)

📋 Información General

Aprendiz: Emmanuel Sierra Holguín

Ficha: 3412768

Curso: Desarrollo C#

Instructor: Carlos Navia

Fecha / Hora de Inicio: 28/10/2026 - 14:04 PM

# 🎯 Descripción de la Actividad

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

Menú principal
1. Libros
2. Usuarios
3. Préstamos
4. Búsquedas y reportes
5. Guardar / Cargar datos
6. Salir

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

📋 Checklist de funciones sugeridas (nombres exactos recomendados)

Menús y navegación
• ShowMainMenu()
• ShowBooksMenu()
• ShowUsersMenu()
• ShowLoansMenu()
• ShowSearchReportsMenu()
• showSavedatamenu()
• ConfirmExitAndSave()
• ShowReturnMenu()


1) Libros
• RegisterBook()
• ListBooksMenu()
• ListBooksAll()
• ListBooksAvailable()
• ListBooksBorrowed()
• ViewBookDetail()
• UpdateBookMenu()
• EditBookTitle()
• EditBookAuthor()
• EditBookYearCategory()
• DeleteBook()
• ShowReturnMenu()

2) Usuarios
• RegisterUser()
• ListUsers()
• ViewUserDetail()
• UpdateUserMenu()
• EditUserName()
• EditUserContact()
• ToggleUserActiveStatus()
• DeleteUser()

3) Préstamos
• CreateLoan() (imprime validaciones sugeridas)
• ListLoansMenu()
• ListLoansAll()
• ListLoansActive()
• ListLoansClosed()
• ViewLoanDetail()
• RegisterReturn()
• DeleteLoan()

4) Búsquedas y reportes
• SearchBook()
• SearchUser()
• ReportsMenu() (o ShowReportsMenu())
• ReportByUser()
• ReportByBook()
• ReportOverdue()
• ReportSummary()

5) Guardar / cargar
• SaveData()
• LoadData()
• ResetData()

# 🚀 Fase inicial : Bootstrap del Proyecto (feature/project-bootstrap)

Se ha inicializado la estructura base del sistema de consola en C# para la biblioteca:
- **`BibliotecaMenu.csproj`**: Archivo de proyecto y configuración general de .NET.
- **`Program.cs`**: Archivo principal que contendrá el punto de entrada (`Main`) y la lógica de navegación procedural.
- **Carpetas `bin/` y `obj/`**: Directorios autogenerados por el compilador para el almacenamiento temporal de binarios.
- **`.gitignore`**: Configurado para omitir archivos de compilación, temporales del IDE y dependencias locales.
- **`README.md`**: Bitácora de seguimiento y documentación del desarrollo por iteraciones (Git Flow).

# 🚀 Fase 1: Menú de Navegación e Infraestructura Base (`feature/main-menu-navigation`)

Se ha inicializado y consolidado la arquitectura base del sistema de biblioteca bajo un paradigma estrictamente procedural.

### 🛠️ Cambios y Características Implementadas:
- **Arquitectura Modular Padre-Hijo:** Se estructuró una función central (`ShowMainMenu`) encargada de enrutar el flujo de ejecución hacia cinco submódulos independientes.
- **Control de Flujo con Banderas:** Uso de un bucle de control booleano (`Exit`) para mantener el sistema activo y permitir un cierre de ciclo limpio.
- **Función Reutilizable de Retorno:** Se incorporó `ShowReturnMenu()` para estandarizar la pausa de pantalla y facilitar la navegación fluida de regreso al menú principal cuando el usuario cometa un error en la opcion.
- **Estabilidad Visual y Pruebas:** Funciones preliminares configuradas con bloques de prueba para verificar la correcta redirección y respuesta de cada submódulo.


# 🚀 Fase 2: Menu de libros (`feature/books-menu`)
Se ha implementado de forma completa el CRUD del Módulo de Libros bajo un modelo estrictamente procedural.

### 🛠️ Cambios y Características Implementadas:
Estado Global en Memoria: Declaración de variables globales simples para simular la persistencia y gestión de datos de un libro a la vez sin usar clases ni colecciones.

- Operaciones CRUD Completas: Implementación de funciones estáticas para Registrar, Listar (Todos / Disponibles / Prestados), Ver Detalle por ID, Actualizar campos individualmente y Eliminar.

- Navegación e Interacción Estable: Corrección de bucles while con negación (!volverMenu) y control de parpadeos en consola mediante pausas de pantalla estandarizadas con ShowReturnMenu().

- Integración al Menú Principal: Enrutamiento funcional del menú de libros desde ShowMainMenu con validación básica de opciones ingresadas.

# 🚀 Fase 3: Módulo de Usuarios (`feature/users-menu`)
Se ha implementado de forma completa el módulo de gestión de usuarios bajo el paradigma estrictamente procedural del proyecto.

### 🛠️ Cambios y Características Implementadas:
- Estado Global en Memoria: Declaración de variables globales (usuarioID, usuarioNombre, usuarioContacto, usuarioActivo) para simular la persistencia y gestión de un único usuario activo a la vez sin necesidad de clases ni colecciones complejas.

- Operaciones CRUD Esenciales: Creación de funciones estáticas para el registro de usuarios (incorporando la configuración de estado activo/inactivo mediante validación de texto con .ToLower()), listados generales, consulta detallada por documento/ID, actualización segmentada (nombre, contacto y alternancia de estado) y eliminación con reseteo de variables.

- Navegación e Interfaz Estabilizada: Integración de un submenú independiente controlado por bucles while con negación (!volverMenu) y pausas de pantalla estandarizadas mediante ShowReturnMenu().

- Enrutamiento Principal: Conexión limpia y directa del submódulo de usuarios desde la función central ShowMainMenu.


# 🚀 Fase 4: Módulo de Préstamos y Validaciones Cruzadas

En esta fase se completa el ciclo del MVP del Sistema de Gestión de Biblioteca, implementando la lógica procedural para la administración de préstamos temporales, control de estados de libros/usuarios y restricciones de integridad entre módulos.

### 🛠️ Características Principales
- **Registro de Préstamo (`CreateLoan`):** Asignación automática de marcas de tiempo (`DateTime.Now` con formato `dd/MM/yyyy`), definición de fecha límite, vinculación con un registro activo de usuario (`usuarioActivo`) y libro disponible (`libroDisponible`).
- **Control de Estados y Trazabilidad:** Manejo de fechas de devolución diferidas (`fechaDevolucion` inicializada en `"Pendiente"` o `"N/A"`) y control de estado dinámico (`"Activo"` / `"Devuelto"`).
- **Validaciones e Integridad Cruzada:**
  - Impedimento de eliminación de libros o usuarios si poseen un préstamo activo en curso.
  - Actualización automática de disponibilidad del libro (`libroDisponible = true`) tras concretar la devolución o al eliminar un registro de préstamo activo por excepción.
- **Listados Filtrados y Detalle (`ListLoansMenu` / `ViewLoanDetail`):** Consulta por submenús para visualizar todos los préstamos, solo activos, cerrados/devueltos, o el detalle por `prestamoID`.


# 🚀Fase 5: Modulo de busquedas y reportes (`feature/search-reports-menu`)

En esta fase se completa el módulo de Búsquedas y Reportes del Sistema de Gestión de Biblioteca, implementando la lógica procedural para la localización de registros por múltiples criterios y la generación de reportes consolidados en tiempo real (por usuario, por libro, préstamos vencidos y resumen general del estado del sistema).

### 📊 Módulo de Reportes (Fase 5)
- **Menú de Reportes (`ReportsMenu`):** Centraliza la navegación hacia los cuatro reportes del sistema.
- **Préstamos por Usuario y Libro (`ReportByUser` y `ReportByBook`):** Filtran y muestran la información detallada del historial y estado de préstamos según el ID ingresado.
- **Seguimiento de Vencidos (`ReportOverdue`):** Identifica y muestra los préstamos activos pendientes de devolución y su fecha límite.
- **Resumen General (`ReportSummary`):** Presenta un consolidado en tiempo real con contadores de libros (disponibles/prestados) y el estado dinámico del usuario y préstamo registrado mediante condicionales `if-else` limpios.

# 🚀 Fase 6: Módulo de Guardar y Cargar Datos (feature/persistence-menu)
### 💾 Persistencia Simulada y Cierre Seguro (Fase 6)
Guardar y Cargar Simulado (SaveData y LoadData): Simulan el almacenamiento y la recuperación del estado actual del sistema (libros, usuarios y préstamos) en memoria RAM mediante confirmaciones visuales por consola, sin manipular archivos físicos del disco duro (System.IO).

Reinicio del Sistema (ResetData): Restablece todas las variables globales a su estado inicial en cero, previa confirmación interactiva de seguridad por parte del usuario (Si/No).

Salida Inteligente (ConfirmExitAndSave): Evalúa si la sesión cuenta con cambios guardados en memoria; de lo contrario, solicita al usuario confirmación para guardar antes de salir e imprime un recibo visual de confirmación con los registros procesados para cerrar la consola de forma segura.


# 📌 Resumen de la Fase Final: Simulación Pura en Consola
Alineación 100% con la Rúbrica SENA:

Se eliminó completamente la dependencia de persistencia física en disco duro (System.IO, archivos .txt).

El sistema opera únicamente en memoria RAM mediante programación estructurada y funciones estáticas, garantizando cero POO y cero colecciones reales.

Módulo de Guardar / Cargar Simulado:

SaveData(): Confirma y muestra el guardado simulado del estado del sistema en memoria.

LoadData(): Simula la lectura de registros previamente cargados.

ResetData(): Solicita confirmación interactiva (Si/No) antes de vaciar las variables globales en memoria RAM.

Salida Inteligente con Recibo en Pantalla:

ConfirmExitAndSave(): Evalúa la bandera datosGuardados. Si hay cambios pendientes, consulta si se desea guardar antes de salir y genera en consola un recibo visual resumido (Acroform/Ticket) con los IDs activos de libro, usuario y préstamo procesados durante la sesión.

Navegación y Validaciones:

Mantiene el control mediante bucles while y bloques switch/case con sus opciones default para captura de entradas inválidas, garantizando opciones operativas de volver, confirmar y salir.