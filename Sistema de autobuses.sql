CREATE DATABASE Sistema_Autobuses
GO

USE Sistema_Autobuses
GO

CREATE TABLE Conductores(
ConductorID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Codigo AS ('C' + RIGHT('000' + CONVERT(VARCHAR,ConductorID),(3))),
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
FechaN DATE NOT NULL,
Cedula VARCHAR(20) NOT NULL,
Estado BIT
);
GO

CREATE TABLE Autobuses(
AutobusID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Codigo AS ('A' + RIGHT('000' + CONVERT(VARCHAR,AutobusID),(3))),
Marca VARCHAR(20),
Modelo VARCHAR (50),
Placa NVARCHAR(10),
Color VARCHAR (20),
Año INT NOT NULL,
Estado BIT
);
GO

CREATE TABLE Rutas(
RutaID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
Ruta VARCHAR(200),
Estado BIT
);
GO

CREATE TABLE Asignar(
AsignarID INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
ConductorID INT,
AutobusID INT,
RutaID INT,
FOREIGN KEY (ConductorID) REFERENCES Conductores(ConductorID),
FOREIGN KEY (AutobusID) REFERENCES Autobuses(AutobusID),
FOREIGN KEY (RutaID) REFERENCES Rutas(RutaID),
);
GO

CREATE VIEW Asignados AS
SELECT
a.AsignarID,
c.ConductorID,
c.Nombre AS Nombre_Conductor,
c.Apellido AS Apellido_Conductor,
c.Cedula,
b.AutobusID,
b.Marca AS Autobus_Marca,
b.Modelo AS Autobus_Modelo,
b.Placa AS Autobus_Placa,
b.Año AS Autobus_Año,
r.RutaID,
r.Ruta
FROM Asignar a
INNER JOIN 
Conductores c ON a.ConductorID = c.ConductorID
INNER JOIN
Autobuses b ON a.AutobusID = b.AutobusID
INNER JOIN
Rutas r ON a.RutaID = r.RutaID;
GO

CREATE PROC SP_REGISTRARCONDUCTOR
@Nombre VARCHAR (50),
@Apellido VARCHAR (50),
@FechaN DATE,
@Cedula VARCHAR (20),
@Estado BIT
AS
BEGIN 
INSERT INTO Conductores (Nombre, Apellido, FechaN, Cedula, Estado) 
VALUES(@Nombre, @Apellido, @FechaN, @Cedula, @Estado);
END;
GO

CREATE PROC SP_LISTARCONDUCTORES
AS
SELECT ConductorID AS ID, Nombre, Apellido, FechaN, Cedula, Estado FROM Conductores 
GO

CREATE PROC SP_REGISTRARAUTOBUS
@Marca VARCHAR(20),
@Modelo VARCHAR(20),
@Placa NVARCHAR(10),
@Color VARCHAR(20),
@Año int,
@Estado BIT
AS
BEGIN
INSERT INTO Autobuses(Marca, Modelo, Placa, Color, Año, Estado)
VALUES(@Marca, @Modelo, @Placa, @Color, @Año, @Estado);
END;
GO

CREATE PROC SP_LISTARAUTOBUSES
AS
SELECT AutobusID AS ID, Marca, Modelo, Placa, Color, Año, Estado FROM Autobuses
GO

CREATE PROC SP_REGISTRARRUTA
@Ruta VARCHAR (300),
@Estado BIT
AS
BEGIN
INSERT INTO Rutas(Ruta, Estado)
VALUES (@Ruta, @Estado);
END;
GO

CREATE PROC SP_LISTARRUTAS
AS
SELECT RutaID AS ID, Ruta, Estado FROM Rutas
GO

CREATE PROCEDURE SP_ASIGNAR
@ConductorID INT,
@AutobusID INT,
@RutaID INT,
@Resultado int OUTPUT
AS
BEGIN
SET @Resultado = 0;
IF EXISTS (SELECT 1 FROM Asignar WHERE ConductorID = @ConductorID)
BEGIN
SET @Resultado = 1;
UPDATE Conductores SET Estado = 1 WHERE ConductorID = @ConductorID;
RETURN;
END

IF EXISTS (SELECT 1 FROM Asignar WHERE AutobusID = @AutobusID)
BEGIN
SET @Resultado = 2;
UPDATE Autobuses SET Estado = 1 WHERE AutobusID = @AutobusID;
RETURN;
END

IF EXISTS (SELECT 1 FROM Asignar WHERE RutaID = @RutaID)
BEGIN
SET @Resultado = 3;
RETURN;
END

UPDATE Rutas SET Estado = 1 WHERE RutaID = @RutaID;

INSERT INTO Asignar (ConductorID, AutobusID, RutaID)
VALUES (@ConductorID, @AutobusID, @RutaID);

SET @Resultado = 4;

UPDATE Conductores SET Estado = 1 WHERE ConductorID = @ConductorID;
UPDATE Autobuses SET Estado = 1 WHERE AutobusID = @AutobusID;
END;
GO

CREATE PROC SP_ASIGNADO 
AS
SELECT Nombre_Conductor,Apellido_Conductor,Cedula,Autobus_marca,Autobus_Modelo, Autobus_Placa, Autobus_Año,Ruta FROM Asignados
GO
