using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCompuCibVista.Database
{
    public class Conexion
    {
        private readonly IConfiguration _configuration;

        public Conexion(IConfiguration config) { 
            this._configuration = config;
        }
        public  SqlConnection OnConfiguring()
        {
            //var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BDCONEXION"].ConnectionString;
            //return new SqlConnection(connectionString);
            var connectionString = _configuration.GetConnectionString("MyConnectionString");
            return new SqlConnection(connectionString);
        }

    }

}
