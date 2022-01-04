using Dapper.Contrib.Extensions;
using Npgsql.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud
{
    public class PostgreSqlBaseCrudDal<TInfo> : IBaseCrudDal<TInfo> where TInfo : BaseInfo
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
                await connection.InsertAsync(entity, transaction);
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
    }
}
