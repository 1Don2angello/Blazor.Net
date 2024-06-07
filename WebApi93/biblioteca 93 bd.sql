USE [master]
GO

/****** Object:  Database [Biblioteca93]    Script Date: 06/06/2024 06:46:18 p. m. ******/
CREATE DATABASE [Biblioteca93]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteca93', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Biblioteca93.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Biblioteca93_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Biblioteca93_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteca93].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Biblioteca93] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Biblioteca93] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Biblioteca93] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Biblioteca93] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Biblioteca93] SET ARITHABORT OFF 
GO

ALTER DATABASE [Biblioteca93] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Biblioteca93] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Biblioteca93] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Biblioteca93] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Biblioteca93] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Biblioteca93] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Biblioteca93] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Biblioteca93] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Biblioteca93] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Biblioteca93] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Biblioteca93] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Biblioteca93] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Biblioteca93] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Biblioteca93] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Biblioteca93] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Biblioteca93] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Biblioteca93] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Biblioteca93] SET RECOVERY FULL 
GO

ALTER DATABASE [Biblioteca93] SET  MULTI_USER 
GO

ALTER DATABASE [Biblioteca93] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Biblioteca93] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Biblioteca93] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Biblioteca93] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Biblioteca93] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Biblioteca93] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Biblioteca93] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Biblioteca93] SET  READ_WRITE 
GO


