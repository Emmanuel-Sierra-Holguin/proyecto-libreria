# 📚 Sistema de Gestión de Biblioteca (Consola C# / .NET)

**Aprendiz / Autor:** Emmanuel Sierra Holguín  
**Ficha:** 3412768  
**Curso:** Desarrollo C#  
**Instructor:** Carlos Navia  

---

## 🎯 Descripción General del Proyecto

Este proyecto consiste en el desarrollo de un sistema de gestión bibliotecaria operado por consola en **C# (.NET)**. El software evolucionó de manera incremental desde una infraestructura estrictamente procedural hacia una arquitectura modular en capas basada en **Programación Orientada a Objetos (POO)**, colecciones dinámicas `List<T>` en memoria RAM y flujo de control de versiones **Git Flow**.

---

## 🛠️ Tecnologías y Herramientas Utilizadas

* **Lenguaje y Framework:** C# (.NET)
* **Entorno de Desarrollo (IDE):** Visual Studio Code
* **Control de Versiones:** Git & GitHub
* **Metodología de Ramificación:** Git Flow (`main`, `develop`, y ramas `feature/*`)

---

## 📁 Estructura del Proyecto

```text
└── 📁 proyecto-libreria
    └── 📁 BibliotecaMenu
        ├── 📁 bin/
        ├── 📁 obj/
        ├── 📁 Models/
        │   ├── 📄 EstadoPrestamo.cs
        │   ├── 📄 Libro.cs
        │   ├── 📄 Prestamo.cs
        │   └── 📄 Usuario.cs
        ├── 📁 Services/
        │   ├── 📄 LibroService.cs
        │   ├── 📄 PrestamoService.cs
        │   └── 📄 UsuarioService.cs
        ├── 📄 BibliotecaMenu.csproj
        └── 📄 Program.cs
    ├── 📄 .gitignore
    └── 📄 README.md
```

---

## 🌿 Estrategia de Ramificación (Git Flow)

El ciclo de vida del desarrollo se gestionó mediante ramas `feature/*` creadas a partir de `develop` y consolidadas finalmente en `main`:

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
         ├──► feature/models-testing-objetos                                │
         └──► feature/services-collections (List<T> y lógica de negocio) ───┘
```

---

## 🧭 Parte 1: Infraestructura de Menús y Flujo en Consola (`Program.cs`)

En esta etapa se construyó la navegación e interacción por consola utilizando estructuras de control (`while`, `switch/case`, `if/else`), validaciones seguras de entrada (`TryParse`, campos obligatorios y conservación de valores actuales con `Enter`) y delegación hacia la capa de servicios.

### 🗺️ Flujo del Menú Interactivo Implementado

* **Comparación Array vs `List<T>` (`0`):** Demostración práctica en consola sobre tamaño fijo vs crecimiento dinámico (`.Add()`, `.Remove()`, `.Count`).
* **Libros (`ShowBooksMenu`):**
  * `1.1` Registrar libro
  * `1.2` Listar libros (Todos, Disponibles, Prestados)
  * `1.3` Ver detalle por ID
  * `1.4` Actualizar libro (Título, Autor, Categoría, Año)
  * `1.5` Eliminar libro (bloqueado si tiene préstamo activo)
* **Usuarios (`ShowUsersMenu`):**
  * `2.1` Registrar usuario (con activación de estado)
  * `2.2` Listar usuarios
  * `2.3` Ver detalle por ID
  * `2.4` Actualizar usuario (Nombre, Correo/Contacto, Activar/Desactivar)
  * `2.5` Eliminar usuario (bloqueado si tiene préstamos sin devolver)
* **Préstamos (`ShowloansMenu`):**
  * `3.1` Crear préstamo (validando usuario activo y libro disponible)
  * `3.2` Listar préstamos (Todos, Activos, Devueltos, Vencidos)
  * `3.3` Ver detalle por ID
  * `3.4` Registrar devolución (libera disponibilidad del libro y registra fecha)
  * `3.5` Eliminar préstamo
* **Búsquedas y Reportes (`ShowSearchReportsMenu`):**
  * `4.1` Buscar libro (por ID, Título o Autor)
  * `4.2` Buscar usuario (por ID o Nombre)
  * `4.3` Ordenamientos y reportes (por usuario, por libro, vencidos, ordenados por año/nombre/fecha límite y resumen KPIs)
* **Guardar / Cargar Datos (`showSavedatamenu`):**
  * `5.1` Guardar datos simulados en memoria
  * `5.2` Cargar datos de prueba
  * `5.3` Reiniciar datos a cero previa confirmación `Si/No`
* **Salida Inteligente (`ConfirmExitAndSave`):**
  * Evalúa si existen cambios sin guardar, solicita confirmación y muestra un resumen de sesión antes de cerrar.

---

## 🏗️ Parte 2: Modelo de Dominio y Programación Orientada a Objetos (`Models/`)

Encapsula las entidades principales del negocio dentro del namespace `BibliotecaMenu.Models`:

* **`Libro.cs`:**
  * **Propiedades:** `Id` (autogenerado `LIB-`), `Titulo`, `Autor`, `Categoria`, `Anio`, `Disponible` (`true` por defecto).
  * **Constructores:** Vacío y completo.
  * **Métodos:** `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.
* **`Usuario.cs`:**
  * **Propiedades:** `Id` (autogenerado `USU-`), `Nombre`, `Correo`, `Telefono`, `Activo` (`true` por defecto).
  * **Constructores:** Vacío y completo.
  * **Métodos:** `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.
* **`EstadoPrestamo.cs` (`enum`):**
  * Define los estados fijos del ciclo de vida de un préstamo: `Activo`, `Devuelto`, `Vencido`.
* **`Prestamo.cs`:**
  * **Propiedades:** `Id` (`PRE-`), vinculación con `Libro` y `Usuario`, fechas con `DateTime` (`FechaInicio`, `FechaLimite`) y `DateTime?` (`FechaDevolucion = null`), y `Estado` (`EstadoPrestamo.Activo`).
  * **Reglas de Negocio:** Al instanciar un préstamo cambia automáticamente el libro a `Disponible = false`.
  * **Métodos:** `EstaVencido()`, `DiasTranscurridos()`, `ResumenCorto()`, `DetalleCompleto()`, `ToString()`.

---

## ⚙️ Parte 3: Servicios y Colecciones Dinámicas (`Services/`)

Separa la lógica de negocio de la interfaz de consola encapsulando listas privadas `List<T>` en cada servicio:

* **`LibroService.cs`:** Gestiona `List<Libro>` con CRUD completo (`.Add()`, `.Remove()`), búsquedas por ID (`Libro?`), título y autor, ordenamiento por año sobre copia (`new List<Libro>(...)`) sin alterar la lista original, protección contra eliminación de libros prestados y conteos (`TotalLibros()`, `LibrosDisponibles()`, `LibrosPrestados()`).
* **`UsuarioService.cs`:** Gestiona `List<Usuario>` con altas, bajas, edición, búsqueda por ID (`Usuario?`) o nombre, ordenamiento alfabético sobre copia (`OrdenarPorNombre()`) y métricas de usuarios activos/inactivos.
* **`PrestamoService.cs`:** Coordina `List<Prestamo>` validando reglas cruzadas antes de prestar, filtrando por estado (`ObtenerActivos()`, `ObtenerDevueltos()`, `ObtenerVencidos()`), gestionando devoluciones (`RegistrarDevolucion(...)`), verificando préstamos activos por usuario (`TienePrestamoActivoUsuario(...)`) y calculando KPIs como `PromedioDiasPrestamo()`.

---

## ▶️ Ejecución del Proyecto

Clona el repositorio y ubícate en la carpeta del proyecto:

```bash
cd proyecto-libreria/BibliotecaMenu
```

Ejecuta el proyecto mediante el CLI de .NET:

```bash
dotnet run
```