using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productos = new List<Producto>();
            productos.Add(new Producto()
            {
                Imagen = "https://picsum.photos/id/237/200/300",
                Descripcion = "Una buena y breve descripción.",
                Nombre = "FOOBAR TRIM",
                Marca = "Patagonia Plus",
                Precio = 1550.05m
            });

            productos.Add(new Producto()
            {
                Imagen = "https://picsum.photos/id/237/200/300",
                Descripcion = "Una buena y breve descripción.",
                Nombre = "FOOBAR TRIM",
                Marca = "Patagonia Plus",
                Precio = 1550.05m
            });

            productos.Add(new Producto()
            {
                Imagen = "https://picsum.photos/id/237/200/300",
                Descripcion = "Una buena y breve descripción.",
                Nombre = "FOOBAR TRIM",
                Marca = "Patagonia Plus",
                Precio = 1550.05m
            });

            productos.Add(new Producto()
            {
                Imagen = "https://picsum.photos/id/237/200/300",
                Descripcion = "Una buena y breve descripción.",
                Nombre = "FOOBAR TRIM",
                Marca = "Patagonia Plus",
                Precio = 1550.05m
            });

            this.ViewBag.Productos = productos;

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Registrarse()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(Usuario usuario)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class Producto
    {
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Marca { get; set; }
    }

    public class Usuario
    {
    }
}