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
    public partial class ClientesForms : Form
    {

        private readonly ClientesController clientesController;

        public ClientesForms()
        {
            InitializeComponent();
            clientesController = new ClientesController();
        }

        private void ClientesForms_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dataGridView1.Columns.Clear(); // Limpiar las columnas existentes
                dataGridView1.DataSource = clientesController.getClientes();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;

                // Establecer los títulos de las columnas
                dataGridView1.Columns["ID_cliente"].HeaderText = "ID";
                dataGridView1.Columns["dni_cliente"].HeaderText = "DNI";
                dataGridView1.Columns["primer_nombre"].HeaderText = "Nombre";
                dataGridView1.Columns["primer_apellido"].HeaderText = "Apellido";
                dataGridView1.Columns["email"].HeaderText = "Email";
                dataGridView1.Columns["celular"].HeaderText = "Celular";

                // Ocultar las últimas dos columnas
                dataGridView1.Columns["direccion"].Visible = false;
                dataGridView1.Columns["solicitud"].Visible = false;

                // Agregar columna de botón para eliminar
                DataGridViewButtonColumn eliminarButtonColumn = new DataGridViewButtonColumn();
                eliminarButtonColumn.Name = "Eliminar";
                eliminarButtonColumn.Text = "Eliminar";
                eliminarButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(eliminarButtonColumn);

                // Agregar columna de botón para modificar
                DataGridViewButtonColumn modificarButtonColumn = new DataGridViewButtonColumn();
                modificarButtonColumn.Name = "Modificar";
                modificarButtonColumn.Text = "Modificar";
                modificarButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(modificarButtonColumn);
                dataGridView1.CellContentClick += dataGridView1_CellContentClick;
                dataGridView1.Visible = true;

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón de eliminar
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Mostrar mensaje de confirmación
                DialogResult result = MetroMessageBox.Show(this, "¿Estás seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del cliente de la fila seleccionada
                    int ID_cliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_cliente"].Value);

                    // Llamar al método removeCliente del controlador para eliminar el cliente
                    clientesController.removeCliente(ID_cliente);

                    // Volver a cargar los cliente en el DataGridView
                    CargarClientes();
                }
            }
            // Verificar si se hizo clic en el botón de modificar
            else if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del cliente de la fila seleccionada
                int ID_cliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID_cliente"].Value);

                // Obtener el cliente correspondiente al ID_cliente
                Cliente cliente = clientesController.getCliente(ID_cliente);

                // Verificar si el cliente existe
                if (cliente != null)
                {
                    // Crear un formulario de modificación
                    ModificarClienteForm modificarForm = new ModificarClienteForm(cliente);

                    // Mostrar el formulario de modificación
                    modificarForm.ShowDialog();

                    // Volver a cargar los cliente en el DataGridView
                    CargarClientes();
                }
            }
        }
    }
}
