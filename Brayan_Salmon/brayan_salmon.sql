-- Crea la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BRAYAN_SALMON')
BEGIN
    CREATE DATABASE BRAYAN_SALMON;
END
GO

-- Selecciona la base de datos
USE BRAYAN_SALMON;
GO

-- Crea la tabla 'Form'
CREATE TABLE [dbo].[Form] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(255) NOT NULL
);
GO

-- Crea la tabla 'Input'
CREATE TABLE [dbo].[Input] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(255) NOT NULL,
    [Type] NVARCHAR(255) NOT NULL,
    [FormId] INT NOT NULL,
    CONSTRAINT FK_Input_Form FOREIGN KEY (FormId) REFERENCES [dbo].[Form](Id)
);
GO

-- Opcional: Crea índices adicionales para mejorar el rendimiento de las consultas
CREATE INDEX IX_Input_FormId ON [dbo].[Input] (FormId);
GO
