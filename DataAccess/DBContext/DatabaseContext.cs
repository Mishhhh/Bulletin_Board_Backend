using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    public class DatabaseContext:IDatabaseContext
    {
        IConfiguration _config;
        SqlConnection _sqlConnection;

        public DatabaseContext(IConfiguration config)
        {
            _config = config;
            _sqlConnection = new SqlConnection(_config.GetSection("ConnectionStrings")["DefaultConnection"]);
            
        }

        public async Task<IEnumerable<T>> ExecuteCommand<T>(string Query_, object param)
        {
            return await _sqlConnection.QueryAsync<T>(Query_, param);
        }
    }
}
