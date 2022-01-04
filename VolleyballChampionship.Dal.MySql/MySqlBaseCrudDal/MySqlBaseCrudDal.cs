using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Dal.MySql.MySqlBaseCrudDal
{
    public abstract class MySqlBaseCrudDal<TInfo> : IBaseCrudDal<TInfo> where TInfo : BaseInfo
    {
        public async virtual Task<List<TInfo>> GetAllAsync(IDbConnection connection)
        {
            var list = await connection.GetAllAsync<TInfo>();
            return list.ToList();
        }
        public async virtual Task<TInfo> GetByIdAsync(int id, IDbConnection connection, IDbTransaction transaction = null)
        {
            return await connection.GetAsync<TInfo>(id, transaction);
        }
        public async virtual Task<bool> InsertAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                var id = await connection.InsertAsync(entity, transaction);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public async virtual Task<bool> UpdateAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.UpdateAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async virtual Task<bool> DeleteAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                return await connection.DeleteAsync(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async virtual Task<int> GetSequenceAsync(string tableName, IDbConnection connection, IDbTransaction transaction = null)
        {
            try
            {
                var sql = $"SELECT coalesce(MAX(id), 0) + 1 next_value FROM { tableName }";

                var x = await connection.QueryAsync<int>(sql, null, transaction);

                return x.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
