using app_CleanServ.Controllers;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class CrearUsuarioForm : MetroForm
    {
        private readonly UsuariosController usuariosController;

        public CrearUsuarioForm()
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
        }

        private void btnCrearUsuario_Click(object sender, System.EventArgs e)
        {
            // Obtener los valores de los campos de texto
            string username = txtUsuario.Text;
            string password = txtPassword.Text;

            // Validar que los campos no estén vacíos y tengan más de tres caracteres
            if (!string.IsNullOrWhiteSpace(username) && username.Length > 3 &&
                !string.IsNullOrWhiteSpace(password) && password.Length > 3)
            {
                try
                {
                    // Llamar al método createUser del controlador para crear el usuario
                    bool resultado = usuariosController.createUser(username, password);

                    if (resultado)
                    {
                        // Mostrar un mensaje de éxito al usuario
                        MetroFramework.MetroMessageBox.Show(this, "El usuario se creó correctamente.", "Creación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cerrar el formulario de creación
                        this.Close();
                    }
                    else
                    {
                        // Mostrar un mensaje de error al usuario
                        MetroFramework.MetroMessageBox.Show(this, "No se pudo crear el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error al usuario
                    MetroFramework.MetroMessageBox.Show(this, "Error al crear el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mostrar un mensaje de error si los campos no cumplen con los requisitos
                MetroFramework.MetroMessageBox.Show(this, "Los campos de usuario y contraseña deben tener al menos tres caracteres y no pueden estar vacíos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
