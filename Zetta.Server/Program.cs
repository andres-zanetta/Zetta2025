using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.REPOSITORY;
using SERVER.Repositorio;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op =>
    op.UseSqlServer("name=conn"));


builder.Services.AddScoped<IItemPresupuestoRepositorio, ItemPresupuestoRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IObraRepositorio, ObraRepositorio>();
builder.Services.AddScoped<IItemPresupuestoRepositorio, ItemPresupuestoRepositorio>();


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