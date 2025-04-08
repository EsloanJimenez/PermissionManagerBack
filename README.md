1- Clonar o descargar el repositorio
2- Configuración en Microsoft SQL Serve Management Studio
Este hay que configurarlo para iniciar seccion con SQL Serve Autentication, creándole un usuario y contraseña. Aqui debajo le dejo un enlace donde se explica como configurar a Management Studio para utilizar Autenticación ⬇️
https://www.youtube.com/watch?v=yXhjFOvNyR4
3- CONEXIÓN A LA BASE DE DATOS
Para la conexión a la base de datos, utilizamos ConnectionString con SQL SERVE AUTENTICACION. En el archivo appsettings.json van a ver ese JSON
"ConnectionStrings": { "AppPermission": "Server=NOMBRE-SERVIDOR;Database=NOMBRE-BASE-DE-DATOS;User Id=NOMBRE-DE-USUARIO;Password=CONTRASEÑA" },
estos datos se van a remplazar por los suyos.
De igual manera la base de datos con sus tablas se las facilito en el repositorio.
4- INSTALACION DE LOS NuGet Packages
los paquetes que debemos de instalar son los siguientes
4.1- API 4.1.1- AutoMapper.Extensions.Microsoft.DependencyInjection
4.1.2- Microsoft.EntityFrameworkCore.Design
4.2- INFRASTRUCTURE 4.2.1- AutoMapper.Extensions.Microsoft.DependencyInjection
4.2.2- Microsoft.EntityFrameworkCore.SqlServer

4.2.3- Microsoft.EntityFrameworkCore.Tools
5- COMPILAR
Compila ejecutando el archivo PermissionManager.sln
