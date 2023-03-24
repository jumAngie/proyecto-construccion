/*
DROP SCHEMA Cons
GO

DROP SCHEMA Gral
GO

DROP SCHEMA Acce
GO

DROP DATABASE Construccion
*/

GO
USE master
GO

CREATE DATABASE Construccion
GO 

USE Construccion
GO

CREATE SCHEMA Cons
GO

CREATE SCHEMA Gral
GO

CREATE SCHEMA Acce
GO

--*****************************************************************************************************************************************--
--*********************************************************** CREACION DE ***************************************************************--
--************************************************************** TABLAS *****************************************************************--


--**********************************************************TABLA ROLES*****************************************************************--
--TABLA ROLES
CREATE TABLE Acce.tbRoles(
	role_Id					INT IDENTITY,
	role_Nombre				NVARCHAR(100) NOT NULL,
	user_UsuCreacion		INT NOT NULL,
	role_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbRoles_role_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	role_FechaModificacion	DATETIME,
	role_Estado				BIT NOT NULL CONSTRAINT DF_tbRoles_role_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbRoles_role_Id PRIMARY KEY(role_Id)
);
GO

--***********************************************************TABLA USUARIOS************************************************************--
--TABLA USUARIOS
CREATE TABLE Acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL UNIQUE,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT,
	user_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbUsuarios_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	user_FechaModificacion	DATETIME,
	user_Estado				BIT NOT NULL CONSTRAINT DF_tbUsuarios_user_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbUsuarios_user_Id  PRIMARY KEY(user_Id),
);
GO

--**********************************************************TABLA PANTALLAS***************************************************************---
--TABLA PANTALLAS
CREATE TABLE Acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_URL                NVARCHAR(300) NOT NULL,
    pant_Menu               NVARCHAR(300) NOT NULL,
    pant_HtmlId             NVARCHAR(80) NOT NULL,
	user_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbPantallas_pant_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_tbPantallas_pant_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

--*************************************************************TABLA ROLES/PANTALLA*****************************************************---
--TABLA ROLES/PANTALLA
CREATE TABLE Acce.tbPantallasRoles(
	ptro_Id					INT IDENTITY,
	role_Id					INT NOT NULL,
	pant_Id					INT NOT NULL,
	user_UsuCreacion		INT NOT NULL,
	ptro_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbPantallasRoles_pantrole_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	ptro_FechaModificacion	DATETIME,
	ptro_Estado				BIT NOT NULL CONSTRAINT DF_tbPantallasRoles_pantrole_Estado DEFAULT(1)
	CONSTRAINT PK_Acce_tbPantallasPorRoles_pantrole_Id				PRIMARY KEY(ptro_Id),
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbRoles_role_Id		FOREIGN KEY(role_Id)		REFERENCES Acce.tbRoles(role_Id),
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id)		REFERENCES Acce.tbPantallas(pant_Id),
);
GO

--*************************************************************TABLA DEPARTAMENTO********************************************************---
--TABLA DEPARTAMENTOS
CREATE TABLE Gral.tbDepartamentos (
	depa_Id  					CHAR(2) NOT NULL,
	depa_Nombre 				NVARCHAR(100) NOT NULL,
	user_UsuCreacion			INT NOT NULL,
	depa_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_tbDepartamentos_depa_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion		INT,
	depa_FechaModificacion		DATETIME
	CONSTRAINT PK_Gral_tbDepartamentos_depa_Id 											PRIMARY KEY(depa_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_user_UsuCreacion_user_Id  		FOREIGN KEY(user_UsuCreacion) 		REFERENCES Acce.tbUsuarios(user_Id),
	CONSTRAINT FK_Gral_tbDepartamentos_Acce_tbUsuarios_user_UsuModificacion_user_Id  	FOREIGN KEY(user_UsuModificacion) 	REFERENCES Acce.tbUsuarios(user_Id)
);
GO

--***********************************************************TABLA MUNICIPIOS************************************************************--
--TABLA MUNICIPIOS
CREATE TABLE Gral.tbMunicipios(
	muni_id					CHAR(4)	NOT NULL,
	muni_Nombre				NVARCHAR(80) NOT NULL,
	depa_Id					CHAR(2)	NOT NULL,
	user_UsuCreacion		INT	NOT NULL,
	muni_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbMunicipios_muni_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	muni_FechaModificacion	DATETIME
	CONSTRAINT PK_Gral_tbMunicipios_muni_Id 										PRIMARY KEY(muni_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Gral_tbDepartamentos_depa_Id 					FOREIGN KEY (depa_Id) 						REFERENCES Gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_muni_UsuCreacion_user_Id  		FOREIGN KEY(user_UsuCreacion) 				REFERENCES Acce.tbUsuarios(user_Id),
	CONSTRAINT FK_Gral_tbMunicipios_Acce_tbUsuarios_muni_UsuModificacion_user_Id  	FOREIGN KEY(user_UsuModificacion) 			REFERENCES Acce.tbUsuarios(user_Id)
);
GO

--*************************************************************TABLA ESTADOS CIVILES*****************************************************---
--TABLA ESTADOS CIVILES
CREATE TABLE Gral.tbEstadosCiviles(
        esta_ID                CHAR(1),
        esta_Descripcion	   NVARCHAR(250) NOT NULL,
        user_IdCreacion		   INT  NOT NULL,
        esta_FechaCrea         DATETIME NOT NULL CONSTRAINT DF_tbEstadosCiviles_estaFechaCrea DEFAULT (GETDATE()),
        user_IdModificacion	   INT,
        esta_FechaModi         DATETIME
		CONSTRAINT PK_Gral_tbEstadosCiviles_esta_ID PRIMARY KEY(esta_ID),
        CONSTRAINT FK_Gral_tbEstadosCiviles_est_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(user_IdCreacion)			REFERENCES Acce.tbUsuarios(user_Id),
        CONSTRAINT FK_Gral_tbEstadosCiviles_est_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(user_IdModificacion)		REFERENCES Acce.tbUsuarios(user_Id)

);
GO

--***********************************************************TABLA CARGOS************************************************************--
--TABLA CARGOS
CREATE TABLE Gral.tbCargos(
	carg_Id					INT IDENTITY(1,1),
	carg_Cargo				NVARCHAR(250) NOT NULL,
	user_UsuCreacion		INT NOT NULL,
	carg_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbCargos_cargFechaCreacion DEFAULT (GETDATE()), 
	user_IdModificacion		INT,
	carg_FechaModificacion	DATETIME
	CONSTRAINT PK_Gral_tbCargos_carg_Id PRIMARY KEY(carg_Id)
);
GO

--***********************************************************TABLA EMPLEADOS************************************************************--
--TABLA EMPLEADOS
CREATE TABLE Gral.tbEmpleados(
	empl_Id					INT IDENTITY(1,1),
	empl_DNI				VARCHAR(13) NOT NULL,
	empl_Nombre				NVARCHAR(255)NOT NULl,
	empl_Apellidos			NVARCHAR(255) NOT NULL,
	empl_Sexo				CHAR(1) NOT NULL,
	esta_ID					CHAR(1) NOT NULL,
	muni_Id					CHAR(4) NOT NULL,
	carg_Id					INT NOT NULL,
	empl_DireccionExacta	NVARCHAR(250)NOT NULL,
	empl_FechaNacimiento	DATE NOT NULL,
	empl_Telefono			NVARCHAR(9)NOT NULL,
	empl_CorreoEletronico	NVARCHAR(255)NOT NULL,
	user_IdCreacion			INT NOT NULL,
	empl_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbEmpleados_empl_FechaCreacion DEFAULT (GETDATE()),
	user_IdModificacion		INT,
	empl_FechaModificacion	DATETIME,
	empl_Estado				BIT DEFAULT 1, 
	CONSTRAINT PK_Gral_tbEmpleados_empl_Id									PRIMARY KEY(empl_Id),
	CONSTRAINT FK_Gral_tbEmpleados_esta_ID_Gral_tbEstadosCiviles_esta_ID	FOREIGN KEY(esta_ID)		REFERENCES Gral.tbEstadosCiviles(esta_ID),
	CONSTRAINT CK_Gral_tbEmpleados_empl_Sexo								CHECK(empl_Sexo IN('F','M')),
	CONSTRAINT FK_Gral_tbEmpleados_carg_Id_Gral_tbCargos_carg_Id			FOREIGN KEY(carg_Id)		REFERENCES Gral.tbCargos(carg_Id)
);
GO

--***********************************************************TABLA CLIENTES************************************************************--
--TABLA CLIENTES
CREATE TABLE Cons.tbClientes(
	clie_Id					INT IDENTITY(1,1) UNIQUE,
	clie_Identificacion		VARCHAR(150) NOT NULL,
	clie_Nombre				NVARCHAR(255)  NOT NULL,
	muni_Id					CHAR(4) NOT NULL,
	clie_DireccionExacta	NVARCHAR(250)NOT NULL,
	clie_Telefono			NVARCHAR(9)NOT NULL,
	clie_CorreoElectronico	NVARCHAR(255) NOT NULL,
	user_IdCreacion			INT NOT NULL,
	clie_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_tbClientes_clieFechaCreacion DEFAULT (GETDATE()), 
	user_IdModificacion		INT,
	clie_FechaModificacion	DATETIME,
	clie_Estado				BIT DEFAULT 1, 
	CONSTRAINT PK_Cons_tbClientes_clie_Id								PRIMARY KEY(clie_Id),
	CONSTRAINT FK_Cons_tbClientes_muni_Id_Gral_tbMunicipios_muni_Id		FOREIGN KEY(muni_Id)	REFERENCES Gral.tbMunicipios(muni_Id)
);
GO

--***********************************************************TABLA CONSTRUCCIONES************************************************************--
--TABLA CONSTRUCCIONES
CREATE TABLE Cons.tbConstrucciones(
        cons_Id							INT IDENTITY,
        cons_Proyecto					NVARCHAR(100),
        cons_ProyectoDescripcion		NVARCHAR(MAX),
        muni_Id							CHAR(4),
        cons_Direccion					NVARCHAR(MAX),
        cons_FechaInicio				DATE,
        cons_FechaFin					DATE,
        user_UsuCreacion				INT,
        cons_FechaCreacion				DATETIME NOT NULL CONSTRAINT DF_tbConstrucciones_user_FechaCreacion DEFAULT(GETDATE()),
        user_UsuModificacion			INT,
        cons_FechaModificacion			DATETIME,
        user_Estado						BIT NOT NULL CONSTRAINT DF_user_Estado DEFAULT(1)
		CONSTRAINT PK_Cons_tbConstrucciones_cons_Id								PRIMARY KEY(cons_Id),
		CONSTRAINT FK_Cons_tbConstrucciones_muni_Id_Gral_tbMunicipios_muni_Id	FOREIGN KEY(muni_Id)	REFERENCES Gral.tbMunicipios(muni_Id)
);
GO

--***********************************************************TABLA INSUMOS************************************************************--
--TABLA INSUMOS
CREATE TABLE Cons.tbInsumos(
        insm_Id						INT IDENTITY(1,1),
        insm_Descripcion			NVARCHAR(200),
        user_UsuCreacion			INT,
        insm_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_tbInsumos_user_FechaCreacion DEFAULT(GETDATE()),
        user_UsuModificacion		INT,
        insm_FechaModificacion		DATETIME,
        user_Estado					BIT NOT NULL CONSTRAINT DF_tbInsumos_user_Estado DEFAULT(1)
		CONSTRAINT PK_Cons_tbInsumos_insm_Id PRIMARY KEY(insm_Id),
        CONSTRAINT FK_Cons_tbInsumos_Acce_tbUsuarios_user_UsuCreacion_user_Id          FOREIGN KEY(user_UsuCreacion)                 REFERENCES Acce.tbUsuarios(user_Id),
        CONSTRAINT FK_Cons_tbInsumos_Acce_tbUsuarios_user_UsuModificacion_user_Id      FOREIGN KEY(user_UsuModificacion)             REFERENCES Acce.tbUsuarios(user_Id)
);
GO

--**********************************************************TABLA CONSUMOSPORCONSTRUCCION*****************************************************************--
--TABLA CONSUMOSPORCONSTRUCCION
CREATE TABLE Cons.tbInsumosConstruccion(
        inco_Id						INT IDENTITY(1,1),
        cons_Id						INT,
        insm_Id						INT,
        user_UsuCreacion            INT,
        user_FechaCreacion          DATETIME NOT NULL CONSTRAINT DF_tbInsumosConstruccion_user_FechaCreacion DEFAULT(GETDATE()),
        user_UsuModificacion        INT,
        user_FechaModificacion      DATETIME,
        user_Estado                 BIT NOT NULL CONSTRAINT DF_tbInsumosConstruccion_user_Estado DEFAULT(1)
		CONSTRAINT PK_Cons_tbInsumosConstruccion_inco_Id										   PRIMARY KEY(inco_Id),
        CONSTRAINT FK_Cons_tbInsumosConstruccion_insm_Id_Cons_tbInsumos_insm_Id					   FOREIGN KEY (insm_Id)					 	 REFERENCES Cons.tbInsumos(insm_Id),
        CONSTRAINT FK_Cons_tbConstrucciones_cons_Id_Cons_tbConstrucciones_cons_Id				   FOREIGN KEY (cons_Id)						 REFERENCES Cons.tbConstrucciones (cons_Id),
        CONSTRAINT FK_Cons_tbInsumosConstruccion_Acce_tbUsuarios_user_UsuCreacion_user_Id          FOREIGN KEY(user_UsuCreacion)                 REFERENCES Acce.tbUsuarios(user_Id),
        CONSTRAINT FK_Cons_tbInsumosConstruccion_Acce_tbUsuarios_user_UsuModificacion_user_Id      FOREIGN KEY(user_UsuModificacion)             REFERENCES Acce.tbUsuarios(user_Id)
)
GO

--***********************************************************TABLA EMPLEADOS/CONSTRUCCION************************************************************--
--TABLA EMPLEADOS/CONSTRUCCION
CREATE TABLE Cons.tbEmpleadosPorConstruccion(
	emco_Id						INT IDENTITY(1,1),
	cons_Id						INT NOT NULL,
	empl_Id						INT NOT NULL,
	user_UsuCreacion			INT NULL,
	cons_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_tbEmpleadosPorConstruccion_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion		INT,
	cons_FechaModificacion		DATETIME,
	cons_Estado					BIT NOT NULL CONSTRAINT DF_tbEmpleadosPorConstruccion_user_Estado DEFAULT(1)
	CONSTRAINT PK_Cons_tbEmpleadosPorConstruccion_emco_Id PRIMARY KEY(emco_Id),
	CONSTRAINT FK_Cons_tbEmpleadosPorConstruccion_Cons_tbConstrucciones_cons_Id		FOREIGN KEY(cons_Id)	REFERENCES Cons.tbConstrucciones(cons_Id),
	CONSTRAINT FK_Cons_tbEmpleadosPorConstruccion_Gral_tbEmpleados_empl_Id			FOREIGN KEY(empl_Id)	REFERENCES Gral.tbEmpleados(empl_Id)
);
GO

--***********************************************************TABLA UNIDADESDEMEDIDA************************************************************--
--TABLA UNIDADESDEMEDIDA
	CREATE TABLE Cons.tbUnidadesMedida(
				unim_Id						INT IDENTITY(1,1) PRIMARY KEY,
				unim_Descripcion			NVARCHAR(100),
				user_UsuCreacion            INT,
				user_FechaCreacion          DATETIME NOT NULL CONSTRAINT DF_tbUnidadesMedida_user_FechaCreacion DEFAULT(GETDATE()),
				user_UsuModificacion        INT,
				user_FechaModificacion		DATETIME,
				user_Estado                 BIT NOT NULL CONSTRAINT DF_tbUnidadesMedida_user_Estado DEFAULT(1)
				CONSTRAINT FK_Cons_tbUnidadesMedida_Acce_tbUsuarios_user_UsuCreacion_user_Id          FOREIGN KEY(user_UsuCreacion)                 REFERENCES Acce.tbUsuarios(user_Id),
				CONSTRAINT FK_Cons_tbUnidadesMedida_Acce_tbUsuarios_user_UsuModificacion_user_Id      FOREIGN KEY(user_UsuModificacion)             REFERENCES Acce.tbUsuarios(user_Id)
	);
GO

--***********************************************************TABLA INCIDENCIAS************************************************************--
--TABLA INCIDENCIAS
	CREATE TABLE Cons.tbIncidencia(
                inci_Id						INT IDENTITY(1,1),
                cons_Id						INT        NOT NULL,
                inci_Descripcion			NVARCHAR(MAX) NOT NULL,
                user_UsuCreacion            INT,
                inci_FechaCreacion          DATETIME NOT NULL CONSTRAINT DF_tbIncidencia_user_FechaCreacion DEFAULT(GETDATE()),
                user_UsuModificacion        INT,
                inci_FechaModificacion		DATETIME,
                user_Estado                 BIT NOT NULL CONSTRAINT DF_tbIncidencia_user_Estado DEFAULT(1)
				CONSTRAINT FK_Cons_tbIncidencia_cons_Id_Cons_tbConstrucciones_cons_Id			  FOREIGN KEY(cons_Id)							REFERENCES Cons.tbConstrucciones (cons_Id),
				CONSTRAINT FK_Cons_tbIncidencia_Acce_tbUsuarios_user_UsuCreacion_user_Id          FOREIGN KEY(user_UsuCreacion)                 REFERENCES Acce.tbUsuarios(user_Id),
				CONSTRAINT FK_Cons_tbIncidencia_Acce_tbUsuarios_user_UsuModificacion_user_Id      FOREIGN KEY(user_UsuModificacion)             REFERENCES Acce.tbUsuarios(user_Id)
);
GO

--*********************************************************** TERMINA LA CREACION ***************************************************************--
--************************************************************** DE TABLAS **********************************************************************--
--***********************************************************************************************************************************************--




--********************************************************* INSERCION DE  DATOS ***************************************************************--
--************************************************************** DE TABLAS **********************************************************************--
--***********************************************************************************************************************************************--

--****************************************************************TABLA ROLES********************************************************************--
--TABLA ROLES
INSERT INTO Acce.tbRoles(role_Nombre, user_UsuCreacion)
VALUES('Digitador', 1);
GO

INSERT INTO Acce.tbRoles(role_Nombre, user_UsuCreacion)
VALUES('Visualizador', 1);
GO

INSERT INTO Acce.tbRoles(role_Nombre, user_UsuCreacion)
VALUES('Miembro',1);
GO


--****************************************************************TABLA USUARIOS********************************************************************--

DECLARE @Pass AS NVARCHAR(MAX), @Clave AS NVARCHAR(250);
SET @Clave = '123';
SET @Pass = CONVERT(NVARCHAR(MAX), HASHBYTES('sha2_512', @Clave),2)

INSERT INTO ACCE.tbUsuarios
VALUES('admin', @Pass, 1, 1, 1,1, GETDATE(), NULL, NULL,1);
GO



--****************************************************************TABLA PANTALLAS********************************************************************--
--TABLA PANTALLAS
INSERT INTO Acce.tbPantallas(pant_Nombre, pant_Url, pant_Menu, pant_HtmlId, user_UsuCreacion) 
VALUES ('Usuarios',                         '/Usuario/Listado',                          'Acceso',          'usuariosItem',                      1),
       ('Roles',                            '/Roles/Listado',                            'Acceso',          'rolesItem',                         1),
       ('Roles Por Pantallas',              '/Roles Por Pantallas/Listado',              'Acceso',          'rolesporpantallasItem',             1),
       ('Cargos',                           '/Cargos/Listado',                           'General',         'cargosItem',                        1),
       ('Clientes',                         '/Clientes/Listado',                         'General',         'clientesItem',                      1),
       ('Empleados',                        '/Empleados/Listado',                        'General',         'empleadosItem',                     1),
       ('Empleados Por Construccion',       '/EmpleadosPorConstruccion/Listado',         'General',         'empleadosporconstruccionItem',      1),
       ('Construcciones',                   '/Construcciones/Listado',                   'Construccion',    'construccionItem',                  1),
       ('Empleados Por Construccion',       '/EmpleadosPorConstruccion/Listado',         'Construccion',    'empleadosporconstruccionItem',		 1),
       ('Insumos por Construccion',         '/InsumosPorConstruccion/Listado',           'Construccion',    'insumosporconstruccionItem',		 1),
       ('Unidades de Medida',               '/UnidadesDeMedida/Listado',                 'Construccion',    'unidadesdemedidaItem',				 1),
       ('Insumos',                          '/Insumos/Listado',                          'Construccion',    'insumosItem',						 1)


--****************************************************************TABLA ROLES POR PANTALLA********************************************************************--
--TABLA ROLES POR PANTALLA
INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 4, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 5, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 6, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 7, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 8, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 9, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 10, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 11, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (1, 12, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (2, 8, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (2, 9, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (2, 10, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (2, 11, 1)
GO

INSERT INTO Acce.tbPantallasRoles(role_Id, pant_Id, user_UsuCreacion)
VALUES                             (2, 12, 1)
GO


--****************************************************************TABLA DEPARTAMENTOS********************************************************************--
--TABLA DEPARTAMENTOS
INSERT INTO  GRAL.tbDepartamentos  
VALUES ('01', 'Atlántida', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('02', 'Colón', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('03', 'Comayagua', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('04', 'Copán', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('05', 'Cortés', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('06', 'Choluteca', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('07', 'El Paraíso', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('08', 'Francisco Morazán', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('09', 'Gracias a Dios', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('10', 'Intibucá', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('11', 'Islas de la Bahía', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('12', 'La Paz', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('13', 'Lempira', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('14', 'Ocotepeque', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('15', 'Olancho', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('16', 'Santa Bárbara', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('17', 'Valle', 1, GETDATE(), null, null);
GO

INSERT INTO  GRAL.tbDepartamentos  
VALUES ('18', 'Yoro', 1, GETDATE(), null, null);
GO


--****************************************************************TABLA ESTADOSCIVILES********************************************************************--
--TABLA ESTADOSCIVILES
INSERT INTO Gral.tbEstadosCiviles
VALUES  ('A','Amante',				1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES  ('C','Casado(a)',			1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES  ('N','Comprometido(a)',		1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES  ('D','Divorciado(a)',		1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES	('S','Soltero(a)',			1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES  ('U','Unión Libre',			1, GETDATE(), null, null);
GO

INSERT INTO Gral.tbEstadosCiviles
VALUES        ('V','Viudo(a)',			1, GETDATE(), null, null);
GO


--****************************************************************TABLA MUNICIPIOS********************************************************************--
--TABLA MUNICIPIOS

INSERT INTO Gral.tbMunicipios
VALUES('0101','La Ceiba','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0102','El Porvenir','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0103','Esparta','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0104','Jutiapa','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0105','La Masica','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0106','San Francisco','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0107','Tela','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0108','Arizona','01',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0201','Trujillo','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0202','Balfate','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0203','Iriona','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0204','Limón','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0205','Sabá','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0206','Santa Fe','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0207','Santa Rosa de Aguán','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0208','Sonaguera','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0209','Tocoa','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0210','Bonito Oriental','02',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0301','Comayagua','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0302','Ajuterique','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0303','El Rosario','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0304','Esquías','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0305','Humuya','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0306','La Libertad','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0307','Lamaní','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0308','La Trinidad','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0309','Lejamaní','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0310','Meámbar','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0311','Minas de Oro','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0312','Ojos de Agua','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0313','San Jerónimo','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0314','San José de Comayagua','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0315','San José del Potrero','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0316','San Luis','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0317','San Sebastián','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0318','Siguatepeque','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0319','Villa de San Antonio','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0320','Las Lajas','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0321','Taulabé','03',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0401','Santa Rosa de Copán','04',1,GETDATE(),NULL,NULL);
 GO
INSERT INTO Gral.tbMunicipios
VALUES('0402','Cabañas','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0403','Concepción','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0404','Copán Ruinas','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0405','Corquín','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0406','Cucuyagua','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0407','Dolores','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0408','Dulce Nombre','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0409','El Paraíso','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0410','Florida','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0411','La Jigua','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0412','La Unión','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0413','Nueva Arcadia','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0414','San Agustín','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0415','San ANTONIO','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0416','San Jerónimo','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0417','San José','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0418','San Juan de Opoa','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0419','San Nicolás','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0420','San Pedro','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0421','Santa Rita','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0422','Trinidad de Copán','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0423','Veracruz','04',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0501','San Pedro Sula','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0502','Choloma','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0503','Omoa','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0504','Pimienta','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0505','Potrerillos','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0506','Puerto Cortés','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0507','San Antonio de Cortés','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0508','San Francisco de Yojoa','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0509','San Manuel','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0510','Santa Cruz de Yojoa','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0511','Villanueva','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0512','La Lima','05',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0601','Choluteca','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0602','Apacilagua','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0603','Concepción de María','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0604','Duyure','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0605','El Corpus','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0606','El Triunfo','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0607','Marcovia','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0608','Morolica','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0609','Namasigüe','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0610','Orocuina','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0611','Pespire','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0612','San Antonio de Flores','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0613','San Isidro','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0614','San José','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0615','San Marcos de Colón','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0616','Santa Ana de Yusguare,','06',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0701','Yuscarán','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0702','Alauca','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0703','Danlí','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0704','El Paraíso','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0705','"Güinope','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0706','Jacaleapa','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0707','Liure','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0708','Morocelí','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0709','Oropolí','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0710','Potrerillos','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0711','San Antonio de Flores','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0712','San Lucas','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0713','San Matías','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0714','Soledad','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0715','Teupasenti','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0716','Texiguat','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0717','Vado Ancho','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0718','Yauyupe','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0719','Trojes','07',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0801','Distrito Central (Tegucigalpa y Comayaguela)','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0802','Alubarén','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0803','Cedros','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0804','Curarén','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0805','El Porvenir','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0806','Guaimaca','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0807','La Libertad','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0808','La Venta','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0809','Lepaterique','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0810','Maraita','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0811','Marale','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0812','Nueva Armenia','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0813','Ojojona','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0814','Orica (Francisco Morazan)','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0815','Reitoca','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0816','Sabanagrande','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0817','San Antonio de Oriente','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0818','San Buenaventura','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0819','San Ignacio','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0820','San Juan de Flores o como se le conoce Cantarrana','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0821','San Miguelito','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0822','Santa Ana','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0823','Santa Lucía','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0824','Talanga','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0825','Tatumbla','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0826','Valle de Ángeles','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0827','Villa de San Francisco','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0828','Vallecillo','08',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0901','Puerto Lempira','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0902','Brus Laguna','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0903','Ahuas','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0904','Juan Francisco Bulnes','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('0905','Ramón Villeda Morales','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('0906','Wampusirpe','09',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1001','La Esperanza','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1002','Camasca','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1003','Colomoncagua','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1004','Concepción','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1005','Dolores','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1006','Intibucá','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1007','Jesús de Otoro','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1008','Magdalena','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1009','Masaguara','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1010','San Antonio','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1011','San Isidro','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1012','San Juan','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1013','San Marcos de la Sierra','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1014','San Miguel Guancapla','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1015','Santa Lucía','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1016','Yamaranguila','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1017','San Francisco de Opalaca','10',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1101','Roatán','11',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1102','Guanaja','11',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1103','José Santos Guardiola','11',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1104','Utila','11',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1201','La Paz','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1202','Aguanqueterique','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1203','Cabañas','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1204','Cane','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1205','Chinacla','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1206','Guajiquiro','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1207','Lauterique','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1208','Marcala','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1209','Mercedes de Oriente','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1210','Opatoro','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1211','San Antonio del Norte','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1212','San José','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1213','San Juan','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1214','San Pedro de Tutule','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1215','Santa Ana','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1216','Santa Elena','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1217','Santa María','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1218','Santiago de Puringla','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1219','Yarula','12',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1301','Gracias','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1302','Belén','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1303','Candelaria','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1304','Cololaca','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1305','Erandique','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1306','Gualcince','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1307','Guarita','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1308','La Campa','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1309','La Iguala','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1310','LaS Flores','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1311','La Unión','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1312','La Virtud','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1313','Lepaera','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1314','Mapulaca','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1315','Piraera','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1316','San Andrés','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1317','San Francisco','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1318','San Juan Guarita','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1319','San Manuel Colohete','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1320','San Rafael','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1321','San Sebastián','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1322','Santa Cruz','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1323','Talgua','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1324','Tambla','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1325','Tomalá','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1326','Valladolid','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1327','Virginia','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1328','San Marcos de Caiquín','13',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1401','Nueva Ocotepeque','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1402','Belén Gualcho','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1403','Concepción','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1404','Dolores Merendón','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1405','Fraternidad','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1406','La Encarnación','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1407','La Labor','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1408','Lucerna','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1409','Mercedes','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1410','San Fernando','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1411','San Francisco del Valle','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1412','San Jorge','14',1,GETDATE(),NULL,NULL);
 GO
INSERT INTO Gral.tbMunicipios 
VALUES('1413','San Marcos','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1414','Santa Fe','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1415','Sensenti','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1416','Sinuapa','14',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1501','Juticalpa','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1502','Campamento','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1503','Catacamas','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1504','Concordia','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1505','Dulce Nombre de Culmí','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1506','El Rosario','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1507','Esquipulas del Norte','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1508','Gualaco','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1509','Guarizama','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1510','GUATA','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1511','Guayape','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1512','Jano','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1513','La UNIÓN','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1514','Mangulile','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1515','Manto','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1516','Salamá','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1517','San Esteban','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1518','San Francisco de Becerra','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1519','San Francisco de la Paz','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1520','Santa María del Real','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1521','Silca','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1522','Yocón','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1523','Patuca','15',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1601','Santa Bárbara','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1602','Arada','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1603','Atima','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1604','Azacualpa','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1605','Ceguaca','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1606','San José de las Colinas','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1607','Concepción del Norte','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1608','Concepción del Sur','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1609','Chinda','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1610','El Níspero','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1611','Gualala','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1612','Ilama','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1613','Macuelizo','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1614','Naranjito','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1615','Nuevo Celilac','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1616','Petoa','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1617','Protección','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1618','Quimistán','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1619','San Francisco de Ojuera','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1620','San Luis','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1621','San Marcos','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1622','San Nicolás','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1623','San Pedro Zacapa','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1624','Santa Rita','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1625','San Vicente Centenario','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1626','Trinidad','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1627','LaS Vegas','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1628','Nueva Frontera','16',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1701','Nacaome','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1702','Alianza','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1703','Amapala','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1704','Aramecina','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1705','Caridad','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1706','Goascorán','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1707','Langue','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1708','San Francisco de Coray','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1709','San Lorenzo','17',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1801','Yoro','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1802','Arenal','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1803','El Negrito','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1804','El Progreso','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1805','Jocón','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1806','Morazán','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1807','Olanchito','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1808','Santa Rita','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1809','Sulaco','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios
VALUES('1810','Victoria','18',1,GETDATE(),NULL,NULL);
GO
INSERT INTO Gral.tbMunicipios 
VALUES('1811','Yorito','18',1,GETDATE(),NULL,NULL);

GO


--****************************************************************TABLA CONSTRUCCIONES********************************************************************--
--TABLA CONSTRUCCIONES
INSERT INTO Cons.tbConstrucciones(cons_Proyecto,cons_ProyectoDescripcion, muni_Id, cons_Direccion, cons_FechaInicio, cons_FechaFin, user_UsuCreacion,user_Estado)
VALUES        ('Proyecto Construccion Edificio', 'Construccion completa de un Edificio con 2 plantas', '0501', '1ra Calle, 3ra Avenida, Frente al Parque Central', '11/12/23', '11/12/25', 1,1)
GO

INSERT INTO Cons.tbConstrucciones(cons_Proyecto,cons_ProyectoDescripcion, muni_Id, cons_Direccion, cons_FechaInicio, cons_FechaFin, user_UsuCreacion,user_Estado)
VALUES        ('Proyecto Arreglo Sucursal', 'Arreglo de primer piso completo de Sucursal', '0803', '5ta Calle, 3ra Avenida, Atrás de Tropigas', '11/12/23', '11/12/25', 1,1)
GO


--****************************************************************TABLA INSUMOS********************************************************************--
--TABLA INSUMOS
INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES                   ('Puertas', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Ventas', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Cerrajería', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Chapas', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Inodoros', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Lavabos', 1);
GO                          
                          
INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Enchufes', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Sierras', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Martillos', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Clavos', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Lavabos', 1);
GO

INSERT INTO Cons.tbInsumos(insm_Descripcion, user_UsuCreacion)
VALUES					('Destornilladores', 1);
GO                         
   
   
--****************************************************************TABLA CONSTRUCCION POR INSUMOS********************************************************************--
--TABLA CONSTRUCCION POR INSUMOS
INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 1,1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 2, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 3, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 4, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 5, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 6, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(1, 7, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(2, 8, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(2, 9, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(2, 10, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id, user_UsuCreacion)
VALUES									(2, 11, 1);
GO

INSERT INTO Cons.tbInsumosConstruccion(cons_Id, insm_Id,user_UsuCreacion)
VALUES									(2, 12, 1);
GO


--****************************************************************TABLA INCIDENCIAS********************************************************************--
--TABLA INCIDENCIAS
INSERT INTO Cons.tbIncidencia(cons_Id, inci_Descripcion, user_UsuCreacion)
VALUES  (1, 'No se pudo conectar el cableado correctamente', 1);
GO


--****************************************************************TABLA UNIDADES DE MEDIDA ********************************************************************--
--TABLA UNIDADES DE MEDIDA
INSERT INTO Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							 ('Libra', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Kilogramo', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Gramo', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Kilo', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Metro', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('CentÃ­metro', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Pulgada', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Pie', 1);
GO

INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Onza', 1);
GO
		
INSERT INTO  Cons.tbUnidadesMedida(unim_Descripcion, user_UsuCreacion)
VALUES							('Sacos', 1);
GO


--****************************************************************TABLA CARGOS ********************************************************************--
--TABLA CARGOS	
INSERT INTO GRAL.tbCargos(carg_Cargo, user_UsuCreacion)
VALUES									   ('Ingeniero', 1);
GO

INSERT INTO GRAL.tbCargos(carg_Cargo, user_UsuCreacion)
VALUES									   ('Jefe de obra', 1);
GO
	
INSERT INTO GRAL.tbCargos(carg_Cargo, user_UsuCreacion)
VALUES									   ('Ingenieros de sistema', 1);
GO

INSERT INTO GRAL.tbCargos(carg_Cargo, user_UsuCreacion)
VALUES									   ('Arquitecto', 1);
GO


	
--****************************************************************TABLA EMPLEADOS ********************************************************************--
--TABLA EMPLEADOS								 
INSERT INTO Gral.tbEmpleados
VALUES('1884200105691', 'Ian Alexander', 'Hernandez Escobar', 'M', 'S','0501',1,'3ra Ave Sur, Col. 2 de Mrazo','10-22-2001', '9471-3500', 'ianh8902@gmail.com', 1,  GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0501200209630', 'Axel Dario', 'Rivera Murillo', 'M', 'C','0802',2,'4ta Ave. Norte, Frente al Supermercado la Antorcha', '03-05-2002', '3165-0161', 'axeldm05@gmail.com', 1,  GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0613199817853', 'Jose Miguel', 'Murcia Castro', 'M', 'C','0701',1,'Entre 4ta Calle y 5ta Calle, Ave. Sur, Col. Los Olivos' ,'03-14-1998', '3831-3029', 'miguel.castro@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('1801200000010', 'Noe Edil', 'Barnica Ramos', 'M', 'S','0102',1,'Entre 5ta Calle y 6ta Calle, Ave Norte', '05-19-2000','8925-8314', 'noe3@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0501200110543', 'Loany Michelle', 'Paz Guerra', 'F', 'V','0501',3,'Col. Primavera, Frente a la Municipalidad','03-27-2001', '8586-2314', 'loany15@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0409199934517', 'Daniel Enrique', 'Matamoros De la O', 'M', 'D','0106',1,'Res. Campisa','04-30-1999','9991-4436', 'enrique.99@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0503200207911', 'Andrea Nicolle', 'Crivelli Zamorano', 'F', 'S','1101',3,'Res. Quintas Marta Elena', '10-29-2002', '3915-1658', 'nicolle29@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0607199301185', 'M?gdaly', 'Z?niga Alvarado', 'F', 'C','0502',2,'Res. Cerro Verde','11-25-1993', '3339-6645', 'magdalyz22@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('0501200506681', 'Javier Eduardo', 'L?pez', 'M', 'V','0502',1,'Res. Los Olivos','03-09-2005', '9821-4819', 'javslopez7@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('1615200500062', 'Juan David', 'Molina Sagastume', 'M', 'D','0502',2,'Res. Los 3 Hermanos', '02-22-2005', '9451-9231', 'juanmolinasagastume@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES('1615200500069', 'Eder Jesus', 'Sanchez Mantinez', 'M', 'C','0501',1,'Ave Sur, 4ta Calle, Col. Esperanza', '04-22-2002', '9858-7548', 'eder85@hotmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES ('1615201504069', 'Mario Adalid', 'Escobar Flores', 'M', 'C','0501',3,'3ra Ave Sur, Col. 2 de Mrazo','10-05-2002','8478-6474', 'marioescobar87@hotmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES ('1154200504869', 'Esdra', 'Cerna', 'F', 'S','0802',1,'4ta Ave. Norte, Frente al Supermercado la Antorcha','10-05-1986','8745-9885', 'esdraCerna45@hotmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES ('1804200804125', 'Giovanny Antonio', 'Hernandez Escobar', 'M', 'C','0701',1,'Entre 4ta Calle y 5ta Calle, Ave. Sur, Col. Los Olivos','10-11-2001','8478-6474', 'gioantony@gmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES ('1804200305214', 'Edgardo Alexander', 'Sandoval Diaz', 'M', 'D','0102',3,'Entre 5ta Calle y 6ta Calle, Ave Norte','02-14-2002','9784-5841', 'edgar84@hotmail.com', 1, GETDATE(), NULL, NULL,1);
GO

INSERT INTO Gral.tbEmpleados
VALUES ('789456487254', 'Esdra Maria', 'Cerna', 'F', 'S','0501',2,'Ave Sur, 4ta Calle, Col. Esperanza','04-20-1992','4512-1205', 'Esdra_Cerna@hotmail.com', 1 ,GETDATE(), NULL, NULL,1);
GO								 
								 

--****************************************************************TABLA EMPLEADOS POR CONSTRUCCION ********************************************************************--
--TABLA EMPLEADOS POR CONSTRUCCION	
INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 1, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 2, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 3, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 4, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 5, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 6, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 7, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 8, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 9, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 10, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 11, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 12, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 13, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 14, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 15, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (1, 16, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (2, 1, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (2, 2, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (2, 3, 1);
GO

INSERT INTO Cons.tbEmpleadosPorConstruccion(cons_Id, empl_Id, user_UsuCreacion)
VALUES									   (2, 10, 1);
GO
		


--****************************************************************TABLA CLIENTES ********************************************************************--
--TABLA CLIENTES
INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado )
VALUES						('1615199009008', 'Hugo Alcerro', '0901', 'Calle hacia Armenta, atras de Mall Altara.', '9009-6778','hugalcerro@gmail.com', 1 , 1);
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('0910197600977', 'Mariela Vega', '0901', '3ra Avenida, 2da Calle Prolonogación Pasaje Valle', '9878-3241','marvega@gmail.com', 1 , 1);
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('0901199209034', 'Oliver Membreño', '0901', '1ra Calle, Salida a La Lima', '8909-3343','olimem@gmail.com', 1 , 1);
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('0304199790567', 'Ernestina Juarez', '0901', '5ta Calle, 5ta Avenida, Barrio El Centro', '9780-5463','ernesmia@gmail.com', 1 , 1);
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('1002199062718', 'Juana Yanez', '1001', '2da Calle, Avenida Junior', '9231-6512','juajua@gmail.com', 1, 1 );
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('1210197600097', 'Victor Carcasa', '0101', '16 Avenida, Barrio Suyapa', '9767-6657','sandroyane@gmail.com', 1, 1 );
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('0912199090790', 'Ilinois Herrera', '0201', '2da Calle, Avenida Junior', '9567-7789','ilinourquia@gmail.com', 1 , 1);
GO

INSERT INTO Cons.tbClientes(clie_Identificacion, clie_Nombre, muni_Id, clie_DireccionExacta, clie_Telefono, clie_CorreoElectronico, user_IdCreacion, clie_Estado)
VALUES						('0915199056281', 'Elia Carcasa', '0301', 'Col. El Carmen, Calle Principal', '9123-5434','eliameji@gmail.com', 1, 1 );
GO


--*********************************************************** TERMINA LA INSERCION ***************************************************************--
--************************************************************** DE TABLAS **********************************************************************--
--***********************************************************************************************************************************************--


--*********************************************************** INICIA LOS ALTER DE***************************************************************--
--************************************************************** LAS TABLAS **********************************************************************--
--***********************************************************************************************************************************************--

--***************************************************************************************************************************************--
GO
ALTER TABLE Acce.tbUsuarios
ADD CONSTRAINT FK_Acce_tbUsuarios_Acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbUsuarios_Acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbUsuarios_Acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES Acce.tbRoles(role_Id)

GO 
ALTER TABLE Acce.tbPantallasRoles
ADD CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([user_UsuCreacion]) REFERENCES Acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_Acce_tbPantallasPorRoles_Acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([user_UsuModificacion]) REFERENCES Acce.tbUsuarios([user_Id])

--***************************************************************************************************************************************--
GO



--*********************************************************** TERMINAN LOS ALTER DE***************************************************************--
--************************************************************** LAS TABLAS **********************************************************************--
--***********************************************************************************************************************************************--



--*********************************************************** INICIAN LOS UDP'S DE***************************************************************--
--************************************************************** LAS TABLAS **********************************************************************--
--***********************************************************************************************************************************************--

GO
CREATE OR ALTER VIEW WW_tbRoles
AS
 SELECT role_Id, role_Nombre FROM Acce.tbRoles
GO

CREATE OR ALTER PROC Acce.UDP_tbRoles_Insert
	@role_Nombre	NVARCHAR(100),
	@status			INT OUTPUT
AS
BEGIN

	BEGIN TRY
		INSERT INTO Acce.tbRoles
		VALUES		(@role_Nombre, 1, GETDATE(), NULL, NULL, 1);
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;

END


GO

CREATE OR ALTER PROC Acce.UDP_tbRoles_Update
	@role_Id		INT,
	@role_Nombre	NVARCHAR(100),
	@status			INT OUTPUT
AS
BEGIN	

	BEGIN TRY
		UPDATE [Acce].[tbRoles]
		SET [role_Nombre] = @role_Nombre
			,[user_UsuModificacion] = 1
			,[role_FechaModificacion] = GETDATE()
		WHERE [role_Id] = @role_Id
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;

END

GO


CREATE OR ALTER PROC Acce.UDP_tbRoles_Delete
	@role_Id					INT,
	@role_role_UsuModificacion	INT,
	@status						INT OUTPUT
AS
BEGIN	

	BEGIN TRY
	   UPDATE [Acce].[tbRoles]
	   SET [user_UsuModificacion] = @role_role_UsuModificacion
		  ,[role_FechaModificacion] = GETDATE()
		  ,[role_Estado] = 0
	 WHERE [role_Id] = @role_Id
		SET @status = 1;
	END TRY
	BEGIN CATCH
		SET @status = 0;
	END CATCH;

END

GO
--********************************************** UDP INSERTAR USUARIOS *************************************************--
--Procediminetos de Usuarios
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