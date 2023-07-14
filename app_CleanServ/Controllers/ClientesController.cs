using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_CleanServ.Controllers
{
    internal class ClientesController
    {
        private readonly SERVICIO_LIMPIEZAEntities dbContext;

        public ClientesController()
        {
            dbContext = new SERVICIO_LIMPIEZAEntities();
        }

        public List<Cliente> getClientes()
        {
            try
            {
                List<Cliente> clientes = dbContext.Cliente.ToList();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar productos: " + ex.Message);
            }
        }
    }
}
