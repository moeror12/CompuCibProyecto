using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Services
{
    public class ClienteService : IClienteService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarCliente(Cliente c)
        {
            int res;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"Update Cliente set nombre = '{c.nombre}',apellido = '{c.apellido}',direccion = '{c.direccion}',correo = '{c.correo}',contrasenia = '{c.contrasenia}',dni = '{c.dni}' WHERE IdCliente = {c.IdCliente}";
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

        public int EliminarCliente(int cId)
        {
            int res;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Cliente where IdCliente = {cId}";
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

        public List<Cliente> ListarClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select c.IdCliente, c.nombre, c.apellido, c.direccion, c.correo, c.contrasenia, c.dni from Cliente c;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var cliente = new Cliente()
                        {
                            IdCliente = sdr.GetInt32(0),
                            nombre = sdr.GetString(1),
                            apellido = sdr.GetString(2),
                            direccion = sdr.GetString(3),
                            correo = sdr.GetString(4),
                            contrasenia = sdr.GetString(5),
                            dni = sdr.GetInt32(6)
                        };
                        lista.Add(cliente);
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

        public Cliente ObtenerCliente(int clienteId)
        {
            Cliente p = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select c.IdCliente, c.nombre, c.apellido, c.direccion, c.correo, c.contrasenia, c.dni from Cliente c where c.IdCliente ={clienteId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Cliente()
                        {
                            IdCliente = sdr.GetInt32(0),
                            nombre = sdr.GetString(1),
                            apellido = sdr.GetString(2),
                            direccion = sdr.GetString(3),
                            correo = sdr.GetString(4),
                            contrasenia = sdr.GetString(5),
                            dni = sdr.GetInt32(6)
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

        public int RegistrarCliente(Cliente c)
        {
            int res;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"INSERT INTO Cliente(nombre,apellido,direccion,correo,contrasenia,dni) values('{c.nombre}','{c.apellido}','{c.direccion}','{c.correo}','{c.contrasenia}','{c.dni}')";
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
