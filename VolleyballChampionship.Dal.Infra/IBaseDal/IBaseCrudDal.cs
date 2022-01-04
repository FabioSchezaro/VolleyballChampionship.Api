using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Dal.Infra.IBaseDal
{
    public interface IBaseCrudDal<TInfo> where TInfo : BaseInfo
    {
        Task<bool> InsertAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(TInfo entity, IDbConnection connection, IDbTransaction transaction = null);
        Task<TInfo> GetByIdAsync(int id, IDbConnection connection, IDbTransaction transaction = null);
        Task<List<TInfo>> GetAllAsync(IDbConnection connection);
        Task<int> GetSequenceAsync(string tableName, IDbConnection connection, IDbTransaction transaction = null);
    }
}
