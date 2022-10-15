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

        //dsAdapters REFERENCIAS a otras db
        ProductosTableREFAdapter adapterProductoREF = new ProductosTableREFAdapter();


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

        [WebMethod]
        public string UpdateProductoINTEGRACION(string codigo, string usuarioCedula)
        {

            adapterProducto.spUpdateProductoEstado(codigo, usuarioCedula);
            clientCore.UpdateProductoCORE(codigo, usuarioCedula);

            //pasar a CAJA o WEBAPP

            Logger.Info("Producto con ID " + codigo + " fue actualizado.");
            return "Producto con ID " + codigo + " fue actualizado.";
        }

        [WebMethod]
        public string InsertClienteINTEGRACION(string Nombres, string Apellidos, string Cedula, string Telefono, DateTime fechaNacimiento, string Email, string Password, string Sexo)
        {

            adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);

            //pasar a CORE, try
            //pasar a CAJA

            Logger.Info("Cliente " + Nombres + " fue insertado.");
            return "Cliente " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteClienteINTEGRACION(string Cedula)
        {

            adapterCliente.spDelCliente(Cedula);

            //Pasar a WEBAPP
            //pasar a CAJA

            Logger.Info("Cliente con cedula " + Cedula + " fue eliminado.");
            return "Cliente con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateClienteINTEGRACION(decimal totalGastado, string Cedula)
        {
            //pasar a CORE, try
            //pasar a WEBAPP

            adapterCliente.spUpdCliente(totalGastado, Cedula);

            Logger.Info("Cliente con cedula " + Cedula + " fue actualizado.");
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

            adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);

            //Pasar a CORE, try

            Logger.Info("Empleado con cedula " + Cedula + " fue actualizado.");
            return "Empleado con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertCuentaINTEGRACION(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula)
        {

            adapterCuenta.spInsCuenta(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);

            //Pasar a CORE, try
            //Pasar a CAJA

            Logger.Info("Cuenta de " + Nombres + " esta pendiente para pagar.");
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

        [WebMethod]
        public string DeleteCuentaINTEGRACION(string cuentaID)
        {

            adapterCuenta.spDelCuenta(cuentaID);
            //Pasar a CORE, try
            //Pasar a WEBAPP


            Logger.Info("Cuenta de la cedula " + cuentaID + " ya fue pagada.");
            return "Cuenta de la cedula " + cuentaID + " ya fue pagada.";
        }

        [WebMethod]
        public string InsertFacturaINTEGRACION(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula, string facturadoPor)
        {

            adapterFactura.spInsFactura(Nombres, Apellidos, Producto, Total, cuentaID, Cedula, facturadoPor);
            //Pasar a CORE, try

            Logger.Info("Cuenta de " + Nombres + " esta pendiente para pagar.");
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

    }
}
