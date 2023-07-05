using app_CleanServ.Utils;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace app_CleanServ.Controllers
{
    public class InicioController
    {
        public List<ChartData> GetTotalRequestsByMonth()
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    var requestsByMonth = dbContext.Solicitud
                        .Join(dbContext.Servicio,
                            solicitud => solicitud.ID_solicitud,
                            servicio => servicio.ID_solicitud,
                            (solicitud, servicio) => new { Solicitud = solicitud, Servicio = servicio })
                        .GroupBy(s => s.Solicitud.fecha_y_hora_de_solicitud.Month)
                        .Select(g => new ChartData
                        {
                            Month = g.Key,
                            TotalRequests = g.Count()
                        })
                        .ToList();
                    foreach (var request in requestsByMonth)
                    {
                        Console.WriteLine($"Mes: {request.Month}, Solicitudes: {request.TotalRequests}");
                    }

                    return requestsByMonth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de solicitudes por mes: " + ex.Message);
                return null;
            }
        }

    }
}