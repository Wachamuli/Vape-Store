CREATE TABLE [dbo].[Productos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [codigo]      NVARCHAR (50)   NOT NULL,
    [marca]       NVARCHAR (150)  NOT NULL,
    [precio]      DECIMAL (18, 2) NOT NULL,
    [cantidad]    INT             NOT NULL,
    [tipo]        NVARCHAR (100)  NOT NULL,
    [nombre]      NVARCHAR (500)  NOT NULL,
    [abastfecha]  DATE            DEFAULT (getdate()) NOT NULL,
    [peso]        DECIMAL (18, 2) NOT NULL,
    [imagen]      NVARCHAR (200)  NULL,
    [descripcion] NVARCHAR (200)  NULL,
	usuarioCedula nvarchar(50)
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Productos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [codigo]      NVARCHAR (50)   NOT NULL,
    [marca]       NVARCHAR (150)  NOT NULL,
    [precio]      DECIMAL (18, 2) NOT NULL,
    [cantidad]    INT             NOT NULL,
    [tipo]        NVARCHAR (100)  NOT NULL,
    [nombre]      NVARCHAR (500)  NOT NULL,
    [abastfecha]  DATE            DEFAULT (getdate()) NOT NULL,
    [peso]        DECIMAL (18, 2) NOT NULL,
    [imagen]      NVARCHAR (200)  NULL,
    [descripcion] NVARCHAR (200)  NULL,
	usuarioCedula nvarchar(50)
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Productos] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [codigo]      NVARCHAR (50)   NOT NULL,
    [marca]       NVARCHAR (150)  NOT NULL,
    [precio]      DECIMAL (18, 2) NOT NULL,
    [cantidad]    INT             NOT NULL,
    [tipo]        NVARCHAR (100)  NOT NULL,
    [nombre]      NVARCHAR (500)  NOT NULL,
    [abastfecha]  DATE            DEFAULT (getdate()) NOT NULL,
    [peso]        DECIMAL (18, 2) NOT NULL,
    [imagen]      NVARCHAR (200)  NULL,
    [descripcion] NVARCHAR (200)  NULL,
	usuarioCedula nvarchar(50)
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion, usuarioCedula)
VALUES ('2432EAD', 'Fucsia', 1230.05, 2, 'hierro', 'Lynx', '2022-06-09', 78.9, 'smok-vape.jpg', 'Se deja fumar solito', null)

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion, usuarioCedula)
VALUES ('X4564Z', 'Fucsia', 1230.05, 2, 'hierro', 'Calimete', '2022-06-09', 78.9, 'vape-lychee.jpg', 'Y no para el pelo', null)

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion, usuarioCedula)
VALUES ('ddd323', 'Fucsia', 550.60, 5, 'hierro', 'Blue Smoke', '2022-06-09', 78.9, 'simple.png', 'Y no para el pelo', null)


