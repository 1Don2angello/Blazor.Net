
CREATE TABLE Usuers
(
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50)
);
INSERT INTO Usuers (Nombre, Apellido)
VALUES
    ('Juan', 'Pérez'),
    ('María', 'López'),
    ('Pedro', 'García'),
    ('Ana', 'Martínez'),
    ('Luis', 'Rodríguez');
