USE [master]
GO

/****** Object:  Database [PROJETO]    Script Date: 11/11/2021 23:40:22 ******/
CREATE DATABASE [PROJETO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PROJETO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PROJETO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PROJETO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PROJETO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PROJETO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PROJETO] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PROJETO] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PROJETO] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PROJETO] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PROJETO] SET ARITHABORT OFF 
GO

ALTER DATABASE [PROJETO] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PROJETO] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PROJETO] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PROJETO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PROJETO] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [PROJETO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PROJETO] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PROJETO] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PROJETO] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PROJETO] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PROJETO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PROJETO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PROJETO] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PROJETO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PROJETO] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PROJETO] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PROJETO] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PROJETO] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PROJETO] SET  MULTI_USER 
GO

ALTER DATABASE [PROJETO] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PROJETO] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PROJETO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PROJETO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PROJETO] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PROJETO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [PROJETO] SET QUERY_STORE = OFF
GO

ALTER DATABASE [PROJETO] SET  READ_WRITE 
GO


