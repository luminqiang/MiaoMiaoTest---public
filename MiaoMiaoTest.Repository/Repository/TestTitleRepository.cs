using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestTitleRepository : BaseRepository<TestTitle>, ITestTitleRepository
    {
        public TestTitleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}