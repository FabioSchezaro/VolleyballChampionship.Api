using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.BaseBll;
using VolleyballChampionship.Bll.Infra;
using VolleyballChampionship.Dal.Infra;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model;

namespace VolleyballChampionship.Bll
{
    public class Group : BaseCrudBll<IGroupDal, GroupInfo>, IGroup
    {
        private readonly IChampionshipGroup _championshipGroup;

        public Group(IGroupDal dal, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor, IChampionshipGroup championshipGroup) : base(dal, baseDal, httpContextAccessor)
        {
            _championshipGroup = championshipGroup;
        }

        public async override Task<bool> InsertAsync(GroupInfo entity, IDbTransaction transaction = null)
        {
            var success = false;
            var trans = _baseDal.BeginTransaction();

            try
            {
                success = await base.InsertAsync(entity, trans);

                if (success)
                {
                    var championshipGroupId = await _dal.GetSequenceAsync(TableNameMapper(typeof(ChampionshipGroupInfo)), _baseDal.GetConnection(), trans);

                    ChampionshipGroupInfo championshipGroupInfo = new ChampionshipGroupInfo
                    {
                        Id = championshipGroupId == 0 ? 1 : championshipGroupId,
                        ChampionshipId = entity.ChampionshipId,
                        GroupId = entity.Id,
                    };

                    success = await _championshipGroup.InsertAsync(championshipGroupInfo, trans);
                }
            }
            finally
            {
                _baseDal.FinallyTransaction(success, trans);
            }

            return success;
        }
        public Task<List<GroupInfo>> GetByParametersAsync(GroupInfo info)
        {
            return _dal.GetByParametersAsync(info, _baseDal.GetConnection());
        }
    }
}
