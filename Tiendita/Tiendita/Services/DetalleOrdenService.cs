using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using System.Security.Cryptography;

namespace Tiendita.Services
{
    public class DetalleOrdenService : IDetalleOrdenService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarDetalleOrden(DetalleOrden d)
        {
            int res;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update DetalleOrden set nomProducto  = '{d.nomProducto}',Precio  = '{d.Precio}', Cantidad = '{d.Cantidad}',IdOrden  = '{d.IdOrden}' WHERE IdDetalleOrden = {d.IdDetalleOrden}";
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

        public int EliminarDetalleOrden(int dId)
        {
            int res;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM DetalleOrden where IdDetalleOrden = {dId}";
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

        public List<DetalleOrden> ListarDetalleOrden()
        {
            List<DetalleOrden> lista = new List<DetalleOrden>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select  d.IdDetalleOrden, d.nomProducto, d.Precio, d.Cantidad, d.IdOrden from DetalleOrden d;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var detalleOrden = new DetalleOrden()
                        {
                            IdDetalleOrden = sdr.GetInt32(0),
                            nomProducto = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            Cantidad = sdr.GetInt32(3),
                            IdOrden = sdr.GetInt32(4)

                        };
                        lista.Add(detalleOrden);
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

        public DetalleOrden ObtenerDetalleOrden(int detalleOrdenId)
        {
            DetalleOrden v = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select  d.IdDetalleOrden, d.nomProducto, d.Precio, d.Cantidad, d.IdOrden from DetalleOrden d Where d.IdDetalleOrden={detalleOrdenId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        v = new DetalleOrden()
                        {
                            IdDetalleOrden = sdr.GetInt32(0),
                            nomProducto = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            Cantidad = sdr.GetInt32(3),
                            IdOrden = sdr.GetInt32(4)
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
            return v;
        }

        public int RegistrarDetalleOrden(List<DetalleOrden> d)
        {
            int res;

            foreach (DetalleOrden det in d.ToList())
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    try
                    {
                        string sql = $"INSERT INTO DetalleOrden (nomProducto, Precio, Cantidad,IdOrden) values ('{det.nomProducto}','{det.Precio}','{det.Cantidad}','{det.IdOrden}')";
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
                    d.Add(det);
                }

            }
            return d.Count;
        }
    }
}
