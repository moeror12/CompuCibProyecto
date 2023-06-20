using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Services
{
    public class VentaService : IVentaService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarVenta(Venta v)
        {
            int res;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Venta set Id = '{v.VentaId}',name = '{v.name}',lastName = '{v.lastName}',address = '{v.address}',landmark = '{v.landmark}',district = '{v.district}',phoneNumber = '{v.phoneNumber}',paymentMethod = '{v.paymentMethod}',IdOrden = '{v.IdOrden}','DiaVenta = '{v.DiaVenta}' WHERE Id = {v.VentaId}";
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

        public int EliminarVenta(int vId)
        {
            int res;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Venta where Id = {vId}";
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

        public List<Venta> ListarVenta()
        {
            List<Venta> lista = new List<Venta>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select v.Id,v.name, v.lastName,v.address,v.landmark,v.district,v.phoneNumber,v.paymentMethod,v.IdOrden,v.DiaVenta from venta v;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var venta = new Venta()
                        {
                            VentaId = sdr.GetInt32(0),
                            name = sdr.GetString(1),
                            lastName = sdr.GetString(2),
                            address = sdr.GetString(3),
                            landmark = sdr.GetString(4),
                            district = sdr.GetString(5),
                            phoneNumber = sdr.GetString(6),
                            paymentMethod = sdr.GetString(7),
                            IdOrden = sdr.GetInt32(8),
                            DiaVenta = sdr.GetDateTime(9),
                        };
                        lista.Add(venta);
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

        public Venta ObtenerVenta(int ventaId)
        {
            Venta v = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select v.id,v.name, v.lastName,v.address,v.landmark,v.district,v.phoneNumber,v.paymentMethod,v.IdOrden,v.DiaVenta from venta v Where v.Id={ventaId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        v = new Venta()
                        {
                            VentaId = sdr.GetInt32(0),
                            name = sdr.GetString(1),
                            lastName = sdr.GetString(2),
                            address = sdr.GetString(3),
                            landmark = sdr.GetString(4),
                            district = sdr.GetString(5),
                            phoneNumber = sdr.GetString(6),
                            paymentMethod = sdr.GetString(7),
                            IdOrden = sdr.GetInt32(8),
                            DiaVenta = sdr.GetDateTime(9),
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

        public int RegistrarVenta(Venta u)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"INSERT INTO Venta (name, lastName, address, landmark, district, phoneNumber, paymentMethod, IdOrden, DiaVenta) values ('{u.name}','{u.lastName}','{u.address}','{u.landmark}','{u.district}','{u.phoneNumber}','{u.paymentMethod}', '{u.IdOrden}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
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
