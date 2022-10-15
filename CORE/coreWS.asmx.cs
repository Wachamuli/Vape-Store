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
        // PRORGAMA HECHO POR JOSE RICHIES Y MARIO ESTRELLA :)))



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
        CarritoTableAdapter adapterCarrito = new CarritoTableAdapter();

        //soap clients
        integracionSR.integracionSWSoapClient clienteIntegracion = new integracionSR.integracionSWSoapClient();


        //metodos que maneja directamente el core
        [WebMethod]
        public string InsertarProductoCORE(string codigo, string marca,decimal precio, int cantidad, string tipo, string nombre, int peso, string imagen, string descripcion) 
        {

            try
            {
                dsCORE.ProductosDataTable dtProductos = adapterProducto.spFillByProductoID1(codigo);

                adapterProducto.Connection.Open();
                transaction = adapterProducto.Connection.BeginTransaction();
                adapterProducto.Transaction = transaction;


                if (dtProductos.Rows.Count == 0)
                {

                    adapterProducto.spInsProducto(codigo, marca, precio, cantidad, tipo, nombre, peso, imagen,descripcion);

                   clienteIntegracion.InsertarProductoINTEGRACION(codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion);

                    transaction.Commit();
                    adapterEmpleado.Connection.Close();

                    Logger.Info("Producto " + nombre + " fue insertado.");
                    return "Producto " + nombre + " fue insertado.";
                }

                throw new Exception();
            }
            catch (Exception)
            {
                transaction.Rollback();
                adapterProducto.Connection.Close();

                Logger.Error("Error al producto empleado " + nombre + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.");
                return "Error al producto empleado " + nombre + " . Tal vez ya exista o la conexion con la capa de integracion no este abierta.";

                throw;
            }

        }

        [WebMethod]
        public string DeleteProductoCORE(string codigo)
        {

            try
            {
                dsCORE.ProductosDataTable dtProductos = adapterProducto.spFillByProductoID1(codigo);

                adapterProducto.Connection.Open();
                transaction = adapterProducto.Connection.BeginTransaction();
                adapterProducto.Transaction = transaction;


                if (dtProductos.Rows.Count > 0)
                {

                    adapterProducto.spDelProducto(codigo);

                   clienteIntegracion.DeleteProductoINTEGRACION(codigo);

                    transaction.Commit();
                    adapterEmpleado.Connection.Close();

                    Logger.Info("Producto con ID " + codigo + " fue eliminado.");
                    return "Producto con ID " + codigo + " fue eliminado.";
                }

                throw new Exception();
            }
            catch (Exception)
            {
                transaction.Rollback();
                adapterProducto.Connection.Close();

                Logger.Error("Error al eliminar el producto con ID " + codigo + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.");
                return "Error al eliminar el producto con ID " + codigo + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.";

                throw;
            }

          
        }

        [WebMethod]
        public string DeleteClienteCORE(string Cedula)
        {

            try
            {
                dsCORE.ClientesDataTable dtCliente = adapterCliente.spFillByCedulaCliente1(Cedula);

                adapterCliente.Connection.Open();
                transaction = adapterCliente.Connection.BeginTransaction();
                adapterCliente.Transaction = transaction;


                if (dtCliente.Rows.Count > 0)
                {

                    adapterCliente.spDelCliente(Cedula);

                    clienteIntegracion.DeleteClienteINTEGRACION(Cedula);

                    transaction.Commit();
                    adapterCliente.Connection.Close();

                    Logger.Info("Cliente con cedula " + Cedula + " fue eliminado.");
                    return "Cliente con cedula " + Cedula + " fue eliminado.";
                }

                throw new Exception();
            }
            catch (Exception)
            {
                transaction.Rollback();
                adapterCliente.Connection.Close();

                Logger.Error("Error al eliminar el cliente con cedula " + Cedula + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.");
                return "Error al eliminar el cliente con cedula " + Cedula + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.";

                throw;
            }
           
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
            catch (Exception)
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

            try
            {
                dsCORE.EmpleadosDataTable dtEmpleados = adapterEmpleado.spFillByCedula1(Cedula);

                adapterEmpleado.Connection.Open();
                transaction = adapterEmpleado.Connection.BeginTransaction();
                adapterEmpleado.Transaction = transaction;


                if (dtEmpleados.Rows.Count > 0)
                {

                    adapterEmpleado.spDelEmpleado(Cedula);

                    clienteIntegracion.DeleteEmpleadoINTEGRACION(Cedula);

                    transaction.Commit();
                    adapterEmpleado.Connection.Close();

                    Logger.Info("Empleado con cedula " + Cedula + " fue eliminado.");
                    return "Empleado con cedula " + Cedula + " fue eliminado.";
                }

                throw new Exception();
            }
            catch (Exception)
            {
                transaction.Rollback();
                adapterEmpleado.Connection.Close();

                Logger.Error("Error al eliminar el empleado con cedula " + Cedula + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.");
                return "Error al eliminar el empleado con cedula " + Cedula + " . Tal vez no exista o la conexion con la capa de integracion no este abierta.";

                throw;
            }


            
        }






        //metodos de update que no maneja directamente el core FALTA

        [WebMethod]
        public string UpdateClienteCORE(decimal totalGastado, string Cedula)
        {

            adapterCliente.spUpdCliente(totalGastado, Cedula);

            Logger.Info("Cliente con cedula " + Cedula + " fue actualizado.");
            return "Cliente con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string UpdateEmpleadoCORE(int cuentasCobradas, string Cedula)
        {

            adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);


            Logger.Info("Empleado con cedula " + Cedula + " fue actualizado.");
            return "Empleado con cedula " + Cedula + " fue actualizado.";
        }

        //[WebMethod]
        //public string UpdateProductoCORE(string codigo, string usuarioCedula)
        //{

        //    adapterProducto.spUpdateProductoEstado(codigo, usuarioCedula);

        //    Logger.Info("Producto con ID " + codigo + " fue actualizado.");
        //    return "Producto con ID " + codigo + " fue actualizado.";
        //}






        //metodos que no maneja directamente el core FALTA

        [WebMethod]
        public string InsertClienteCORE(string Nombres, string Apellidos, string Cedula, string Telefono, DateTime fechaNacimiento, string Email, string Password, string Sexo)
        {

            adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);


            Logger.Info("Cliente " + Nombres + " fue insertado.");
            return "Cliente " + Nombres + " fue insertado.";
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

        [WebMethod]
        public string InsertarCarritoCORE(string codigo, string marca, decimal precio, int cantidad, string tipo, string nombre, int peso, string imagen, string descripcion, string usuarioCedula)
        {

            adapterCarrito.spInsertProductoACarrito(codigo, tipo, marca, precio, cantidad, nombre, peso, imagen, descripcion, usuarioCedula);

            Logger.Info("Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito.");
            return "Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito.";
        }

        [WebMethod]
        public string DeleteCarritoCORE(string usuarioCedula)
        {

            adapterCarrito.spDelCarrito(usuarioCedula);

            Logger.Info("Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito.");
            return "Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito.";
        }





    }
}
