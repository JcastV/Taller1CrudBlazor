using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Taller1CrudBlazor.Data.Model;

namespace Taller1CrudBlazor.Data.Services
{
    public class ClienteService : IClienteService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Cliente>> ListarClientes()
        {
            //METODO DE LISTAR TODOS LOS CLIENTES
            List<Cliente> clientes;


            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = "SELECT * FROM FacCliente";
                clientes = (List<Cliente>)await conn.QueryAsync<Cliente>(query, commandType: CommandType.Text);
            }
            return clientes;

        }
    }
}
