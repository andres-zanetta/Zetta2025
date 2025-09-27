using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SERVER.Repositorio;
using Zetta.BD.DATA;
using Zetta.BD.DATA.REPOSITORY;
using Zetta.Server.Repositorios;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IItemPresupuestoRepositorio, ItemPresupuestoRepositorio>();
builder.Services.AddScoped<IPresupuestoRepositorio, PresupuestoRepositorio>();

// DbContext
builder.Services.AddDbContext<Context>(op =>
    op.UseSqlServer("name=conn"));

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenWeb",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:4200",                // local angular
                "zetta2025.netlify.app",            // netlify prod 
                "https://zetta2025.vercel.app",    // vercel prod 
                "http://www.ZettaServicios.somee.com"   // API en somee
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("PermitirOrigenWeb"); // Aplica la política CORS
app.UseAuthorization();

app.MapControllers();

app.Run();
