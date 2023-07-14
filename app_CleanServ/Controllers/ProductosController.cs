using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_CleanServ.Controllers
{
    internal class ProductosController
    {
        private readonly SERVICIO_LIMPIEZAEntities dbContext;

        public ProductosController()
        {
            dbContext = new SERVICIO_LIMPIEZAEntities();
        }

        public List<Producto> getProductos()
        {
            try
            {
                List<Producto> productos = dbContext.Producto.ToList();
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar productos: " + ex.Message);
            }
        }
    }
}
