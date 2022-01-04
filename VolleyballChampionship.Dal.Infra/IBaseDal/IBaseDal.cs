using System;
using System.Data;

namespace VolleyballChampionship.Dal.Infra.IBaseDal
{
    public interface IBaseDal : IDisposable
    {
        void FinallyTransaction(bool success, IDbTransaction trans);
        IDbConnection GetConnection();
        IDbTransaction BeginTransaction();
    }
}