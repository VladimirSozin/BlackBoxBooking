using Vacation.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApi();

using (var app = builder.Build())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/Swagger/v1/swagger.json", "General");
        c.RoutePrefix = string.Empty;
        c.DisplayRequestDuration();
    });
    app.MapControllers();
    app.Run();
}