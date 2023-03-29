using Microsoft.EntityFrameworkCore;
using ToToDiario.API.Application.InfrastructureContracts;
using ToToDiario.API.Application.NoteService;
using ToToDiario.API.Application.UserService;
using ToToDiario.API.Infrastructure.Persistence;
using ToToDiario.API.Infrastructure.Persistence.Repositories;
using ToToDiario.API.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<INotaRepository, NotaRepository>();
builder.Services.AddScoped<INoteService, NoteService>();


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDiarioDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
