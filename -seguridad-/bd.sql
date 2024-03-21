create database Seguridad;
use Seguridad;

create TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50)
);

INSERT INTO Usuarios (Nombre, Apellido)
VALUES ('Juan', 'Perez'),
       ('Mar�a', 'Gonz�lez'),
       ('Pedro', 'L�pez');


select * from Usuarios


CREATE TABLE Logs (
   Id INT IDENTITY(1,1) PRIMARY KEY,
    IpAdress NVARCHAR(50),
    Respuesta NVARCHAR(MAX),
    Datos NVARCHAR(MAX),
    Funcion NVARCHAR(50)
);
INSERT INTO Logs (IpAdress, Respuesta, Datos, Funcion)
VALUES ('192.168.1.1', 'OK', 'Datos de ejemplo', 'FuncionEjemplo');
