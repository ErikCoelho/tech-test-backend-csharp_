using System.Text.Json;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Infra.Repositories
{
    public class ProdutoFileRepository : IProdutoFileRepository
    {
        private readonly string _filePath = @"H:\Database\fileDb.txt";

        public IEnumerable<Produto> GetAll()
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonSerializer.Deserialize<List<Produto>>(jsonData);
                }
            }
            return new List<Produto>();
        }

        public Produto GetById(Guid id)
        {
            var produto = GetAll().FirstOrDefault(x => x.Id == id);
            return produto;
        }

        public void Create(Produto produto)
        {
            var produtos = GetAll().ToList(); 
            produtos.Add(produto); 
            SaveData(produtos);
        }

        public void Delete(Produto produto)
        {
            var produtos = GetAll().ToList();
            int index = produtos.FindIndex(x => x.Id == produto.Id);
            if (index != -1)
            {
                produtos.RemoveAt(index);
                SaveData(produtos);
            }
        }

        public void Update(Produto produto)
        {
            var produtos = GetAll().ToList();
            int index = produtos.FindIndex(x => x.Id == produto.Id);
            if (index != -1)
            {
                produtos[index] = produto;
                SaveData(produtos);
            }
        }

        public void SaveData(IEnumerable<Produto> produtos)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true 
            };

            string jsonData = JsonSerializer.Serialize(produtos, options);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
