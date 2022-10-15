using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        DtEntities entities = new DtEntities();

        //soap clients
        integracionSR.integracionSWSoapClient clientIntegracion = new integracionSR.integracionSWSoapClient();

        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                Session["Usuario"] = "ANONIMO";

            var productos = new List<WEB.spSelectProductos_Result>();
            var productoData = entities.spSelectProductos();
            var carritos = new List<WEB.spSelectCarrito_Result>();
            var carritoData = entities.spSelectCarrito(Session["Usuario"].ToString());

            foreach (var c in carritoData)
            {
                carritos.Add(c);
            }

            foreach (var p in productoData)
            {
                productos.Add(p);
            }

            this.ViewBag.Productos = productos;
            this.ViewBag.Carritos = carritos;

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(Cliente cliente)
        {
            ViewBag.Message = "Your application description page.";

            var clienteEncontrado = entities.spSelectByCedu(cliente.Cedula).SingleOrDefault();

            if (clienteEncontrado != null)
            {
                if (cliente.Cedula == clienteEncontrado.Cedula && cliente.Password == clienteEncontrado.Password)
                {
                    Session["Usuario"] = cliente.Cedula;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "Cédula o contraseña incorrectos. Intente de nuevo";
                }
            }

            ViewData["Error"] = "Célula no registrada";
            return View();
        }

        public ActionResult Registrarse()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Registrarse(Cliente cliente)
        {
            ViewBag.Message = "Your contact page.";

            var clienteEncontrado = entities.spSelectByCedu(cliente.Cedula).SingleOrDefault();
            if (clienteEncontrado == null)
            {
                entities.spInsCliente(cliente.Nombres, cliente.Apellidos, cliente.Cedula, cliente.Telefono, cliente.fechaNacimiento, cliente.Email, cliente.Password, cliente.Sexo);
                clientIntegracion.InsertClienteINTEGRACION(cliente.Nombres, cliente.Apellidos, cliente.Cedula, cliente.Telefono, cliente.fechaNacimiento, cliente.Email, cliente.Password, cliente.Sexo);
                return RedirectToAction("Login");
            }

            ViewData["Error"] = "Cliente ya existe";

            return View();
        }

        [HttpPost]
        public ActionResult Index(string productoCodigo)
        {
            if (Session["Usuario"] == null)
                Session["Usuario"] = "ANONIMO";

            var producto = entities.spSelectProductoByCodigo(productoCodigo).Single();
            entities.spInsertProductoACarrito(producto.codigo, producto.tipo, producto.marca, producto.precio, producto.cantidad, producto.nombre, producto.peso, producto.imagen, producto.descripcion, Session["Usuario"].ToString());

            clientIntegracion.InsertarCarritoINTEGRACION(producto.codigo, producto.marca, producto.precio, producto.cantidad,  producto.tipo, producto.nombre, (int)producto.peso, producto.imagen, producto.descripcion, Session["Usuario"].ToString());

            entities.spUpdateProductoEstado(productoCodigo, Session["Usuario"].ToString());

            return RedirectToAction("Carrito");
        }

        [Route("Carrito")]
        public ActionResult Carrito()
        {
            if (Session["Usuario"] == null)
                Session["Usuario"] = "ANONIMO";

            var productos = new List<WEB.spSelectCarrito_Result>();
            var productoData = entities.spSelectCarrito(Session["Usuario"].ToString());


            foreach (var p in productoData)
            {
                productos.Add(p);
            }

            this.ViewBag.Productos = productos;

            var productosCarrito = entities.spSelectCarrito(Session["Usuario"].ToString());

            decimal preciosTotales = 0;
            int cantidadCompra = 0;
            decimal pesoTotal = 0;

            foreach (var item in productosCarrito)
            {
                preciosTotales += item.precio;
                cantidadCompra += item.cantidad;
                pesoTotal += item.peso;
            }

            ViewData["preciosTotales"] = preciosTotales;
            ViewData["cantidadCompra"] = cantidadCompra;
            ViewData["pesoTotal"] = pesoTotal;

            return View();
        }


        [HttpPost]
        public ActionResult CarritoComprar()
        {
            Guid myuuid = Guid.NewGuid();
           

            if (Session["Usuario"] == null)
                Session["Usuario"] = "ANONIMO";
        
            var clienteEncontrado = entities.spSelectByCedu(Session["Usuario"].ToString()).SingleOrDefault();
            var productosCarrito = entities.spSelectCarrito(Session["Usuario"].ToString());

            var listaProducto = new List<spSelectCarrito_Result>();

            foreach (var item in productosCarrito)
            {
                listaProducto.Add(item);
            }


            foreach (var item in listaProducto)
            {
                string cuentaID = myuuid.ToString();

                if (clienteEncontrado == null)
                {
                    entities.spInsCuenta("ANONIMO", "ANONIMO", item.nombre, item.precio, cuentaID, "ANONIMO");

                    clientIntegracion.InsertCuentaINTEGRACION("ANONIMO", "ANONIMO", item.nombre, item.precio, cuentaID, "ANONIMO");

                    entities.spDelCarrito("ANONIMO");

                    clientIntegracion.DeleteCarritoINTEGRACION("ANONIMO");

                    entities.spUpdateProductoEstado(item.codigo, null);
                }
                else 
                {
                    entities.spInsCuenta(clienteEncontrado.Nombres, clienteEncontrado.Apellidos, item.nombre, item.precio, cuentaID, Session["Usuario"].ToString());

                    clientIntegracion.InsertCuentaINTEGRACION(clienteEncontrado.Nombres, clienteEncontrado.Apellidos, item.nombre, item.precio, cuentaID, Session["Usuario"].ToString());

                    entities.spDelCarrito(Session["Usuario"].ToString());

                    clientIntegracion.DeleteCarritoINTEGRACION(Session["Usuario"].ToString());

                    entities.spUpdateProductoEstado(item.codigo, null);
                }
                   
            }

            return RedirectToAction("Carrito");
            //return View("CuentasPorCobrar", Session["Usuario"].ToString());
            return RedirectToAction("CuentasPorCobrar");
        }

        public ActionResult CuentasPorCobrar()
        {
            //var listaCuentasPorCobrar = new List<WEB.spSelectCarrito_Result>();
            //var cuentasPorCobrar = entities.spFillByCedulaCUENTAS(Session["Usuario"].ToString());

            //foreach (var c in cuentasPorCobrar)
            //{
            //    listaCuentasPorCobrar.Add(c);
            //}

            //this.ViewBag.CuentasPorCobrar = listaCuentasPorCobrar;

            return View();
        }

     
        public ActionResult CuentasPorCobrar()
        {
            return View();
        }

    }
}