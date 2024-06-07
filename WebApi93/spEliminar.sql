create PROCEDURE [dbo].[spEliminarAutor]
    @PkAutor INT
AS
BEGIN
    DELETE FROM Autores
    WHERE PkAutor = @PkAutor;

	Select * from Autores

END;