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
            policy.WithOrigins("http://localhost:5500", "http://127.0.0.1:5500") 
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
app.UseCors("PermitirOrigenWeb"); // Si tienes CORS configurado
app.UseAuthorization();


app.UseStaticFiles(); // Habilita servir archivos de wwwroot
app.UseRouting();
app.MapControllers(); 


app.MapFallbackToFile("index.html");

app.Run();