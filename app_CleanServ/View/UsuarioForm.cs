using app_CleanServ.Controllers;
using System;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class UsuarioForm : Form
    {

        private readonly UsuariosController usuariosController;

        public UsuarioForm()
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearUsuarioForm crearUsuario = new CrearUsuarioForm();

            crearUsuario.ShowDialog();

        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = usuariosController.getUsuarios();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ReadOnly = true;

                // Establecer los títulos de las columnas
                dataGridView1.Columns["id"].HeaderText = "ID";
                dataGridView1.Columns["username"].HeaderText = "Username";
                dataGridView1.Columns["pass"].HeaderText = "Password";
                dataGridView1.Columns["activo"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
