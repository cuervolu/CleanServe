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
    public partial class ProductosForm : Form
    {

        private readonly ProductosController productosController;

        public ProductosForm()
        {
            InitializeComponent();
            productosController = new ProductosController();
        }

        private void ProductoForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = productosController.getProductos();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;

                // Establecer los títulos de las columnas
                dataGridView1.Columns["ID_producto"].HeaderText = "ID";
                dataGridView1.Columns["nombre"].HeaderText = "Nombre";  
                dataGridView1.Columns["presentacion"].HeaderText = "Presentacion";
                dataGridView1.Columns["imagen"].HeaderText = "Imagen";

                // Ocultar las últimas tres columnas
                dataGridView1.Columns["Producto_por_compra"].Visible = false;
                dataGridView1.Columns["Producto_por_servicio"].Visible = false;
                dataGridView1.Columns["Proveedor_por_producto"].Visible = false;
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
