namespace WebAPI.Models
{
    public class ServiceResponse<T> //Por exemplo poderia usar para ProdutoModel
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
