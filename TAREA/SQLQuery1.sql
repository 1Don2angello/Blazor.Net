
CREATE TABLE Usuers
(
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50)
);
INSERT INTO Usuers (Nombre, Apellido)
VALUES
    ('Juan', 'P�rez'),
    ('Mar�a', 'L�pez'),
    ('Pedro', 'Garc�a'),
    ('Ana', 'Mart�nez'),
    ('Luis', 'Rodr�guez');
