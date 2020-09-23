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
                            ConnectionString = configuration.GetConnectionString("MysqlConnectionString"),//必填, 数据库连接字符串
                            DbType = DbType.MySql,// 数据库类型
                            IsAutoCloseConnection = true,// 设置为true无需使用using或者Close操作
                            InitKeyType = InitKeyType.SystemTable//默认SystemTable, 字段信息读取, 如：该属性是不是主键，标识列等等信息
                        });
                    });
            return services;
        }
    }
}
