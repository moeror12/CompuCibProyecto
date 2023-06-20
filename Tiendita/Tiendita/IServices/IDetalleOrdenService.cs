using Microsoft.AspNetCore.Mvc;
using Tiendita.Models;

namespace Tiendita.IServices
{
    public interface IDetalleOrdenService
    {
        public List<DetalleOrden> ListarDetalleOrden();
        public DetalleOrden ObtenerDetalleOrden(int detalleOrdenId);
        public int RegistrarDetalleOrden(List<DetalleOrden> d);
        public int ActualizarDetalleOrden(DetalleOrden d);
        public int EliminarDetalleOrden(int dId);
    }
}
