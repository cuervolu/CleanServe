using DataAccess.Models;
using PasswordEncryptor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app_CleanServ.Controllers
{
    public class UsuariosController
    {
        private readonly Encryption encryption;

        public UsuariosController()
        {
            encryption = new Encryption();
        }

        public string encrypt(string password)
        {
            string encryptedPassword = encryption.HashMD5(password);

            return encryptedPassword;
        }

        public bool confirmPassword(string password, string oldPassword)
        {
            try
            {
                bool confirm = encryption.VerifyPassword(password, oldPassword);
                return confirm;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo verificar la contraseña: {ex.Message}");
            }
        }

        public bool createUser(string user, string password)
        {
            try
            {
                // Encriptar la contraseña utilizando la función encrypt del controlador
                string encryptedPassword = encrypt(password);
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Crear una instancia del modelo de usuario y asignar los valores
                    Usuario nuevoUsuario = new Usuario()
                    {
                        username = user,
                        pass = encryptedPassword,
                        activo = true
                    };

                    // Agregar el nuevo usuario al contexto de la base de datos
                    dbContext.Usuario.Add(nuevoUsuario);

                    // Guardar los cambios en la base de datos
                    int rowsAffected = dbContext.SaveChanges();

                    // Devolver true si el usuario se creó correctamente
                    return rowsAffected > 0;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario: " + ex.Message);
            }
        }

        public bool login(string username, string password)
        {
            try
            {
                // Encriptar la contraseña introducida por el usuario
                string encryptedPassword = encrypt(password);

                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el usuario en la base de datos que coincida con el nombre de usuario y la contraseña encriptada
                    Usuario usuario = dbContext.Usuario.FirstOrDefault(u => u.username == username && u.pass == encryptedPassword);

                    // Devolver true si se encontró el usuario, lo que significa que las credenciales son válidas
                    return usuario != null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el inicio de sesión: " + ex.Message);
            }
        }


        public List<Usuario> getUsuarios()
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    List<Usuario> usuarios = dbContext.Usuario.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar usuarios: " + ex.Message);
            }
        }

        public Usuario getUsuario(int id_usuario)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el usuario por su ID
                    var usuario = dbContext.Usuario.FirstOrDefault(u => u.id == id_usuario);

                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario: " + ex.Message);
            }
        }

        public bool UpdateActivo(int id, bool activo)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    Usuario usuario = getUsuario(id);
                    usuario.activo = activo;
                    dbContext.SaveChanges();
                    Console.WriteLine("Modificado");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se pudo actualizar el estado del usuario: {ex.Message}");
            }
        }

        public bool updateUsuario(Usuario usuario)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    Usuario oldUsuario = dbContext.Usuario.FirstOrDefault(u => u.id == usuario.id);

                    if (oldUsuario != null)
                    {
                        string encryptedPassword = encrypt(usuario.pass);
                        oldUsuario.username = usuario.username;
                        oldUsuario.pass = encryptedPassword;
                        oldUsuario.activo = usuario.activo;

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

        public void removeUsuario(int id)
        {
            try
            {
                using (var dbContext = new SERVICIO_LIMPIEZAEntities())
                {
                    // Buscar el servicio por su ID
                    Usuario usuario = dbContext.Usuario.FirstOrDefault(u => u.id == id);

                    if (usuario != null)
                    {

                        // Eliminar el usuario
                        dbContext.Usuario.Remove(usuario);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el servicio: " + ex.Message);
            }
        }
    }
}
