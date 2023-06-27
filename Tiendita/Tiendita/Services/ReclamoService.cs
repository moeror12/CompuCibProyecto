using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using System.Security.Cryptography;

namespace Tiendita.Services
{
    public class ReclamoService : IReclamoService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarReclamo(Reclamo r)
        {
            int res;
   

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Reclamo set descripcion = '{r.descripcion}', DiaReclamo = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', Id = {r.IdVenta} where IdReclamo = {r.IdReclamo}";
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

        public int EliminarReclamo(int rId)
        {
            int res;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Reclamo where IdReclamo = {rId}";
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

        public List<Reclamo> ListarRelcamos()
        {
            List<Reclamo> lista = new List<Reclamo>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select r.IdReclamo, r.descripcion, r.DiaReclamo, r.Id from reclamo r";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var producto = new Reclamo()
                        {
                            IdReclamo = sdr.GetInt32(0),
                            descripcion = sdr.GetString(1),
                            DiaReclamo = sdr.GetDateTime(2),
                            IdVenta = sdr.GetInt32(3),
                        };
                        lista.Add(producto);
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

        public List<Reclamo> listReclamosxCorreo(string correo)
        {
            if (correo == null)
            {
                return ListarRelcamos();
            }
            List<Reclamo> cProducto = new List<Reclamo>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select r.IdReclamo, r.descripcion,r.DiaReclamo, r.Id  from Reclamo r inner join Venta v on r.Id= v.id inner join Orden o on v.IdOrden=o.IdOrden where o.correo like '%{correo}%'";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        cProducto.Add(new Reclamo
                        {
                            IdReclamo = sdr.GetInt32(0),
                            descripcion = sdr.GetString(1),
                            DiaReclamo = sdr.GetDateTime(2),
                            IdVenta = sdr.GetInt32(3),
                        });
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
            return cProducto;
        }

        public ReclamoN numeroReclamos()
        {
            ReclamoN p = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"SELECT COUNT(r.IdReclamo )as numerosReclamos FROM reclamo r";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new ReclamoN ()
                        {
                            numerosReclamos = sdr.GetInt32(0)
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

        public Reclamo ObtenerReclamo(int rId)
        {
            Reclamo p = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select r.IdReclamo, r.descripcion, r.DiaReclamo, r.Id from reclamo r where r.IdReclamo = {rId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Reclamo()
                        {
                            IdReclamo = sdr.GetInt32(0),
                            descripcion = sdr.GetString(1),
                            DiaReclamo = sdr.GetDateTime(2),
                            IdVenta = sdr.GetInt32(3),
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

        public int RegistrarReclamo(Reclamo r)
        {
            int res;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"INSERT INTO Reclamo (descripcion, DiaReclamo, Id) VALUES  ('{r.descripcion}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {r.IdVenta})";
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
