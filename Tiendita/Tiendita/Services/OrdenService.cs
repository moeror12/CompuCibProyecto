using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using Microsoft.Extensions.Logging;

namespace Tiendita.Services
{
    public class OrdenService : IOrdenService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarOrden(Orden o)
        {
            int res;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Orden set correo = '{o.correo}' WHERE IdOrden = {o.IdOrden}";
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

        public int EliminarOrden(int oId)
        {
            int res;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Orden where IdOrden = {oId}";
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

        public List<Orden> ListarOrden()
        {
            List<Orden> lista = new List<Orden>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select  o.IdOrden, o.correo from Orden o;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var orden = new Orden()
                        {
                            IdOrden = sdr.GetInt32(0),
                            correo = sdr.GetString(1),

                        };
                        lista.Add(orden);
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

        public Orden ObtenerOrden(int ordenId)
        {
            Orden v = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select  o.IdOrden, o.correo from Orden o Where o.IdOrden={ordenId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        v = new Orden()
                        {
                            IdOrden = sdr.GetInt32(0),
                            correo = sdr.GetString(1),
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

        public int RegistrarOrden(Orden o)
        {
            int res;
         

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"INSERT INTO Orden (correo) values ('{o.correo}')";
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
