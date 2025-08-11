using ECommerce.API.Extensions;
using ECommerce.Api.Middlewares;
using ECommerce.Application.Extensions;
using ECommerce.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Build app
var app = builder.Build();

app.UseCors();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();