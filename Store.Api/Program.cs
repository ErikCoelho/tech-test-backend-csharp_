using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using Store.Infra.Contexts;
using Store.Infra.Repositories;
using Store.Infra.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddScoped<MongoDbContext>();

builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseInMemoryDatabase("Database"));
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<SqlDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddTransient<IProdutoRepository, ProdutoSqlRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoNoSqlRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoFileRepository>();


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
