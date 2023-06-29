using DataAccess.Models;
using System.Linq;
using System.Web.Mvc;

namespace web_CleanServe.Controllers
{
    [Route("")] // Prefijo vacío para el controlador HomeController
    public class HomeController : Controller
    {
        // GET: /
        [Route("")]
        public ActionResult Index()
        {
            using (var dbContext = new SERVICIO_LIMPIEZAEntities())
            {
                ViewBag.Productos = dbContext.Producto.Take(20).ToList(); //solo los 20 primeros
                return View();
            }
        }


        // GET: /Productos/Detalle/{id}
        [Route("Productos/Detalle/{id}")]
        public ActionResult DetalleProducto(int id)
        {
            using (var dbContext = new SERVICIO_LIMPIEZAEntities())
            {
                Producto producto = dbContext.Producto.FirstOrDefault(p => p.ID_producto == id);

                if (producto == null)
                {
                    return RedirectToAction("Index");
                }

                return View("DetalleProducto", producto);
            }
        }

        // GET: /Productos
        [Route("Productos")]
        public ActionResult Productos()
        {
            using (var dbContext = new SERVICIO_LIMPIEZAEntities())
            {
                ViewBag.Productos = dbContext.Producto.ToList();

                return View();
            }
        }

        //GET: /Servicios
        public ActionResult Servicios()
        {
            using (var dbContext = new SERVICIO_LIMPIEZAEntities())
            {
                ViewBag.Calificaciones = dbContext.Calificacion_de_servicio.ToList();

                return View();
            }
        }
    }
}
