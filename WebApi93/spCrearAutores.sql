alter procedure spCrearAutor
@Nombre varchar (20),
@Nacionalidad varchar(20)
as 
begin 
	insert into Autores values (@Nombre, @Nacionalidad)
	select * from Autores
	where Nombre = @Nombre;
end

---Ejecutar prueba 
exec spCrearAutor 'prueba','prueba' 
----Mostrar prueba 
select * from Autores;