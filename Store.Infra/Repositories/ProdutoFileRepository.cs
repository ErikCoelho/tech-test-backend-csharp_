using System.Text;
using System.Text.Json;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Infra.Repositories
{
    public class ProdutoFileRepository : IProdutoFileRepository
    {
        private readonly string _containerName = "produtodata"; 
        private readonly string _configuration;

        public ProdutoFileRepository(IConfiguration configuration)
        {
            _configuration = configuration.GetConnectionString("AzureStorageConnectionString")!;
        }

        private BlobContainerClient GetBlobContainerClient()
        {
            var blobServiceClient = new BlobServiceClient(_configuration);
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            if (!blobContainerClient.Exists())
            {
                 blobContainerClient.CreateAsync(PublicAccessType.BlobContainer);
            }

            return blobContainerClient;
        }

        public  IEnumerable<Produto> GetAll()
        {
            var blobContainerClient = GetBlobContainerClient();
            var blobClient = blobContainerClient.GetBlobClient("fileDb.txt");

            if (blobClient.Exists())
            {
                using (var memoryStream = new MemoryStream())
                {
                    blobClient.DownloadTo(memoryStream);
                    memoryStream.Position = 0;
                    using (var reader = new StreamReader(memoryStream))
                    {
                        string jsonData =  reader.ReadToEnd();
                        if (!string.IsNullOrEmpty(jsonData))
                        {
                            return JsonSerializer.Deserialize<List<Produto>>(jsonData);
                        }
                    }
                }
            }

            return new List<Produto>();
        }

        public Produto GetById(Guid id)
        {
            var produtos = GetAll().ToList();
            return produtos.Find(x => x.Id == id);
        }

        public void Create(Produto produto)
        {
            var produtos = GetAll().ToList();
            produtos.Add(produto);
            SaveData(produtos);
        }

        public void Update(Produto produto)
        {
            var produtos = new List<Produto>(GetAll());
            int index = produtos.FindIndex(x => x.Id == produto.Id);
            if (index != -1)
            {
                produtos[index] = produto;
                SaveData(produtos);
            }
        }

        public void Delete(Produto produto)
        {
            var produtos = new List<Produto>(GetAll());
            int index = produtos.FindIndex(x => x.Id == produto.Id);
            if (index != -1)
            {
                produtos.RemoveAt(index);
                SaveData(produtos);
            }
        }

        private void SaveData(IEnumerable<Produto> produtos)
        {
            var blobContainerClient = GetBlobContainerClient();
            var blobClient = blobContainerClient.GetBlobClient("fileDb.txt");

            JsonSerializerOptions options = new()
            {
                WriteIndented = true
            };

            string jsonData = JsonSerializer.Serialize(produtos, options);

            var blobUploadOptions = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = "application/json" }
            };

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
            {
                blobClient.Upload(memoryStream, blobUploadOptions);
            }
        }
    }
}
