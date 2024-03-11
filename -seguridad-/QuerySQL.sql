create database Seguridad;
use Seguridad;

create table Usuarios(
	Id int identity(1,1) primary key,
	Nombre varchar(50),
	Apellido varchar(50)
)
select * from Usuarios

insert into Usuarios values('Aldo', 'Maldonado');
insert into Usuarios values('Felipe', 'Fernando');
insert into Usuarios values('Oliver', 'Olan');
-- Sí funciona Create en C#

create table Logs(
	Id int identity(1,1) primary key,
	IpAdress varchar(20),
	Respuesta varchar(20),
	Datos varchar(20),
	Funcion varchar(20)
)

Select * from Logs
