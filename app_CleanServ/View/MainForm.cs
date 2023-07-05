using app_CleanServ.View;
using MetroFramework;
using System;
using System.Windows.Forms;

namespace app_CleanServ
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        public MainForm()
        {
            InitializeComponent();
            LoadForms(new InicioForm());
        }


        public void LoadForms(object form)
        {
            //Limpiar panel
            this.splitContainer.Panel2.Controls.Clear();
            //Transformo el objeto como form
            Form f = form as Form;

            //Ordenar la jerarquía y orden de los formlarios

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            //Cargamos el formulario en el panel

            this.splitContainer.Panel2.Controls.Add(f);
            this.splitContainer.Panel2.Tag = f;
            f.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMain_Click_1(object sender, System.EventArgs e)
        {
            LoadForms(new InicioForm());
        }

        private void btnServicios_Click_1(object sender, System.EventArgs e)
        {
            LoadForms(new ServiciosForm());
        }

        private void btnClientes_Click_1(object sender, System.EventArgs e)
        {
            LoadForms(new ClientesForms());
        }

        private void btnProductos_Click_1(object sender, System.EventArgs e)
        {
            LoadForms(new ProductosForm());
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            // Mostrar un mensaje de confirmación antes de cerrar sesión
            DialogResult result = MetroMessageBox.Show(this, "¿Está seguro de que desea cerrar sesión?", "Confirmar cierre de sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close(); // Cerrar el MainForm
            }
        }


        private void btnUsuarios_Click(object sender, System.EventArgs e)
        {
            LoadForms(new UsuarioForm());
        }
    }
}
