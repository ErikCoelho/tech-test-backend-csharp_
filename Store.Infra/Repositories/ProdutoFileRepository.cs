using Newtonsoft.Json;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Infra.Repositories
{
    public class ProdutoFileRepository : IProdutoRepository
    {
        private readonly string _filePath = "";

        public IEnumerable<Produto> GetAll()
        {
            if (File.Exists(_filePath))
            {
                string jsonData = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<Produto>>(jsonData);
            }
            return new List<Produto>();
        }

        public Produto GetById(Guid id)
        {
            var produtos = GetAll();
            return produtos.FirstOrDefault(x => x.Id == id)!;
        }

        public void Create(Produto produto)
        {
            var produtos = GetAll();
            produtos.Append(produto);
            SaveData(produtos);
        }

        public void Delete(Produto produto)
        {
            var produtos = GetAll().ToList();
            produtos.Remove(produto);
            SaveData(produtos);
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
            string jsonData = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
