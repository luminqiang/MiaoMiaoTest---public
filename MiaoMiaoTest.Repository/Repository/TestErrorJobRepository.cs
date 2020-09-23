using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestErrorJobRepository : BaseRepository<TestErrorJob>, ITestErrorJobRepository
    {
        public TestErrorJobRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}