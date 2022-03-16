using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1CrudBlazor.Data.Model
{
    public class FacProducto
    {
        public int ID { get; set; }
        public string NOMBRE  { get; set; }
        public int PRECIO { get; set; }
        public string FOTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int STOCK { get; set; }

    }
}
