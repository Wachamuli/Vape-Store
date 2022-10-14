CREATE TABLE [dbo].[Productos] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [codigo]     NVARCHAR (50)   NOT NULL,
    [marca]      NVARCHAR (150)  NOT NULL,
    [precio]     DECIMAL (18, 2) NOT NULL,
    [cantidad]   INT             NOT NULL,
    [tipo]       NVARCHAR (100)  NOT NULL,
    [nombre]     NVARCHAR (500)  NOT NULL,
    [abastfecha] DATE            DEFAULT (getdate()) NOT NULL,
    [peso]       DECIMAL (18, 2) NOT NULL,
    [imagen]     IMAGE           NULL,
	[descripcion] NVARCHAR(200) 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Clientes] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Nombres]         NVARCHAR (150)  NOT NULL,
    [Apellidos]       NVARCHAR (150)  NOT NULL,
    [Cedula]          NVARCHAR (150)  NOT NULL,
    [Telefono]        NVARCHAR (150)  NOT NULL,
    [fechaNacimiento] DATE            NOT NULL,
    [fechaIngreso]    DATE            DEFAULT (getdate()) NOT NULL,
    [totalGastado]    DECIMAL (18, 2) DEFAULT ((0)) NOT NULL,
    [Email]           NVARCHAR (150)  NOT NULL,
    [Password]        NVARCHAR (150)  NOT NULL,
    [Sexo]            NVARCHAR (150)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE PROCEDURE spInsCliente
(
    @Nombres nvarchar(150),
    @Apellidos nvarchar(150),
    @Cedula nvarchar(150),
    @Telefono nvarchar(150),
    @fechaNacimiento date,
    @Email nvarchar(150),
    @Password nvarchar(150),
    @Sexo nvarchar(150)
)
AS
    SET NOCOUNT OFF;
INSERT INTO [dbo].[Clientes] ([Nombres], [Apellidos], [Cedula], [Telefono], [fechaNacimiento], [Email], [Password], [Sexo]) VALUES (@Nombres, @Apellidos, @Cedula, @Telefono, @fechaNacimiento, @Email, @Password, @Sexo)

create procedure spSelectProductos
as
SELECT * FROM Productos


INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, peso, imagen) 
VALUES ('231321a', 'Trufa', 889.99, 3, 'desechable', 'Revividor', 78.9, '')

CREATE PROCEDURE spSelectByCedula 
(
    @cedula nvarchar(150)
)
as
    select 1 from Clientes where Cedula = @cedula