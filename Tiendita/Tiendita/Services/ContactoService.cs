using System.Data.SqlClient;
using System.Data;
using Tiendita.IServices;
using Tiendita.Models;

namespace Tiendita.Services
{
    public class ContactoService : IContactoService
    {
        string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
        public int ActualizarContacto(Contacto c)
        {
            int res;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"Update Contacto set nombreapellido = '{c.nombreapellido}',correo = '{c.correo}',asunto = '{c.asunto}',mensaje = '{c.mensaje}' WHERE IdContacta = {c.IdContacta}";
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

        public int EliminarContacto(int cId)
        {
            int res;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Contacto where IdContacta = {cId}";
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

        public List<Contacto> ListarContacto()
        {
            List<Contacto> lista = new List<Contacto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "select c.IdContacta, c.nombreapellido, c.correo,c.asunto,c.mensaje from Contacto c;";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var contacto = new Contacto()
                        {
                            IdContacta = sdr.GetInt32(0),
                            nombreapellido = sdr.GetString(1),
                            correo = sdr.GetString(2),
                            asunto = sdr.GetString(3),
                            mensaje = sdr.GetString(4),
                        };
                        lista.Add(contacto);
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

        public Contacto ObtenerContacto(int contactoId)
        {
            Contacto p = null;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"select c.IdContacta,c.nombreapellido,c.correo,c.asunto,c.mensaje from Contacto c where c.IdContacta={contactoId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Contacto()
                        {
                            IdContacta = sdr.GetInt32(0),
                            nombreapellido = sdr.GetString(1),
                            correo = sdr.GetString(2),
                            asunto = sdr.GetString(3),
                            mensaje = sdr.GetString(4),
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

        public int RegistrarContacto(Contacto c)
        {
            int res;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"INSERT INTO Contacto(nombreapellido,correo,asunto,mensaje)values('{c.nombreapellido}','{c.correo}','{c.asunto}','{c.mensaje}')";
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
