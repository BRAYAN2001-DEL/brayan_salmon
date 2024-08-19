using Backend.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura el servicio de DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura los servicios necesarios para usar controladores
builder.Services.AddControllers();

// Configuraci�n de Swagger para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuraci�n de CORS (Cross-Origin Resource Sharing)
// Permitir solicitudes desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Habilita Swagger y la UI de Swagger en el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura la redirecci�n HTTPS y la autorizaci�n
app.UseHttpsRedirection();
app.UseAuthorization();

// Habilita CORS
app.UseCors("AllowAll");

// Configura el middleware para manejar excepciones globalmente
app.UseExceptionHandler("/error");

// Mapea los controladores
app.MapControllers();

// Configura un endpoint para manejar errores globalmente
app.Map("/error", (HttpContext context) =>
{
    var feature = context.Features.Get<IExceptionHandlerFeature>();
    var exception = feature?.Error;
    // Puedes registrar el error y devolver una respuesta adecuada aqu�
    return Results.Problem(detail: "An error occurred.");
});

app.Run();
