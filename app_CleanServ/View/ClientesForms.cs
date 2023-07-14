using app_CleanServ.Controllers;
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
            try
            {
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

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
