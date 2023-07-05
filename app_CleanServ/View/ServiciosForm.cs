using app_CleanServ.Controllers;
using DataAccess.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class ServiciosForm : Form
    {
        private readonly ServiciosController serviciosController;

        public ServiciosForm()
        {
            InitializeComponent();

            serviciosController = new ServiciosController();
        }

        private void MostrarCarga()
        {
            if (metroProgressSpinner1.InvokeRequired)
            {
                metroProgressSpinner1.Invoke(new MethodInvoker(() =>
                {
                    metroProgressSpinner1.Visible = true;
                    metroProgressSpinner1.Spinning = true;
                }));
            }
            else
            {
                metroProgressSpinner1.Visible = true;
                metroProgressSpinner1.Spinning = true;
            }
        }

        private void OcultarCarga()
        {
            if (metroProgressSpinner1.InvokeRequired)
            {
                metroProgressSpinner1.Invoke(new MethodInvoker(() =>
                {
                    metroProgressSpinner1.Visible = false;
                    metroProgressSpinner1.Spinning = false;
                }));
            }
            else
            {
                metroProgressSpinner1.Visible = false;
                metroProgressSpinner1.Spinning = false;
            }
        }

        private void ServiciosForm_Load(object sender, EventArgs e)
        {
            MostrarCarga(); // Mostrar icono de carga
            dgvServicios.Visible = false;

            CargarServicios();

            OcultarCarga(); // Ocultar icono de carga
        }

        private void CargarServicios()
        {
            List<Servicio> servicios = serviciosController.getServicios();

            if (servicios != null)
            {
                dgvServicios.Columns.Clear(); // Limpiar las columnas existentes
                dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Agregar las columnas al DataGridView
                dgvServicios.Columns.Add("ID_servicio", "ID Servicio");
                dgvServicios.Columns.Add("fecha_del_servicio", "Fecha del Servicio");
                dgvServicios.Columns.Add("numero_de_horas", "Número de Horas");
                dgvServicios.Columns.Add("hora_de_inicio", "Hora de Inicio");
                dgvServicios.Columns.Add("hora_de_fin", "Hora de Fin");
                dgvServicios.Columns.Add("comision_empresa", "Comisión de la Empresa");
                dgvServicios.Columns.Add("pago_a_trabajador", "Pago al Trabajador");
                dgvServicios.Columns.Add("precio_de_servicio", "Precio del Servicio");
                dgvServicios.Columns.Add("direccion1", "Dirección");
                dgvServicios.Columns.Add("referencias", "Referencias");
                dgvServicios.Columns.Add("nombre_completo", "Nombre del Trabajador");

                // Agregar columna de botón para eliminar
                DataGridViewButtonColumn eliminarButtonColumn = new DataGridViewButtonColumn();
                eliminarButtonColumn.Name = "Eliminar";
                eliminarButtonColumn.Text = "Eliminar";
                eliminarButtonColumn.UseColumnTextForButtonValue = true;
                dgvServicios.Columns.Add(eliminarButtonColumn);

                // Agregar columna de botón para modificar
                DataGridViewButtonColumn modificarButtonColumn = new DataGridViewButtonColumn();
                modificarButtonColumn.Name = "Modificar";
                modificarButtonColumn.Text = "Modificar";
                modificarButtonColumn.UseColumnTextForButtonValue = true;
                dgvServicios.Columns.Add(modificarButtonColumn);
                dgvServicios.CellContentClick += dgvServicios_CellContentClick;
                dgvServicios.Visible = true;

                // Agregar las filas con los valores de los servicios
                foreach (var servicio in servicios)
                {
                    string nombreCompleto = servicio.Trabajador.primer_nombre + " " + servicio.Trabajador.primer_apellido;

                    dgvServicios.Rows.Add(
                        servicio.ID_servicio,
                        servicio.fecha_del_servicio,
                        servicio.numero_de_horas,
                        servicio.hora_de_inicio,
                        servicio.hora_de_fin,
                        servicio.comision_empresa,
                        servicio.pago_a_trabajador,
                        servicio.precio_de_servicio,
                        servicio.Direccion.direccion1,
                        servicio.Direccion.referencias,
                        nombreCompleto
                    );
                }

                // Mostrar el DataGridView
                dgvServicios.ReadOnly = true;
                dgvServicios.Visible = true;
            }
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón de eliminar
            if (e.ColumnIndex == dgvServicios.Columns["Eliminar"].Index && e.RowIndex >= 0)
            {
                // Mostrar mensaje de confirmación
                DialogResult result = MetroMessageBox.Show(this, "¿Estás seguro de eliminar este servicio?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del servicio de la fila seleccionada
                    int ID_servicio = Convert.ToInt32(dgvServicios.Rows[e.RowIndex].Cells["ID_servicio"].Value);

                    // Llamar al método removeServicio del controlador para eliminar el servicio
                    serviciosController.removeServicio(ID_servicio);

                    // Volver a cargar los servicios en el DataGridView
                    CargarServicios();
                }
            }
            // Verificar si se hizo clic en el botón de modificar
            else if (e.ColumnIndex == dgvServicios.Columns["Modificar"].Index && e.RowIndex >= 0)
            {
                // Obtener el ID del servicio de la fila seleccionada
                int ID_servicio = Convert.ToInt32(dgvServicios.Rows[e.RowIndex].Cells["ID_servicio"].Value);

                // Obtener el servicio correspondiente al ID_servicio
                Servicio servicio = serviciosController.getServicio(ID_servicio);

                // Verificar si el servicio existe
                if (servicio != null)
                {
                    // Crear un formulario de modificación
                    ModificarServicioForm modificarForm = new ModificarServicioForm(servicio);

                    // Mostrar el formulario de modificación
                    modificarForm.ShowDialog();

                    // Volver a cargar los servicios en el DataGridView
                    CargarServicios();
                }
            }
        }


    }
}