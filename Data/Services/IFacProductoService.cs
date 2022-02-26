using System.Threading.Tasks;
using Taller1CrudBlazor.Data.Model;

namespace Taller1CrudBlazor.Data.Services
{
    public interface IFacProductoService
    {
        Task<bool> FacProductoInsert(FacProducto producto);
    }
}