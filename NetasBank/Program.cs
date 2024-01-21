using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetasBank.Context;
using NetasBank.Filters;
using NetasBank.Services;

Environment.SetEnvironmentVariable("ConnStr", "Host=localhost;Database=netas;Username=postgres;Password=1234");
//change to 1 to write to file, or to 0 to write to database... There is no business logic other than writing like accessing the report at the file level
Environment.SetEnvironmentVariable("IsWriteToFile", "0");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IsBankBelongsToTransactionActionFilter>();
builder.Services.AddTransient<IsAmountBiggerThanZero>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContextPool<TheMasterContext>(options =>
           options.UseNpgsql(Environment.GetEnvironmentVariable("ConnStr")));

builder.Services.AddTransient<IBankService, BankService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();

