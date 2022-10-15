CREATE TABLE Carrito (
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
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

drop table Carrito

create procedure spIsExistProductoEnCarrito(
    @codigo nvarchar(50)
)
as
select 1 from Productos where codigo = @codigo

create procedure spSelectProductoByCodigo(
    @codigo nvarchar(50)
)
as
select * from Productos where codigo = @codigo 

CREATE PROCEDURE spInsertProductoACarrito
(
    @codigo NVARCHAR(50),
    @tipo NVARCHAR(50),
    @marca NVARCHAR(150),
    @precio decimal(18, 2),
    @cantidad int,
    @nombre nvarchar(500),
    @peso decimal(18, 2),
    @imagen nvarchar(200),
    @descripcion nvarchar(200)
)
as
insert into Productos (codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion)
VALUES (@codigo, @marca, @precio, @cantidad, @tipo, @nombre, @peso, @imagen, @descripcion)

update Productos set enCarrito = 0 where enCarrito = 1

create procedure spUpdateCarritoEstado
(
    @codigo NVARCHAR(50)
)
as
UPDATE Productos SET enCarrito = 1 WHERE codigo = @codigo

UPDATE Productos SET enCarrito = 1 WHERE id = 1

create procedure spSelectCarrito
( usuarioCedula nvarchar(50) )
as
select * from Carrito where usuarioCedula = @usuarioCedula