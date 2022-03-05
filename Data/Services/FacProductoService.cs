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
                parameters.Add("ID_MARCA", producto.ID_MARCA, DbType.String);
                parameters.Add("COLOR", producto.COLOR, DbType.String);
                parameters.Add("PRECIO", producto.PRECIO, DbType.Int32);
                parameters.Add("MEM_RAM", producto.MEM_RAM, DbType.String);
                parameters.Add("ALMACENAMIENTO", producto.ALMACENAMIENTO, DbType.String);
                parameters.Add("FOTO", producto.FOTO, DbType.String);
                parameters.Add("DESCRIPCION", producto.DESCRIPCION, DbType.String);
                parameters.Add("ID_CATEGORIA", producto.ID_CATEGORIA, DbType.Int32);
                parameters.Add("STOCK", producto.STOCK, DbType.Int32);

                const string query = @"INSERT INTO FacProducto (NOMBRE,ID_MARCA,COLOR,PRECIO,MEM_RAM,ALMACENAMIENTO,FOTO,
                                        DESCRIPCION,ID_CATEGORIA,STOCK) 
                                VALUES (@NOMBRE,@ID_MARCA,@COLOR,@PRECIO,@MEM_RAM,@ALMACENAMIENTO,@FOTO,@DESCRIPCION,@ID_CATEGORIA,@STOCK)";
                await conn.ExecuteAsync(query, new
                {
                    //producto.ID,
                    producto.NOMBRE,
                    producto.ID_MARCA,
                    producto.COLOR,
                    producto.PRECIO,
                    producto.MEM_RAM,
                    producto.ALMACENAMIENTO,
                    producto.FOTO,
                    producto.DESCRIPCION,
                    producto.ID_CATEGORIA,
                    producto.STOCK
                }, commandType: CommandType.Text);
            }
            return true;
        }
    }
}
