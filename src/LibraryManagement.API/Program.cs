


using AutoMapper;
using LibraryManagement.API.Data;
using LibraryManagement.API.Repositories;
using LibraryManagement.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(s =>
{
    s.AddMaps(AppDomain.CurrentDomain.GetAssemblies());

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
