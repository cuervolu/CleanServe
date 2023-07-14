using app_CleanServ.Controllers;
using DataAccess.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class ModificarClienteForm : MetroFramework.Forms.MetroForm
    {
        private Cliente cliente; // Servicio a modificar

        private readonly ClientesController clientesController;

        public ModificarClienteForm(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;
            clientesController = new ClientesController();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModificarClienteForm_Load(object sender, EventArgs e)
        {
            txtID.Text = cliente.ID_cliente.ToString();
            txtDNI.Text = cliente.dni_cliente.ToString();
            txtNombre.Text = cliente.primer_nombre.ToString();
            txtApellido.Text = cliente.primer_apellido.ToString();
            txtEmail.Text = cliente.email.ToString();
            txtCelular.Text = cliente.celular.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación utilizando MetroFramework
            DialogResult result = MetroMessageBox.Show(this, "¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Actualizar los atributos del cliente según los controles del formulario
                    cliente.dni_cliente = txtDNI.Text;
                    cliente.primer_nombre = txtNombre.Text;
                    cliente.primer_apellido = txtApellido.Text;
                    cliente.email = txtEmail.Text;
                    cliente.celular = txtCelular.Text;

                    // Llamar al método updateCliente del controlador para guardar los cambios
                    bool resultado = clientesController.updateCliente(cliente);

                    if (resultado)
                    {
                        // Mostrar un mensaje de éxito al usuario
                        MetroMessageBox.Show(this, "El cliente se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cerrar el formulario de modificación
                        this.Close();
                    }
                    else
                    {
                        // Mostrar un mensaje de error al usuario
                        MetroMessageBox.Show(this, "No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {// Mostrar un mensaje de error al usuario
                    MetroMessageBox.Show(this, "Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
