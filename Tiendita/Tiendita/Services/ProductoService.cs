using System.Data;
using Tiendita.IServices;
using Tiendita.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Tiendita.Services
{
    public class ProductoService : IProductoService
    {
        public List<Producto> ListarProducto()
        {
            List<Producto> lista = new List<Producto>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "Select p.Id, p.Nombre, p.Precio, p.Fechacreacion, p.Foto, c.Id, c.Nombre, p.Stock from Producto p INNER JOIN Categoria c on p.Categoriaid = c.Id";
                
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        var producto = new Producto()
                        {
                            ProductoId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            FechaCreacion = sdr.GetDateTime(3),
                            Foto = sdr.IsDBNull(4) ? "" : sdr.GetString(4),
                            CategoriaId = sdr.GetInt32(5),
                            Categoria = sdr.GetString(6),
                            Stock = sdr.GetInt32(7)
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
        public Producto ObtenerProducto(int productoId)
        {
            Producto p = null;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Select p.Id, p.Nombre, p.Precio, p.Fechacreacion, p.Foto, c.Nombre, p.Stock, p.CategoriaId from Producto p INNER JOIN Categoria c on p.Categoriaid = c.Id Where p.Id={productoId}";

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text,
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        p = new Producto()
                        {
                            ProductoId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            FechaCreacion = sdr.GetDateTime(3),
                            Foto = sdr.IsDBNull(4) ? "" : sdr.GetString(4),
                            Categoria = sdr.GetString(5),
                            Stock = sdr.GetInt32(6),
                            CategoriaId = sdr.GetInt32(7)
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
        public int RegistrarProducto(Producto p)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Insert into Producto (Nombre, Precio, Fechacreacion, Foto, CategoriaId, Stock) values ('{p.Nombre}', {p.Precio}" +
                        $", '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{p.Foto}', {p.CategoriaId}, {p.Stock})";
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
        public int ActualizarProducto(Producto p)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Update Producto set Nombre = '{p.Nombre}', Precio = {p.Precio}, Foto = '{p.Foto}', CategoriaId = {p.CategoriaId}, Stock = {p.Stock} WHERE Id = {p.ProductoId}";
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
        public int EliminarProducto(int pId)
        {
            int res;
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"DELETE FROM Producto where Id = {pId}";
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

        public List<Producto> listProductoxCat(int cat)
        {
            if (cat == 0)
            {
                return ListarProducto();
            }
            List<Producto> cProducto = new List<Producto>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Select p.Id, p.Nombre, p.Precio, p.Fechacreacion, p.Foto, c.Nombre, p.Stock, p.CategoriaId from Producto p INNER JOIN Categoria c on p.Categoriaid = c.Id Where p.CategoriaId={cat}";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        cProducto.Add(new Producto
                        {
                            ProductoId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            FechaCreacion = sdr.GetDateTime(3),
                            Foto = sdr.IsDBNull(4) ? "" : sdr.GetString(4),
                            Categoria = sdr.GetString(5),
                            Stock = sdr.GetInt32(6),
                            CategoriaId = sdr.GetInt32(7)
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
        public List<Producto> listProductoxNom(string nom)
        {
            if (nom == null)
            {
                return ListarProducto();
            }
            List<Producto> cProducto = new List<Producto>();
            string connectionString = "Data Source=DESKTOP-IRS4GG3\\EDDIELOCAL;Initial Catalog=CarritoBD;Integrated Security = True;Encrypt=False;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    string sql = $"Select p.Id, p.Nombre, p.Precio, p.Fechacreacion, p.Foto, c.Nombre, p.Stock, p.CategoriaId from Producto p INNER JOIN Categoria c on p.Categoriaid = c.Id where p.Nombre like '%{nom}%'";
                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        cProducto.Add(new Producto
                        {
                            ProductoId = sdr.GetInt32(0),
                            Nombre = sdr.GetString(1),
                            Precio = sdr.GetDecimal(2),
                            FechaCreacion = sdr.GetDateTime(3),
                            Foto = sdr.IsDBNull(4) ? "" : sdr.GetString(4),
                            Categoria = sdr.GetString(5),
                            Stock = sdr.GetInt32(6),
                            CategoriaId = sdr.GetInt32(7)
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
    }
}
