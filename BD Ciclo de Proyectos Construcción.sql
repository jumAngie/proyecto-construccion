CREATE DATABASE Construccion

GO 
USE Construccion
GO

GO
CREATE SCHEMA Cons
GO
CREATE SCHEMA Gral
GO
CREATE SCHEMA Acce
GO

--********************************************************** TABLA ROLES*****************************************************************--
CREATE TABLE Acce.tbRoles(
	role_Id					INT IDENTITY,
	role_Nombre				NVARCHAR(100) NOT NULL,
	role_UsuCreacion		INT NOT NULL,
	role_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_role_FechaCreacion DEFAULT(GETDATE()),
	role_UsuModificacion	INT,
	role_FechaModificacion	DATETIME,
	role_Estado				BIT NOT NULL CONSTRAINT DF_role_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbRoles_role_Id PRIMARY KEY(role_Id)
);
GO

INSERT INTO Acce.tbRoles(role_Nombre, role_UsuCreacion)
VALUES					('Digitador', 1),
						('Visualizador', 1)
						('Miembro',1)

--**********************************************************TABLA PANTALLAS***************************************************************---
CREATE TABLE Acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

---- ACÁ INSERTAR PANTALLAS ---



--*************************************************************TABLA ROLES/PANTALLA*****************************************************---
CREATE TABLE Acce.tbPantallasRoles(
	pantrole_Id					INT IDENTITY,
	pantrole_Identificador		NVARCHAR(100) NOT NULL,
	role_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	pantrole_UsuCreacion		INT NOT NULL,
	pantrole_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pantrole_FechaCreacion DEFAULT(GETDATE()),
	pantrole_UsuModificacion	INT,
	pantrole_FechaModificacion	DATETIME,
	pantrole_Estado				BIT NOT NULL CONSTRAINT DF_pantrole_Estado DEFAULT(1)
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES Acce.tbRoles(role_Id),
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id)	REFERENCES Acce.tbPantallas(pant_Id),
	CONSTRAINT PK_Acce_tbPantallasPorRoles_pantrole_Id PRIMARY KEY(pantrole_Id),
);
GO


--***********************************************************TABLA USUARIOS************************************************************--
CREATE TABLE Acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT,
	user_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	user_FechaModificacion	DATETIME,
	user_Estado				BIT NOT NULL CONSTRAINT DF_user_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbUsuarios_user_Id  PRIMARY KEY(user_Id),
);

--********************************************** UDP INSERTAR USUARIOS *************************************************--
GO
CREATE OR ALTER PROCEDURE Acce.UDP_InsertUsuario
	@user_NombreUsuario NVARCHAR(100),	@user_Contrasena NVARCHAR(200),
	@user_EsAdmin BIT,					@role_Id INT, 
	@empe_Id INT										
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

	INSERT Acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
	VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, 1);
END;


GO


-- ACÁ INSERTAR EL USUARIO ADMIN ---




--***************************************************************************************************************************************-
ALTER TABLE Acce.tbRoles
ADD CONSTRAINT FK_Acce_tbRoles_Acce_tbUsuarios_role_UsuCreacion_user_Id 	FOREIGN KEY(role_UsuCreacion) REFERENCES Acce.tbUsuarios(user_Id),
	CONSTRAINT FK_Acce_tbRoles_Acce_tbUsuarios_role_UsuModificacion_user_Id 	FOREIGN KEY(role_UsuModificacion) REFERENCES Acce.tbUsuarios(user_Id);

GO

-- ACÁ INSERTAR ROLES -----


--***************************************************************************************************************************************--
GO
ALTER TABLE Acce.tbUsuarios
ADD CONSTRAINT FK_Acce_tbUsuarios_Acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbUsuarios_Acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbUsuarios_Acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES Acce.tbRoles(role_Id)

GO 
ALTER TABLE Acce.tbPantallasPorRoles
ADD CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([pantrole_UsuCreacion]) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([pantrole_UsuModificacion]) REFERENCES Acce.tbUsuarios([user_Id])

--***************************************************************************************************************************************--

GO
CREATE TABLE Gral.tbDepartamentos (
	depa_Id  					CHAR(2) NOT NULL,
	depa_Nombre 				NVARCHAR(100) NOT NULL,
	depa_UsuCreacion			INT NOT NULL,
	depa_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_depa_FechaCreacion DEFAULT(GETDATE()),
	depa_UsuModificacion		INT,
	depa_FechaModificacion		DATETIME,
	depa_Estado					BIT NOT NULL CONSTRAINT DF_depa_Estado DEFAULT(1)
	CONSTRAINT PK_Gral_tbDepartamentos_depa_Id 									PRIMARY KEY(depa_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_depa_UsuCreacion_user_Id  		FOREIGN KEY(depa_UsuCreacion) 		REFERENCES Acce.tbUsuarios(user_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_depa_UsuModificacion_user_Id  	FOREIGN KEY(depa_UsuModificacion) 	REFERENCES Acce.tbUsuarios(user_Id)
);


--********TABLA MUNICIPIO****************---
GO
CREATE TABLE Gral.tbMunicipios(
	muni_id					CHAR(4)	NOT NULL,
	muni_Nombre				NVARCHAR(80) NOT NULL,
	depa_Id					CHAR(2)	NOT NULL,
	muni_UsuCreacion		INT	NOT NULL,
	muni_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_muni_FechaCreacion DEFAULT(GETDATE()),
	muni_UsuModificacion	INT,
	muni_FechaModificacion	DATETIME,
	muni_Estado				BIT	NOT NULL CONSTRAINT DF_muni_Estado DEFAULT(1)
	CONSTRAINT PK_Gral_tbMunicipios_muni_Id 										PRIMARY KEY(muni_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Gral_tbDepartamentos_depa_Id 						FOREIGN KEY (depa_Id) 						REFERENCES Gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_muni_UsuCreacion_user_Id  		FOREIGN KEY(muni_UsuCreacion) 				REFERENCES Acce.tbUsuarios(user_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_muni_UsuModificacion_user_Id  	FOREIGN KEY(muni_UsuModificacion) 			REFERENCES Acce.tbUsuarios(user_Id)
);
