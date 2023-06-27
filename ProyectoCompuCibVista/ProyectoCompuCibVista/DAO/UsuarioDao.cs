using ProyectoCompuCibVista.Database;
using ProyectoCompuCibVista.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoCompuCibVista.DAO
{
    public class UsuarioDao
    {
        //private readonly SqlConnection conexion;
        //public UsuarioDao()
        //{
        //    conexion = Conexion.OnConfiguring();
        //}
        //public Usuario Login(Usuario u)
        //{
        //    Usuario user = null;
        //    try
        //    {
        //        string sql = $"Select * from Usuario where CodigoUsuario = '{u.CodigoUsuario}' and Password = '{u.Password}'";
        //        SqlCommand cmd = new SqlCommand(sql, conexion)
        //        {
        //            CommandType = CommandType.Text,
        //        };
        //        conexion.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            user = new Usuario()
        //            {
        //                UsuarioId = sdr.GetInt32(0),
        //                CodigoUsuario = sdr.GetString(1),
        //                Nombre = sdr.GetString(2),
        //                Apellido = sdr.GetString(3),
        //                Correo = sdr.GetString(4),
        //                Direccion = sdr.GetString(5),
        //                Telefono = sdr.GetString(6),
        //                Password = sdr.GetString(7),
        //                TipoUsuarioId = sdr.GetInt32(8),
        //            };
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //    return user;
        //}
        //public List<Usuario> ListarUsuario()
        //{
        //    List<Usuario> lista = new List<Usuario>();
        //    try
        //    {
        //        string sql = "Select p.UsuarioId, p.CodigoUsuario, p.Nombre,p.Apellido,p.Correo,p.Direccion,p.Telefono, p.Password, p.TipoUsuarioId from Usuario p;";

        //        SqlCommand cmd = new SqlCommand(sql, conexion)
        //        {
        //            CommandType = CommandType.Text,
        //        };
        //        conexion.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            var usuario = new Usuario()
        //            {
        //                UsuarioId = sdr.GetInt32(0),
        //                CodigoUsuario = sdr.GetString(1),
        //                Nombre = sdr.GetString(2),
        //                Apellido = sdr.GetString(3),
        //                Correo = sdr.GetString(4),
        //                Direccion = sdr.GetString(5),
        //                Telefono = sdr.GetString(6),
        //                Password = sdr.GetString(7),
        //                TipoUsuarioId = sdr.GetInt32(8),
        //            };
        //            lista.Add(usuario);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //    return lista;
        //}
        //public Usuario ObtenerUsuario(int usuarioId)
        //{
        //    Usuario p = null;
        //    try
        //    {
        //        string sql = $"Select p.UsuarioId, p.CodigoUsuario, p.Nombre,p.Apellido,p.Correo,p.Direccion,p.Telefono, p.Password, p.TipoUsuarioId from Usuario p Where p.UsuarioId={usuarioId}";

        //        SqlCommand cmd = new SqlCommand(sql, conexion)
        //        {
        //            CommandType = CommandType.Text,
        //        };
        //        conexion.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            p = new Usuario()
        //            {
        //                UsuarioId = sdr.GetInt32(0),
        //                CodigoUsuario = sdr.GetString(1),
        //                Nombre = sdr.GetString(2),
        //                Apellido = sdr.GetString(3),
        //                Correo = sdr.GetString(4),
        //                Direccion = sdr.GetString(5),
        //                Telefono = sdr.GetString(6),
        //                Password = sdr.GetString(7),
        //                TipoUsuarioId = sdr.GetInt32(8),

        //            };
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //    return p;
        //}

    }
}
