using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VolleyballChampionship.Bll.Infra.IBaseBll;
using VolleyballChampionship.Dal.Infra.IBaseDal;
using VolleyballChampionship.Model.Base;

namespace VolleyballChampionship.Bll.BaseBll
{
    public class BaseCrudBll<TIDal, TInfo> : IBaseCrudBll<TInfo> where TIDal : IBaseCrudDal<TInfo> where TInfo : BaseInfo
    {
        protected readonly TIDal _dal;
        protected readonly IBaseDal _baseDal;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BaseCrudBll(TIDal dal, IBaseDal baseDal, IHttpContextAccessor httpContextAccessor)
        {
            _dal = dal;
            _baseDal = baseDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual async Task<TInfo> GetByIdAsync(int id, IDbTransaction transaction = null)
        {
            return await _dal.GetByIdAsync(id, _baseDal.GetConnection(), transaction);
        }

        public virtual async Task<List<TInfo>> GetAllAsync()
        {
            return await _dal.GetAllAsync(_baseDal.GetConnection());
        }

        public virtual async Task<bool> InsertAsync(TInfo entity, IDbTransaction transaction = null)
        {
            SetCreateUser(entity);
            return await _dal.InsertAsync(entity, _baseDal.GetConnection(), transaction);
        }

        public virtual async Task<bool> UpdateAsync(TInfo entity, IDbTransaction transaction = null)
        {
            TInfo newEntity = await GetByIdAsync(entity.Id, transaction);
            entity.CreateUser = newEntity.CreateUser;
            entity.CreateDate = newEntity.CreateDate;

            SetUpdateUser(entity);

            return await _dal.UpdateAsync(entity, _baseDal.GetConnection(), transaction);
        }

        public virtual async Task<bool> DeleteAsync(TInfo entity, IDbTransaction transaction = null)
        {
            TInfo newEntity = await GetByIdAsync(entity.Id);
            entity.CreateUser = newEntity.CreateUser;
            entity.CreateDate = newEntity.CreateDate;

            SetUpdateUser(entity);
            return await _dal.DeleteAsync(entity, _baseDal.GetConnection(), transaction);
        }

        public void SetCreateUser(TInfo entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.CreateUser = GetLoggedUser();
        }

        public void SetUpdateUser(TInfo entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.UpdateUser = GetLoggedUser();
        }

        public string GetNameLoggedUser()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name).Value;
        }

        public int GetLoggedUser()
        {
            try
            {
                return string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value) ? 1 : int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            catch
            {
                return 1;
            }
        }

        public string TableNameMapper(Type type)
        {
            dynamic tableattr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
            var name = string.Empty;

            if (tableattr != null)
            {
                name = tableattr.Name;
            }

            return name;
        }
    }
}
