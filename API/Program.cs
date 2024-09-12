using API.Data;
using API.Mappers;
using API.Repositorio;
using API.Repositorio.API.Repositorio;
using API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IAlumnoRepositorio, AlumnoRepositorio>();
builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
builder.Services.AddScoped<IProvinciaRepositorio, ProvinciaRepositorio>();
builder.Services.AddScoped<IDistritoRepositorio, DistritoRepositorio>();

builder.Services.AddAutoMapper(typeof(APIMapper));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("PolicyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
