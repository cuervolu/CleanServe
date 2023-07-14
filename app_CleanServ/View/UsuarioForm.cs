using app_CleanServ.Controllers;
using DataAccess.Models;
using MetroFramework;
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
            CargarUsuarios();

        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificar si se hizo clic en el botón de eliminar
                if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index && e.RowIndex >= 0)
                {
                    // Mostrar mensaje de confirmación
                    DialogResult result = MetroMessageBox.Show(this, "¿Estás seguro de eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Obtener el ID del usuario de la fila seleccionada
                        int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                        // Llamar al método removeServicio del controlador para eliminar el usuario
                        usuariosController.removeUsuario(id);

                        // Volver a cargar los usuarios en el DataGridView
                        CargarUsuarios();
                    }
                }
                // Verificar si se hizo clic en el botón de modificar
                else if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index && e.RowIndex >= 0)
                {
                    // Obtener el ID del usuario de la fila seleccionada
                    int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                    // Obtener el usuario correspondiente al id
                    Usuario usuario = usuariosController.getUsuario(id);

                    // Verificar si el usuario existe
                    if (usuario != null)
                    {
                        // Crear un formulario de modificación
                        ModificarUsuarioForm modificarForm = new ModificarUsuarioForm(usuario);

                        // Mostrar el formulario de modificación
                        modificarForm.ShowDialog();

                        // Volver a cargar los usuarios en el DataGridView
                        CargarUsuarios();
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al modificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = usuariosController.getUsuarios();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Establecer los títulos de las columnas
                dataGridView1.Columns["id"].HeaderText = "ID";
                dataGridView1.Columns["id"].ReadOnly = true;
                dataGridView1.Columns["username"].HeaderText = "Username";
                dataGridView1.Columns["username"].ReadOnly = true;
                dataGridView1.Columns["pass"].HeaderText = "Password";
                dataGridView1.Columns["pass"].ReadOnly = true;
                dataGridView1.Columns["activo"].HeaderText = "Activo";
                dataGridView1.Columns["activo"].ReadOnly = false;

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

                // Suscribe el evento CellValueChanged al método dataGridView1_CellValueChanged
                dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Console.WriteLine("Hola");
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;

                    // Verifica si el cambio se realizó en la columna "Activo"
                    if (dataGridView.Columns[e.ColumnIndex].Name == "activo")
                    {
                        int id = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["id"].Value);
                        bool newActivoValue = (bool)dataGridView.Rows[e.RowIndex].Cells["activo"].Value;

                        // Actualiza el estado "activo" del usuario en la base de datos
                        usuariosController.UpdateActivo(id, newActivoValue);
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario
                MetroFramework.MetroMessageBox.Show(this, "Error al actualizar el estado 'activo' del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
