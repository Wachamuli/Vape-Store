using CORE.dsCORETableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using System.Data.SqlClient;

namespace CORE
{
    /// <summary>
    /// Summary description for coreWS
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class coreWS : System.Web.Services.WebService
    {
        //transaction
        SqlTransaction transaction = null;



        //log4net init
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        //dsAdapters
        ProductosTableAdapter adapterProducto = new ProductosTableAdapter();
        ClientesTableAdapter adapterCliente = new ClientesTableAdapter();
        EmpleadosTableAdapter adapterEmpleado = new EmpleadosTableAdapter();
        CuentasPorCobrarTableAdapter adapterCuenta = new CuentasPorCobrarTableAdapter();
        FacturasTableAdapter adapterFactura = new FacturasTableAdapter();

        //soap clients
        integracionSR.integracionSWSoapClient clienteIntegracion = new integracionSR.integracionSWSoapClient();


        //metodos
        [WebMethod]
        public string InsertarProductoCORE(string Nombre, string Tipo, decimal Precio, int Cantidad, string productoID, string Descripcion, string Marca, string Imagen) 
        {

            try
            {
                dsCORE.ProductosDataTable dtProductos = adapterProducto.spFillByProductoID1(productoID);

                adapterProducto.Connection.Open();
                transaction = adapterProducto.Connection.BeginTransaction();
                adapterProducto.Transaction = transaction;


                if (dtProductos.Rows.Count == 0)
                {

                    adapterProducto.spInsProducto(Nombre, Tipo, Precio, Cantidad, productoID, Descripcion, Marca, Imagen);

                    clienteIntegracion.InsertarProductoINTEGRACION(Nombre, Tipo, Precio, Cantidad, productoID, Descripcion, Marca, Imagen);

                    transaction.Commit();
                    adapterEmpleado.Connection.Close();

                    Logger.Info("Producto " + Nombre + " fue insertado.");
                    return "Producto " + Nombre + " fue insertado.";
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                adapterEmpleado.Connection.Close();

                Logger.Error("Error al producto empleado " + Nombre + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.");
                return "Error al producto empleado " + Nombre + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.";

                throw;
            }

        }

        [WebMethod]
        public string DeleteProductoCORE(string productoID)
        {

            adapterProducto.spDelProducto(productoID);

            clienteIntegracion.DeleteProductoINTEGRACION(productoID);

            Logger.Info("Producto con ID " + productoID + " fue eliminado.");
            return "Producto con ID " + productoID + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateProductoCORE(int Cantidad, string productoID)
        {

            adapterProducto.spUpdProducto(Cantidad, productoID);

            Logger.Info("Producto con ID " + productoID + " fue actualizado.");
            return "Producto con ID " + productoID + " fue actualizado.";
        }

        [WebMethod]
        public string InsertClienteCORE(string Nombres, string Apellidos, string Cedula, string Telefono, DateTime fechaNacimiento, string Email, string Password, string Sexo)
        {

            adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);


            Logger.Info("Cliente " + Nombres + " fue insertado.");
            return "Cliente " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteClienteCORE(string Cedula)
        {

            adapterCliente.spDelCliente(Cedula);

            clienteIntegracion.DeleteClienteINTEGRACION(Cedula);

            Logger.Info("Cliente con cedula " + Cedula + " fue eliminado.");
            return "Cliente con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateClienteCORE(decimal totalGastado, string Cedula)
        {

            adapterCliente.spUpdCliente(totalGastado, Cedula);

            Logger.Info("Cliente con cedula " + Cedula + " fue actualizado.");
            return "Cliente con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertEmpleadoCORE(string Nombres, string Apellidos, string Cedula, string Telefono, string rol, string Email, string Password, string Sexo)
        {

            try
            {
                dsCORE.EmpleadosDataTable dtEmpleados = adapterEmpleado.spFillByCedula1(Cedula);

                adapterEmpleado.Connection.Open();
                transaction = adapterEmpleado.Connection.BeginTransaction();
                adapterEmpleado.Transaction = transaction;


                if (dtEmpleados.Rows.Count == 0)
                {

                adapterEmpleado.spInsEmpleado(Nombres, Apellidos, Email, Telefono, Cedula, Password, rol, Sexo);

                clienteIntegracion.InsertEmpleadoINTEGRACION(Nombres, Apellidos, Cedula, Telefono, rol,  Email, Password, Sexo);

                transaction.Commit();
                adapterEmpleado.Connection.Close();

                Logger.Info("Empleado " + Nombres + " fue insertado.");
                return "Empleado " + Nombres + " fue insertado.";
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                adapterEmpleado.Connection.Close();

                Logger.Error("Error al insertar empleado " + Nombres + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.");
                return "Error al insertar empleado " + Nombres + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.";
                
                throw;
            }

            
        }

        [WebMethod]
        public string DeleteEmpleadoCORE(string Cedula)
        {

            adapterEmpleado.spDelEmpleado(Cedula);

            clienteIntegracion.DeleteEmpleadoINTEGRACION(Cedula);

            Logger.Info("Empleado con cedula " + Cedula + " fue eliminado.");
            return "Empleado con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateEmpleadoCORE(int cuentasCobradas, string Cedula)
        {

            adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);


            Logger.Info("Empleado con cedula " + Cedula + " fue actualizado.");
            return "Empleado con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertCuentaCORE(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula)
        {

            adapterCuenta.spInsCuenta(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);


            Logger.Info("Cuenta de " + Nombres + " esta pendiente para pagar.");
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

        [WebMethod]
        public string DeleteCuentaCORE(string cuentaID)
        {

            adapterCuenta.spDelCuenta(cuentaID);


            Logger.Info("Cuenta de la cedula " + cuentaID + " ya fue pagada.");
            return "Cuenta de la cedula " + cuentaID + " ya fue pagada.";
        }

        [WebMethod]
        public string InsertFacturaCORE(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula, string facturadoPor)
        {

            adapterFactura.spInsFactura(Nombres, Apellidos, Producto, Total, cuentaID, Cedula, facturadoPor);


            Logger.Info("Cuenta de " + Nombres + " esta pendiente para pagar.");
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

    }
}
