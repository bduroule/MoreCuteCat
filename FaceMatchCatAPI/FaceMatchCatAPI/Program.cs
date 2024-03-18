using Microsoft.Extensions.Configuration;
using Repository;
using Repository.Data;
using Repository.Interface;
using Services;
using Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// var configuration = new ConfigurationBuilder()
//     .AddJsonFile("appsettings.json", optional: false)
//     .Build();

var conn = builder.Configuration.GetConnectionString("WebApiDatabase");

// set data base
Console.WriteLine($"co = {conn}");
builder.Services.AddDbContext<CatContext>(options =>
{
    options.UseNpgsql(conn);
});



// var conn = builder.con;
// builder.Services.AddDbContext<CatContext>(options =>
// options.UseNpgsql(conn));


Console.WriteLine($"co = {conn}");

// Services
builder.Services.AddTransient<ICatService, CatService>();

// Repository
builder.Services.AddTransient<ICatRepository, CatRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
