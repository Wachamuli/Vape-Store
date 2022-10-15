CREATE PROCEDURE [dbo].spFillByCedulaCUENTAS
(
    @Cedula nvarchar(150)
)
AS
SELECT Id, Nombres, Apellidos, Producto, Total, cuentaID, sucursal, fechaCompra, Cedula FROM dbo.CuentasPorCobrar WHERE @Cedula = Cedula