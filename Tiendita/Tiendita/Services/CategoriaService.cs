using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Tiendita.Services
{
    public class CategoriaService : ICategoriaService
    {
        public int ActualizarCategoria(Categoria c)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Categoria set Nombre = '{c.Nombre}' WHERE Id = {c.CategoriaId}";
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

        public int EliminarCategoria(int cId)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Categoria where Id = {cId}";
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

        public List<Categoria> ListarCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = "SELECT Id, Nombre FROM Categoria";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            CategoriaId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1)
                        });
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
            return categorias;
        }


        public Categoria ObtenerCategoria(int categoriaId)
        {
            Categoria p = null;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Select p.Id, p.Nombre from Categoria p  Where p.Id={categoriaId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Categoria()
                        {
                            CategoriaId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1),
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

        public int RegistrarCategoria(Categoria c)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Insert into Categoria (Nombre) values ('{c.Nombre}')";
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
    

