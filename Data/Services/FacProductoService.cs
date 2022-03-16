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
    public class FacProductoService : IFacProductoService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public FacProductoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> FacProductoInsert(FacProducto producto)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                //parameters.Add("ID", producto.ID, DbType.Int32);
                parameters.Add("NOMBRE", producto.NOMBRE, DbType.String);
                parameters.Add("PRECIO", producto.PRECIO, DbType.Int32);
                parameters.Add("FOTO", producto.FOTO, DbType.String);
                parameters.Add("DESCRIPCION", producto.DESCRIPCION, DbType.String);
                parameters.Add("STOCK", producto.STOCK, DbType.Int32);

                const string query = @"INSERT INTO FacProducto (NOMBRE,PRECIO,FOTO,
                                        DESCRIPCION,STOCK) 
                                VALUES (@NOMBRE,@PRECIO,@FOTO,@DESCRIPCION,@STOCK)";
                await conn.ExecuteAsync(query, new
                {
                    //producto.ID,
                    producto.NOMBRE,
                    producto.PRECIO,
                    producto.FOTO,
                    producto.DESCRIPCION,
                    producto.STOCK
                }, commandType: CommandType.Text);
            }
            return true;
        }
        public async Task<List<FacProducto>> ListarProductos()
        {
            //METODO DE LISTAR TODOS LOS PRODUCTOS
            List<FacProducto> productos;
                

                using (var conn = new SqlConnection(_configuration.Value))
                {
                    const string query = "SELECT * FROM FacProducto";
                productos = (List<FacProducto>)await conn.QueryAsync<FacProducto>(query, commandType: CommandType.Text);
                }
                return productos;
            
        }
        //Metodo eliminar producto
        public async Task<bool> FacProductoDelete(FacProducto productoDel)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id", productoDel.ID, DbType.String);

                const string query = @"DELETE FROM FacProducto WHERE ID = @id";
                await conn.ExecuteAsync(query, new { productoDel.ID }, commandType: CommandType.Text);
            }
            return true;
        }
    }
}
