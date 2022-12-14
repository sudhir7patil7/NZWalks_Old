global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using NZWalks.API.Data;
global using NZWalks.API.Repositories;


global using NZWalks.API.Models.Domain;
global using System.Collections;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NzWalks"));
});
builder.Services.AddScoped<IRegionRepository , RegionRepository>();
builder.Services.AddScoped<IWalkRepository , WalkRepository>(); 
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

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
