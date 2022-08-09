using SmartSchool.Api.Configurations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartSchool.Api.Data.Context;
using SmartSchool.Api.Data.Interfaces;
using SmartSchool.Api.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();