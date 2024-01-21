using Dapper;
using static Dapper.SqlMapper;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        Task<int> Add(string storeProcedure, DynamicParameters parameters);
        Task<int> Delete(string storeProcedure, DynamicParameters parameters);
        Task<int> Update(string storeProcedure, DynamicParameters parameters);
        Task<List<TEntity>> GetAllAsync(string storeProcedure, DynamicParameters parameters);
        Task<TEntity> GetByIdAsync(string storeProcedure, DynamicParameters parameters);
    }
}
