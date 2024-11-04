using Microsoft.OpenApi.Models;
using API_ASP_NET_CORE.DB;

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

app.MapGet("/Products/{id}", (int id) => ProductDB.GetProduct(id));
app.MapGet("/Products", () => ProductDB.GetProducts());
app.MapPost("/Products", (Product Product) => ProductDB.CreateProduct(Product));
app.MapPut("/Products", (Product Product) => ProductDB.UpdateProduct(Product));
app.MapDelete("/Products/{id}", (int id) => ProductDB.RemoveProduct(id));

app.Run();