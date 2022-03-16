using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taller1CrudBlazor.Data.Services
{
    public class FavoritosC
    {
        public int idFavorito { get; set; }
        public string CLIENTE { get; set; }
        public string PRODUCTO { get; set; }
        public int PRECIO { get; set; }
        public int STOCK { get; set; }
    }
}
