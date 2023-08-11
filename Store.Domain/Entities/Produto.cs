using Store.Domain.Exceptions;

namespace Store.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, decimal preco, int quantidadeEstoque)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            DataCriacao = DateTime.Now;
            ValorTotal = preco * quantidadeEstoque;

            InvalidProductException.ThrowIfInvalid(nome, preco, quantidadeEstoque);
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public void ProdutoUpdate(string nome, decimal preco, int quantidadeEstoque)
        {
            Nome = nome;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            ValorTotal = preco * quantidadeEstoque;

            InvalidProductException.ThrowIfInvalid(nome, preco, quantidadeEstoque);
        }
    }
}
