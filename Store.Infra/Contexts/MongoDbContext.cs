﻿using MongoDB.Driver;
using Store.Domain.Entities;

namespace Store.Infra.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Produto> Produtos => _database.GetCollection<Produto>("Produtos");
    }
}
