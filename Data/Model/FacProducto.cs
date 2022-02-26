using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1CrudBlazor.Data.Model
{
    public class FacProducto
    {
        public int ID { get; set; }
        public int NOMBRE  { get; set; }
        public int ID_MARCA { get; set; }
        public int COLOR { get; set; }
        public int PRECIO { get; set; }
        public int MEM_RAM { get; set; }
        public int ALMACENAMIENTO { get; set; }
        public int FOTO { get; set; }
        public int DESCRIPCION { get; set; }
        public int ID_CATEGORIA { get; set; }
        public int STOK { get; set; }

    }
}
