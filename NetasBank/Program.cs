using Microsoft.EntityFrameworkCore;
using NetasBank.Context;
using NetasBank.Services;

Environment.SetEnvironmentVariable("ConnStr", "Host=localhost;Database=netas;Username=postgres;Password=1234");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBankService, BankService>();

builder.Services.AddDbContextPool<NetasBankContext>(options =>
           options.UseNpgsql(Environment.GetEnvironmentVariable("ConnStr")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
