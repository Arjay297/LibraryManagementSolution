using LibraryManagement.Application.CommandHandler;
using LibraryManagement.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IMemberCommandService, MemberCommandService>();
            services.AddScoped<IBookCommandService, BookCommandService>();
            services.AddScoped<IBorrowingCommandService, BorrowingCommandService>();
            return services;
        }
    }
}
