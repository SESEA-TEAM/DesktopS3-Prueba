USE [master]
GO
/****** Object:  Database [Usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
CREATE DATABASE [Usuario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Usuario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Usuario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Usuario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Usuario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Usuario] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Usuario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Usuario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Usuario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Usuario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Usuario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Usuario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Usuario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Usuario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Usuario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Usuario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Usuario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Usuario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Usuario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Usuario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Usuario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Usuario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Usuario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Usuario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Usuario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Usuario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Usuario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Usuario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Usuario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Usuario] SET RECOVERY FULL 
GO
ALTER DATABASE [Usuario] SET  MULTI_USER 
GO
ALTER DATABASE [Usuario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Usuario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Usuario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Usuario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Usuario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Usuario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Usuario', N'ON'
GO
ALTER DATABASE [Usuario] SET QUERY_STORE = OFF
GO
USE [Usuario]
GO
/****** Object:  User [Omar]    Script Date: 02/12/2022 09:44:40 a. m. ******/
CREATE USER [Omar] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_owner]
GO
/****** Object:  ColumnMasterKey [CMK_Auto1]    Script Date: 02/12/2022 09:44:40 a. m. ******/
CREATE COLUMN MASTER KEY [CMK_Auto1]
WITH
(
	KEY_STORE_PROVIDER_NAME = N'MSSQL_CERTIFICATE_STORE',
	KEY_PATH = N'CurrentUser/my/7BB0932975D0D93F0F4DEE5AD3DF5F81CB01EAFB'
)
GO
/****** Object:  ColumnEncryptionKey [CEK_Auto1]    Script Date: 02/12/2022 09:44:40 a. m. ******/
CREATE COLUMN ENCRYPTION KEY [CEK_Auto1]
WITH VALUES
(
	COLUMN_MASTER_KEY = [CMK_Auto1],
	ALGORITHM = 'RSA_OAEP',
	ENCRYPTED_VALUE = 0x016E000001630075007200720065006E00740075007300650072002F006D0079002F003700620062003000390033003200390037003500640030006400390033006600300066003400640065006500350061006400330064006600350066003800310063006200300031006500610066006200A7C0787E1EA47FC1103DDEF778D7641253C6B7064A8CD6FE8E175AFE01C2928DB1E20AF8D449ABCADECE0E2276D2FDC8CFAAE37C6FB7E6C6687429A143BFB85D39389FFEEA93342E2B217AF8DEBE47B19DF3D79A8568F00CECDB79BB927E85FB7FDE2529948B35A0E4BE72610AEC46C1E2593D3F2ADEC4AD79A09203D83DEFCDF3F112C27C68A25FE9DDA5542644D89A5C2DA01B8D8800957B31BBE63DFBE0FF21B07C8AB9782BA224436E45EAA19D171BF11E5A7634D9E7A747EE5C6FDA8010E83FE3A487C8B56B6E996F41E8EACB2ADA5291A50F2A8219C84F00B95E2B4C647D234480542DBB4E37EAD02234E199C1B48F8E0CAA718EAF113F2367216E4C909E4341673232C34A9AE40749EF1E31CB6F3411D373A48487B59F141F04C7FBAA3760990324417CA28F0E4899DF04F7199FCDC5C8726BB41EA5ECC2558445A888C6379C54FAC67BA977B0C49F2EB7472E847A2DA9DCFC71AE511668A4C416B51EDF5953FFBB52B0E47E69A586817C44C45F5364C47BE80AABB0AF486C3B88966EF63C5C625454E95BB4695C92AD4B9390665C0F8A0509F5F6A921A3B1304A1B68E92916996FFE9A562DF00609DA492C62A8F14956E40E4EE923DC39B2DBCB7C69498366241A50C00E56A27511B893579643674E0327AC4E994706525301553A7129E022FE33731DAC052E851A2810E452405FD4D62682803A50C2AE0CBB9F0033
)
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[operacion] [varchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[sistema] [varchar](100) NOT NULL,
	[registros] [int] NOT NULL,
	[usuario] [int] NOT NULL,
 CONSTRAINT [PK_bitacora] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contrasena]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contrasena](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contrasena] [varchar](max) NULL,
 CONSTRAINT [PK_contrasena] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[perfil]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[perfil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cargo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[proveedor] [varchar](200) NOT NULL,
	[sistema] [varchar](100) NULL,
	[estatus] [varchar](20) NULL,
	[fecha_alta] [datetime] NOT NULL,
	[fecha_actualizacion] [datetime] NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidoUno] [varchar](50) NOT NULL,
	[apellidoDos] [varchar](50) NULL,
	[correoElectronico] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[extension] [varchar](50) NULL,
	[usuario] [varchar](50) NOT NULL,
	[proveedorDatos] [int] NOT NULL,
	[estatus] [varchar](20) NOT NULL,
	[id_perfil] [int] NOT NULL,
	[id_contrasena] [int] NOT NULL,
	[cargo] [varchar](50) NULL,
	[fecha_alta] [datetime] NULL,
	[fecha_actualizacion] [datetime] NULL,
	[sesion] [tinyint] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[perfil] ON 

INSERT [dbo].[perfil] ([id], [cargo]) VALUES (1, N'Administrador')
INSERT [dbo].[perfil] ([id], [cargo]) VALUES (2, N'Capturador')
SET IDENTITY_INSERT [dbo].[perfil] OFF
GO
/****** Object:  Index [IX_usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
CREATE NONCLUSTERED INDEX [IX_usuario] ON [dbo].[usuario]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[bitacora]  WITH CHECK ADD  CONSTRAINT [FK_bitacora_usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[bitacora] CHECK CONSTRAINT [FK_bitacora_usuario]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_contrasena] FOREIGN KEY([id_contrasena])
REFERENCES [dbo].[contrasena] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_contrasena]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_perfil] FOREIGN KEY([id_perfil])
REFERENCES [dbo].[perfil] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_perfil]
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD  CONSTRAINT [FK_usuario_usuario] FOREIGN KEY([proveedorDatos])
REFERENCES [dbo].[proveedor] ([id])
GO
ALTER TABLE [dbo].[usuario] CHECK CONSTRAINT [FK_usuario_usuario]
GO
/****** Object:  StoredProcedure [dbo].[buscarBitacora]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[buscarBitacora]
@fInicial DATETIME, @fFinal DATETIME, @sistema VARCHAR (50)=NULL, @usuario VARCHAR (50)=NULL
AS
IF @sistema IS NULL
    BEGIN
        SET @sistema = '%';
    END
IF @usuario IS NULL
    BEGIN
        SET @usuario = '%';
    END
SELECT b.operacion,
       b.fecha,
       b.sistema,
       b.registros,
       u.usuario
FROM   bitacora AS b
       INNER JOIN
       usuario AS u
       ON (b.usuario = u.id)
WHERE  b.fecha BETWEEN @fInicial AND @fFinal
       AND b.sistema LIKE @sistema
       AND CONVERT (VARCHAR, b.usuario) LIKE @usuario;
GO
/****** Object:  StoredProcedure [dbo].[cargarComboPerfil]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cargarComboPerfil]

as
begin
select id, cargo from perfil;
end
GO
/****** Object:  StoredProcedure [dbo].[cargarComboProveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[cargarComboProveedor]

as
begin
select id, proveedor from proveedor
where estatus = 'Vigente';
end
GO
/****** Object:  StoredProcedure [dbo].[Editar_proveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Editar_proveedor]
(@Id int,
@Proveedor Varchar(50),
@Sistema Varchar(100),
@Estatus Varchar(20)

 ) 
as
BEGIN            
update  proveedor
     set
           
		   proveedor = @Proveedor,
          sistema = @Sistema ,
         estatus=  @Estatus,
		 fecha_actualizacion = getdate()
		where
           id = @Id

		   end
GO
/****** Object:  StoredProcedure [dbo].[Editar_usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Editar_usuario]
(@Id int,
@Nombre Varchar(50),
@ApellidoUno Varchar(50),
@ApellidoDos Varchar(50),
@Cargo Varchar(50),
@CorreoElectronico Varchar(50),
@Telefono Varchar(50),
@Extension Varchar(50),
@Usuario Varchar(50),
@ProveedorDatos int,
@Estatus Varchar(50)
 ) 
as
BEGIN            
update  usuario
     set
           nombre = @Nombre,
		   apellidoUno = @ApellidoUno,
		   apellidoDos = @ApellidoDos,
		   Cargo = @Cargo,
		   correoElectronico = @CorreoElectronico,
		   telefono = @Telefono,
		   extension = @Extension,
		   usuario = @Usuario,
		   proveedorDatos = @ProveedorDatos,
		   estatus=  @Estatus,
		   fecha_actualizacion = getdate()
		where
           id = @Id
		   end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_proveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Eliminar_proveedor]
(@Id int
 ) 
as
BEGIN            
	update   proveedor
	set
			 estatus = 'No vigente'
	where
	id = @id;
end
GO
/****** Object:  StoredProcedure [dbo].[Eliminar_usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Eliminar_usuario]
(@Id int
 ) 
as
BEGIN            
	delete from usuario
			where id = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[Insertar_proveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertar_proveedor]
(@Proveedor Varchar(50),
@Sistema Varchar(100)
 ) 
as
BEGIN            
INSERT INTO proveedor
           (proveedor
           ,sistema
           ,estatus
           ,fecha_alta)
     VALUES
           (@Proveedor,
          @Sistema ,
          'Vigente',
           getdate() );

		   end
GO
/****** Object:  StoredProcedure [dbo].[insertar_usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insertar_usuario]
(@Nombre Varchar(50),
@ApellidoUno Varchar(50),
@ApellidoDos Varchar(50),
@Cargo Varchar(50),
@CorreoElectronico Varchar(50),
@Telefono Varchar(50),
@Extension Varchar(50),
@Usuario Varchar(50),
@Perfil int,
@Contraseña Varchar(200),
@ProveedorDatos int
) 
as
BEGIN

INSERT INTO contrasena (contrasena) values (@Contraseña)
declare @idContraseña as int
set @idContraseña = (select max(id) from contrasena)

INSERT INTO usuario
           (nombre
           ,apellidoUno
           ,apellidoDos
		   ,Cargo
           ,correoElectronico
		   ,telefono
		   ,extension
		   ,usuario
		   ,proveedorDatos
		   ,estatus
		   ,id_perfil
		   ,id_contrasena
		   ,fecha_alta
		   ,sesion)
     VALUES
           (@Nombre,
          @ApellidoUno,
		  @ApellidoDos,
		  @Cargo,
		  @CorreoElectronico,
		  @Telefono,
		  @Extension,
		  @Usuario,
		  @ProveedorDatos,
          'Vigente',
		  @Perfil,
		  @idContraseña,
		  getdate(),
		  0);

		   end
GO
/****** Object:  StoredProcedure [dbo].[llenaUsuarios]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[llenaUsuarios]
as
select id,
		usuario
		from usuario;
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[login]
(@Usuario varchar(50),
@Contrasena varchar(200))
as
begin
--declare @us
select	
        a.nombre,
		b.cargo,
		a.id
		from usuario as a
		inner join perfil as b on (a.id_perfil = b.id) inner join contrasena as c on (a.id_contrasena = c.id) where a.usuario = @Usuario and c.contrasena = @Contrasena
update sus set sesion = 1 	
		from usuario as sus
		inner join perfil as b on (sus.id_perfil = b.id) inner join contrasena as c on (sus.id_contrasena = c.id) where sus.usuario = @Usuario and c.contrasena = @Contrasena
		end
GO
/****** Object:  StoredProcedure [dbo].[logout]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[logout]
(@Usuario tinyint)
as
begin
--declare @us

update sus set sesion = 0 	
		from usuario as sus
		where id=@Usuario
		end
GO
/****** Object:  StoredProcedure [dbo].[procedure_insertar]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[procedure_insertar]
 (@operacion varchar(50), @sistema varchar(50), @registros int ,@usuario int  )
as

    INSERT INTO bitacora(operacion, fecha, sistema,registros,usuario)
    SELECT @operacion,GETDATE(),@sistema,@registros, @usuario FROM bitacora;
GO
/****** Object:  StoredProcedure [dbo].[seleccionar_datosUser]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[seleccionar_datosUser]
@InicioTablaListadoUSR int, @FinalTablaListadoUSR int
as
declare @tablaAUX table(
	id int not null IDENTITY(1,1),
	idUsuario varchar(50),
    nombreCompleto varchar(50),
	nombre varchar(50),
	apellidoUno varchar(50),
	apellidoDos varchar(50),
	cargo varchar(50),
	usuario varchar(50),
	correoElectronico varchar(50),
    proveedor varchar(200),
	telefono varchar(50),
	extension varchar(50),
	estatus varchar(50),
	fecha_alta varchar(50),
	fecha_actualizacion varchar(50))
insert into @tablaAUX (idUsuario, nombreCompleto, nombre, apellidoUno, apellidoDos, cargo, usuario, correoElectronico, proveedor, telefono, extension, estatus, fecha_alta, fecha_actualizacion) select
b.id, CONCAT(b.nombre, ' ', b.apellidoUno, ' ', b.apellidoDos) full_name, b.nombre, b.apellidoUno, b.apellidoDos, b.Cargo, b.usuario, b.correoElectronico, a.proveedor, b.telefono, b.extension, 
b.estatus, b.fecha_alta, b.fecha_actualizacion
		from usuario as b
		inner join proveedor as a on (b.proveedorDatos = a.id)

select	top(10) id,
		idUsuario,
		CONCAT(nombre, ' ', apellidoUno, ' ', apellidoDos) full_name,
		nombre, 
		apellidoUno,
		apellidoDos,
		Cargo,
		usuario,
		correoElectronico,
		proveedor,
		telefono,
		extension,
		estatus,
		fecha_alta,
		fecha_actualizacion
		from @tablaAUX
		where id >= @InicioTablaListadoUSR;
GO
/****** Object:  StoredProcedure [dbo].[seleccionar_proveedor]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[seleccionar_proveedor]
as
select id,
		proveedor,
		sistema,
		estatus,
		fecha_alta,
		fecha_actualizacion
		from proveedor;
GO
/****** Object:  StoredProcedure [dbo].[seleccionar_usuario]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[seleccionar_usuario]
as
select	b.id,
		CONCAT(b.nombre, ' ', b.apellidoUno, ' ', b.apellidoDos) full_name,
		b.usuario,
		b.correoElectronico,
		a.proveedor
		from usuario as b
		inner join proveedor as a on (b.proveedorDatos = a.id);
GO
/****** Object:  StoredProcedure [dbo].[UltimoBarraListadoUsuarios]    Script Date: 02/12/2022 09:44:40 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UltimoBarraListadoUsuarios]
@Total int = null output
as
declare @tablaAUXUltimo table(
	id int not null IDENTITY(1,1),
    nombre varchar(50))
insert into @tablaAUXUltimo (nombre) select nombre from usuario 
select COUNT(*) as cantidad from @tablaAUXUltimo
	set @Total = (select count(*) from @tablaAUXUltimo)
	return @Total
GO
USE [master]
GO
ALTER DATABASE [Usuario] SET  READ_WRITE 
GO
