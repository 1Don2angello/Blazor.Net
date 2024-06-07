create PROCEDURE [dbo].[spEditarAutor]
    @PkAutor INT,
    @Nombre VARCHAR(20),
    @Nacionalidad VARCHAR(20)
AS
BEGIN
    UPDATE Autores
    SET Nombre = @Nombre,
        Nacionalidad = @Nacionalidad
WHERE PkAutor = @PkAutor;

    SELECT *
    FROM Autores
    WHERE PkAutor = @PkAutor;
END