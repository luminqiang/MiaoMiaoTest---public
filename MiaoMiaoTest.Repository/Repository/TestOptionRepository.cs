using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestOptionRepository : BaseRepository<TestOption>, ITestOptionRepository
    {
        public TestOptionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}