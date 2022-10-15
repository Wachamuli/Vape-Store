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
    [imagen]     NVARCHAR(200)           NULL,
	[descripcion] NVARCHAR(200) 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



drop table Productos

drop procedure spSelectByCedula

create procedure spSelectByCedu 
(
    @cedula NVARCHAR(200)
)
AS 
SELECT [Nombres], [Apellidos], Cedula, Telefono, fechaNacimiento, totalGastado, Email, [Password], Sexo FROM Clientes WHERE Cedula = @cedula

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion)
VALUES ('2432EAD', 'Fucsia', 1230.05, 2, 'hierro', 'Lynx', '2022-06-09', 78.9, 'smok-vape.jpg', 'Se deja fumar solito')

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion)
VALUES ('X4564Z', 'Fucsia', 1230.05, 2, 'hierro', 'Calimete', '2022-06-09', 78.9, 'vape-lychee.jpg', 'Y no para el pelo')

INSERT INTO Productos (codigo, marca, precio, cantidad, tipo, nombre, abastfecha, peso, imagen, descripcion)
VALUES ('ddd323', 'Fucsia', 550.60, 5, 'hierro', 'Blue Smoke', '2022-06-09', 78.9, 'simple.png', 'Y no para el pelo')

update Productos set descripcion = 'Oferta 2x1 por hoy' where nombre = 'Blue Smoke'

create procedure spSelectCarrito
( usuarioCedula nvarchar(50) )
as
select * from Carrito where usuarioCedula = @usuarioCedula