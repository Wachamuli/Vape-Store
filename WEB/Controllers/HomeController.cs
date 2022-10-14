using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        DtEntities entities = new DtEntities();

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

            entities.spInsCliente(cliente.Nombres, cliente.Apellidos, cliente.Cedula, cliente.Telefono, cliente.fechaNacimiento, cliente.Email, cliente.Password, cliente.Sexo);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Index(string productoCodigo)
        {
            if (Session["Usuario"] == null)
                Session["Usuario"] = "ANONIMO";

            var producto = entities.spSelectProductoByCodigo(productoCodigo).Single();
            entities.spInsertProductoACarrito(producto.codigo, producto.tipo, producto.marca, producto.precio, producto.cantidad, producto.nombre, producto.peso, producto.imagen, producto.descripcion, Session["Usuario"].ToString());
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

            var totales = new Dictionary<string, string>();
            //var precioTotal = entities.spGetPrecioTotal(Session["Usuario"].ToString();
            //var pesoTotal = entities.spGetPesoTotal(Session["Usuario"].ToString());
            //var cantidadTotal = entities.spGetCantidadTotal(Session["Usuario"].ToString());

            //totales.Add("precioTotal", );
            


            return View();
        }
    }
}