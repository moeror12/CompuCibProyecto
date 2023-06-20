using System.Net;
using System.Xml.Linq;

namespace Tiendita.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string landmark { get; set; }
        public string district { get; set; }
        public string phoneNumber { get; set; }
        public string paymentMethod { get; set; }
        public int IdOrden { get; set; }
        public DateTime DiaVenta { get; set; }
    }
}
