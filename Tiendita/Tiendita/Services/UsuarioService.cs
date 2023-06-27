using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Tiendita.Services
{
    public class UsuarioService : IUsuarioService
    {
        public int ActualizarUsuario(Usuario u)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Usuario set CodigoUsuario = '{u.CodigoUsuario}',Nombre = '{u.Nombre}',Apellido = '{u.Apellido}',Correo = '{u.Correo}',Direccion = '{u.Direccion}',Telefono = '{u.Telefono}',Password = '{u.Password}',TipoUsuarioId = '{u.TipoUsuarioId}' WHERE UsuarioId = {u.UsuarioId}";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    res = 0;
                }
                finally
                {
                    connection.Close();
                }
            }
            return res;
        }

        public int EliminarUsuario(int uId)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Usuario where UsuarioId = {uId}";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    res = 0;
                }
                finally
                {
                    connection.Close();
                }
            }
            return res;
        }

        public List<Usuario> ListarUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "Select p.UsuarioId, p.CodigoUsuario, p.Nombre,p.Apellido,p.Correo,p.Direccion,p.Telefono, p.Password, p.TipoUsuarioId from Usuario p;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var usuario = new Usuario()
                        {
                            UsuarioId = sdr.GetInt32(0),
                            CodigoUsuario = sdr.GetString(1),
                            Nombre = sdr.GetString(2),
                            Apellido = sdr.GetString(3),
                            Correo = sdr.GetString(4),
                            Direccion = sdr.GetString(5),
                            Telefono = sdr.GetString(6),
                            Password = sdr.GetString(7),
                            TipoUsuarioId = sdr.GetInt32(8),
                        };
                        lista.Add(usuario);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return lista;
        }

        public Usuario ObtenerUsuario(int usuarioId)
        {
            Usuario p = null;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Select p.UsuarioId, p.CodigoUsuario, p.Nombre,p.Apellido,p.Correo,p.Direccion,p.Telefono, p.Password, p.TipoUsuarioId from Usuario p Where p.UsuarioId={usuarioId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Usuario()
                        {
                            UsuarioId = sdr.GetInt32(0),
                            CodigoUsuario = sdr.GetString(1),
                            Nombre = sdr.GetString(2),
                            Apellido = sdr.GetString(3),
                            Correo = sdr.GetString(4),
                            Direccion = sdr.GetString(5),
                            Telefono = sdr.GetString(6),
                            Password = sdr.GetString(7),
                            TipoUsuarioId = sdr.GetInt32(8),
                        };
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    connection.Close();
                }
            }
            return p;
        }
        public int RegistrarUsuario(Usuario u)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Insert into Usuario (CodigoUsuario, Nombre,Apellido,Correo,Direccion,Telefono, Password, TipoUsuarioId) values ('{u.CodigoUsuario}','{u.Nombre}','{u.Apellido}','{u.Correo}','{u.Direccion}','{u.Telefono}','{u.Password}', '{u.TipoUsuarioId}')";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    res = 0;
                }
                finally
                {
                    connection.Close();
                }
            }
            return res;
        }
    }
}
