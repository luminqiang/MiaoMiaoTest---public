using MiaoMiaoTest.Models.Entity;
using MiaoMiaoTest.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Repository.Repository
{
    public class TestLabelRepository : BaseRepository<TestLabel>, ITestLabelRepository
    {
        public TestLabelRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
