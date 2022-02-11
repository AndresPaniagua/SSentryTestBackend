IF EXISTS (SELECT NAME FROM MASTER.DBO.SYSDATABASES WHERE NAME = N'SistemaSentryTest')
BEGIN
    PRINT 'EL NOMBRE DE LA BASE DE DATOS YA EXISTE'
END
ELSE
BEGIN
    CREATE DATABASE [SistemaSentryTest]
    PRINT 'NUEVA BASE DE DATOS CREADA'
END
GO

USE [SistemaSentryTest]
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'TipoIdentificaciones')
BEGIN
	PRINT 'YA EXISTE [dbo].[TipoIdentificaciones]'
END
ELSE
BEGIN
    PRINT 'NO EXISTE [dbo].[TipoIdentificaciones]'
    PRINT 'CREANDO [dbo].[TipoIdentificaciones]'
    CREATE TABLE TipoIdentificaciones (								
        Id INT PRIMARY KEY IDENTITY NOT NULL,		
        Nombre VARCHAR(30) NOT NULL)
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Empresas')
BEGIN
	PRINT 'YA EXISTE [dbo].[Empresas]'
END
ELSE
BEGIN
    PRINT 'NO EXISTE [dbo].[Empresas]'
    PRINT 'CREANDO [dbo].[Empresas]'
    CREATE TABLE Empresas (								
        Id INT PRIMARY KEY IDENTITY NOT NULL,		
        EmpresaNombre VARCHAR(50) NULL,	
		NumeroIdentificacion VARCHAR(9) NOT NULL,
		PrimerNombre VARCHAR(50) NULL,
		SegundoNombre VARCHAR(50) NULL,
		PrimerApellido VARCHAR(50) NULL,
		SegundoApellido VARCHAR(50) NULL,
		CorreoElectronico VARCHAR(50) NULL,
		PermiteMensajesCelular BIT DEFAULT(0) NOT NULL,
		PermiteMensajesCorreo BIT DEFAULT(0) NOT NULL,
		TipoIdentificacionId INT REFERENCES TipoIdentificaciones(Id) ON DELETE CASCADE NOT NULL)
END

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Seguridad')
BEGIN
	PRINT 'YA EXISTE [dbo].[Seguridad]'
END
ELSE
BEGIN
    PRINT 'NO EXISTE [dbo].[Seguridad]'
    PRINT 'CREANDO [dbo].[Seguridad]'
    CREATE TABLE Seguridad (
	IdSeguridad INT IDENTITY PRIMARY KEY,
	Usuario VARCHAR(50) NOT NULL,
	NombreUsuario VARCHAR(100) NOT NULL,
	Contrasena VARCHAR(200) NOT NULL,
	Rol VARCHAR(15) NOT NULL)
END

DECLARE @primerTipo INT = 0

SELECT @primerTipo = Id FROM TipoIdentificaciones WHERE Nombre = 'NIT'

IF @primerTipo <> 0
BEGIN
	PRINT 'YA EXISTE NIT EN LA TABLA TipoIdentificaciones'
END
ELSE
BEGIN
	PRINT 'NO EXISTE NIT EN LA TABLA TipoIdentificaciones'
	PRINT 'CREANDO NIT EN LA TABLA TipoIdentificaciones'
	INSERT INTO TipoIdentificaciones VALUES ('NIT')
END

DECLARE @segundoTipo INT = 0

SELECT @segundoTipo = Id FROM TipoIdentificaciones WHERE Nombre = 'Cédula de Ciudadanía'

IF @segundoTipo <> 0
BEGIN
	PRINT 'YA EXISTE Cédula de Ciudadanía EN LA TABLA TipoIdentificaciones'
END
ELSE
BEGIN
	PRINT 'NO EXISTE Cédula de Ciudadanía EN LA TABLA TipoIdentificaciones'
	PRINT 'CREANDO Cédula de Ciudadanía EN LA TABLA TipoIdentificaciones'
	INSERT INTO TipoIdentificaciones VALUES ('Cédula de Ciudadanía')
END

DECLARE @tercerTipo INT = 0

SELECT @tercerTipo = Id FROM TipoIdentificaciones WHERE Nombre = 'Cédula de Extranjería'

IF @tercerTipo <> 0
BEGIN
	PRINT 'YA EXISTE Cédula de Extranjería EN LA TABLA TipoIdentificaciones'
END
ELSE
BEGIN
	PRINT 'NO EXISTE Cédula de Extranjería EN LA TABLA TipoIdentificaciones'
	PRINT 'CREANDO Cédula de Extranjería EN LA TABLA TipoIdentificaciones'
	INSERT INTO TipoIdentificaciones VALUES ('Cédula de Extranjería')
END

DECLARE @primeraEmpresa INT = 0

SELECT @primeraEmpresa = Id FROM Empresas WHERE NumeroIdentificacion = '900674335'

IF @primeraEmpresa <> 0
BEGIN
	PRINT 'YA EXISTE IDENTIFICACION 900674335 EN LA TABLA Empresas'
END
ELSE
BEGIN
	PRINT 'NO EXISTE IDENTIFICACION 900674335 EN LA TABLA Empresas'
	PRINT 'CREANDO IDENTIFICACION 900674335 EN LA TABLA Empresas'
	INSERT INTO Empresas (NumeroIdentificacion, TipoIdentificacionId) VALUES ('900674335', 1)
END

DECLARE @segundaEmpresa INT = 0

SELECT @segundaEmpresa = Id FROM Empresas WHERE NumeroIdentificacion = '900674336'

IF @segundaEmpresa <> 0
BEGIN
	PRINT 'YA EXISTE IDENTIFICACION 900674336 EN LA TABLA Empresas'
END
ELSE
BEGIN
	PRINT 'NO EXISTE IDENTIFICACION 900674336 EN LA TABLA Empresas'
	PRINT 'CREANDO IDENTIFICACION 900674336 EN LA TABLA Empresas'
	INSERT INTO Empresas (NumeroIdentificacion, TipoIdentificacionId) VALUES ('900674336', 2)
END

DECLARE @terceraEmpresa INT = 0

SELECT @terceraEmpresa = Id FROM Empresas WHERE NumeroIdentificacion = '811033098'

IF @terceraEmpresa <> 0
BEGIN
	PRINT 'YA EXISTE IDENTIFICACION 811033098 EN LA TABLA Empresas'
END
ELSE
BEGIN
	PRINT 'NO EXISTE IDENTIFICACION 811033098 EN LA TABLA Empresas'
	PRINT 'CREANDO IDENTIFICACION 811033098 EN LA TABLA Empresas'
	INSERT INTO Empresas (NumeroIdentificacion, TipoIdentificacionId) VALUES ('811033098', 3)
END

DECLARE @administrador INT = 0

SELECT @administrador = IdSeguridad FROM Seguridad WHERE Usuario = 'Master'

IF @administrador <> 0
BEGIN
	PRINT 'YA EXISTE Master EN LA TABLA Seguridad'
END
ELSE
BEGIN
	PRINT 'NO EXISTE Master EN LA TABLA Seguridad'
	PRINT 'CREANDO Master EN LA TABLA Seguridad'
	INSERT INTO Seguridad VALUES ('Master', 'SistemaSentry', '10000.KeCxXo94PjA5qHl7DN1oHQ==.A9/TnsBYi9uoDFxqc1mynJMpzpCJLCutehrQjO49+ws=', 'Administrator')
END

DECLARE @consumer INT = 0

SELECT @consumer = IdSeguridad FROM Seguridad WHERE Usuario = 'User'

IF @consumer <> 0
BEGIN
	PRINT 'YA EXISTE User EN LA TABLA Seguridad'
END
ELSE
BEGIN
	PRINT 'NO EXISTE User EN LA TABLA Seguridad'
	PRINT 'CREANDO User EN LA TABLA Seguridad'
	INSERT INTO Seguridad VALUES ('User', 'Andres Paniagua', '10000.kDmXy6kxoZ32W4MdcB4mFQ==.nJT0eFaft9FVUiY1VghjdD78ivj5OcZLKAZtmF66hvY=', 'Consumer')
END

