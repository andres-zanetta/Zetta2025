using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;

#region Configuracion Servicios Ctor de la app
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(op =>
    op.UseSqlServer("name=conn"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenWeb",
        policy =>
        {
            policy.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500") // Agrega aquí la URL donde tu frontend se ejecutará
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

#endregion

#region Construccion de la app

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirOrigenWeb");

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion