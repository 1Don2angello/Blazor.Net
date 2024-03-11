CREATE TABLE Users (
    PkUser INT PRIMARY KEY,
    Nombre VARCHAR(255),
    Apellido VARCHAR(255)
);

CREATE TABLE logs2 (
    id INT PRIMARY KEY,
    ipadrres VARCHAR(255),
    funcion VARCHAR(255),
    respuesta VARCHAR(255),
    datos VARCHAR(255)
);
INSERT INTO Users (PkUser, Nombre, Apellido) VALUES (1, 'John', 'Doe');
INSERT INTO Users (PkUser, Nombre, Apellido) VALUES (2, 'Jane', 'Doe');
INSERT INTO Users (PkUser, Nombre, Apellido) VALUES (3, 'Bob', 'Smith');

INSERT INTO logs2 (id, ipadrres, funcion, respuesta, datos) VALUES (1, '127.0.0.1', 'login', 'success', '');
INSERT INTO logs2 (id, ipadrres, funcion, respuesta, datos) VALUES (2, '192.168.1.1', 'login', 'failure', '');
INSERT INTO logs2 (id, ipadrres, funcion, respuesta, datos) VALUES (3, '10.0.0.1', 'logout', 'success', '');
				2

select * from Users;
select * from logs2;