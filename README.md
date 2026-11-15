```markdown
# 📚 Sistema de Gestión de Biblioteca (Consola C# / .NET)

**Aprendiz / Autor:** Emmanuel Sierra Holguín  
**Ficha:** 3412768  
**Curso:** Desarrollo C#  
**Instructor:** Carlos Navia  

---

## 🎯 Descripción General del Proyecto

Este proyecto consiste en el desarrollo de un sistema de gestión bibliotecaria operado por consola en C# (.NET). El software se construyó de manera incremental en dos grandes fases, evolucionando desde una infraestructura estrictamente procedural hacia una arquitectura modular basada en Programación Orientada a Objetos (POO), todo bajo la metodología de control de versiones Git Flow.

---

## 🛠️ Tecnologías y Herramientas Utilizadas

* **Lenguaje de Programación:** C# (.NET)
* **Entorno de Desarrollo (IDE):** Visual Studio Code
* **Control de Versiones:** Git & GitHub
* **Metodología de Ramificación:** Git Flow (`main`, `develop`, y ramas `feature/*`)

---

## 📁 Estructura del Proyecto

```text
└── 📁 proyecto-libreria
    ├── 📁 img/
    │   ├── 🖼️ Prueba1.png
    │   └── 🖼️ Prueba2.png
    └── 📁 BibliotecaMenu
        ├── 📁 bin/
        ├── 📁 obj/
        ├── 📁 Models/
        │   ├── 📄 EstadoPrestamo.cs
        │   ├── 📄 Libro.cs
        │   ├── 📄 Prestamo.cs
        │   └── 📄 Usuario.cs
        ├── 📄 BibliotecaMenu.csproj
        └── 📄 Program.cs
    ├── 📄 .gitignore
    └── 📄 README.md

```

---

## 🌿 Estrategia de Ramificación (Git Flow)

El ciclo de vida del desarrollo se gestionó mediante ramas `feature/` creadas a partir de `develop` y consolidadas finalmente en `main`:

```text
main ───────────────────────────────────────────────────────────────────► [Release Final]
  │                                                                         ▲
  └──► develop ─────────────────────────────────────────────────────────────┤
         ├──► feature/project-bootstrap                                     │
         ├──► feature/main-menu-navigation                                  │
         ├──► feature/books-menu                                            │
         ├──► feature/users-menu                                            │
         ├──► feature/loans-menu                                            │
         ├──► feature/search-reports-menu                                   │
         ├──► feature/persistence-menu                                      │
         ├──► feature/exit-flow                                             │
         ├──► feature/models-libro                                          │
         ├──► feature/models-usuario                                        │
         ├──► feature/models-enum-estado-prestamo                           │
         ├──► feature/models-prestamo                                       │
         └──► feature/models-testing-objetos ───────────────────────────────┘

```

---

## 🧭 Parte 1: Infraestructura Procedural y Navegación (EV06)

En esta primera etapa se construyó la lógica de navegación e interacción por consola utilizando exclusivamente funciones estáticas (`static void`), estructuras de control (`while`, `switch/case`, `if/else`) y variables globales en memoria RAM (sin clases de dominio, colecciones ni archivos físicos).

### 🗺️ Flujo del Menú Interactivo Implementado

* **Libros (`ShowBooksMenu`):**
* **1.1** Registrar libro (`RegisterBook`)
* **1.2** Listar libros (`ListBookMenu`: Todos, Disponibles, Prestados)
* **1.3** Ver detalle por ID (`ViewBookDetail`)
* **1.4** Actualizar libro (`UpdateBookMenu`: Título, Autor, Año/Categoría)
* **1.5** Eliminar libro (`DeleteBook` — con validación de préstamo activo)


* **Usuarios (`ShowUsersMenu`):**
* **2.1** Registrar usuario (`RegisterUser` — con activación de estado)
* **2.2** Listar usuarios (`ListUsers`)
* **2.3** Ver detalle por ID (`ViewUserDetail`)
* **2.4** Actualizar usuario (`UpdateUserMenu`: Nombre, Contacto, Activar/Desactivar)
* **2.5** Eliminar usuario (`DeleteUser` — con validación de préstamo activo)


* **Préstamos (`ShowloansMenu`):**
* **3.1** Crear préstamo (`CreateLoan` — asignación de fechas `DateTime.Now` y validaciones cruzadas)
* **3.2** Listar préstamos (`ListLoansMenu`: Todos, Activos, Cerrados)
* **3.3** Ver detalle por ID (`ViewLoanDetail`)
* **3.4** Registrar devolución (`RegisterReturn` — libera disponibilidad del libro)
* **3.5** Eliminar préstamo (`DeleteLoan`)


* **Búsquedas y Reportes (`ShowSearchReportsMenu`):**
* **4.1** Buscar libro (`SearchBook` — por ID, Título, Autor o Categoría)
* **4.2** Buscar usuario (`SearchUser` — por ID o Nombre)
* **4.3** Reportes (`ReportsMenu` — por usuario, por libro, vencidos y resumen general)


* **Guardar / Cargar Datos (`showSavedatamenu`):**
* **5.1** Guardar datos simulados en memoria (`SaveData`)
* **5.2** Cargar datos simulados (`LoadData`)
* **5.3** Reiniciar datos a cero previa confirmación Si/No (`ResetData`)


* **Salida Inteligente (`ConfirmExitAndSave`):**
* Evalúa si existen cambios sin guardar, solicita confirmación y genera un recibo visual en consola con los IDs procesados durante la sesión.



---

## 🏗️ Parte 2: Modelo de Dominio y Programación Orientada a Objetos (EV07)

En esta segunda fase, el sistema dio el salto arquitectónico hacia la Programación Orientada a Objetos (POO), encapsulando las entidades principales dentro del namespace `BibliotecaMenu.Models`:

### 🧩 Entidades y Componentes del Modelo (`Models/`)

* **`Libro.cs`**:
* **Propiedades:** `Id` (autogenerado con prefijo `LIB-`), `Titulo`, `Autor`, `Categoria`, `Anio`, `Disponible` (inicializado en `true`).
* **Constructores:** Vacío y completo.
* **Métodos:** `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.


* **`Usuario.cs`**:
* **Propiedades:** `Id` (autogenerado con prefijo `USU-`), `Nombre`, `Correo`, `Telefono`, `Activo` (inicializado en `true`).
* **Constructores:** Vacío y completo.
* **Métodos:** `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.


* **`EstadoPrestamo.cs` (`enum`)**:
* Define los estados estrictos del ciclo de vida de un préstamo: `Activo`, `Devuelto`, `Vencido`.


* **`Prestamo.cs`**:
* **Propiedades:** `Id` (prefijo `PRE-`), vinculación de datos con `Libro` y `Usuario`, manejo de fechas con `DateTime` (`FechaInicio`, `FechaLimite`) y `DateTime?` (`FechaDevolucion = null`), `Estado` (`EstadoPrestamo.Activo`) y `PrestamoActivo`.
* **Reglas de Negocio:** Al instanciar un préstamo, cambia automáticamente el estado del libro asociado a `Disponible = false`.
* **Métodos:** `EstaVencido()`, `DiasTranscurridos()`, `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.



### 🧪 Pruebas y Validación de Objetos (`PruebaPoo`)

Dentro de `Program.cs` (rama `feature/models-testing-objetos`) se implementó el método estático `PruebaPoo()`, el cual se ejecuta al iniciar el programa antes de desplegar el menú principal para validar:

* Instanciación de 2 libros reales (*Clean Code*, *Cien años de soledad*) y 2 usuarios.
* Visualización de resúmenes cortos (`ToString()`) y fichas detalladas (`DetalleCompleto()`).
* Creación de 1 préstamo vinculando libro y usuario, verificando el cambio automático de disponibilidad, cálculo de días transcurridos y estado activo.

---

## ▶️ Ejecución del Proyecto

Para compilar y ejecutar la aplicación de consola en tu entorno local:

1. Clona el repositorio y ubícate en la carpeta del proyecto:
```bash
cd proyecto-libreria/BibliotecaMenu

```


2. Ejecuta el proyecto mediante el CLI de .NET:
```bash
dotnet run

```



---

