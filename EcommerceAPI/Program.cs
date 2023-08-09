using EcommerceAPI.Comunes.Classes.Excepciones;
using EcommerceAPI.Configuracion.Inicial;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Container.ConfiguracionDependencias(builder.Services,builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseMiddleware<MiddlewareExcepciones>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
