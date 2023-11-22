CREATE DATABASE Examen
GO

USE Examen
GO

CREATE TABLE Tecnicos 
(	
	TecnicoID int identity(1,1),
	Nombre varchar(50),
	Especialidad varchar(20)
	CONSTRAINT pk_TecnicosID PRIMARY KEY(TecnicoID) 
)
GO

CREATE TABLE Usuarios
(
	UsuarioID int identity(1,1),
	Nombre varchar(50) NOT NULL,
	Correo varchar(50),
	Telefono varchar(15) UNIQUE, 
	CONSTRAINT pk_UsuariosID PRIMARY KEY(UsuarioID)
)
GO

CREATE TABLE Equipos 
(	
	EquipoID int identity(1,1),
	UsuarioID int,
	TipoEquipo varchar(50) NOT NULL,
	Modelo varchar(50),
	CONSTRAINT pk_EquiposID PRIMARY KEY(EquipoID),
	CONSTRAINT fk_UsuarioID FOREIGN KEY(UsuarioID)REFERENCES Usuarios(UsuarioID)
)
GO 

CREATE TABLE Reparaciones 
(
	ReparacionID int identity(1,1),
	EquipoID int,
	FechaSolicitud datetime CONSTRAINT df_Fecha DEFAULT GETDATE(),
	Estado varchar(1)
	CONSTRAINT pk_ReparacionID PRIMARY KEY(ReparacionID),
	CONSTRAINT fk_EqupoID FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
)
GO

CREATE TABLE DetallesRepacion
(	
	DetalleID int identity(1,1),
	ReparacionID int,
	Descripcion varchar(50),
	FechaInicio datetime,
	FechaFin datetime
	CONSTRAINT pk_DetalleID PRIMARY KEY(DetalleID),
	CONSTRAINT fk_ReparacionID FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID) 
)
GO

CREATE TABLE Asignaciones
(	
	AsignacionId int identity(1,1),
	ReparacionID int, 
	TecnicoID int,
	FechaAsignacion datetime
	CONSTRAINT pk_AsignacionID PRIMARY KEY(AsignacionID),
	CONSTRAINT fk_ReparacioID FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID), 
	CONSTRAINT fk_TecnicoID FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID) 
)
GO

INSERT INTO Tecnicos(Nombre,Especialidad) VALUES ('Fernanda','Base de datos'),('Maria','Redes')

CREATE PROCEDURE CONSULTARTECNICO
AS
	BEGIN
		SELECT * FROM Tecnicos
	END

CREATE PROCEDURE CONSULTARTECNICO_FILTRO
@Codigo int
AS 
	BEGIN 
		SELECT * FROM Tecnicos WHERE TecnicoID =@Codigo
	END 

	CREATE PROCEDURE BORRARTECNICO
@Codigo int
AS 
	BEGIN 
		DELETE Tecnicos WHERE TecnicoID = @Codigo
	END 


CREATE PROCEDURE AGREGARTECNICO
@Nombre varchar(50),
@Especialidad varchar(20)
AS 
	BEGIN 
		INSERT INTO Tecnicos (Nombre,Especialidad) VALUES (@Nombre,@Especialidad)
	END 

CREATE PROCEDURE MODIFICARTECNICO
@Codigo int,
@Nombre varchar(50),
@Especialidad varchar(20)
AS 
	BEGIN 
		UPDATE Tecnicos SET Nombre=@Nombre, Especialidad=@Especialidad WHERE TecnicoID=@Codigo
	END 



	EXEC AGREGARTECNICO 'Jimena','Base de datos' 
	EXEC CONSULTARTECNICO
	EXEC BORRARTECNICO 1
	EXEC MODIFICARTECNICO 4, 'Daniela','Base de datos'
	EXEC CONSULTARTECNICO
	EXEC CONSULTARTECNICO_FILTRO 1

CREATE PROCEDURE CONSULTARUSUARIO
AS
	BEGIN
		SELECT * FROM Usuarios
	END

INSERT INTO Usuarios(Nombre,Correo,Telefono) VALUES ('Fernanda','fer@gmail.com','0988090'),('Maria','mar@gmail,com','77663355')

CREATE PROCEDURE CONSULTARUSUARIO_FILTRO
@Codigo int
AS 
	BEGIN 
		SELECT * FROM Usuarios WHERE UsuarioID =@Codigo
	END 

CREATE PROCEDURE BORRARUSUARIO
@Codigo int
AS 
	BEGIN 
		DELETE Usuarios WHERE UsuarioID = @Codigo
	END 

CREATE PROCEDURE AGREGARUSUARIO
@Nombre varchar(50),
@Correo varchar(50),
@Telefono int
AS 
	BEGIN 
		INSERT INTO Usuarios(Nombre,Correo,Telefono) VALUES (@Nombre,@Correo,@Telefono)
	END 

CREATE PROCEDURE MODIFICARUSUARIO
@Codigo int,
@Nombre varchar(50),
@Correo varchar(50),
@Telefono int 
AS 
	BEGIN 
		UPDATE Usuarios SET Nombre=@Nombre,Correo=@Correo,Telefono=@Telefono WHERE UsuarioID=@Codigo
	END 



EXEC BORRARUSUARIO 1
EXEC AGREGARUSUARIO 'Jimena','jim@gmail.com','89403209'
EXEC MODIFICARUSUARIO 3,'Juan','J@gmail,com','90908800'
EXEC CONSULTARUSUARIO
EXEC CONSULTARUSUARIO_FILTRO 1

CREATE PROCEDURE CONSULTAREQUIPOS
AS
	BEGIN
		SELECT * FROM Equipos
	END

CREATE PROCEDURE CONSULTAREQUIPO_FILTRO
@Codigo int
AS 
	BEGIN 
		SELECT * FROM Equipos WHERE EquipoID =@Codigo
	END 

CREATE PROCEDURE BORRAREQUIPO
@Codigo int
AS 
	BEGIN 
		DELETE Equipos WHERE EquipoID = @Codigo
	END 


CREATE PROCEDURE AGREGAREQUIPO
@UsuarioID int,
@TipoEquipo varchar(50),
@Modelo varchar(50)
AS 
	BEGIN 
		INSERT INTO Equipos(UsuarioID,TipoEquipo,Modelo) VALUES (@UsuarioID,@TipoEquipo,@Modelo)
	END 


CREATE PROCEDURE MODIFICAREQUIPO
@Codigo int,
@UsuarioID int,
@TipoEquipo varchar(50),
@Modelo varchar(50)

AS 
	BEGIN 
		UPDATE Equipos SET UsuarioID=@UsuarioID,TipoEquipo=@TipoEquipo,Modelo=@Modelo WHERE EquipoID=@Codigo
	END 



EXEC AGREGAREQUIPO 1,'Impresora','Epson'
EXEC BORRAREQUIPO 4
EXEC MODIFICAREQUIPO 1,'3','Laptop','Huawei'
EXEC CONSULTAREQUIPOS
EXEC CONSULTAREQUIPO_FILTRO 5

