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

        public Servicio getServicio(int ID_servicio)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el servicio por su ID
                    var servicio = dbContext.Servicio.FirstOrDefault(s => s.ID_servicio == ID_servicio);

                    return servicio;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el servicio: " + ex.Message);
                return null;
            }
        }

        public bool updateServicio(Servicio servicio)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    Servicio oldServicio = dbContext.Servicio.FirstOrDefault(s => s.ID_solicitud == servicio.ID_solicitud);

                    if (oldServicio != null)
                    {
                        oldServicio.fecha_del_servicio = servicio.fecha_del_servicio;
                        oldServicio.hora_de_inicio = servicio.hora_de_inicio;
                        oldServicio.hora_de_fin = servicio.hora_de_fin;
                        oldServicio.comision_empresa = servicio.comision_empresa;
                        oldServicio.pago_a_trabajador = servicio.pago_a_trabajador;
                        oldServicio.precio_de_servicio = servicio.precio_de_servicio;
                        oldServicio.ID_trabajador = servicio.ID_trabajador;

                        int rowsAffected = dbContext.SaveChanges();
                        return rowsAffected > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el servicio: " + ex.Message);
            }
        }


        public void removeServicio(int ID_servicio)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el servicio por su ID
                    var servicio = dbContext.Servicio.FirstOrDefault(s => s.ID_servicio == ID_servicio);

                    if (servicio != null)
                    {
                        // Eliminar las entidades relacionadas una por una
                        foreach (var calificacion in servicio.Calificacion_de_servicio.ToList())
                        {
                            dbContext.Calificacion_de_servicio.Remove(calificacion);
                        }

                        foreach (var producto in servicio.Producto_por_servicio.ToList())
                        {
                            dbContext.Producto_por_servicio.Remove(producto);
                        }

                        // Eliminar el servicio
                        dbContext.Servicio.Remove(servicio);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el servicio: " + ex.Message);
            }
        }

        public List<Trabajador> getTrabajadores()
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    List<Trabajador> trabajadores = dbContext.Trabajador.ToList();

                    return trabajadores;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar trabajadores: " + ex.Message);
                return null;
            }
        }


    }
}
