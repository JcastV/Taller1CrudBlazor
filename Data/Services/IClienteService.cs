using System.Collections.Generic;
using System.Threading.Tasks;
using Taller1CrudBlazor.Data.Model;

namespace Taller1CrudBlazor.Data.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> ListarClientes();
    }
}