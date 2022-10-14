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
            var productos = new List<WEB.spSelectProductos_Result>();
            var productoData = entities.spSelectProductos();

            foreach (var p in productoData)
            {
                productos.Add(p);
            }

            this.ViewBag.Productos = productos;

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
                    Session["Usuario"] = cliente;
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

            return View();
        }

        [Route("Carrito")]
        [Route("Carrito/{productoCodigo}")]
        public ActionResult Carrito()
        {
            return View();
        }
    }
}