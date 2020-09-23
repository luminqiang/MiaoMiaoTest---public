using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestAnswerRepository : BaseRepository<TestAnswer>, ITestAnswerRepository
    {
        public TestAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
