using SqlSugar;

namespace MiaoMiaoTest.Repository
{
    public interface IUnitOfWork
    {
        ISqlSugarClient GetDbClient();

        void BeginTran();

        void CommitTran();

        void RollbackTran();
    }
}