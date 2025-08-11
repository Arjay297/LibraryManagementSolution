using Borrowing.Application.Queries;
using Borrowing.Domain.Repositories;
using Borrowing.Infrastructure.Data;
using Borrowing.Infrastructure.Data.Repositories;
using Borrowing.Infrastructure.QueryHandlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Borrowing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBorrowingInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {

            services.AddDbContext<BorrowingDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Borrowing"));
            });

           

            //Repositories
            services.AddScoped<IBorrowingRecordRepository, BorrowingRecordRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            //Queries
            services.AddScoped<IMemberQueries, MemberQueries>();
            services.AddScoped<IBookQueries, BookQueries>();


            
            return services;
        }
    }
}
