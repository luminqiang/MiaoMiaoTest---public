using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}