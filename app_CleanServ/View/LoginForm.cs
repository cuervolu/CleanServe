using app_CleanServ.Controllers;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class LoginForm : MetroForm
    {
        private readonly UsuariosController usuariosController;

        public LoginForm()
        {
            InitializeComponent();
            usuariosController = new UsuariosController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text.Trim(); // Eliminar espacios en blanco al principio y al final
            string password = txtPass.Text.Trim(); // Eliminar espacios en blanco al principio y al final

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                // Los campos de nombre de usuario o contraseña están vacíos
                MetroMessageBox.Show(this, "Por favor, ingrese el nombre de usuario y la contraseña", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Realizar el inicio de sesión llamando al método login del controlador
            bool loginSuccessful = usuariosController.login(username, password);
            if (loginSuccessful)
            {
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += (s, args) =>
                {
                    mainForm.Hide();
                    // Mostrar el formulario de inicio de sesión nuevamente
                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();
                    mainForm.Close();
                };

                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }

            else
            {
                // Las credenciales de inicio de sesión son inválidas
                MetroMessageBox.Show(this, "Nombre de usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Mostrar un mensaje de error al usuario o realizar otras acciones necesarias
            }
        }
    }
}