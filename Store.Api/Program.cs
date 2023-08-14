using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using Store.Api.Application;
using Store.Infra.Contexts;
using Store.Infra.Repositories;
using Store.Infra.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<MongoDbContext>();

//builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseInMemoryDatabase("Database"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddTransient<IProdutoSqlRepository,ProdutoSqlRepository>();
builder.Services.AddTransient<IProdutoNoSqlRepository, ProdutoNoSqlRepository>();
builder.Services.AddTransient<IProdutoFileRepository, ProdutoFileRepository>();
builder.Services.AddScoped<ProdutoAppService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
