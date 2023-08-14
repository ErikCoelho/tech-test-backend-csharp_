using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using Store.Api.Application;
using Store.Infra.Contexts;
using Store.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IProdutoSqlRepository,ProdutoSqlRepository>();
builder.Services.AddTransient<IProdutoNoSqlRepository, ProdutoNoSqlRepository>();
builder.Services.AddTransient<IProdutoFileRepository, ProdutoFileRepository>();
builder.Services.AddScoped<ProdutoAppService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
