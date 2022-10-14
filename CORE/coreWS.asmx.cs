using CORE.dsCORETableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CORE
{
    /// <summary>
    /// Summary description for coreWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class coreWS : System.Web.Services.WebService
    {
        //dsAdapters
        ProductosTableAdapter adapterProducto = new ProductosTableAdapter();
        ClientesTableAdapter adapterCliente = new ClientesTableAdapter();
        EmpleadosTableAdapter adapterEmpleado = new EmpleadosTableAdapter();
        CuentasPorCobrarTableAdapter adapterCuenta = new CuentasPorCobrarTableAdapter();
        FacturasTableAdapter adapterFactura = new FacturasTableAdapter();

        [WebMethod]
        public string InsertarProductoCORE(string Nombre, string Tipo, decimal Precio, int Cantidad, string productoID, string Descripcion, string Marca, string Imagen) 
        {

            adapterProducto.spInsProducto(Nombre, Tipo, Precio, Cantidad, productoID, Descripcion, Marca, Imagen);

            //Pasar a integracion

            //Log4Net
            return "Producto " + Nombre + " fue insertado.";
        }

        [WebMethod]
        public string DeleteProductoCORE(string productoID)
        {

            adapterProducto.spDelProducto(productoID);

            //Pasar a integracion

            //Log4Net
            return "Producto con ID " + productoID + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateProductoCORE(int Cantidad, string productoID)
        {

            adapterProducto.spUpdProducto(Cantidad, productoID);

            //Log4Net
            return "Producto con ID " + productoID + " fue actualizado.";
        }

        [WebMethod]
        public string InsertClienteCORE(string Nombres, string Apellidos, string Cedula, string Telefono, DateTime fechaNacimiento, string Email, string Password, string Sexo)
        {

            adapterCliente.spInsCliente(Nombres, Apellidos, Cedula, Telefono, fechaNacimiento, Email, Password, Sexo);


            //Log4Net
            return "Cliente " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteClienteCORE(string Cedula)
        {

            adapterCliente.spDelCliente(Cedula);

            //Pasar a integracion

            //Log4Net
            return "Cliente con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateClienteCORE(decimal totalGastado, string Cedula)
        {

            adapterCliente.spUpdCliente(totalGastado, Cedula);

            //Log4Net
            return "Cliente con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertEmpleadoCORE(string Nombres, string Apellidos, string Cedula, string Telefono, string rol, string Email, string Password, string Sexo)
        {

            adapterEmpleado.spInsEmpleado(Nombres, Apellidos, Email, Telefono, Cedula, Password, rol, Sexo);

            //Pasar a integracion

            //Log4Net
            return "Empleado " + Nombres + " fue insertado.";
        }

        [WebMethod]
        public string DeleteEmpleadoCORE(string Cedula)
        {

            adapterEmpleado.spDelEmpleado(Cedula);

            //Pasar a integracion

            //Log4Net
            return "Empleado con cedula " + Cedula + " fue eliminado.";
        }

        [WebMethod]
        public string UpdateEmpleadoCORE(int cuentasCobradas, string Cedula)
        {

            adapterEmpleado.spUpdEmpleado(cuentasCobradas, Cedula);


            //Log4Net
            return "Empleado con cedula " + Cedula + " fue actualizado.";
        }

        [WebMethod]
        public string InsertCuentaCORE(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula)
        {

            adapterCuenta.spInsCuenta(Nombres, Apellidos, Producto, Total, cuentaID, Cedula);


            //Log4Net
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

        [WebMethod]
        public string DeleteCuentaCORE(string cuentaID)
        {

            adapterCuenta.spDelCuenta(cuentaID);


            //Log4Net
            return "Cuenta de la cedula " + cuentaID + " ya fue pagada.";
        }

        [WebMethod]
        public string InsertFacturaCORE(string Nombres, string Apellidos, string Producto, decimal Total, string cuentaID, string Cedula, string facturadoPor)
        {

            adapterFactura.spInsFactura(Nombres, Apellidos, Producto, Total, cuentaID, Cedula, facturadoPor);


            //Log4Net
            return "Cuenta de " + Nombres + " esta pendiente para pagar.";
        }

    }
}
