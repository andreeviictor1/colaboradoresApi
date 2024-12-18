using Microsoft.EntityFrameworkCore;
using colaboradorApi.Infra.DataBase;
using colaboradorApi.Services.Implementations;
using colaboradorApi.Services.Interfaces;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IColaboradorService, ColaboradorService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// app.UseHttpsRedirection();
app.MapControllers();

app.Run();




