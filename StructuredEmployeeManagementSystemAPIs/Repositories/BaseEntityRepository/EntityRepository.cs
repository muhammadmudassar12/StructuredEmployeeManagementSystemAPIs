﻿using Dapper;
using StructuredEmployeeManagementSystemAPIs.Connection;
using System.Data.SqlClient;
using System.Data;

namespace StructuredEmployeeManagementSystemAPIs.Repositories.BaseEntityRepository
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private readonly IConnectionString _connectionString;
        public EntityRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection CreateConnection()
        {
            var connectionString = _connectionString.GetConnectionString();
            return new SqlConnection(connectionString);
        }
        public async Task<int> Add(string storeProcedure, DynamicParameters parameters)
        {
            using var connection = CreateConnection();


            {
                return await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }


        }

        public async Task<int> Delete(string storeProcedure, DynamicParameters parameters)
        {
            using var connection = CreateConnection();

            {
                return await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> Update(string storeProcedure, DynamicParameters parameters)
        {
            using var connection = CreateConnection();


            {
                return await connection.ExecuteAsync(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<TEntity>> GetAllAsync(string storeProcedure, DynamicParameters parameters)
        {
            using var connection = CreateConnection();

            {

                {
                    var result = await connection.QueryAsync<TEntity>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }

            }

        }
        public async Task<TEntity> GetByIdAsync(string storeProcedure, DynamicParameters parameters)
        {
            using var connection = CreateConnection();

            {
                var result = await connection.QueryAsync<TEntity>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
        }
    }
}
