drop table Logs
CREATE TABLE Logs (
    Id INT IDENTITY(1,1) NOT NULL,
    Fecha DATETIME,
    Mensaje NVARCHAR(MAX),
    IpAddress NVARCHAR(50),
    NomFuncion NVARCHAR(50),
    StatusLog NVARCHAR(50),
    Datos NVARCHAR(MAX)
);

select * from Logs