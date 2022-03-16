using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taller1CrudBlazor.Data.Services
{
    public interface IFavoritosService
    {
        Task<List<FavoritosC>> ListarFavoritos();
    }
}