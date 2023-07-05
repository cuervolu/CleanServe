using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace app_CleanServ.Controllers
{
    public class ServiciosController
    {
        public List<Servicio> getServicios()
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    var serviciosData = dbContext.Servicio
                        .Include("Direccion")
                        .Include("Trabajador")
                        .ToList();

                    var servicios = serviciosData.Select(s => new Servicio
                    {
                        ID_servicio = s.ID_servicio,
                        fecha_del_servicio = s.fecha_del_servicio,
                        numero_de_horas = s.numero_de_horas,
                        hora_de_inicio = s.hora_de_inicio,
                        hora_de_fin = s.hora_de_fin,
                        comision_empresa = s.comision_empresa,
                        pago_a_trabajador = s.pago_a_trabajador,
                        precio_de_servicio = s.precio_de_servicio,
                        Direccion = new Direccion
                        {
                            direccion1 = s.Direccion.direccion1,
                            referencias = s.Direccion.referencias
                        },
                        Producto_por_servicio = s.Producto_por_servicio.Select(p => new Producto_por_servicio
                        {
                            cantidad = p.cantidad
                        }).ToList(),
                        Trabajador = new Trabajador
                        {
                            primer_nombre = s.Trabajador.primer_nombre,
                            primer_apellido = s.Trabajador.primer_apellido
                        }
                    }).ToList();

                    return servicios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos de servicios: " + ex.Message);
                return null;
            }
        }
    }
}
