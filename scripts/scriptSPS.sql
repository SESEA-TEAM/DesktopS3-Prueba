USE [master]
GO
/****** Object:  Database [PublicosSancionados]    Script Date: 07/12/2022 10:56:01 a. m. ******/
CREATE DATABASE [PublicosSancionados]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Prueba', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Prueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Prueba_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Prueba_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PublicosSancionados] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PublicosSancionados].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PublicosSancionados] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PublicosSancionados] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PublicosSancionados] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PublicosSancionados] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PublicosSancionados] SET ARITHABORT OFF 
GO
ALTER DATABASE [PublicosSancionados] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PublicosSancionados] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PublicosSancionados] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PublicosSancionados] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PublicosSancionados] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PublicosSancionados] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PublicosSancionados] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PublicosSancionados] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PublicosSancionados] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PublicosSancionados] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PublicosSancionados] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PublicosSancionados] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PublicosSancionados] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PublicosSancionados] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PublicosSancionados] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PublicosSancionados] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PublicosSancionados] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PublicosSancionados] SET RECOVERY FULL 
GO
ALTER DATABASE [PublicosSancionados] SET  MULTI_USER 
GO
ALTER DATABASE [PublicosSancionados] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PublicosSancionados] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PublicosSancionados] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PublicosSancionados] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PublicosSancionados] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PublicosSancionados] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PublicosSancionados', N'ON'
GO
ALTER DATABASE [PublicosSancionados] SET QUERY_STORE = OFF
GO
USE [PublicosSancionados]
GO
/****** Object:  Table [dbo].[documentos]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[documentos](
	[idDocumentos] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](140) NOT NULL,
	[tipoDocumento] [int] NULL,
	[descripcion] [varchar](140) NOT NULL,
	[url] [varchar](200) NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[idDocumentos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genero]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genero](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [char](1) NOT NULL,
	[valor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_genero_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inhabilitacion]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inhabilitacion](
	[idInhabilitacion] [int] IDENTITY(1,1) NOT NULL,
	[plazo] [varchar](10) NULL,
	[fechaInicial] [date] NULL,
	[fechaFinal] [date] NULL,
 CONSTRAINT [PK_Inhabilitacion] PRIMARY KEY CLUSTERED 
(
	[idInhabilitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[institucionDependencia]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[institucionDependencia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](140) NULL,
	[nombre] [varchar](140) NOT NULL,
	[siglas] [varchar](10) NULL,
 CONSTRAINT [PK_InstitucionDepenencia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[listaDocumento]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[listaDocumento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDocumento] [int] NOT NULL,
	[idSancion] [int] NOT NULL,
 CONSTRAINT [PK_listaDocumento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[listaSanciones]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[listaSanciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idTipoSancion] [int] NOT NULL,
	[idSancion] [int] NOT NULL,
	[descripcionSancion] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moneda]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneda](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [char](10) NOT NULL,
	[valor] [varchar](140) NOT NULL,
 CONSTRAINT [PK_moneda_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[multa]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[multa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[moneda] [int] NULL,
	[monto] [float] NULL,
 CONSTRAINT [PK_Multa] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resolucion]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resolucion](
	[idResolucion] [int] IDENTITY(1,1) NOT NULL,
	[fechaResolucion] [date] NULL,
	[url] [varchar](140) NULL,
 CONSTRAINT [PK_Resolucion] PRIMARY KEY CLUSTERED 
(
	[idResolucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sancion]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sancion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaCaptura] [date] NOT NULL,
	[expediente] [varchar](140) NOT NULL,
	[autoridadSancionadora] [varchar](140) NOT NULL,
	[causaMotivoHecho] [varchar](140) NOT NULL,
	[servidorPublicoSancionado] [int] NOT NULL,
	[tipoFalta] [int] NOT NULL,
	[observaciones] [varchar](140) NULL,
	[institucionDependencia] [int] NOT NULL,
	[multa] [int] NULL,
	[resolucion] [int] NOT NULL,
	[inhabilitacion] [int] NOT NULL,
	[descripcionFalta] [varchar](140) NULL,
	[ultimaActualizacion] [date] NOT NULL,
 CONSTRAINT [PK_Sancion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servidorPublicoSancionado]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servidorPublicoSancionado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rfc] [char](13) NOT NULL,
	[curp] [char](18) NOT NULL,
	[nombre] [varchar](140) NOT NULL,
	[primerApellido] [varchar](140) NOT NULL,
	[segundoApellido] [varchar](140) NULL,
	[puesto] [varchar](140) NOT NULL,
	[nivel] [varchar](140) NULL,
	[genero] [int] NULL,
 CONSTRAINT [PK_servidorPublicoSancionado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoDocumento]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoDocumento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipoDocumento] [varchar](140) NOT NULL,
 CONSTRAINT [PK_tipoDocumento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoFalta]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoFalta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[valor] [varchar](140) NOT NULL,
 CONSTRAINT [PK_tipoFalta_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoSancion]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoSancion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[valor] [varchar](140) NOT NULL,
 CONSTRAINT [PK_tipoSancion_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[genero] ON 

INSERT [dbo].[genero] ([id], [clave], [valor]) VALUES (1, N'M', N'MASCULINO')
INSERT [dbo].[genero] ([id], [clave], [valor]) VALUES (2, N'F', N'FEMENINO')
SET IDENTITY_INSERT [dbo].[genero] OFF
GO
SET IDENTITY_INSERT [dbo].[moneda] ON 

INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (1, N'MXN       ', N'PESO MEXICANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (2, N'AED       ', N'DÍRHAM DE LOS EMIRATOS ÁRABES UNIDOS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (3, N'AFN       ', N'AFGANI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (4, N'ALL       ', N'LEK')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (5, N'AMD       ', N'DRAM ARMENIO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (6, N'ANG       ', N'FLORÍN ANTILLANO NEERLANDÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (7, N'AOA       ', N'KWANZA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (8, N'ARS       ', N'PESO ARGENTINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (9, N'AUD       ', N'DÓLAR AUSTRALIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (10, N'AWG       ', N'FLORÍN ARUBEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (11, N'AZN       ', N'MANAT AZERBAIYANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (12, N'BAM       ', N'MARCO CONVERTIBLE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (13, N'BBD       ', N'DÓLAR BARBADENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (14, N'BDT       ', N'TAKA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (15, N'BGN       ', N'LEV BÚLGARO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (16, N'BHD       ', N'DINAR BAREINÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (17, N'BIF       ', N'FRANCO DE BURUNDI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (18, N'BMD       ', N'DÓLAR BERMUDEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (19, N'BND       ', N'DÓLAR DE BRUNÉI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (20, N'BOB       ', N'BOLIVIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (21, N'BOV       ', N'MVDOL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (22, N'BRL       ', N'REAL BRASILEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (23, N'BSD       ', N'DÓLAR BAHAMEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (24, N'BTN       ', N'NGULTRUM')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (25, N'BWP       ', N'PULA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (26, N'BYN       ', N'RUBLO BIELORRUSO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (27, N'BZD       ', N'DÓLAR BELICEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (28, N'CAD       ', N'DÓLAR CANADIENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (29, N'CDF       ', N'FRANCO CONGOLEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (30, N'CHE       ', N'EURO WIR')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (31, N'CHF       ', N'FRANCO SUIZO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (32, N'CHW       ', N'FRANCO WIR')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (33, N'CLF       ', N'UNIDAD DE FOMENTO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (34, N'CLP       ', N'PESO CHILENO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (35, N'CNY       ', N'YUAN CHINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (36, N'COP       ', N'PESO COLOMBIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (37, N'COU       ', N'UNIDAD DE VALOR REAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (38, N'CRC       ', N'COLÓN COSTARRICENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (39, N'CUC       ', N'PESO CONVERTIBLE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (40, N'CUP       ', N'PESO CUBANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (41, N'CVE       ', N'ESCUDO CABOVERDIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (42, N'CZK       ', N'CORONA CHECA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (43, N'DJF       ', N'FRANCO YIBUTIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (44, N'DKK       ', N'CORONA DANESA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (45, N'DOP       ', N'PESO DOMINICANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (46, N'DZD       ', N'DINAR ARGELINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (47, N'EGP       ', N'LIBRA EGIPCIA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (48, N'ERN       ', N'NAKFA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (49, N'ETB       ', N'BIRR ETÍOPE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (50, N'EUR       ', N'EURO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (51, N'FJD       ', N'DÓLAR FIYIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (52, N'FKP       ', N'LIBRA MALVINENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (53, N'GBP       ', N'LIBRA ESTERLINA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (54, N'GEL       ', N'LARI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (55, N'GHS       ', N'CEDI GHANÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (56, N'GIP       ', N'LIBRA DE GIBRALTAR')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (57, N'GMD       ', N'DALASI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (58, N'GNF       ', N'FRANCO GUINEANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (59, N'GTQ       ', N'QUETZAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (60, N'GYD       ', N'DÓLAR GUYANÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (61, N'HKD       ', N'DÓLAR DE HONG KONG')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (62, N'HNL       ', N'LEMPIRA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (63, N'HRK       ', N'KUNA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (64, N'HTG       ', N'GOURDE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (65, N'HUF       ', N'FORINTO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (66, N'IDR       ', N'RUPIA INDONESIA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (67, N'ILS       ', N'NUEVO SÉQUEL ISRAELÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (68, N'INR       ', N'RUPIA INDIA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (69, N'IQD       ', N'DINAR IRAQUÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (70, N'IRR       ', N'RIAL IRANÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (71, N'ISK       ', N'CORONA ISLANDESA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (72, N'JMD       ', N'DÓLAR JAMAIQUINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (73, N'JOD       ', N'DINAR JORDANo')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (74, N'JPY       ', N'YEN')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (75, N'KES       ', N'CHELÍN KENIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (76, N'KGS       ', N'SOM')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (77, N'KHR       ', N'RIEL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (78, N'KMF       ', N'FRANCO COMORENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (79, N'KPW       ', N'WON NORCOREANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (80, N'KRW       ', N'WON')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (81, N'KWD       ', N'DINAR KUWAITÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (82, N'KYD       ', N'DÓLAR DE LAS ISLAS CAIMÁN')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (83, N'KZT       ', N'TENGE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (84, N'LAK       ', N'KIP')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (85, N'LBP       ', N'LIBRA LIBANESA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (86, N'LKR       ', N'RUPIA DE SRI LANKA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (87, N'LRD       ', N'DÓLAR LIBERIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (88, N'LSL       ', N'LOTI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (89, N'LYD       ', N'DINAR LIBIO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (90, N'MAD       ', N'DÍRHAM MARROQUÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (91, N'MDL       ', N'LEU MOLDAVO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (92, N'MGA       ', N'ARIARY MALGACHE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (93, N'MKD       ', N'DENAR')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (94, N'MMK       ', N'KYAT')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (95, N'MNT       ', N'TUGRIK')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (96, N'MOP       ', N'PATACA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (97, N'MRU       ', N'UGUIYA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (98, N'MUR       ', N'RUPIA DE MAURICIO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (99, N'MVR       ', N'RUFIYAA')
GO
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (100, N'MWK       ', N'KWACHA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (101, N'MXV       ', N'UNIDAD DE INVERSIÓN (UDI) MEXICANA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (102, N'MYR       ', N'RINGGIT MALAYO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (103, N'MZN       ', N'METICAL MOZAMBIQUEÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (104, N'NAD       ', N'DÓLAR NAMIBIO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (105, N'NGN       ', N'NAIRA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (106, N'NIO       ', N'CÓRDOBA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (107, N'NOK       ', N'CORONA NORUEGA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (108, N'NPR       ', N'RUPIA NEPALÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (109, N'NZD       ', N'DÓLAR NEOZELANDÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (110, N'OMR       ', N'RIAL OMANÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (111, N'PAB       ', N'BALBOA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (112, N'PEN       ', N'SOL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (113, N'PGK       ', N'KINA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (114, N'PHP       ', N'PESO FILIPINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (115, N'PKR       ', N'RUPIA PAKISTANÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (116, N'PLN       ', N'ZLOTY')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (117, N'PYG       ', N'GUARANÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (118, N'QAR       ', N'RIAL CATARÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (119, N'RON       ', N'LEU RUMANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (120, N'RSD       ', N'DINAR SERBIO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (121, N'RUB       ', N'RUBLO RUSO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (122, N'RWF       ', N'FRANCO RUANDÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (123, N'SAR       ', N'RIAL SAUDÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (124, N'SBD       ', N'DÓLAR DE LAS ISLAS SALOMÓN')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (125, N'SCR       ', N'RUPIA SEYCHELENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (126, N'SDG       ', N'LIBRA SUDANESA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (127, N'SEK       ', N'CORONA SUECA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (128, N'SGD       ', N'DÓLAR DE SINGAPUR')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (129, N'SHP       ', N'LIBRA DE SANTA ELENA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (130, N'SLL       ', N'LEONE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (131, N'SOS       ', N'CHELÍN SOMALÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (132, N'SRD       ', N'DÓLAR SURINAMÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (133, N'SSP       ', N'LIBRA SURSUDANESA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (134, N'STN       ', N'DOBRA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (135, N'SVC       ', N'COLÓN SALVADOREÑO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (136, N'SYP       ', N'LIBRA SIRIA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (137, N'SZL       ', N'LILANGENI')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (138, N'THB       ', N'BAHT')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (139, N'TJS       ', N'SOMONI TAYIKO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (140, N'TMT       ', N'MANAT TURCOMANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (141, N'TND       ', N'DINAR TUNECINO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (142, N'TOP       ', N'PA?ANGA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (143, N'TRY       ', N'LIRA TURCA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (144, N'TTD       ', N'DÓLAR DE TRINIDAD Y TOBAGO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (145, N'TWD       ', N'NUEVO DÓLAR TAIWANÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (146, N'TZS       ', N'CHELÍN TANZANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (147, N'UAH       ', N'GRIVNA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (148, N'UGX       ', N'CHELÍN UGANDÉS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (149, N'USD       ', N'DÓLAR ESTADOUNIDENSE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (150, N'USN       ', N'DÓLAR ESTADOUNIDENSE (SIGUIENTE DÍA)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (151, N'UYI       ', N'PESO EN UNIDADES INDEXADAS (URUGUAY)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (152, N'UYU       ', N'PESO URUGUAYO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (153, N'UYW       ', N'UNIDAD PREVISIONAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (154, N'UZS       ', N'SOM UZBEKO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (155, N'VES7?     ', N'BOLÍVAR SOBERANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (156, N'VND       ', N'DONG VIETNAMITA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (157, N'VUV       ', N'VATU')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (158, N'WST       ', N'TALA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (159, N'XAF       ', N'FRANCO CFA DE ÁFRICA CENTRAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (160, N'XAG       ', N'PLATA (DENOMINADO EN ONZA TROY)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (161, N'XAU       ', N'ORO (DENOMINADO EN ONZA TROY)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (162, N'XCD       ', N'DÓLAR DEL CARIBE ORIENTAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (163, N'XDR       ', N'DERECHOS ESPECIALES DE GIRO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (164, N'XOF       ', N'FRANCO CFA DE ÁFRICA OCCIDENTAL')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (165, N'XPD       ', N'PALADIO (DENOMINADO EN ONZA TROY)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (166, N'XPF       ', N'FRANCO CFP')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (167, N'XPT       ', N'PLATINO (DENOMINADO EN ONZA TROY)')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (168, N'XSU       ', N'SUCRE')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (169, N'XTS       ', N'RESERVADO PARA PRUEBAS')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (170, N'XUA       ', N'UNIDAD DE CUENTA BAD')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (171, N'XXX       ', N'SIN DIVISA')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (172, N'YER       ', N'RIAL YEMENÍ')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (173, N'ZAR       ', N'RAND')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (174, N'ZMW       ', N'KWACHA ZAMBIANO')
INSERT [dbo].[moneda] ([id], [clave], [valor]) VALUES (175, N'ZWL       ', N'DÓLAR ZIMBABUENSE')
SET IDENTITY_INSERT [dbo].[moneda] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoDocumento] ON 

INSERT [dbo].[tipoDocumento] ([id], [tipoDocumento]) VALUES (1, N'RESOLUCION')
INSERT [dbo].[tipoDocumento] ([id], [tipoDocumento]) VALUES (2, N'CONSTANCIA_SANCION')
INSERT [dbo].[tipoDocumento] ([id], [tipoDocumento]) VALUES (3, N'CONSTANCIA_INHABILITACION')
INSERT [dbo].[tipoDocumento] ([id], [tipoDocumento]) VALUES (4, N'CONSTANCIA_ABSTENCION')
SET IDENTITY_INSERT [dbo].[tipoDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoFalta] ON 

INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (1, N'AG', N'ADMINISTRATIVA GRAVE')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (2, N'ANG', N'ADMINISTRATIVA NO GRAVE')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (3, N'NAD', N'NEGLIGENCIA ADMINISTRATIVA')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (4, N'VPC', N'VIOLACION PROCEDIMIENTOS DE CONTRATACION')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (5, N'VLNP', N'VIOLACION LEYES Y NORMATIVIDAD PRESUPUESTAL')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (6, N'AUT', N'ABUSO DE AUTORIDAD')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (7, N'CEX', N'COHECHO O EXTORSION')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (8, N'IDSP', N'INCUMPLIMIENTO EN DECLARACION DE SITUACION PATRIMONIAL')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (9, N'DCSP', N'DELITO COMETIDO POR SERVIDORES PUBLICOS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (10, N'EIFM', N'EJERCICIO INDEBIDO DE SUS FUNCIONES EN MATERIA MIGRATORIA')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (11, N'VDH', N'VIOLACIÓN A LOS DERECHOS HUMANOS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (12, N'AC', N'ACTO DE CORRUPCIÓN')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (13, N'O', N'OTRO')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (14, N'HSEX', N'COMETER O TOLERAR CONDUCTAS DE HOSTIGAMIENTO SEXUAL')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (15, N'ASEX', N'COMETER O TOLERAR CONDUCTAS DE ACOSO SEXUAL')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (16, N'PEC', N'PECULADO')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (17, N'DRP', N'DESVÍO DE RECURSOS PÚBLICOS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (18, N'UII', N'UTILIZACIÓN INDEBIDA DE INFORMACIÓN')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (19, N'ANF', N'ABUSO DE FUNCIONES')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (20, N'ABCI', N'ACTUACIÓN BAJO CONFLICTO DE INTERÉS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (21, N'CIND', N'CONTRATACIÓN INDEBIDA')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (22, N'EOCI', N'ENRIQUECIMIENTO OCULTO U OCULTAMIENTO DE CONFLICTO DE INTERÉS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (23, N'TINF', N'TRÁFICO DE INFLUENCIAS')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (24, N'ENCB', N'ENCUBRIMIENTO')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (25, N'DSCT', N'DESACATO')
INSERT [dbo].[tipoFalta] ([id], [clave], [valor]) VALUES (26, N'OJUST', N'OBSTRUCCIÓN DE LA JUSTICIA')
SET IDENTITY_INSERT [dbo].[tipoFalta] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoSancion] ON 

INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (1, N'I', N'INHABILITADO')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (2, N'M', N'MULTADO')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (3, N'S', N'SUSPENSION DEL EMPLEO, CARGO O COMISIÓN')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (4, N'D', N'DESTITUCIÓN DEL EMPLEO, CARGO O COMISIÓN')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (5, N'IRSC', N'INDEMNIZACIÓN RESARCITORIA')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (6, N'SE', N'SANCIÓN ECONÓMICA')
INSERT [dbo].[tipoSancion] ([id], [clave], [valor]) VALUES (7, N'O', N'OTRO')
SET IDENTITY_INSERT [dbo].[tipoSancion] OFF
GO
ALTER TABLE [dbo].[sancion] ADD  CONSTRAINT [DF_sancion_fechaCaptura]  DEFAULT (getdate()) FOR [fechaCaptura]
GO
ALTER TABLE [dbo].[sancion] ADD  CONSTRAINT [DF_sancion_ultimaActualizacion]  DEFAULT (getdate()) FOR [ultimaActualizacion]
GO
ALTER TABLE [dbo].[documentos]  WITH CHECK ADD  CONSTRAINT [FK_documentos_tipoDocumento] FOREIGN KEY([tipoDocumento])
REFERENCES [dbo].[tipoDocumento] ([id])
GO
ALTER TABLE [dbo].[documentos] CHECK CONSTRAINT [FK_documentos_tipoDocumento]
GO
ALTER TABLE [dbo].[listaDocumento]  WITH CHECK ADD  CONSTRAINT [FK_listaDocumento_documentos] FOREIGN KEY([idDocumento])
REFERENCES [dbo].[documentos] ([idDocumentos])
GO
ALTER TABLE [dbo].[listaDocumento] CHECK CONSTRAINT [FK_listaDocumento_documentos]
GO
ALTER TABLE [dbo].[listaDocumento]  WITH CHECK ADD  CONSTRAINT [FK_listaDocumento_sancion] FOREIGN KEY([idSancion])
REFERENCES [dbo].[sancion] ([id])
GO
ALTER TABLE [dbo].[listaDocumento] CHECK CONSTRAINT [FK_listaDocumento_sancion]
GO
ALTER TABLE [dbo].[listaSanciones]  WITH CHECK ADD  CONSTRAINT [FK_listaSanciones_servidorPublicoSancionado] FOREIGN KEY([idSancion])
REFERENCES [dbo].[sancion] ([id])
GO
ALTER TABLE [dbo].[listaSanciones] CHECK CONSTRAINT [FK_listaSanciones_servidorPublicoSancionado]
GO
ALTER TABLE [dbo].[listaSanciones]  WITH CHECK ADD  CONSTRAINT [FK_listaSanciones_tipoSancion] FOREIGN KEY([idTipoSancion])
REFERENCES [dbo].[tipoSancion] ([id])
GO
ALTER TABLE [dbo].[listaSanciones] CHECK CONSTRAINT [FK_listaSanciones_tipoSancion]
GO
ALTER TABLE [dbo].[multa]  WITH CHECK ADD  CONSTRAINT [FK_multa_multa] FOREIGN KEY([moneda])
REFERENCES [dbo].[moneda] ([id])
GO
ALTER TABLE [dbo].[multa] CHECK CONSTRAINT [FK_multa_multa]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_inhabilitacion] FOREIGN KEY([inhabilitacion])
REFERENCES [dbo].[inhabilitacion] ([idInhabilitacion])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_inhabilitacion]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_institucionDependencia] FOREIGN KEY([institucionDependencia])
REFERENCES [dbo].[institucionDependencia] ([id])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_institucionDependencia]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_multa] FOREIGN KEY([multa])
REFERENCES [dbo].[multa] ([id])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_multa]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_resolucion] FOREIGN KEY([resolucion])
REFERENCES [dbo].[resolucion] ([idResolucion])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_resolucion]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_servidorPublicoSancionado] FOREIGN KEY([servidorPublicoSancionado])
REFERENCES [dbo].[servidorPublicoSancionado] ([id])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_servidorPublicoSancionado]
GO
ALTER TABLE [dbo].[sancion]  WITH CHECK ADD  CONSTRAINT [FK_sancion_tipoFalta] FOREIGN KEY([tipoFalta])
REFERENCES [dbo].[tipoFalta] ([id])
GO
ALTER TABLE [dbo].[sancion] CHECK CONSTRAINT [FK_sancion_tipoFalta]
GO
ALTER TABLE [dbo].[servidorPublicoSancionado]  WITH CHECK ADD  CONSTRAINT [FK_servidorPublicoSancionado_genero] FOREIGN KEY([genero])
REFERENCES [dbo].[genero] ([id])
GO
ALTER TABLE [dbo].[servidorPublicoSancionado] CHECK CONSTRAINT [FK_servidorPublicoSancionado_genero]
GO
/****** Object:  StoredProcedure [dbo].[BarraListadoSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[BarraListadoSPS]
@fechaActualizacion VARCHAR (140) = null, @expediente varchar(140) = null, @institucionDependencia VARCHAR (140) = null, @nombre VARCHAR (140) = null, @primerApellido VARCHAR (140) = null, 
@segundoApellido VARCHAR (140) = null, @tipoSancion VARCHAR(140) = null, @inhabilitacion varchar(140) = null, @inicioTablaListadoSPS int, @finalTablaListadoSPS int
AS
IF @fechaActualizacion is null and @expediente is null and @institucionDependencia is null and @nombre is null and @primerApellido is null and @segundoApellido is null and @tipoSancion is null and
@inhabilitacion is null 
	BEGIN

	IF @fechaActualizacion IS NULL
    BEGIN
        SET @fechaActualizacion = '%';
    END
IF @expediente IS NULL
    BEGIN
        SET @expediente = '%';		
    END
IF @institucionDependencia IS NULL
    BEGIN
        SET @institucionDependencia = '%';
    END
IF @nombre IS NULL
    BEGIN
        SET @nombre = '%';		
    END
IF @primerApellido IS NULL
    BEGIN
        SET @primerApellido = '%';		
    END
IF @segundoApellido IS NULL
    BEGIN
        SET @segundoApellido = '%';		
    END
IF @inhabilitacion IS NULL
    BEGIN
        SET @inhabilitacion = '%';		
    END
IF @tipoSancion IS NULL
    BEGIN
       SET @tipoSancion = '%';
	END

	declare @tablaAUXSPS table(
	id int not null IDENTITY(1,1),
	idSancion varchar(140),
    expediente varchar(140), 
	institucionDependencia varchar(140),
	nombre varchar(140),
	primerApellido varchar(140),
	segundoApellido varchar(140),
    servidorPublicoSancionado varchar(140),
	tipoSancion varchar(140),
	inhabilitacion varchar(140),
	ultimaActualizacion VARCHAR (140))
insert into @tablaAUXSPS (idSancion, expediente, ultimaActualizacion, institucionDependencia, nombre, primerApellido, segundoApellido, servidorPublicoSancionado, tipoSancion, inhabilitacion) select 
ISNULL(d.id, ' '), ISNULL(d.expediente, ' '), ISNULL(d.ultimaActualizacion, ' '), ISNULL(e.nombre, ' '), ISNULL(f.nombre, ' '), ISNULL(f.primerApellido, ' '), ISNULL(f.segundoApellido, ' '), 
CONCAT(f.nombre, ' ', f.primerApellido, ' ', f.segundoApellido), STRING_AGG(j.valor, ' - '), ISNULL(h.fechaFinal, ' ') 
from sancion as d
	left join institucionDependencia as e on (d.institucionDependencia =e.id)
	left join servidorPublicoSancionado as f on (d.servidorPublicoSancionado =f.id) 
	left join inhabilitacion as h on (d.inhabilitacion =h.idInhabilitacion)
	left join listaSanciones as i on (d.id = i.idSancion)
	left join tipoSancion as j on (i.idTipoSancion = j.id)
	group by d.id, d.expediente, d.ultimaActualizacion, e.nombre, f.nombre, f.primerApellido, f.segundoApellido, h.fechaFinal
	
	select COUNT(*) as cantidad from @tablaAUXSPS
	select top(10) id, idSancion, expediente, institucionDependencia, servidorPublicoSancionado, STRING_AGG(tipoSancion, ' - ') AS Jose from @tablaAUXSPS where ID >= @inicioTablaListadoSPS 
	and CONVERT(varchar,ultimaActualizacion) like @fechaActualizacion
	and expediente like @expediente
	and CONVERT(varchar,institucionDependencia) like @institucionDependencia
	and nombre like @nombre
	and primerApellido like @primerApellido
	and segundoApellido like @segundoApellido
	and tipoSancion like @tipoSancion
	and convert(varchar,inhabilitacion) like @inhabilitacion
	group by id, idSancion, expediente, institucionDependencia, servidorPublicoSancionado
	order by MAX(id)

	END
ELSE
	BEGIN
IF @fechaActualizacion IS NULL
    BEGIN
        SET @fechaActualizacion = '%';
    END
IF @expediente IS NULL
    BEGIN
        SET @expediente = '%';		
    END
IF @institucionDependencia IS NULL
    BEGIN
        SET @institucionDependencia = '%';
    END
IF @nombre IS NULL
    BEGIN
        SET @nombre = '%';		
    END
IF @primerApellido IS NULL
    BEGIN
        SET @primerApellido = '%';		
    END
IF @segundoApellido IS NULL
    BEGIN
        SET @segundoApellido = '%';		
    END
IF @inhabilitacion IS NULL
    BEGIN
        SET @inhabilitacion = '%';		
    END

IF @tipoSancion IS NULL
    BEGIN
		SET @tipoSancion = '%';	
	end

	declare @tablaAUXSPSB table(
	id int not null IDENTITY(1,1),
	idSancion varchar(140),
    expediente varchar(140), 
	institucionDependencia varchar(140),
	nombre varchar(140),
	primerApellido varchar(140),
	segundoApellido varchar(140),
    servidorPublicoSancionado varchar(140),
	tipoSancion varchar(140),
	inhabilitacion varchar(140),
	ultimaActualizacion VARCHAR (140))
insert into @tablaAUXSPSB (idSancion, expediente, ultimaActualizacion, institucionDependencia, nombre, primerApellido, segundoApellido, servidorPublicoSancionado, tipoSancion, inhabilitacion) select 
ISNULL(d.id, ' '), ISNULL(d.expediente, ' '), ISNULL(d.ultimaActualizacion, ' '), ISNULL(e.nombre, ' '), ISNULL(f.nombre, ' '), ISNULL(f.primerApellido, ' '), ISNULL(f.segundoApellido, ' '), 
CONCAT(f.nombre, ' ', f.primerApellido, ' ', f.segundoApellido), STRING_AGG(j.valor, ' - '), ISNULL(h.fechaFinal, ' ') 
from sancion as d
	left join institucionDependencia as e on (d.institucionDependencia =e.id)
	left join servidorPublicoSancionado as f on (d.servidorPublicoSancionado =f.id) 
	left join inhabilitacion as h on (d.inhabilitacion =h.idInhabilitacion)
	left join listaSanciones as i on (d.id = i.idSancion)
	left join tipoSancion as j on (i.idTipoSancion = j.id)


	group by d.id, d.expediente, d.ultimaActualizacion, e.nombre, f.nombre, f.primerApellido, f.segundoApellido, h.fechaFinal
	--order by MAX(d.id)


select COUNT(*) as cantidad from @tablaAUXSPSB
select top(10) id, idSancion, expediente, institucionDependencia, servidorPublicoSancionado, STRING_AGG(tipoSancion, ' - ') AS Miguel from @tablaAUXSPSB where ID >= @inicioTablaListadoSPS 
	and CONVERT(varchar,ultimaActualizacion) like @fechaActualizacion
	and expediente like @expediente
	and CONVERT(varchar,institucionDependencia) like @institucionDependencia
	and nombre like @nombre
	and primerApellido like @primerApellido
	and segundoApellido like @segundoApellido
	and tipoSancion like @tipoSancion
	and convert(varchar,inhabilitacion) like @inhabilitacion

	group by id, idSancion, expediente, institucionDependencia, servidorPublicoSancionado
	order by MAX(id)
	END
	
GO
/****** Object:  StoredProcedure [dbo].[InsertarDocumentosSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarDocumentosSPS]
@Titulo varchar(140) = null, @idTipoDocumento int = null, @descripcion varchar(140) = null, @url varchar(200) = null, @fecha date = null
AS
declare @idSancion as int
set @idSancion = (select MAX(id) from sancion)

INSERT INTO documentos(titulo, tipoDocumento, descripcion, url, fecha) values (@Titulo, @idTipoDocumento, @descripcion, @url, @fecha)
declare @idDocumento as int
set @idDocumento = (select max(idDocumentos) from documentos)

INSERT INTO listaDocumento(idDocumento, idSancion) values (@idDocumento, @idSancion) 
GO
/****** Object:  StoredProcedure [dbo].[InsertarSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarSPS]
@expediente varchar(140) = null, @autoridadSancionadora varchar(140) = null, @causaMotivoHecho varchar(140), @RFC CHAR (13) = null, @CURP CHAR (18) = null, 
@nombre VARCHAR (140) = null, @primerApellido VARCHAR (140) = null, @segundoApellido VARCHAR (140) = null, @puesto VARCHAR (140) = null, @nivel VARCHAR (140) = null, @genero INT = null, 
@tipoFalta INT = null, @observaciones VARCHAR (140) = null, @claveInstitucionDependencia VARCHAR (140) = null, @nombreInstitucionDependencia VARCHAR (140) = null, 
@siglasInstitucionDependencia VARCHAR (10) = null, @monto FLOAT = null, @moneda INT = null, @fechaResolucion DATE = null, @urlResolucion varchar(140) = null, 
@plazoInhabilitacion varchar(10) = null, @fechaInicialInhabilitacion date = null, @fechaFinalInhabilitacion date = null, @descripcionFalta varchar(140) = null
AS
INSERT INTO servidorPublicoSancionado (rfc, curp, nombre, primerApellido, segundoApellido, puesto, nivel, genero) values (@RFC, @CURP, @nombre, @primerApellido, @segundoApellido, @puesto,
@nivel, @genero) 
declare @idServidorPublicoSancionado as int
set @idServidorPublicoSancionado = (select max(id) from servidorPublicoSancionado)

INSERT INTO institucionDependencia(clave, nombre, siglas) values (@claveInstitucionDependencia, @nombreInstitucionDependencia, @siglasInstitucionDependencia) 
declare @idInstitucionDependencia as int
set @idInstitucionDependencia = (select max(id) from institucionDependencia)

INSERT INTO multa(monto, moneda) values (@monto, @moneda) 
declare @idMulta as int
set @idMulta = (select max(id) from multa)

INSERT INTO resolucion(fechaResolucion, url) values (@fechaResolucion, @urlResolucion) 
declare @idResolucion as int
set @idResolucion = (select max(idResolucion) from resolucion)

INSERT INTO inhabilitacion(plazo, fechaInicial, fechaFinal) values (@plazoInhabilitacion, @fechaInicialInhabilitacion, @fechaFinalInhabilitacion) 
declare @idInhabilitacion as int
set @idInhabilitacion = (select max(idInhabilitacion) from inhabilitacion)

INSERT INTO sancion(expediente, autoridadSancionadora, causaMotivoHecho, servidorPublicoSancionado, tipoFalta, observaciones, institucionDependencia, multa, resolucion, inhabilitacion, descripcionFalta)
values (@expediente, @autoridadSancionadora, @causaMotivoHecho, @idServidorPublicoSancionado, @tipoFalta, @observaciones, @idInstitucionDependencia, @idMulta, @idResolucion, @idInhabilitacion, @descripcionFalta) 
GO
/****** Object:  StoredProcedure [dbo].[InsertarTipoSancionSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarTipoSancionSPS]
@TipoSancion int = null, @descripcionSancion varchar(500) = null
AS

declare @idSancion as int
set @idSancion = (select MAX(id) from sancion)

INSERT INTO listaSanciones(idTipoSancion, idSancion, descripcionSancion) values (@TipoSancion, @idSancion, @descripcionSancion) 
GO
/****** Object:  StoredProcedure [dbo].[llenarDocumento]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenarDocumento]
as
begin
select id, tipoDocumento from tipoDocumento;
end
GO
/****** Object:  StoredProcedure [dbo].[llenarFalta]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenarFalta]
as
begin
select id, valor from tipoFalta;
end
GO
/****** Object:  StoredProcedure [dbo].[llenarGenero]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenarGenero]
as
begin
select id, valor from genero;
end
GO
/****** Object:  StoredProcedure [dbo].[llenarMoneda]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenarMoneda]
as
begin
select id, valor from moneda;
end
GO
/****** Object:  StoredProcedure [dbo].[llenarSancion]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[llenarSancion]
as
begin
select id, valor from tipoSancion;
end
GO
/****** Object:  StoredProcedure [dbo].[ModificarDocumentosSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarDocumentosSPS]
@Titulo varchar(140) = null, @idTipoDocumento int = null, @descripcion varchar(140) = null, @url varchar(200) = null, @fecha date = null, @idSancion int
AS

INSERT INTO documentos(titulo, tipoDocumento, descripcion, url, fecha) values (@Titulo, @idTipoDocumento, @descripcion, @url, @fecha)
declare @idDocumento as int
set @idDocumento = (select max(idDocumentos) from documentos)

INSERT INTO listaDocumento(idDocumento, idSancion) values (@idDocumento, @idSancion) 

GO
/****** Object:  StoredProcedure [dbo].[ModificarSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarSPS]
@id int,

@expediente varchar(140) = null, @autoridadSancionadora varchar(140) = null, @causaMotivoHecho varchar(140), @RFC CHAR (13) = null, @CURP CHAR (18) = null, 
@nombre VARCHAR (140) = null, @primerApellido VARCHAR (140) = null, @segundoApellido VARCHAR (140) = null, @puesto VARCHAR (140) = null, @nivel VARCHAR (140) = null, @genero INT = null, 
@tipoFalta INT = null, @observaciones VARCHAR (140) = null, @claveInstitucionDependencia VARCHAR (140) = null, @nombreInstitucionDependencia VARCHAR (140) = null, 
@siglasInstitucionDependencia VARCHAR (10) = null, @monto FLOAT = null, @moneda INT = null, @fechaResolucion DATE = null, @urlResolucion varchar(140) = null, 
@plazoInhabilitacion varchar(10) = null, @fechaInicialInhabilitacion date = null, @fechaFinalInhabilitacion date = null, @descripcionFalta varchar(140) = null
AS

UPDATE SPO set rfc = @RFC, curp = @CURP, nombre = @nombre, primerApellido = @primerApellido, segundoApellido = @segundoApellido, puesto = @puesto, nivel = @nivel, genero = @genero 
from servidorPublicoSancionado as SPO
inner join sancion as d on (SPO.id = d.servidorPublicoSancionado)
where d.id = @id

UPDATE ISD set clave = @claveInstitucionDependencia, nombre = @nombreInstitucionDependencia, siglas = @siglasInstitucionDependencia from institucionDependencia as ISD
inner join sancion as d on (ISD.id = d.institucionDependencia)
where d.id = @id

UPDATE MUL set monto = @monto, moneda = @moneda from multa as MUL
inner join sancion as d on (MUL.id = d.multa)
where d.id = @id

UPDATE RES set fechaResolucion = @fechaResolucion, url = @urlResolucion from resolucion as RES
inner join sancion as d on (RES.idResolucion = d.resolucion)
where d.id = @id

UPDATE INH set plazo = @plazoInhabilitacion, fechaInicial = @fechaInicialInhabilitacion, fechaFinal = @fechaFinalInhabilitacion from inhabilitacion as INH
inner join sancion as d on (INH.idInhabilitacion = d.inhabilitacion)
where d.id = @id

UPDATE SC set expediente = @expediente, autoridadSancionadora = @autoridadSancionadora, causaMotivoHecho = @causaMotivoHecho, tipoFalta = @tipoFalta, observaciones = @observaciones,
descripcionFalta = @descripcionFalta from sancion as SC
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[ModificarTipoSancionSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ModificarTipoSancionSPS]
@TipoSancion int = null, @descripcionSancion varchar(500) = null, @idSancion int
AS

INSERT INTO listaSanciones(idTipoSancion, idSancion, descripcionSancion) values (@TipoSancion, @idSancion, @descripcionSancion)
GO
/****** Object:  StoredProcedure [dbo].[UltimoBarraListadoSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UltimoBarraListadoSPS]
@fechaActualizacion VARCHAR (140) = null, @expediente varchar(140) = null, @institucionDependencia VARCHAR (140) = null, @nombre VARCHAR (140) = null, @primerApellido VARCHAR (140) = null, 
@segundoApellido VARCHAR (140) = null, @tipoSancion VARCHAR(140) = null, @inhabilitacion varchar(140) = null, @Total int = null output
as

IF @fechaActualizacion is null and @expediente is null and @institucionDependencia is null and @nombre is null and @primerApellido is null and @segundoApellido is null and @tipoSancion is null and
@inhabilitacion is null 
	BEGIN
	declare @tablaAUXTotal table(
	id int not null IDENTITY(1,1),
	idSancion varchar(140),
    expediente varchar(140), 
	institucionDependencia varchar(140),
	nombre varchar(140),
	primerApellido varchar(140),
	segundoApellido varchar(140),
	tipoSancion varchar(140),
	inhabilitacion varchar(140),
	ultimaActualizacion VARCHAR (140))
		insert into @tablaAUXTotal (idSancion, expediente, ultimaActualizacion, institucionDependencia, nombre, primerApellido, segundoApellido, tipoSancion, inhabilitacion) select 
d.id, ISNULL(d.expediente, ' '), ISNULL(d.ultimaActualizacion, ' '), ISNULL(e.nombre, ' '), ISNULL(f.nombre, ' '), ISNULL(f.primerApellido, ' '), 
ISNULL(f.segundoApellido, ' '), STRING_AGG(ISNULL(j.valor, ' '), ' - '), ISNULL(h.fechaFinal, ' ') 
from sancion as d
	left join institucionDependencia as e on (d.institucionDependencia =e.id)
	left join servidorPublicoSancionado as f on (d.servidorPublicoSancionado =f.id) 
	left join inhabilitacion as h on (d.inhabilitacion =h.idInhabilitacion)
	left join listaSanciones as i on (d.id = i.idSancion)
	left join tipoSancion as j on (i.idTipoSancion = j.id)
	group by d.id, d.expediente, d.ultimaActualizacion, e.nombre, f.nombre, f.primerApellido, f.segundoApellido, h.fechaFinal

	select * from @tablaAUXTotal
	select COUNT(*) as cantidad from @tablaAUXTotal
	set @Total = (select count(DISTINCT idSancion) from @tablaAUXTotal)
	return @Total
	END
ELSE
	BEGIN
IF @fechaActualizacion IS NULL
    BEGIN
        SET @fechaActualizacion = '%';
    END
IF @expediente IS NULL
    BEGIN
        SET @expediente = '%';		
    END
IF @institucionDependencia IS NULL
    BEGIN
        SET @institucionDependencia = '%';
    END
IF @nombre IS NULL
    BEGIN
        SET @nombre = '%';		
    END
IF @primerApellido IS NULL
    BEGIN
        SET @primerApellido = '%';		
    END
IF @segundoApellido IS NULL
    BEGIN
        SET @segundoApellido = '%';		
    END
IF @inhabilitacion IS NULL
    BEGIN
        SET @inhabilitacion = '%';		
    END
IF @tipoSancion IS NULL
    BEGIN
       SET @tipoSancion = '%';
	END

 declare @tablaAUXUltimo table(
	id int not null IDENTITY(1,1),
	idSancion varchar(140),
    expediente varchar(140), 
	institucionDependencia varchar(140),
	nombre varchar(140),
	primerApellido varchar(140),
	segundoApellido varchar(140),
	tipoSancion varchar(140),
	inhabilitacion varchar(140),
	ultimaActualizacion VARCHAR (140))
insert into @tablaAUXUltimo (idSancion, expediente, ultimaActualizacion, institucionDependencia, nombre, primerApellido, segundoApellido, tipoSancion, inhabilitacion) select 
d.id, ISNULL(d.expediente, ' '), ISNULL(d.ultimaActualizacion, ' '), ISNULL(e.nombre, ' '), ISNULL(f.nombre, ' '), ISNULL(f.primerApellido, ' '), 
ISNULL(f.segundoApellido, ' '), STRING_AGG(isnull(j.valor, ' '), ' - '), ISNULL(h.fechaFinal, ' ') 
from sancion as d
	left join institucionDependencia as e on (d.institucionDependencia =e.id)
	left join servidorPublicoSancionado as f on (d.servidorPublicoSancionado =f.id) 
	left join inhabilitacion as h on (d.inhabilitacion =h.idInhabilitacion)
	left join listaSanciones as i on (d.id = i.idSancion)
	left join tipoSancion as j on (i.idTipoSancion = j.id)

	group by d.id, d.expediente, d.ultimaActualizacion, e.nombre, f.nombre, f.primerApellido, f.segundoApellido, h.fechaFinal

	set @total = (select COUNT(DISTINCT idSancion) as cantidad from @tablaAUXUltimo where CONVERT(varchar,ultimaActualizacion) like @fechaActualizacion
	and expediente like @expediente
	and CONVERT(varchar,nombre) like @institucionDependencia
	and nombre like @nombre
	and primerApellido like @primerApellido
	and segundoApellido like @segundoApellido
	and tipoSancion like @tipoSancion
	and convert(varchar,inhabilitacion) like @inhabilitacion)
	

	select count(*) as jose from @tablaAUXUltimo where CONVERT(varchar,ultimaActualizacion) like @fechaActualizacion
	and expediente like @expediente
	and CONVERT(varchar,nombre) like @institucionDependencia
	and nombre like @nombre
	and primerApellido like @primerApellido
	and segundoApellido like @segundoApellido
	and tipoSancion like @tipoSancion
	and convert(varchar,inhabilitacion) like @inhabilitacion
	DELETE FROM @tablaAUXUltimo

	END
GO
/****** Object:  StoredProcedure [dbo].[VisualizarDocumentosSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[VisualizarDocumentosSPS]
@id varchar(50)
AS
SELECT b.titulo, c.tipoDocumento, b.fecha, b.url, b.descripcion
from listaDocumento as a
	inner join documentos as b on (a.idDocumento = b.idDocumentos)
	inner join tipoDocumento as c on (b.tipoDocumento = c.id)
	inner join sancion as d on (a.idSancion = d.id)
	where @id = d.id

GO
/****** Object:  StoredProcedure [dbo].[VisualizarSancionesSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[VisualizarSancionesSPS]
@id varchar(50)
AS
SELECT b.valor, a.descripcionSancion
from listaSanciones as a
	inner join tipoSancion as b on (a.idTipoSancion =b.id)
	inner join sancion as c on (a.idSancion = c.id)
	where @id = c.id
GO
/****** Object:  StoredProcedure [dbo].[VisualizarSPS]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[VisualizarSPS]
@id varchar(50)
AS
SELECT a.expediente, a.ultimaActualizacion, c.nombre, c.primerApellido, c.segundoApellido, c.CURP, c.RFC, d.valor as genero, d.id as genero2, b.nombre as nombreISD, b.clave, b.siglas, c.puesto, c.nivel, a.autoridadSancionadora,
e.fechaResolucion, e.url, f.plazo, f.fechaInicial, f.fechaFinal, g.monto as monto, j.valor as moneda, j.id as moneda2, h.id as idFalta, h.valor as falta, a.causaMotivoHecho, a.observaciones, a.descripcionFalta
from sancion as a
	inner join institucionDependencia as b on (a.institucionDependencia =b.id)
	inner join servidorPublicoSancionado as c on (a.servidorPublicoSancionado =c.id) 
	left join genero as d on (c.genero =d.id)
	inner join resolucion as e on (a.resolucion =e.idResolucion)
	inner join inhabilitacion as f on (a.inhabilitacion =f.idInhabilitacion)
	inner join multa as g on (a.multa =g.id)
	left join moneda as j on (g.moneda = j.id)
	inner join tipoFalta as h on (a.tipoFalta = h.id)
	where @id = a.id
GO
/****** Object:  Trigger [dbo].[actualizar_bitacoraP]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[actualizar_bitacoraP]
ON [dbo].[sancion]
FOR UPDATE  
AS
	set nocount on;
    INSERT INTO Usuario.dbo.bitacora(operacion,fecha,sistema,registros,usuario)
    SELECT 'Actualización',GETDATE(),'Sistema de los Servidores Públicos Sancionados','1',(select id from Usuario.dbo.usuario where sesion = 1);
GO
ALTER TABLE [dbo].[sancion] ENABLE TRIGGER [actualizar_bitacoraP]
GO
/****** Object:  Trigger [dbo].[eliminar_bitacoraP]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create TRIGGER [dbo].[eliminar_bitacoraP]
ON [dbo].[sancion]
FOR DELETE  
AS
	set nocount on;
    INSERT INTO Usuario.dbo.bitacora(operacion,fecha,sistema,registros,usuario)
    SELECT 'Eliminación',GETDATE(),'Sistema de los Servidores Públicos Sancionados','1',1 ;
GO
ALTER TABLE [dbo].[sancion] DISABLE TRIGGER [eliminar_bitacoraP]
GO
/****** Object:  Trigger [dbo].[insertar_bitacoraP]    Script Date: 07/12/2022 10:56:01 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[insertar_bitacoraP]
ON [dbo].[sancion]
FOR INSERT
AS
	set nocount on;
    INSERT INTO Usuario.dbo.bitacora(operacion,fecha,sistema,registros,usuario)
    SELECT 'Alta',GETDATE(),'Sistema de los Servidores Públicos Sancionados','1',(select id from Usuario.dbo.usuario where sesion = 1);
GO
ALTER TABLE [dbo].[sancion] ENABLE TRIGGER [insertar_bitacoraP]
GO
USE [master]
GO
ALTER DATABASE [PublicosSancionados] SET  READ_WRITE 
GO
