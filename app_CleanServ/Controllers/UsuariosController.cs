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
    }
}
