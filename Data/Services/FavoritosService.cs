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
    public class FavoritosService : IFavoritosService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public FavoritosService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<FavoritosC>> ListarFavoritos()
        {
            //METODO DE LISTAR TODOS LOS PRODUCTOS FAVORITOS
            List<FavoritosC> favoritos;


            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();

                const string query = "select F.idFavorito,c.NOMBRE AS CLIENTE,p.NOMBRE AS PRODUCTO,p.PRECIO,p.STOCK " +
                    "from FacProducto p " +
                    "inner join FavoritosCliente f on f.idProducto = p.ID " +
                    "inner join FacCliente c on c.ID = f.idCliente ";
                favoritos = (List<FavoritosC>)await conn.QueryAsync<FavoritosC>(query, commandType: CommandType.Text);
            }
            return favoritos;

        }
    }
}
