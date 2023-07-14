using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Cliente getCliente(int ID_cliente)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el cliente por su ID
                    var cliente = dbContext.Cliente.FirstOrDefault(c => c.ID_cliente == ID_cliente);

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el cliente: " + ex.Message);
                return null;
            }
        }

        public bool updateCliente(Cliente cliente)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    Cliente oldCliente = dbContext.Cliente.FirstOrDefault(c => c.ID_cliente == cliente.ID_cliente);

                    if (oldCliente != null)
                    {
                        oldCliente.dni_cliente = cliente.dni_cliente;
                        oldCliente.primer_nombre = cliente.primer_nombre;
                        oldCliente.primer_apellido = cliente.primer_apellido;
                        oldCliente.email = cliente.email;
                        oldCliente.celular = cliente.celular;

                        int rowsAffected = dbContext.SaveChanges();
                        return rowsAffected > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente: " + ex.Message);
            }
        }

        public void removeCliente(int ID_cliente)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el cliente por su ID
                    var cliente = dbContext.Cliente.FirstOrDefault(c => c.ID_cliente == ID_cliente);

                    if (cliente != null)
                    {
                        // Eliminar el cliente
                        dbContext.Cliente.Remove(cliente);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
            }
        }
    }
}
