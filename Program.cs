using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
     {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net Core Product Api", Description = "Digital warehouse for products", Version = "v1" });
     });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core Product Api V1");
    });
}

app.MapGet("/", () => "Hello World!");

app.Run();