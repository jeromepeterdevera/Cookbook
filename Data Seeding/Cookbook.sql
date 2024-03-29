USE [Cookbook]
GO
ALTER TABLE [Recipe].[RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Recipe_RecipeId]
GO
ALTER TABLE [Recipe].[RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId]
GO
ALTER TABLE [Recipe].[Recipe] DROP CONSTRAINT [FK_Recipe_Cook_CookId]
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient] DROP CONSTRAINT [FK_PreparedRecipeIngredient_PreparedRecipe_PreparedRecipeId]
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient] DROP CONSTRAINT [FK_PreparedRecipeIngredient_Ingredient_IngredientId]
GO
ALTER TABLE [Recipe].[PreparedRecipe] DROP CONSTRAINT [FK_PreparedRecipe_Recipe_RecipeId]
GO
ALTER TABLE [Recipe].[PreparedRecipe] DROP CONSTRAINT [FK_PreparedRecipe_Cook_CookId]
GO
/****** Object:  Index [IX_RecipeIngredient_RecipeId_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_RecipeIngredient_RecipeId_IngredientId] ON [Recipe].[RecipeIngredient]
GO
/****** Object:  Index [IX_RecipeIngredient_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_RecipeIngredient_IngredientId] ON [Recipe].[RecipeIngredient]
GO
/****** Object:  Index [IX_Recipe_Name_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_Recipe_Name_CookId] ON [Recipe].[Recipe]
GO
/****** Object:  Index [IX_Recipe_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_Recipe_CookId] ON [Recipe].[Recipe]
GO
/****** Object:  Index [IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId] ON [Recipe].[PreparedRecipeIngredient]
GO
/****** Object:  Index [IX_PreparedRecipeIngredient_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_PreparedRecipeIngredient_IngredientId] ON [Recipe].[PreparedRecipeIngredient]
GO
/****** Object:  Index [IX_PreparedRecipe_RecipeId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_PreparedRecipe_RecipeId] ON [Recipe].[PreparedRecipe]
GO
/****** Object:  Index [IX_PreparedRecipe_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_PreparedRecipe_CookId] ON [Recipe].[PreparedRecipe]
GO
/****** Object:  Index [IX_Ingredient_Name]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP INDEX [IX_Ingredient_Name] ON [Recipe].[Ingredient]
GO
/****** Object:  Table [Recipe].[RecipeIngredient]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[RecipeIngredient]
GO
/****** Object:  Table [Recipe].[Recipe]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[Recipe]
GO
/****** Object:  Table [Recipe].[PreparedRecipeIngredient]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[PreparedRecipeIngredient]
GO
/****** Object:  Table [Recipe].[PreparedRecipe]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[PreparedRecipe]
GO
/****** Object:  Table [Recipe].[Ingredient]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[Ingredient]
GO
/****** Object:  Table [Recipe].[Cook]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [Recipe].[Cook]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Schema [Recipe]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP SCHEMA [Recipe]
GO
USE [master]
GO
/****** Object:  Database [Cookbook]    Script Date: 19/04/2019 7:18:30 AM ******/
DROP DATABASE [Cookbook]
GO
/****** Object:  Database [Cookbook]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE DATABASE [Cookbook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cookbook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Cookbook.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cookbook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Cookbook_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Cookbook] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cookbook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cookbook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cookbook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cookbook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cookbook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cookbook] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cookbook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cookbook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cookbook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cookbook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cookbook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cookbook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cookbook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cookbook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cookbook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cookbook] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cookbook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cookbook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cookbook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cookbook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cookbook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cookbook] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Cookbook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cookbook] SET RECOVERY FULL 
GO
ALTER DATABASE [Cookbook] SET  MULTI_USER 
GO
ALTER DATABASE [Cookbook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cookbook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cookbook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cookbook] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cookbook] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cookbook', N'ON'
GO
ALTER DATABASE [Cookbook] SET QUERY_STORE = OFF
GO
USE [Cookbook]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Cookbook]
GO
/****** Object:  Schema [Recipe]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE SCHEMA [Recipe]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[Cook]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[Cook](
	[CookId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Cook] PRIMARY KEY CLUSTERED 
(
	[CookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[Ingredient]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[Ingredient](
	[IngredientId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[PreparedRecipe]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[PreparedRecipe](
	[PreparedRecipeId] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [nvarchar](25) NULL,
	[CookId] [int] NOT NULL,
	[PreparedWhen] [datetime2](7) NOT NULL,
	[Complete] [bit] NOT NULL,
	[RecipeId] [int] NULL,
 CONSTRAINT [PK_PreparedRecipe] PRIMARY KEY CLUSTERED 
(
	[PreparedRecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[PreparedRecipeIngredient]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[PreparedRecipeIngredient](
	[PreparedRecipeIngredientId] [int] IDENTITY(1,1) NOT NULL,
	[PreparedRecipeId] [int] NOT NULL,
	[IngredientId] [int] NULL,
 CONSTRAINT [PK_PreparedRecipeIngredient] PRIMARY KEY CLUSTERED 
(
	[PreparedRecipeIngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[Recipe]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[Recipe](
	[RecipeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](25) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CookId] [int] NOT NULL,
 CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED 
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Recipe].[RecipeIngredient]    Script Date: 19/04/2019 7:18:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Recipe].[RecipeIngredient](
	[RecipeIngredientId] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
 CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY CLUSTERED 
(
	[RecipeIngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190417045139_CreateDatabaseAndTablesForCookbook', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190417182220_UpdatePreparedRecipeIngredientStructure', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190417182433_UpdateStructureOfRecipeIngredient', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190417190638_AddIndexingToJoinTables', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190418062416_AlterIndexOfPreparedRecipeEntity', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190418183200_UpdatePreparedRecipeConstraintAllowEmptyAlias', N'2.2.4-servicing-10062')
SET IDENTITY_INSERT [Recipe].[Cook] ON 

INSERT [Recipe].[Cook] ([CookId], [Email], [FirstName], [LastName]) VALUES (1, N'nicole_reyes@cookbook.com', N'Nicole', N'Reyes')
INSERT [Recipe].[Cook] ([CookId], [Email], [FirstName], [LastName]) VALUES (2, N'johnpaul_santos@cookbook.com', N'John Paul', N'Santos')
SET IDENTITY_INSERT [Recipe].[Cook] OFF
SET IDENTITY_INSERT [Recipe].[Ingredient] ON 

INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (14, N'Almond Flour')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (12, N'Baking Powder')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (1, N'Bread')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (2, N'Butter')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (16, N'Castor sugar')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (3, N'Cheese')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (4, N'Chilled Pasta')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (13, N'Confectioners’ Sugar')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (9, N'Eggs')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (8, N'Flour')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (11, N'Milk')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (6, N'Oil')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (15, N'Salt')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (7, N'Sugar')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (10, N'Vanilla Extract')
INSERT [Recipe].[Ingredient] ([IngredientId], [Name]) VALUES (5, N'Vinegar')
SET IDENTITY_INSERT [Recipe].[Ingredient] OFF
SET IDENTITY_INSERT [Recipe].[Recipe] ON 

INSERT [Recipe].[Recipe] ([RecipeId], [Name], [Description], [CookId]) VALUES (1, N'Grilled Cheese', N'', 2)
INSERT [Recipe].[Recipe] ([RecipeId], [Name], [Description], [CookId]) VALUES (2, N'Pasta Salad', N'', 2)
INSERT [Recipe].[Recipe] ([RecipeId], [Name], [Description], [CookId]) VALUES (3, N'Cake', N'', 1)
INSERT [Recipe].[Recipe] ([RecipeId], [Name], [Description], [CookId]) VALUES (4, N'Macarons', N'', 1)
SET IDENTITY_INSERT [Recipe].[Recipe] OFF
SET IDENTITY_INSERT [Recipe].[RecipeIngredient] ON 

INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (1, 1, 1)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (2, 1, 2)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (3, 1, 3)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (4, 2, 4)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (5, 2, 5)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (6, 2, 6)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (8, 3, 2)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (7, 3, 7)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (9, 3, 8)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (10, 3, 9)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (11, 3, 10)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (12, 3, 11)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (13, 3, 12)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (14, 4, 9)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (15, 4, 13)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (16, 4, 14)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (17, 4, 15)
INSERT [Recipe].[RecipeIngredient] ([RecipeIngredientId], [RecipeId], [IngredientId]) VALUES (18, 4, 16)
SET IDENTITY_INSERT [Recipe].[RecipeIngredient] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Ingredient_Name]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ingredient_Name] ON [Recipe].[Ingredient]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PreparedRecipe_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_PreparedRecipe_CookId] ON [Recipe].[PreparedRecipe]
(
	[CookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PreparedRecipe_RecipeId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_PreparedRecipe_RecipeId] ON [Recipe].[PreparedRecipe]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PreparedRecipeIngredient_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_PreparedRecipeIngredient_IngredientId] ON [Recipe].[PreparedRecipeIngredient]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId] ON [Recipe].[PreparedRecipeIngredient]
(
	[PreparedRecipeId] ASC,
	[IngredientId] ASC
)
WHERE ([IngredientId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipe_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_Recipe_CookId] ON [Recipe].[Recipe]
(
	[CookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Recipe_Name_CookId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Recipe_Name_CookId] ON [Recipe].[Recipe]
(
	[Name] ASC,
	[CookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredient_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredient_IngredientId] ON [Recipe].[RecipeIngredient]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredient_RecipeId_IngredientId]    Script Date: 19/04/2019 7:18:30 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RecipeIngredient_RecipeId_IngredientId] ON [Recipe].[RecipeIngredient]
(
	[RecipeId] ASC,
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Recipe].[PreparedRecipe]  WITH CHECK ADD  CONSTRAINT [FK_PreparedRecipe_Cook_CookId] FOREIGN KEY([CookId])
REFERENCES [Recipe].[Cook] ([CookId])
ON DELETE CASCADE
GO
ALTER TABLE [Recipe].[PreparedRecipe] CHECK CONSTRAINT [FK_PreparedRecipe_Cook_CookId]
GO
ALTER TABLE [Recipe].[PreparedRecipe]  WITH CHECK ADD  CONSTRAINT [FK_PreparedRecipe_Recipe_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [Recipe].[Recipe] ([RecipeId])
GO
ALTER TABLE [Recipe].[PreparedRecipe] CHECK CONSTRAINT [FK_PreparedRecipe_Recipe_RecipeId]
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_PreparedRecipeIngredient_Ingredient_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [Recipe].[Ingredient] ([IngredientId])
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient] CHECK CONSTRAINT [FK_PreparedRecipeIngredient_Ingredient_IngredientId]
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_PreparedRecipeIngredient_PreparedRecipe_PreparedRecipeId] FOREIGN KEY([PreparedRecipeId])
REFERENCES [Recipe].[PreparedRecipe] ([PreparedRecipeId])
ON DELETE CASCADE
GO
ALTER TABLE [Recipe].[PreparedRecipeIngredient] CHECK CONSTRAINT [FK_PreparedRecipeIngredient_PreparedRecipe_PreparedRecipeId]
GO
ALTER TABLE [Recipe].[Recipe]  WITH CHECK ADD  CONSTRAINT [FK_Recipe_Cook_CookId] FOREIGN KEY([CookId])
REFERENCES [Recipe].[Cook] ([CookId])
ON DELETE CASCADE
GO
ALTER TABLE [Recipe].[Recipe] CHECK CONSTRAINT [FK_Recipe_Cook_CookId]
GO
ALTER TABLE [Recipe].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [Recipe].[Ingredient] ([IngredientId])
ON DELETE CASCADE
GO
ALTER TABLE [Recipe].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId]
GO
ALTER TABLE [Recipe].[RecipeIngredient]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredient_Recipe_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [Recipe].[Recipe] ([RecipeId])
ON DELETE CASCADE
GO
ALTER TABLE [Recipe].[RecipeIngredient] CHECK CONSTRAINT [FK_RecipeIngredient_Recipe_RecipeId]
GO
USE [master]
GO
ALTER DATABASE [Cookbook] SET  READ_WRITE 
GO
