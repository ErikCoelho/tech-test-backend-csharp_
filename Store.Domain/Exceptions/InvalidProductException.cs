namespace Store.Domain.Exceptions
{
    public class InvalidProductException: Exception
    {
        private const string DefaultErrorMessage = "Produto inválido";
        public InvalidProductException(string message = DefaultErrorMessage)
            :base(message)
        {
        }

        public static void ThrowIfInvalid(string nome, decimal preco, int quantidadeEstoque)
        {
            if(nome == null || nome == "") throw new InvalidProductException("O nome do produto não pode ser nulo");

            if (preco < 0) throw new InvalidProductException("O preço do produto deve ser maior que 0");

            if(quantidadeEstoque < 0) throw new InvalidProductException("A quantidade de produto em estoque não pode ser menor que 0");
        }
    }
}
