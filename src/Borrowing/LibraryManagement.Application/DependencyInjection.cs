using Borrowing.Application.CommandHandler;
using Borrowing.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Borrowing.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddBorrowingApplication(this IServiceCollection services)
        {          
            services.AddScoped<IMemberCommands, MemberCommands>();
            services.AddScoped<IBookCommands, BookCommands>();
            services.AddScoped<IBorrowingCommands, BorrowingCommands>();
            return services;
        }
    }
}
