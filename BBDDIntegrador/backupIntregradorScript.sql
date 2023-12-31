USE [master]
GO
/****** Object:  Database [INTEGRADOR_AgenciaTurismo_DB]    Script Date: 22/11/2023 17:06:45 ******/
CREATE DATABASE [INTEGRADOR_AgenciaTurismo_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INTEGRADOR_AgenciaTurismo_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\INTEGRADOR_AgenciaTurismo_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INTEGRADOR_AgenciaTurismo_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\INTEGRADOR_AgenciaTurismo_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [INTEGRADOR_AgenciaTurismo_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET  MULTI_USER 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'INTEGRADOR_AgenciaTurismo_DB', N'ON'
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET QUERY_STORE = OFF
GO
USE [INTEGRADOR_AgenciaTurismo_DB]
GO
/****** Object:  Table [dbo].[pasajeros]    Script Date: 22/11/2023 17:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pasajeros](
	[dni_pasajero] [varchar](8) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido] [varchar](20) NOT NULL,
	[edad] [int] NOT NULL,
 CONSTRAINT [PK_pasajeros] PRIMARY KEY CLUSTERED 
(
	[dni_pasajero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservas]    Script Date: 22/11/2023 17:06:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservas](
	[dni_pasajero] [varchar](8) NOT NULL,
	[montoFinal] [decimal](8, 2) NOT NULL,
	[paqueteSeleccionado] [varchar](6) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'10919581', N'Julina', N'Ghidini', 65)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'12047805', N'Leisha', N'Inkpen', 47)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'13261018', N'Curr', N'Degoe', 37)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'13784701', N'Vonnie', N'Schooley', 90)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'15367690', N'Bianka', N'Ralton', 61)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'16614204', N'Tiebold', N'Lapre', 87)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'17166929', N'Joelly', N'Cuardall', 78)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'18256057', N'Ross', N'Jancik', 84)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'23317293', N'Monro', N'Bottini', 33)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'26220357', N'Cecilio', N'Bradberry', 53)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'26463919', N'Andy', N'Sarle', 9)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'26526679', N'Lynnelle', N'MacRury', 36)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'26693764', N'Willy', N'Baldi', 36)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'26907154', N'Nolan', N'Levecque', 35)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'32014647', N'Aleen', N'Knell', 69)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'32385516', N'Loretta', N'Loretta', 78)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'33047387', N'Margeaux', N'Boddice', 60)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'33137424', N'Hollis', N'Costock', 63)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'33964938', N'Annabel', N'Boynton', 43)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'35620179', N'Ruby', N'Golton', 12)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'37477650', N'Oralle', N'Crackan', 31)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'39283240', N'Marji', N'Le Lievre', 10)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'41065503', N'Ham', N'Benard', 69)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'42810404', N'Sebastian', N'Serrano', 23)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'43503588', N'Hiram', N'Nehls', 11)
INSERT [dbo].[pasajeros] ([dni_pasajero], [nombre], [apellido], [edad]) VALUES (N'4558511', N'Giralda', N'Edgson', 7)
GO
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'10919581', CAST(2550.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'12047805', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'13261018', CAST(3000.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'13261018', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'13784701', CAST(8500.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'15367690', CAST(10000.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'16614204', CAST(2550.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'17166929', CAST(8500.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'18256057', CAST(8500.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'42810404', CAST(3000.00 AS Decimal(8, 2)), N'Plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'4558511', CAST(2700.00 AS Decimal(8, 2)), N'Plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'23317293', CAST(10000.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26220357', CAST(3000.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26463919', CAST(2700.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26463919', CAST(900.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26526679', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26693764', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26693764', CAST(10000.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'26907154', CAST(10000.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'32014647', CAST(850.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'32385516', CAST(850.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'32385516', CAST(2550.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'33047387', CAST(3000.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'33137424', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'33964938', CAST(1000.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'35620179', CAST(9000.00 AS Decimal(8, 2)), N'oro')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'35620179', CAST(2700.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'39283240', CAST(900.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'41065503', CAST(2550.00 AS Decimal(8, 2)), N'plata')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'43503588', CAST(900.00 AS Decimal(8, 2)), N'bronce')
INSERT [dbo].[reservas] ([dni_pasajero], [montoFinal], [paqueteSeleccionado]) VALUES (N'4558511', CAST(9000.00 AS Decimal(8, 2)), N'oro')
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD  CONSTRAINT [FK_reservas_pasajeros] FOREIGN KEY([dni_pasajero])
REFERENCES [dbo].[pasajeros] ([dni_pasajero])
GO
ALTER TABLE [dbo].[reservas] CHECK CONSTRAINT [FK_reservas_pasajeros]
GO
USE [master]
GO
ALTER DATABASE [INTEGRADOR_AgenciaTurismo_DB] SET  READ_WRITE 
GO
