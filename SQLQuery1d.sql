CREATE PROCEDURE spSelectCarrito
(
	@usuarioCedula nvarchar(50)
)
as
select codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion, usuarioCedula from Carrito
where usuarioCedula = @usuarioCedula