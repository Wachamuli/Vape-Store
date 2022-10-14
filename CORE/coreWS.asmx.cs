using CORE.dsCORETableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;

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
        //log4net init
        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        //dsAdapters
        ProductosTableAdapter adapterProducto = new ProductosTableAdapter();
        ClientesTableAdapter adapterCliente = new ClientesTableAdapter();
        EmpleadosTableAdapter adapterEmpleado = new EmpleadosTableAdapter();
        CuentasPorCobrarTableAdapter adapterCuenta = new CuentasPorCobrarTableAdapter();
        FacturasTableAdapter adapterFactura = new FacturasTableAdapter();

        //soap clients



        //metodos
        [WebMethod]
        public string InsertarProductoCORE(string Nombre, string Tipo, decimal Precio, int Cantidad, string productoID, string Descripcion, string Marca, string Imagen) 
        {

            adapterProducto.spInsProducto(Nombre, Tipo, Precio, Cantidad, productoID, Descripcion, Marca, Imagen);

            //Pasar a integracion

            Logger.Info("Producto " + Nombre + " fue insertado.");
            return "Producto " + Nombre + " fue insertado.";
        }

        [WebMethod]
        public string DeleteProductoCORE(string productoID)
        {

            adapterProducto.spDelProducto(productoID);

            //Pasar a integracion

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

            //Pasar a integracion

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

            adapterEmpleado.spInsEmpleado(Nombres, Apellidos, Email, Telefono, Cedula, Password, rol, Sexo);

            //Pasar a integracion

            Logger.Info("Empleado " + Nombres + " fue insertado.");
            return "Empleado " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteEmpleadoCORE(string Cedula)
        {

            adapterEmpleado.spDelEmpleado(Cedula);

            //Pasar a integracion

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
