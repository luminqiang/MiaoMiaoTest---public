using MiaoMiaoTest.Repository.IRepository;
using MiaoMiaoTest.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiaoMiaoTest.Repository
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITestRepository, TestRepository>()
                    .AddScoped<ITestTitleRepository, TestTitleRepository>()
                    .AddScoped<ITestAnswerRepository, TestAnswerRepository>()
                    .AddScoped<ITestLabelRepository, TestLabelRepository>()
                    .AddScoped<ITestOptionRepository, TestOptionRepository>()
                    .AddScoped<ITestErrorJobRepository, TestErrorJobRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<ISqlSugarClient>(o =>
                    {
                        return new SqlSugarClient(new ConnectionConfig()
                        {
                            ConnectionString = configuration.GetConnectionString("MysqlConnectionString"),
                            DbType = DbType.MySql,
                            IsAutoCloseConnection = true,
                            InitKeyType = InitKeyType.SystemTable
                        });
                    });
            return services;
        }
    }
}
