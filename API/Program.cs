using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context, loggerFactory);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}

app.Run();