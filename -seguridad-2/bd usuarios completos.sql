--CREATE TABLE UsuariosCompletos (
--    Id INT IDENTITY(1,1) PRIMARY KEY,
--    Nombre NVARCHAR(50),
--    Apellido NVARCHAR(50),
--    Edad INT,
--    Email NVARCHAR(100),
--    Telefono NVARCHAR(20),
--    Direccion NVARCHAR(100),
--    Ciudad NVARCHAR(50),
--    Pais NVARCHAR(50),
--    CodigoPostal NVARCHAR(10),
--    Genero NVARCHAR(10)
--); select * from UsuariosCompletos 
--------10
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Juan', 'P�rez', 30, 'juan.perez@example.com', '1234567890', 'Calle Falsa 123', 'Ciudad de M�xico', 'M�xico', '12345', 'Masculino'),
--('Ana', 'Garc�a', 25, 'ana.garcia@example.com', '0987654321', 'Avenida Siempre Viva 456', 'Bogot�', 'Colombia', '54321', 'Femenino'),
--('Carlos', 'L�pez', 28, 'carlos.lopez@example.com', '5555555555', 'Boulevard de las Flores 789', 'Lima', 'Per�', '67890', 'Masculino'),
--('Mar�a', 'Mart�nez', 35, 'maria.martinez@example.com', '4444444444', 'Calle del Sol 101', 'Buenos Aires', 'Argentina', '98765', 'Femenino'),
--('Luis', 'Hern�ndez', 40, 'luis.hernandez@example.com', '3333333333', 'Avenida de la Luna 202', 'Santiago', 'Chile', '54321', 'Masculino'),
--('Sof�a', 'Gonz�lez', 22, 'sofia.gonzalez@example.com', '2222222222', 'Paseo de la Monta�a 303', 'Caracas', 'Venezuela', '56789', 'Femenino'),
--('Diego', 'Rodr�guez', 33, 'diego.rodriguez@example.com', '1111111111', 'Camino del R�o 404', 'Quito', 'Ecuador', '67890', 'Masculino'),
--('Luc�a', 'Fern�ndez', 29, 'lucia.fernandez@example.com', '6666666666', 'Ruta de la Selva 505', 'Asunci�n', 'Paraguay', '78901', 'Femenino'),
--('Javier', 'S�nchez', 38, 'javier.sanchez@example.com', '7777777777', 'V�a de las Estrellas 606', 'Montevideo', 'Uruguay', '89012', 'Masculino'),
--( 'Andrea', 'Ram�rez', 27, 'andrea.ramirez@example.com', '8888888888', 'Sendero de la Luna 707', 'La Paz', 'Bolivia', '90123', 'Femenino');
-----------20
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Roberto', 'Morales', 32, 'roberto.morales@example.com', '9999999999', 'Calle de los P�jaros 808', 'Madrid', 'Espa�a', '23456', 'Masculino'),
--('Patricia', 'Alvarez', 26, 'patricia.alvarez@example.com', '1231231234', 'Avenida del Mar 909', 'Lisboa', 'Portugal', '34567', 'Femenino'),
--('Alejandro', 'Cruz', 29, 'alejandro.cruz@example.com', '2342342345', 'Boulevard de las Rosas 1010', 'Roma', 'Italia', '45678', 'Masculino'),
--('Claudia', 'Gutierrez', 33, 'claudia.gutierrez@example.com', '3453453456', 'Calle del Bosque 1111', 'Par�s', 'Francia', '56789', 'Femenino'),
--('Fernando', 'Torres', 37, 'fernando.torres@example.com', '4564564567', 'Avenida del Sol 1212', 'Berl�n', 'Alemania', '67890', 'Masculino'),
--('Laura', 'Martinez', 24, 'laura.martinez@example.com', '5675675678', 'Paseo de la Playa 1313', 'Bruselas', 'B�lgica', '78901', 'Femenino'),
--('Daniel', 'Gomez', 31, 'daniel.gomez@example.com', '6786786789', 'Camino del Lago 1414', 'Viena', 'Austria', '89012', 'Masculino'),
--('Sara', 'Herrera', 28, 'sara.herrera@example.com', '7897897890', 'Ruta de las Monta�as 1515', 'Copenhague', 'Dinamarca', '90123', 'Femenino'),
--('Miguel', 'Jimenez', 36, 'miguel.jimenez@example.com', '8908908901', 'V�a de los Campos 1616', 'Helsinki', 'Finlandia', '01234', 'Masculino'),
--('Elena', 'Diaz', 25, 'elena.diaz@example.com', '9019019012', 'Sendero de los Lagos 1717', 'Estocolmo', 'Suecia', '12345', 'Femenino');
-------- 30
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Ricardo', 'N��ez', 34, 'ricardo.nunez@example.com', '9129129123', 'Calle de la Luz 1818', 'Dubl�n', 'Irlanda', '23456', 'Masculino'),
--('Carmen', 'L�pez', 30, 'carmen.lopez@example.com', '9239239234', 'Avenida de la Paz 1919', 'Reikiavik', 'Islandia', '34567', 'Femenino'),
--('Jos�', 'Mart�nez', 27, 'jose.martinez@example.com', '9349349345', 'Boulevard de la Esperanza 2020', 'Oslo', 'Noruega', '45678', 'Masculino'),
--('Isabel', 'Garc�a', 32, 'isabel.garcia@example.com', '9459459456', 'Calle del R�o 2121', '�msterdam', 'Pa�ses Bajos', '56789', 'Femenino'),
--('Antonio', 'Hern�ndez', 39, 'antonio.hernandez@example.com', '9569569567', 'Avenida de las Flores 2222', 'Bratislava', 'Eslovaquia', '67890', 'Masculino'),
--('Lorena', 'P�rez', 28, 'lorena.perez@example.com', '9679679678', 'Paseo de la Monta�a 2323', 'Ljubljana', 'Eslovenia', '78901', 'Femenino'),
--('Jorge', 'S�nchez', 35, 'jorge.sanchez@example.com', '9789789789', 'Camino de la Playa 2424', 'Varsovia', 'Polonia', '89012', 'Masculino'),
--('Paula', 'Rodr�guez', 24, 'paula.rodriguez@example.com', '9899899890', 'Ruta de las Colinas 2525', 'Atenas', 'Grecia', '90123', 'Femenino'),
--('Andr�s', 'G�mez', 38, 'andres.gomez@example.com', '9909909901', 'V�a de la Selva 2626', 'Bucarest', 'Rumania', '01234', 'Masculino'),
--('Marta', 'L�pez', 31, 'marta.lopez@example.com', '9019019012', 'Sendero de la Luna 2727', 'Sof�a', 'Bulgaria', '12345', 'Femenino');
---------40
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Carlos', 'Rivera', 36, 'carlos.rivera@example.com', '8128128123', 'Calle de la Alegr�a 2828', 'Belgrado', 'Serbia', '23456', 'Masculino'),
--('Daniela', 'Molina', 29, 'daniela.molina@example.com', '8238238234', 'Avenida del Bosque 2929', 'Zagreb', 'Croacia', '34567', 'Femenino'),
--('Felipe', 'Castro', 33, 'felipe.castro@example.com', '8348348345', 'Boulevard del Sol 3030', 'Praga', 'Rep�blica Checa', '45678', 'Masculino'),
--('Sandra', 'Ortiz', 26, 'sandra.ortiz@example.com', '8458458456', 'Calle del Mar 3131', 'Budapest', 'Hungr�a', '56789', 'Femenino'),
--('Ra�l', 'Guti�rrez', 38, 'raul.gutierrez@example.com', '8568568567', 'Avenida de la Estrella 3232', 'Minsk', 'Bielorrusia', '67890', 'Masculino'),
--('Ver�nica', 'Ruiz', 31, 'veronica.ruiz@example.com', '8678678678', 'Paseo del Lago 3333', 'Kiev', 'Ucrania', '78901', 'Femenino'),
--('Sergio', 'Moreno', 35, 'sergio.moreno@example.com', '8788788789', 'Camino de la Sierra 3434', 'Mosc�', 'Rusia', '89012', 'Masculino'),
--('Laura', 'Jim�nez', 22, 'laura.jimenez@example.com', '8898898890', 'Ruta de la Pradera 3535', 'Tallin', 'Estonia', '90123', 'Femenino'),
--('Oscar', 'Vargas', 40, 'oscar.vargas@example.com', '8908908901', 'V�a de la Costa 3636', 'Riga', 'Letonia', '01234', 'Masculino'),
--('Luc�a', 'Torres', 27, 'lucia.torres@example.com', '9019019012', 'Sendero del Valle 3737', 'Vilna', 'Lituania', '12345', 'Femenino');
--------50
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Diego', 'Ram�rez', 34, 'diego.ramirez@example.com', '7127127123', 'Calle de la Monta�a 3838', 'Estambul', 'Turqu�a', '23456', 'Masculino'),
--('Catalina', 'N��ez', 29, 'catalina.nunez@example.com', '7237237234', 'Avenida del R�o 3939', 'El Cairo', 'Egipto', '34567', 'Femenino'),
--('Iv�n', 'D�az', 32, 'ivan.diaz@example.com', '7347347345', 'Boulevard de la Luna 4040', 'Riad', 'Arabia Saudita', '45678', 'Masculino'),
--('M�nica', 'Herrera', 27, 'monica.herrera@example.com', '7457457456', 'Calle del Desierto 4141', 'Teher�n', 'Ir�n', '56789', 'Femenino'),
--('Gustavo', '�lvarez', 36, 'gustavo.alvarez@example.com', '7567567567', 'Avenida de la Playa 4242', 'Nueva Delhi', 'India', '67890', 'Masculino'),
--('Patricia', 'Moreno', 30, 'patricia.moreno@example.com', '7677677678', 'Paseo del Bosque 4343', 'Bangkok', 'Tailandia', '78901', 'Femenino'),
--('Luis', 'P�rez', 33, 'luis.perez@example.com', '7787787789', 'Camino de la Selva 4444', 'Pek�n', 'China', '89012', 'Masculino'),
--('Sof�a', 'Gonz�lez', 25, 'sofia.gonzalez@example.com', '7897897890', 'Ruta de las Colinas 4545', 'Tokio', 'Jap�n', '90123', 'Femenino'),
--('Marco', 'Rodr�guez', 38, 'marco.rodriguez@example.com', '7907907901', 'V�a de la Ciudad 4646', 'Se�l', 'Corea del Sur', '01234', 'Masculino'),
--('Alejandra', 'Mart�nez', 31, 'alejandra.martinez@example.com', '7017017012', 'Sendero de la Costa 4747', 'S�dney', 'Australia', '12345', 'Femenino');
------- 60
select * from UsuariosCompletos
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Julio', 'Castillo', 37, 'julio.castillo@example.com', '6126126123', 'Calle de la Paz 4848', 'Auckland', 'Nueva Zelanda', '23456', 'Masculino'),
--('Fernanda', 'Ortega', 28, 'fernanda.ortega@example.com', '6236236234', 'Avenida del Mar 4949', 'Ciudad del Cabo', 'Sud�frica', '34567', 'Femenino'),
--('Andr�s', 'Reyes', 31, 'andres.reyes@example.com', '6346346345', 'Boulevard de las Estrellas 5050', 'Lagos', 'Nigeria', '45678', 'Masculino'),
--('Carla', 'Romero', 26, 'carla.romero@example.com', '6456456456', 'Calle del Sol 5151', 'Nairobi', 'Kenia', '56789', 'Femenino'),
--('Roberto', 'Torres', 35, 'roberto.torres@example.com', '6566566567', 'Avenida de la Luna 5252', 'Casablanca', 'Marruecos', '67890', 'Masculino'),
--('Daniela', 'Soto', 29, 'daniela.soto@example.com', '6676676678', 'Paseo de la Monta�a 5353', 'El Cairo', 'Egipto', '78901', 'Femenino'),
--('H�ctor', 'Garc�a', 32, 'hector.garcia@example.com', '6786786789', 'Camino de la Playa 5454', 'Dub�i', 'Emiratos �rabes Unidos', '89012', 'Masculino'),
--('Mariana', 'V�zquez', 27, 'mariana.vazquez@example.com', '6896896890', 'Ruta de la Selva 5555', 'Singapur', 'Singapur', '90123', 'Femenino'),
--('Jos�', 'Hern�ndez', 39, 'jose.hernandez@example.com', '6906906901', 'V�a de la Ciudad 5656', 'Kuala Lumpur', 'Malasia', '01234', 'Masculino'),
--('Ana', 'L�pez', 30, 'ana.lopez@example.com', '6016016012', 'Sendero de las Colinas 5757', 'Bangkok', 'Tailandia', '12345', 'Femenino');
-------70

--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Pedro', 'Mart�nez', 36, 'pedro.martinez@example.com', '5125125123', 'Calle de la Armon�a 5858', 'Manila', 'Filipinas', '23456', 'Masculino'),
--('Sonia', 'Guti�rrez', 27, 'sonia.gutierrez@example.com', '5235235234', 'Avenida de la Esperanza 5959', 'Yakarta', 'Indonesia', '34567', 'Femenino'),
--('Alejandro', 'L�pez', 34, 'alejandro.lopez@example.com', '5345345345', 'Boulevard del R�o 6060', 'Ho Chi Minh', 'Vietnam', '45678', 'Masculino'),
--('Cecilia', 'Rodr�guez', 29, 'cecilia.rodriguez@example.com', '5455455456', 'Calle de la Luz 6161', 'Phnom Penh', 'Camboya', '56789', 'Femenino'),
--('David', 'G�mez', 38, 'david.gomez@example.com', '5565565567', 'Avenida del Bosque 6262', 'Vienti�n', 'Laos', '67890', 'Masculino'),
--('Leticia', 'P�rez', 32, 'leticia.perez@example.com', '5675675678', 'Paseo de la Monta�a 6363', 'Yang�n', 'Myanmar', '78901', 'Femenino'),
--('Miguel', 'S�nchez', 37, 'miguel.sanchez@example.com', '5785785789', 'Camino de la Playa 6464', 'Katmand�', 'Nepal', '89012', 'Masculino'),
--('Patricia', 'D�az', 28, 'patricia.diaz@example.com', '5895895890', 'Ruta de la Ciudad 6565', 'Tashkent', 'Uzbekist�n', '90123', 'Femenino'),
--('Javier', 'Hern�ndez', 33, 'javier.hernandez@example.com', '5905905901', 'V�a de la Selva 6666', 'Astana', 'Kazajist�n', '01234', 'Masculino'),
--('Mar�a', 'Gonz�lez', 31, 'maria.gonzalez@example.com', '5015015012', 'Sendero del Valle 6767', 'Biskek', 'Kirguist�n', '12345', 'Femenino');
--------80
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Fernando', 'Ruiz', 35, 'fernando.ruiz@example.com', '4124124123', 'Calle de la Victoria 6868', 'Dusamb�', 'Tayikist�n', '23456', 'Masculino'),
--('Laura', 'Morales', 26, 'laura.morales@example.com', '4234234234', 'Avenida de la Paz 6969', 'Taskent', 'Uzbekist�n', '34567', 'Femenino'),
--('Ra�l', 'Ortega', 33, 'raul.ortega@example.com', '4344344345', 'Boulevard de la Alegr�a 7070', 'Ashgabat', 'Turkmenist�n', '45678', 'Masculino'),
--('Carmen', 'Castro', 28, 'carmen.castro@example.com', '4454454456', 'Calle del Mar 7171', 'Teher�n', 'Ir�n', '56789', 'Femenino'),
--('V�ctor', 'Reyes', 37, 'victor.reyes@example.com', '4564564567', 'Avenida de las Estrellas 7272', 'Kabul', 'Afganist�n', '67890', 'Masculino'),
--('Silvia', 'Romero', 31, 'silvia.romero@example.com', '4674674678', 'Paseo del Sol 7373', 'Islamabad', 'Pakist�n', '78901', 'Femenino'),
--('Juan', 'Torres', 36, 'juan.torres@example.com', '4784784789', 'Camino de la Luna 7474', 'Daca', 'Banglad�s', '89012', 'Masculino'),
--('Elena', 'Soto', 29, 'elena.soto@example.com', '4894894890', 'Ruta de las Flores 7575', 'Katmand�', 'Nepal', '90123', 'Femenino'),
--('Sergio', 'Garc�a', 34, 'sergio.garcia@example.com', '4904904901', 'V�a de la Monta�a 7676', 'But�n', 'But�n', '01234', 'Masculino'),
--('Paula', 'V�zquez', 32, 'paula.vazquez@example.com', '4014014012', 'Sendero de la Ciudad 7777', 'Colombo', 'Sri Lanka', '12345', 'Femenino');
--------90
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Gonzalo', 'Mart�nez', 38, 'gonzalo.martinez@example.com', '3123123123', 'Calle de la Armon�a 7878', 'Mal�', 'Maldivas', '23456', 'Masculino'),
--('Ana', 'Guti�rrez', 27, 'ana.gutierrez@example.com', '3233233234', 'Avenida de la Esperanza 7979', 'Katmand�', 'Nepal', '34567', 'Femenino'),
--('Carlos', 'L�pez', 35, 'carlos.lopez@example.com', '3343343345', 'Boulevard del R�o 8080', 'Thimphu', 'But�n', '45678', 'Masculino'),
--('Sof�a', 'Rodr�guez', 30, 'sofia.rodriguez@example.com', '3453453456', 'Calle de la Luz 8181', 'Yakarta', 'Indonesia', '56789', 'Femenino'),
--('Diego', 'G�mez', 39, 'diego.gomez@example.com', '3563563567', 'Avenida del Bosque 8282', 'Singapur', 'Singapur', '67890', 'Masculino'),
--('Leticia', 'P�rez', 33, 'leticia.perez@example.com', '3673673678', 'Paseo de la Monta�a 8383', 'Kuala Lumpur', 'Malasia', '78901', 'Femenino'),
--('Miguel', 'S�nchez', 36, 'miguel.sanchez@example.com', '3783783789', 'Camino de la Playa 8484', 'Bangkok', 'Tailandia', '89012', 'Masculino'),
--('Patricia', 'D�az', 29, 'patricia.diaz@example.com', '3893893890', 'Ruta de la Ciudad 8585', 'Manila', 'Filipinas', '90123', 'Femenino'),
--('Javier', 'Hern�ndez', 34, 'javier.hernandez@example.com', '3903903901', 'V�a de la Selva 8686', 'Han�i', 'Vietnam', '01234', 'Masculino'),
--('Mar�a', 'Gonz�lez', 32, 'maria.gonzalez@example.com', '3013013012', 'Sendero del Valle 8787', 'Phnom Penh', 'Camboya', '12345', 'Femenino');
----------100
--INSERT INTO UsuariosCompletos (Nombre, Apellido, Edad, Email, Telefono, Direccion, Ciudad, Pais, CodigoPostal, Genero)
--VALUES
--('Roberto', 'Alvarez', 37, 'roberto.alvarez@example.com', '2122122123', 'Calle de la Victoria 8888', 'Vienti�n', 'Laos', '23456', 'Masculino'),
--('Carmen', 'Morales', 28, 'carmen.morales@example.com', '2232232234', 'Avenida de la Paz 8989', 'Yang�n', 'Myanmar', '34567', 'Femenino'),
--('Iv�n', 'Ortega', 34, 'ivan.ortega@example.com', '2342342345', 'Boulevard de la Alegr�a 9090', 'Daca', 'Banglad�s', '45678', 'Masculino'),
--('M�nica', 'Castro', 31, 'monica.castro@example.com', '2452452456', 'Calle del Mar 9191', 'Colombo', 'Sri Lanka', '56789', 'Femenino'),
--('Gustavo', 'Reyes', 36, 'gustavo.reyes@example.com', '2562562567', 'Avenida de las Estrellas 9292', 'Mal�', 'Maldivas', '67890', 'Masculino'),
--('Patricia', 'Romero', 29, 'patricia.romero@example.com', '2672672678', 'Paseo del Sol 9393', 'Thimphu', 'But�n', '78901', 'Femenino'),
--('Luis', 'Torres', 33, 'luis.torres@example.com', '2782782789', 'Camino de la Luna 9494', 'Katmand�', 'Nepal', '89012', 'Masculino'),
--('Sof�a', 'Soto', 27, 'sofia.soto@example.com', '2892892890', 'Ruta de las Flores 9595', 'Islamabad', 'Pakist�n', '90123', 'Femenino'),
--('Marco', 'Garc�a', 35, 'marco.garcia@example.com', '2902902901', 'V�a de la Monta�a 9696', 'Nueva Delhi', 'India', '01234', 'Masculino'),
--('Alejandra', 'V�zquez', 32, 'alejandra.vazquez@example.com', '2012012012', 'Sendero de la Ciudad 9797', 'Katmand�', 'Nepal', '12345', 'Femenino');
