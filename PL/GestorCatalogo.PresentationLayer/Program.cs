using GestorCatalogo.BusinessLayer.Interfaces;
using GestorCatalogo.BusinessLayer.Services;
using GestorCatalogo.DataAccessLayer.Interfaces;
using GestorCatalogo.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Info = new()
        {
            Title = "API de Gestión de Productos",
            Version = "v1",
            Description =
                "API RESTful para consultar, crear, actualizar y eliminar productos."
        };

        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Gestor Catálogo API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
