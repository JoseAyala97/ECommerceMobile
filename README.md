# Proyecto Backend en .NET 8
Este proyecto está desarrollado en C# con .NET 8, utilizando Clean Architecture y el patrón de diseño-arquitectónico CQRS. A continuación, se detallan las instrucciones para configurar y utilizar el proyecto.

# Estructura del Proyecto
El proyecto se divide en dos bases de datos:

- Base de datos de usuarios y roles: Utiliza Identity para la gestión de usuarios y roles.
- Base de datos de productos: Maneja la lógica relacionada con los productos.
# Configuración de la Base de Datos
Para configurar las bases de datos, es necesario realizar las migraciones correspondientes. Ejecuta los siguientes comandos en la consola del administrador de paquetes de Visual Studio o en la terminal de .NET CLI:

# Migraciones para la Base de Datos de Productos
- add-migration "nombre_deseado" -context ECommerceMobileDbContext
- update-database -context ECommerceMobileDbContext

# Migraciones para la Base de Datos de Identity
- add-migration "nombre_deseado" -context ECommerceMobileIdentityDbContext
- update-database -context ECommerceMobileIdentityDbContext

Estos comandos crearán las tablas necesarias en las bases de datos.

# Registro de Usuarios
Para registrar un nuevo usuario, utiliza el endpoint de register. Asegúrate de seguir las validaciones correspondientes para la creación de usuarios.

# Gestión de Imágenes
El proyecto utiliza Cloudinary para el manejo de imágenes de productos. Puedes realizar operaciones de POST y GET para subir y recuperar imágenes respectivamente.

# Tecnologías Utilizadas
- C# y .NET 8
- Clean Architecture
- CQRS
- Identity para gestión de usuarios y roles
- Cloudinary para manejo de imágenes
- Swagger (documentation)

# Requisitos
- .NET 8 SDK
- Visual Studio o una terminal compatible con .NET CLI

# Instalación y Ejecución
- Clona el repositorio del proyecto.
- Abre el proyecto en Visual Studio o utiliza la terminal para navegar a la carpeta del proyecto.
- Ejecuta los comandos de migración descritos anteriormente para configurar las bases de datos.
- Asegúrate de que el servicio de Cloudinary esté configurado adecuadamente en el proyecto.

# Planes Futuros
Para futuras versiones, se planea:

- Eliminar código hardcodeado: Refactorizar el código para eliminar valores y configuraciones codificados directamente en el código fuente.
- Implementar Docker Compose: Configurar Docker Compose para simplificar la ejecución del proyecto, permitiendo que se ejecute con un solo comando.
