using app_CleanServ.Controllers;
using DataAccess.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace app_CleanServ.View
{
    public partial class ModificarServicioForm : MetroFramework.Forms.MetroForm
    {
        private Servicio servicio; // Servicio a modificar

        public readonly ServiciosController serviciosController;

        public ModificarServicioForm(Servicio servicio)
        {
            InitializeComponent();

            this.servicio = servicio;
            serviciosController = new ServiciosController();
        }

        private void ModificarServicioForm_Load_1(object sender, EventArgs e)
        {
            // Cargar los datos del servicio en los controles del formulario
            txtID.Text = servicio.ID_servicio.ToString();
            txtFechaServicio.Value = servicio.fecha_del_servicio;
            txtNumeroHoras.Value = servicio.numero_de_horas;

            // Convertir TimeSpan a DateTime
            DateTime horaDeInicio = DateTime.Today.Add(servicio.hora_de_inicio);
            DateTime horaFin = DateTime.Today.Add(servicio.hora_de_fin ?? TimeSpan.Zero);
            txtHoraDeInicio.Value = horaDeInicio;
            txtHoraFin.Value = horaFin;
            txtComision.Value = (decimal)servicio.comision_empresa;
            txtPagoTrabajador.Value = (decimal)servicio.pago_a_trabajador;
            txtPrecioServicio.Value = (decimal)servicio.precio_de_servicio;

            // Cargar los trabajadores en el ComboBox
            List<Trabajador> trabajadores = serviciosController.getTrabajadores();
            var trabajadoresConNombreCompleto = trabajadores.Select(t => new { ID_trabajador = t.ID_trabajador, NombreCompleto = $"{t.primer_nombre} {t.primer_apellido}" }).ToList();

            cbxTrabajador.DataSource = trabajadoresConNombreCompleto;
            cbxTrabajador.DisplayMember = "NombreCompleto";
            cbxTrabajador.ValueMember = "ID_trabajador";

            // Encontrar el índice del trabajador asignado al servicio en la lista
            int index = trabajadoresConNombreCompleto.FindIndex(t => t.ID_trabajador == servicio.ID_trabajador);

            // Establecer el índice seleccionado del ComboBox si se encontró el trabajador
            if (index >= 0)
            {
                cbxTrabajador.SelectedIndex = index;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Obtener la hora de inicio y fin del formulario
            TimeSpan horaInicio = txtHoraDeInicio.Value.TimeOfDay;
            TimeSpan horaFin = txtHoraFin.Value.TimeOfDay;

            // Validar que la hora de fin sea mayor que la hora de inicio
            if (horaFin < horaInicio)
            {
                MetroMessageBox.Show(this, "La hora de fin no puede ser menor que la hora de inicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin continuar con la actualización del servicio
            }

            // Mostrar un mensaje de confirmación utilizando MetroFramework
            DialogResult result = MetroMessageBox.Show(this, "¿Desea guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Actualizar los atributos del servicio según los controles del formulario
                    servicio.fecha_del_servicio = txtFechaServicio.Value.Date;
                    servicio.numero_de_horas = (int)txtNumeroHoras.Value;
                    servicio.hora_de_inicio = txtHoraDeInicio.Value.TimeOfDay;
                    servicio.hora_de_fin = txtHoraFin.Value.TimeOfDay;
                    servicio.comision_empresa = (double)txtComision.Value;
                    servicio.pago_a_trabajador = (int?)(double)txtPagoTrabajador.Value;
                    servicio.precio_de_servicio = (double)txtPrecioServicio.Value;

                    // Llamar al método updateServicio del controlador para guardar los cambios
                    bool resultado = serviciosController.updateServicio(servicio);

                    if (resultado)
                    {
                        // Mostrar un mensaje de éxito al usuario
                        MetroMessageBox.Show(this, "El servicio se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cerrar el formulario de modificación
                        this.Close();
                    }
                    else
                    {
                        // Mostrar un mensaje de error al usuario
                        MetroMessageBox.Show(this, "No se pudo actualizar el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {// Mostrar un mensaje de error al usuario
                    MetroMessageBox.Show(this, "Error al actualizar el servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}