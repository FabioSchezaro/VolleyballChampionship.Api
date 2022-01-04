using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace VolleyballChampionship.Bll.Infra.IBaseBll
{
    public interface IBaseCrudBll<TInfo>
    {
        Task<TInfo> GetByIdAsync(int id, IDbTransaction transaction = null);
        Task<List<TInfo>> GetAllAsync();
        Task<bool> InsertAsync(TInfo entity, IDbTransaction transaction = null);
        Task<bool> UpdateAsync(TInfo entity, IDbTransaction transaction = null);
        Task<bool> DeleteAsync(TInfo entity, IDbTransaction transaction = null);
    }
}
