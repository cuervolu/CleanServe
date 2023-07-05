using app_CleanServ.View;
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
            this.containerPanel.Controls.Clear();
            //Transformo el objeto como form
            Form f = form as Form;

            //Ordenar la jerarquía y orden de los formlarios

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;

            //Cargamos el formulario en el panel

            this.containerPanel.Controls.Add(f);
            this.containerPanel.Tag = f;
            f.Show();
        }

        private void btnMain_Click(object sender, System.EventArgs e)
        {
            LoadForms(new InicioForm());
        }

        private void btnServicios_Click(object sender, System.EventArgs e)
        {
            LoadForms(new ServiciosForm());
        }

        private void btnClientes_Click(object sender, System.EventArgs e)
        {
            LoadForms(new ClientesForms());
        }

        private void btnProductos_Click(object sender, System.EventArgs e)
        {
            LoadForms(new ProductosForm());
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            LoadForms(new LogoutForm());
        }


    }
}
