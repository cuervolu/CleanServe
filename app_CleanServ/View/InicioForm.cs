using app_CleanServ.Controllers;
using app_CleanServ.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace app_CleanServ.View
{
    public partial class InicioForm : Form
    {
        private readonly InicioController inicioController;

        public InicioForm()
        {
            InitializeComponent();

            // Crear instancia del controlador
            inicioController = new InicioController();
        }

        private void InicioForm_Load(object sender, EventArgs e)
        {
            // Obtener los datos de cantidad de solicitudes de servicios por mes desde el controlador
            List<ChartData> requestData = inicioController.GetTotalRequestsByMonth();

            // Verificar si se obtuvieron los datos correctamente
            if (requestData != null)
            {
                // Limpiar el gráfico antes de asignar nuevos datos
                chartSales.Series.Clear();

                // Crear una nueva serie en el gráfico
                Series series = new Series("Solicitudes de Servicios por Mes");
                series.ChartType = SeriesChartType.Line;

                // Asignar los datos al gráfico
                chartSales.DataSource = requestData;
                chartSales.Series.Add(series);

                // Establecer los nombres de los campos de datos para X y Y
                chartSales.Series[0].XValueMember = "Month";
                chartSales.Series[0].YValueMembers = "TotalRequests";

                // Crear y configurar el ChartArea
                ChartArea chartArea = new ChartArea();
                chartArea.AxisX.Title = "Mes";
                chartArea.AxisY.Title = "Cantidad de Solicitudes";
                chartSales.ChartAreas.Add(chartArea);

                // Agregar la serie al gráfico
                chartSales.DataBind();

                // Configurar los ejes y el título del gráfico
                chartSales.Titles.Add("Cantidad de Solicitudes de Servicios por Mes");
            }
        }
    }
}