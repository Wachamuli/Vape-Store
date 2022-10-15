using INTEGRACION.dsINTEGRACIONTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;
using System.Data;
using INTEGRACION.dsWEBREFTableAdapters;

namespace INTEGRACION
{
    /// <summary>
    /// Summary description for integracionSW
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class integracionSW : System.Web.Services.WebService
    {
        //log4net init
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        //try para cuando no haya conexion

        DataTable dtUpdate = new DataTable();


        //dsAdapters
        ProductosTableAdapter adapterProducto = new ProductosTableAdapter();
        ClientesTableAdapter adapterCliente = new ClientesTableAdapter();
        EmpleadosTableAdapter adapterEmpleado = new EmpleadosTableAdapter();
        CuentasPorCobrarTableAdapter adapterCuenta = new CuentasPorCobrarTableAdapter();
        FacturasTableAdapter adapterFactura = new FacturasTableAdapter();
        CarritoTableAdapter adapterCarrito = new CarritoTableAdapter();

        //dsAdapters REFERENCIAS a otras db
        ProductosTableREFAdapter adapterProductoREF = new ProductosTableREFAdapter();
        ClientesTableREFAdapter adapterClienteREF = new ClientesTableREFAdapter();



        //soap clients
        coreSR.coreWSSoapClient clientCore = new coreSR.coreWSSoapClient();



        //metodos
        [WebMethod]
        public string InsertarProductoINTEGRACION(string codigo, string marca, decimal precio, int cantidad, string tipo, string nombre, int peso, string imagen, string descripcion)
        {

            adapterProducto.spInsProducto(codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion);

            adapterProductoREF.spInsProducto(codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion);

            //pasar a CAJA

            Logger.Info("Producto " + nombre + " fue insertado.");
            return "Producto " + nombre + " fue insertado.";
        }

        [WebMethod]
        public string DeleteProductoINTEGRACION(string codigo)
        {

            adapterProducto.spDelProducto(codigo);

            adapterProductoREF.spDelProducto(codigo);

            //pasar a CAJA

            Logger.Info("Producto con ID " + codigo + " fue eliminado.");
            return "Producto con ID " + codigo + " fue eliminado.";
        }

        //[WebMethod]
        //public string UpdateProductoINTEGRACION(string codigo, string usuarioCedula)
        //{

        //    adapterProducto.spUpdateProductoEstado(codigo, usuarioCedula);
        //    clientCore.UpdateProductoCORE(codigo, usuarioCedula);

        //    //pasar a CAJA o WEBAPP

        //    Logger.Info("Producto con ID " + codigo + " fue actualizado.");
        //    return "Producto con ID " + codigo + " fue actualizado.";
        //}

        [WebMethod]
        public string InsertClienteINTEGRACION(string Nombres, string Apellidos, string Cedula, string Telefono, DateTime fechaNacimiento, string Email, string Password, string Sexo)
        {
            try
            {
                adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);
                //pasar a CAJA
                clientCore.InsertClienteCORE(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);

                Logger.Info("Cliente " + Nombres + " fue insertado.");
            }
            catch (Exception)
            {
                adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);
                //pasar a CAJA
                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cliente " + Nombres + " fue insertado a lo demas.");

            }
            
            return "Cliente " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteClienteINTEGRACION(string Cedula)
        {

            adapterCliente.spDelCliente(Cedula);
            adapterClienteREF.spDelCliente(Cedula);
            //pasar a CAJA

            Logger.Info("Cliente con cedula " + Cedula + " fue eliminado.");
            return "Cliente con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateClienteINTEGRACION(decimal totalGastado, string Cedula)
        {

           

            try
            {
                adapterCliente.spUpdCliente(totalGastado, Cedula);
                //pasar a WEBAPP
                clientCore.UpdateClienteCORE(totalGastado, Cedula);

                Logger.Info("Cliente con cedula " + Cedula + " fue actualizado.");
            }
            catch (Exception)
            {
                adapterCliente.spUpdCliente(totalGastado, Cedula);
                //pasar a WEBAPP
                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + Cedula + " fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + Cedula + " fue actualizado a lo demas.";
            }

            return "Cliente con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertEmpleadoINTEGRACION(string Nombres, string Apellidos, string Cedula, string Telefono, string rol, string Email, string Password, string Sexo)
        {

            adapterEmpleado.spInsEmpleado(Nombres, Apellidos, Email, Telefono, Cedula, Password, rol, Sexo);
            //Pasar a CAJA

            Logger.Info("Empleado " + Nombres + " fue insertado.");
            return "Empleado " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteEmpleadoINTEGRACION(string Cedula)
        {

            adapterEmpleado.spDelEmpleado(Cedula);

            //Pasar a CAJA

            Logger.Info("Empleado con cedula " + Cedula + " fue eliminado.");
            return "Empleado con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateEmpleadoINTEGRACION(int cuentasCobradas, string Cedula)
        {
            try
            {
                adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);
                //Pasar a CORE, try

                Logger.Info("Empleado con cedula " + Cedula + " fue actualizado.");

            }
            catch (Exception)
            {
                adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);
                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Empleado con cedula " + Cedula + " fue actualizado.");
                return "Error al comunicarse con el CORE, estara desactualizado... Empleado con cedula " + Cedula + " fue actualizado.";
            }
            
            return "Empleado con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertCuentaINTEGRACION(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula)
        {

            try
            {
                adapterCuenta.spInsCuenta(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);
                //Pasar a CAJA
                clientCore.InsertCuentaCORE(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);

                Logger.Info("Cuenta de " + Nombres + " esta pendiente para pagar.");
            }
            catch (Exception)
            {
                adapterCuenta.spInsCuenta(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);
                //Pasar a CAJA

                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cuenta de " + Nombres + " esta pendiente para pagar fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Cuenta de " + Nombres + " esta pendiente para pagar fue actualizado a lo demas.";
            }

            
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

        [WebMethod]
        public string DeleteCuentaINTEGRACION(string cuentaID)
        {

            try
            {
                adapterCuenta.spDelCuenta(cuentaID);
                //Pasar a WEBAPP
                clientCore.DeleteCuentaCORE(cuentaID);

                Logger.Info("Cuenta de la cedula " + cuentaID + " ya fue pagada.");
            }
            catch (Exception)
            {
                adapterCuenta.spDelCuenta(cuentaID);
                //Pasar a WEBAPP

                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cuenta de la cedula " + cuentaID + " ya fue pagada fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Cuenta de la cedula " + cuentaID + " ya fue pagada fue actualizado a lo demas.";
            }
  
            return "Cuenta de la cedula " + cuentaID + " ya fue pagada.";
        }

        [WebMethod]
        public string InsertFacturaINTEGRACION(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula, string facturadoPor)
        {
            try
            {
                adapterFactura.spInsFactura(Nombres, Apellidos, Producto, Total, cuentaID, Cedula, facturadoPor);
                //Pasar a CORE

                Logger.Info("Factura de " + Nombres + ".");
            }
            catch (Exception)
            {
                adapterFactura.spInsFactura(Nombres, Apellidos, Producto, Total, cuentaID, Cedula, facturadoPor);
                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Factura de " + Nombres + " fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Factura de " + Nombres + " fue actualizado a lo demas.";
            }
            
            return "Factura de " + Nombres + ".";
        }

        [WebMethod]
        public string InsertarCarritoINTEGRACION(string codigo, string marca, decimal precio, int cantidad, string tipo, string nombre, int peso, string imagen, string descripcion, string usuarioCedula)
        {
            try
            {
                adapterCarrito.spInsertProductoACarrito(codigo, tipo, marca, precio, cantidad, nombre, peso, imagen, descripcion, usuarioCedula);
                clientCore.InsertarCarritoCORE(codigo, marca, precio, cantidad, tipo, nombre, peso, imagen, descripcion, usuarioCedula);

                Logger.Info("Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito.");
            }
            catch (Exception)
            {
                adapterCarrito.spInsertProductoACarrito(codigo, tipo, marca, precio, cantidad, nombre, peso, imagen, descripcion, usuarioCedula);
                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito fue actualizado a lo demas.";
            }
            
            return "Cliente con cedula " + usuarioCedula + " agrego el producto " + nombre + " al carrito.";
        }


        [WebMethod]
        public string DeleteCarritoINTEGRACION(string usuarioCedula)
        {
            try
            {
                adapterCarrito.spDelCarrito(usuarioCedula);
                clientCore.DeleteCarritoCORE(usuarioCedula);

                Logger.Info("Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito.");
            }
            catch (Exception)
            {
                adapterCarrito.spDelCarrito(usuarioCedula);

                Logger.Error("Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito fue actualizado a lo demas.");
                return "Error al comunicarse con el CORE, estara desactualizado... Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito fue actualizado a lo demas.";
            }
            
            return "Cliente con cedula " + usuarioCedula + " ha comprado todos sus productos del carrito.";
        }

    }
}
