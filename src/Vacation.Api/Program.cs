using Vacation.Api;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
    c.IncludeXmlComments(xmlPath);
});
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
