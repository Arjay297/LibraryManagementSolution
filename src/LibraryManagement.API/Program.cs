using Borrowing.Application;
using Borrowing.Controllers;
using Borrowing.Infrastructure;
using Identity.Application;
using Identity.Controllers;
using Identity.Infrastructure;
using LibraryManagement.Contracts.Services;
using LibraryManagement.SharedKernel;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(AuthenticationController).Assembly)
    .AddApplicationPart(typeof(BooksController).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In =ParameterLocation.Header,
        Description = "Bearer Token"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Borrowing.Application.AssemblyReference).Assembly);   
    cfg.RegisterServicesFromAssembly(typeof(Identity.Application.AssemblyReference).Assembly);
});

//Identity
builder.Services.AddIdentityApplication();
builder.Services.AddIdentityInfrastructure(builder.Configuration);

//Borrowing
builder.Services.AddBorrowingInfrastructure(builder.Configuration);
builder.Services.AddBorrowingApplication();


builder.Services.AddScoped<IEventBus, EventBus>();
builder.Services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
