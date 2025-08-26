using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SERVER.Repositorio;
using Zetta.BD.DATA;
using Zetta.BD.DATA.REPOSITORY;
using Zetta.Server.Repositorios;


var builder = WebApplication.CreateBuilder(args);
   
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));// <-- necesario para ejecutar los resolvers.
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IItemPresupuestoRepositorio, ItemPresupuestoRepositorio>();

//agregar repositorio de presupuesto












builder.Services.AddDbContext<Context>(op =>
    op.UseSqlServer("name=conn"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenWeb",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
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