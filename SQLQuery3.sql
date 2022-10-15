create procedure spUpdateProductoEstado
(
    @codigo NVARCHAR(50),
	@usuarioCedula nvarchar(50)
)
as
UPDATE Productos SET usuarioCedula = @usuarioCedula WHERE codigo = @codigo