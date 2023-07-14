using app_CleanServ.Controllers;
using DataAccess.Models;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class ModificarUsuarioForm : MetroForm
    {
        private readonly UsuariosController usuariosController;
        private Usuario usuario;
        private bool passwordChanged;

        public ModificarUsuarioForm(Usuario usuario)
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
            this.usuario = usuario;
            passwordChanged = false;

            // Suscribirse a los eventos TextChanged para realizar validaciones en tiempo real
            txtUser.TextChanged += OnTextChanged;
            txtPass.TextChanged += OnTextChanged;
            txtConfirmPass.TextChanged += OnTextChanged;

            // Llamar inicialmente a la validación para actualizar el estado del botón "Guardar"
            ValidateFields();
        }

        private void ModificarUsuarioForm_Load(object sender, EventArgs e)
        {
            // Cargar los datos en los textbox
            txtUser.Text = usuario.username;
            chxActivo.Checked = usuario.activo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación utilizando MetroFramework
            DialogResult result = MetroMessageBox.Show(this, "¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    usuario.username = txtUser.Text;
                    if (passwordChanged)
                    {
                        usuario.pass = txtPass.Text;
                    }
                    usuario.activo = chxActivo.Checked;

                    // Llamar al método updateUsuario del controlador para guardar los cambios
                    bool resultado = usuariosController.updateUsuario(usuario);

                    if (resultado)
                    {
                        // Mostrar un mensaje de éxito al usuario
                        MetroMessageBox.Show(this, "El usuario se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cerrar el formulario de modificación
                        this.Close();
                    }
                    else
                    {
                        // Mostrar un mensaje de error al usuario
                        ShowErrorMessage("No se pudo actualizar el servicio.");
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error al usuario
                    ShowErrorMessage("Error al actualizar el usuario: " + ex.Message);
                }
            }
        }

        private void ValidateFields()
        {
            // Realizar las validaciones y actualizar el estado del botón "Guardar" o mostrar mensajes de error en tiempo real
            if (txtUser.Text == usuario.username)
            {
                errorProvider.SetError(txtUser, "El nuevo nombre de usuario no debe ser igual al anterior.");
            }
            else
            {
                errorProvider.SetError(txtUser, string.Empty);
            }

            if (passwordChanged && txtPass.Text != txtConfirmPass.Text)
            {
                errorProvider.SetError(txtConfirmPass, "Las contraseñas deben coincidir.");
            }
            else
            {
                errorProvider.SetError(txtConfirmPass, string.Empty);
            }

            bool verify = usuariosController.confirmPassword(txtPass.Text, usuario.pass);
            if (verify)
            {
                errorProvider.SetError(txtPass, "La contraseña no debe ser igual a la anterior.");
            }
            else
            {
                errorProvider.SetError(txtPass, string.Empty);
            }

            // Habilitar o deshabilitar el botón "Guardar" según las validaciones
            btnGuardar.Enabled = errorProvider.GetError(txtUser) == string.Empty &&
                                 errorProvider.GetError(txtConfirmPass) == string.Empty &&
                                 errorProvider.GetError(txtPass) == string.Empty;
        }

        private void ShowErrorMessage(string message)
        {
            MetroMessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            // Verificar si se ha cambiado la contraseña
            if (sender == txtPass || sender == txtConfirmPass)
            {
                passwordChanged = true;
            }

            ValidateFields();
        }
    }
}
