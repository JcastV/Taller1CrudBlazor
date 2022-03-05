using System.Collections.Generic;
using System.Threading.Tasks;
using Taller1CrudBlazor.Data.Model;

namespace Taller1CrudBlazor.Data.Services
{
    public interface IFacProductoService
    {
        //Task<IEnumerable<FacProducto>> GetProducto();
        Task<bool> FacProductoInsert(FacProducto producto);
        //Task<bool> FacProductoUpdate(FacProducto producto);
        //Task<bool> FacProductoDelete(int id);
    }
}