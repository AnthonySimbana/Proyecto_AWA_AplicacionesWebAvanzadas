<h1 align="center"> ProyectoAWA - Warcraft Friends </h1> 
Proyecto Aplicaciones Web Avanzadas

## Breve descripción:

Chat comunitario diseñado para jugadores de Warcraft. Los usuarios pueden acceder al sistema mediante un proceso de inicio de sesión que requiere su correo electrónico y contraseña asociada. Una vez autenticados, los usuarios tienen la capacidad de agregar hasta seis personajes los cuales podrán ser seleccionados para adentrarse en el chat de la comunidad.


## Autores:

- Cabrera Danny
- Lincango Dennis
- Pallo Fredy 
- Simbaña Anthony


Para replicar el proyecto:
Abrir Visual Studio, clonar el repositorio.
Ejecutar los microservicios (MicroServiceCharacter, MicroServiceUser, WebsocktChatRoom) without debug y finalmente ejecutar el aplicativo principal (WebAppWarcraftFriends)

El proyecto se encuentra conectado a una base de datos en Azure la cual se encuentra desactiva, se debe configurar una nueva conexion a la base de datos en los appsetings.json de cada microservicio.

El microservicio de websockets no se encuentra conectado a ninguna base de datos.

