using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Medialink.Dal.Abstractions;
using Medialink.Dal.Models;

namespace Medialink.Dal.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DapperConnection"].ConnectionString;
        public void Create(Operation operation)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Operations (Name, A, B, Result, Date) VALUES(@Name, @A, @B, @Result, @Date); SELECT CAST(SCOPE_IDENTITY() as int)";
                var operationId = db.Query<int>(sqlQuery, operation).First();
                operation.Id = operationId;
            }
        }
    }
}