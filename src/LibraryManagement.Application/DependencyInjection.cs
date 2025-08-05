using LibraryManagement.Application.CommandHandler;
using LibraryManagement.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommands, AuthenticationCommands>();
            services.AddScoped<IMemberCommands, MemberCommands>();
            services.AddScoped<IBookCommands, BookCommands>();
            services.AddScoped<IBorrowingCommands, BorrowingCommands>();
            return services;
        }
    }
}
