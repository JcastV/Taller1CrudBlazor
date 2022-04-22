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
        public async Task<List<FavoritosC>> ListarFavoritos(int codigo)
        {
            //METODO DE LISTAR TODOS LOS PRODUCTOS FAVORITOS
            List<FavoritosC> favoritos;


            using (var conn = new SqlConnection(_configuration.Value))
            {
                string query = "SELECT f.idFavorito, c.Nombre as CLIENTE, p.Nombre as PRODUCTO, p.precio, p.stock" +
                    " FROM FavoritosCliente f, facCliente c, FacProducto p WHERE f.idProducto = p.ID AND f.idCliente = c.ID AND c.ID = " + codigo;
                favoritos = (List<FavoritosC>)await conn.QueryAsync<FavoritosC>(query, commandType: CommandType.Text);
            }
            return favoritos;

        }
        //TODO: carpeta para cargar las imagenes name uploadimg, instal fileupload
    }
}
