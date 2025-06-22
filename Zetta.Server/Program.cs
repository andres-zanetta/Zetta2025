using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op =>
    op.UseSqlServer("name=conn"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenWeb",
        policy =>
        {
            // ¡CORREGIDO: Ahora apunta al puerto 4200 de tu Angular!
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

// *** ¡MUY IMPORTANTE! ***
// Se han ELIMINADO TODAS LAS LÍNEAS RELACIONADAS CON SPA (AngularCliServer, UseSpa, MapFallbackToFile, AddSpaStaticFiles, etc.)
// porque estás ejecutando Angular por separado con 'ng serve'.
// El backend AHORA solo se encargará de servir tu API.

app.MapControllers(); // Solo para mapear tus controladores API (ej. ItemPresupuestoController)

app.Run();