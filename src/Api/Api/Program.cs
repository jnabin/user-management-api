using Infrastructure;
using Application;
using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAppliation();
builder.Services.AddInfrastracture(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty;  // Make Swagger UI available at the root
    });
    app.MapOpenApi();
    app.ApplyMigration();
}

app.UseHttpsRedirection();
app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
