using Npgsql;
using System.Data;
using VolleyballChampionship.Dal.Infra.IBaseDal;

namespace VolleyballChampionship.Dal.PostgreSql.PostgreSqlBaseCrud
{
    public class BaseDal : IBaseDal
    {
        public IDbTransaction Transaction { get; set; }
        public IDbConnection Connection { get; set; }
        public BaseDal(string config)
        {
            Connection = new NpgsqlConnection(config);
            Connection.Open();
        }
        public IDbTransaction BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
            return Transaction;
        }

        public void FinallyTransaction(bool success, IDbTransaction trans)
        {
            if (success)
                Commit(trans);
            else
                Rollback(trans);
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }
            if (Connection == null)
                return;
            Connection.Dispose();
            Connection = null;
        }

        public IDbConnection GetConnection()
        {
            return Connection;
        }

        private bool Commit(IDbTransaction trans)
        {
            if (Transaction == null)
                return false;

            try
            {
                Transaction.Commit();
                return true;
            }
            catch
            {
                Transaction.Rollback();
                return false;
            }
            finally
            {
                Transaction.Dispose();
                Transaction = null;
            }
        }

        private bool Rollback(IDbTransaction trans)
        {
            try
            {
                if (Transaction == null)
                    return false;
                Transaction.Rollback();
                Transaction = null;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}