// Programa principal del backend Link.Api.
// Este es solo el esqueleto: la integracion real con la app movil llega en U4-U5.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// OpenAPI / Swagger habilitados para desarrollo.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Link.Api v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
