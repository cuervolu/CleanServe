using app_CleanServ.View;
using System.Windows.Forms;

namespace app_CleanServ
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {

        public MainForm()
        {
            InitializeComponent();

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


        public void LoadForms(object form)
        {
            //Limpiar el panel
            this.panel1.Controls.Clear();

            //Transformar el objeto como Form
            Form f = form as Form;

            //Ordenar la jerarquía de los forms.
            f.TopLevel = false;

            f.Dock = DockStyle.Fill;

            //Cargar el form
            this.panel1.Controls.Add(f);
            this.panel1.Tag = f;
            f.Show();
        }
    }
}
